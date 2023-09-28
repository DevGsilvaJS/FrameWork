using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using UI.WEB.Model;
using UI.WEB.Query.Utilitarios;
using UI.WEB.WorkFlow.Outros;

namespace WorkFlow.Utilitarios
{
    public class LaboratorioWorkFlow : BaseWeb
    {
        DBComando db = new DBComando();

        public LaboratorioEntity RetornaObjInclusao()
        {
            LaboratorioEntity _obj = new LaboratorioEntity();

            return _obj;
        }
        public string GravarLaboratorio(LaboratorioEntity _Laboratorio)
        {

            string retorno = "NOTOK";

            if (_Laboratorio.LABID > 0)
            {
                AtualizarLaboratorio(_Laboratorio);
            }

            else
            {

                //Verifico se já existe algum laboratório cadastrado neste andar
                string sLabJaCadastrado = RetornaObjeto("TB_LAB_LABORATORIO", "ANDID", _Laboratorio.ANDID);

                if (!string.IsNullOrEmpty(sLabJaCadastrado))
                {
                    return "LAB";
                }


                AddListaSalvar(_Laboratorio);
            }

            ExecuteTransacao();

            return retorno;

        }
        public string AtualizarLaboratorio(LaboratorioEntity _Laboratorio)
        {
            string sRetorno = "";

            return sRetorno;
        }
        public List<LaboratorioEntity> ListaDados()
        {
            List<LaboratorioEntity> lsLaboratorios = new List<LaboratorioEntity>();

            StringBuilder sb = new StringBuilder();

            List<LaboratorioEntity> lista = new List<LaboratorioEntity>();


            sb.AppendLine(" SELECT                                                  ");
            sb.AppendLine("     LAB.LABID,                                          ");
            sb.AppendLine("	    ADN.ANDID,                                          ");
            sb.AppendLine("	    LAB.LABDESCRICAO,                                   ");
            sb.AppendLine("	    LAB.LABSTATUS,                                      ");
            sb.AppendLine("	    ADN.ANDNUMERO                                       ");
            sb.AppendLine(" FROM TB_LAB_LABORATORIO LAB                             ");
            sb.AppendLine(" JOIN TB_AND_ANDAR ADN ON ADN.ANDID = LAB.ANDID          ");

            SqlDataReader dr = ListarDadosEntity(sb.ToString());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LaboratorioEntity _Laboratorio = new LaboratorioEntity();

                    _Laboratorio.LABID = int.Parse(dr["LABID"].ToString());
                    _Laboratorio.TbAndar.ANDID = int.Parse(dr["ANDID"].ToString());
                    _Laboratorio.LABDESCRICAO = dr["LABDESCRICAO"].ToString();
                    _Laboratorio.LABSTATUS = dr["LABSTATUS"].ToString();
                    _Laboratorio.TbAndar.ANDNUMERO = dr["ANDNUMERO"].ToString();

                    lista.Add(_Laboratorio);
                    
                    
                }
            }

            return lista;

        }
        public LaboratorioEntity GetLaboratorioByID(int labid)
        {

            LaboratorioEntity _Laboratorio = new LaboratorioEntity();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                                  ");
            sb.AppendLine("     LAB.LABID,                                          ");
            sb.AppendLine("	    ADN.ANDID,                                          ");
            sb.AppendLine("	    LAB.LABDESCRICAO,                                   ");
            sb.AppendLine("	    LAB.LABSTATUS,                                      ");
            sb.AppendLine("	    ADN.ANDNUMERO                                       ");
            sb.AppendLine(" FROM TB_LAB_LABORATORIO LAB                             ");
            sb.AppendLine(" JOIN TB_AND_ANDAR ADN ON ADN.ANDID = LAB.ANDID          ");
            sb.AppendLine(" WHERE LAB.LABID = @LABID                                ");




            SqlCommand _Comando = new SqlCommand(sb.ToString(), db.MinhaConexao());

            SqlParameter parameter = new SqlParameter("@LABID", labid);
            _Comando.Parameters.Add(parameter);
            _Comando.CommandType = CommandType.Text;
            SqlDataReader dr = _Comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    _Laboratorio.LABID = int.Parse(dr["LABID"].ToString());
                    _Laboratorio.TbAndar.ANDID = int.Parse(dr["ANDID"].ToString());
                    _Laboratorio.LABDESCRICAO = dr["LABDESCRICAO"].ToString();
                    _Laboratorio.LABSTATUS = dr["LABSTATUS"].ToString();
                    _Laboratorio.TbAndar.ANDNUMERO = dr["ANDNUMERO"].ToString();
                }
            }




            return _Laboratorio;
        }
        public string ExcluirLaboratorio(int labid)
        {

            string sLaboratorio = RetornaQueryDelete("TB_LAB_LABORATORIO", "LABID", labid);
            AddListaDeletar(sLaboratorio);

            ExecuteTransacao();

            return "";

        }
    }
}
