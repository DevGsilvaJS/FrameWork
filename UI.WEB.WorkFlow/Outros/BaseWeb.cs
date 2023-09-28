using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace UI.WEB.WorkFlow.Outros
{
    public class BaseWeb
    {
        DBComando _Conexao = new DBComando();
        SqlCommand _Comando = new SqlCommand();
        List<string> listaSalvar = new List<string>();
        public string RetornaQueryInclusao(object entity)
        {

            var insertScriptBuilder = new StringBuilder();

            var tableAttribute = entity.GetType().GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            string tableName = tableAttribute?.Name ?? entity.GetType().Name;


            string inicioPropriedade = tableName.Substring(3, 3);
            int valueID = 0;

            insertScriptBuilder.Append($"INSERT INTO {tableName} (");

            PropertyInfo[] propriedades = entity.GetType().GetProperties();

            for (int i = 0; i < propriedades.Length; i++)
            {
                if (propriedades[i].GetCustomAttribute<ColumnAttribute>() != null)
                {
                    string nomeColuna = propriedades[i].GetCustomAttribute<ColumnAttribute>().Name;
                }
                else
                {
                    if (propriedades[i].Name.Contains("ID") && propriedades[i].Name.Contains(inicioPropriedade) && i == 0)
                    {
                        valueID = RetornaSequencial(propriedades[i].Name);
                        propriedades[i].SetValue(entity, valueID);
                    }

                    if (propriedades[i].Name.Contains(inicioPropriedade))
                    {
                        insertScriptBuilder.Append($"{propriedades[i].Name}, ");
                    }
                    else if (propriedades[i].Name.Contains("ID") && propriedades[i].Name.Length == 5)
                    {
                        insertScriptBuilder.Append($"{propriedades[i].Name}, ");
                    }
                }
            }
            insertScriptBuilder.Length -= 2;

            insertScriptBuilder.Append(") VALUES (");
            for (int i = 0; i < propriedades.Length; i++)
            {
                object value = propriedades[i].GetValue(entity);

                if (value == null)
                {
                    string formattedValue = FormatValue(value);
                    insertScriptBuilder.Append($"{formattedValue}, ");
                }

                else if (value.GetType() == typeof(int) && i == 0)
                {
                    insertScriptBuilder.Append($"{valueID}, ");
                }


                else if (value.GetType() == typeof(string) || value.GetType() == typeof(int) || value == null)
                {
                    string formattedValue = FormatValue(value);
                    insertScriptBuilder.Append($"{formattedValue}, ");
                }
            }

            insertScriptBuilder.Length -= 2;
            insertScriptBuilder.Append(")" + " SELECT SCOPE_IDENTITY()");

            return insertScriptBuilder.ToString();
        }
        public string RetornaQueryUpdate(object obj)
        {
            StringBuilder updateCommand = new StringBuilder();

            var tableAttribute = obj.GetType().GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            string tableName = tableAttribute?.Name ?? obj.GetType().Name;

            updateCommand.Append("UPDATE ");
            updateCommand.Append(tableName);
            updateCommand.Append(" SET ");
            string where = "";

            Type objectType = obj.GetType();
            PropertyInfo[] properties = objectType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(obj);

                if (IsPropertyClass(property))
                {
                    continue;
                }
                if (updateCommand.Length >= 2 && propertyName.EndsWith("ID") && propertyValue != null && !propertyValue.Equals(0) && where == "")
                {
                    where = " WHERE " + propertyName + " = " + propertyValue;
                }

                else
                {
                    updateCommand.Append(propertyName);
                    updateCommand.Append(" = ");

                    if (propertyValue is string || propertyValue is DateTime)
                    {
                        updateCommand.Append("'");
                        updateCommand.Append(propertyValue);
                        updateCommand.Append("'");
                        updateCommand.Append(",");

                    }
                    else
                    {

                        if (propertyValue == null)
                        {
                            string SETNULL = "NULL";
                            updateCommand.Append(SETNULL);
                            updateCommand.Append(",");
                        }
                        else
                        {
                            updateCommand.Append(propertyValue);
                            updateCommand.Append(",");
                        }
                    }
                }
            }

            if (updateCommand.Length > 0 && updateCommand[updateCommand.Length - 1] == ',')
            {
                updateCommand.Length--;  // Remove o último caractere
            }

            updateCommand.Append(where);



            return updateCommand.ToString();
        }
        public string RetornaQueryDelete(string tabela, string coluna, int id)
        {

            string idFormatado = tabela.Substring(3, 3);

            string deleteScript = $"DELETE FROM {tabela} WHERE " + coluna + " = " + id;
            return deleteScript;
        }
        public bool IsPropertyClass(PropertyInfo property)
        {
            Type propertyType = property.PropertyType;
            return propertyType.IsClass && propertyType != typeof(string);
        }
        private static string FormatValue(object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            else if (value is string || value is DateTime)
            {
                return $"'{value.ToString()}'";
            }
            else if (value is bool)
            {
                return ((bool)value) ? "1" : "0";
            }
            else
            {
                return value.ToString();
            }

        }
        public SqlDataReader ListarDadosEntity(string Query)
        {
            try
            {
                SqlCommand _Comando = new SqlCommand(Query, _Conexao.MinhaConexao());
                _Comando.CommandType = CommandType.Text;
                SqlDataReader _DataReader = _Comando.ExecuteReader();

                _Conexao.FechaConexao(_Conexao.MinhaConexao());

                return _DataReader;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public int RetornaSequencial(string SEQ)
        {

            SqlCommand command = new SqlCommand($"SELECT NEXT VALUE FOR SEQ_{SEQ.Substring(0, 3)}", _Conexao.MinhaConexao());

            object nextValue = command.ExecuteScalar();

            int sequencial = Convert.ToInt32(nextValue);

            return sequencial;
        }
        public void AddListaSalvar(object entity)
        {
            listaSalvar.Add(RetornaQueryInclusao(entity));
        }
        public void AddListaAtualizar(object entity)
        {
            listaSalvar.Add(RetornaQueryUpdate(entity));
        }
        public void AddListaDeletar(string query)
        {
            listaSalvar.Add(query);
        }
        public void AddListaParametros(string query)
        {
            listaSalvar.Add(query);
        }
        public string ExecuteTransacao()
        {
            string retorno = "NOTOK";

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (string insert in listaSalvar)
                    {
                        _Comando = new SqlCommand(insert, _Conexao.MinhaConexao());
                        _Comando.CommandType = CommandType.Text;
                        int Result = (int)_Comando.ExecuteNonQuery();
                    }

                    scope.Complete();
                    retorno = "OK";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return retorno;
            }
        }
        public string RetornaObjeto(string tableName, string columnName, object value)
        {
            string query = $"SELECT {tableName.Substring(3, 3)}ID FROM {tableName} WHERE {columnName} = '{value}'";

            string campo = $"{tableName.Substring(3, 3)}ID";
            string sRetorno = "";

            SqlCommand _Comando = new SqlCommand(query, _Conexao.MinhaConexao());
            _Comando.CommandType = CommandType.Text;
            SqlDataReader dr = _Comando.ExecuteReader();

            if (dr.Read())
            {
                sRetorno = dr[campo].ToString();
            }
            return sRetorno;
        }

    }
}

