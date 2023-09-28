using System;
using System.Data;
using System.Data.SqlClient;

namespace UI.WEB.WorkFlow.Outros
{
    public class DBComando
    {
        public SqlConnection MinhaConexao()
        {
            // 1 - string de conexão com o banco de dados
            string strCnn = @"Data Source=DESKTOP-5P4KOV3\SQLEXPRESS;Initial Catalog=DBFrameWorks;Integrated Security=SSPI;";

            //string strCnn = "Data Source=SQL8003.site4now.net;Initial Catalog=db_a8f609_dbworld;User Id=db_a8f609_dbworld_admin;Password=Defdesp2012@";

            SqlConnection _Cnn = new SqlConnection();

            try
            {
                // 2 - Abro a conexão
                _Cnn.ConnectionString = strCnn;

                _Cnn.Open();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return _Cnn;
        }
        // 3 - Fecho a conexão 
        public void FechaConexao(SqlConnection _Cnn)
        {


            try
            {

                if (_Cnn.State == ConnectionState.Open)
                {
                    _Cnn.Close();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
