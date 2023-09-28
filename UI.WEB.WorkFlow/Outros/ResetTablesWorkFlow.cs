
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WEB.Query;

namespace UI.WEB.WorkFlow.Outros
{
    public class ResetTablesWorkFlow : BaseWeb
    {
        DBComando db = new DBComando();
        public string DeletTables()
        {
            List<string> tablesDrop = new List<string>
            {
                "TB_MPC_MATPRECOCUSTO",
                "TB_MPV_MATPRECOVENDA",
                "TB_AAT_ATRIBUTOS",
                "TB_ACN_ATRCORNUMERICA",
                "TB_ARC_ATRCOR",
                "TB_ARG_ATRGRIFE",
                "TB_ARL_ATRLINHAPROD",
                "TB_ARM_ATRMODELO",
                "TB_AS1_ATRSUBLINHA1",
                "TB_AS2_ATRSUBLINHA2",
                "TB_ATO_ATRTAMANHO",
                "TB_ATP_ATRGRUPO",
               "TB_MAT_MATERIAL",
               "TB_FOR_FORNECEDOR",
               "TB_CCU_CENTROCUSTO",
               "TB_PCT_PLANOCONTAS",
               "TB_VND_VENDEDOR",
               "TB_TEL_TELEFONE",
               "TB_EML_EMAIL",
               "TB_CLI_CLIENTE",
               "TB_EDN_ENDERECO",
               "TB_NCM_NCM",
               "TB_TPV_TIPOVENDA",
               "TB_USU_USUARIO",
               "TB_PES_PESSOA",
               "TB_PRV_PARAMETROVALOR",
               "TB_IND_INDICACAO",
               "TB_TPV_TIPOVENDA"
            };

            foreach (string tableName in tablesDrop)
            {
                // Verifica se a tabela existe antes de tentar excluí-la (opcional)

                string dropTableQuery = $"DROP TABLE {tableName}";

                SqlCommand _Comando = new SqlCommand(dropTableQuery, db.MinhaConexao());
                _Comando.CommandType = System.Data.CommandType.Text;
                int result = (int)_Comando.ExecuteNonQuery();
            }

            db.FechaConexao(db.MinhaConexao());

            return CreateTables();

        }
        public string CreateTables()
        {

            ResetarTabelasSQLQuery Query = new ResetarTabelasSQLQuery();
            List<string> lista = new List<string>();

            lista.Add(Query.CreateTablePessoaQuery());
            lista.Add(Query.CreateTableClienteQuery());
            lista.Add(Query.CreateTableUsuarioQuery());
            lista.Add(Query.CreateTablePlanoContasQuery());
            lista.Add(Query.CreateTableCentroCustoQuery());
            lista.Add(Query.CreateTableFornecedorQuery());
            lista.Add(Query.CreateTableNCMQuery());
            lista.Add(Query.CreateTableMaterialQuery());
            lista.Add(Query.CreateTablePrecoCustoQuery());
            lista.Add(Query.CreateTableAtributoCorQuery());
            lista.Add(Query.CreateTableAtributoCorNumericaQuery());
            lista.Add(Query.CreateTableAtributoGrifeQuery());
            lista.Add(Query.CreateTableAtributoGrupoQuery());
            lista.Add(Query.CreateTableAtributoLinhaQuery());
            lista.Add(Query.CreateTableAtributoModeloQuery());
            lista.Add(Query.CreateTableAtributoSublinha1Query());
            lista.Add(Query.CreateTableAtributoSublinha2Query());
            lista.Add(Query.CreateTableAtributoTamanhoQuery());
            lista.Add(Query.CreateTableAtributosQuery());
            lista.Add(Query.CreateTableEmailQuery());
            lista.Add(Query.CreateTableEnderecoQuery());
            lista.Add(Query.CreateTablePrecoVendaQuery());
            lista.Add(Query.CreateTableTelefoneQuery());
            lista.Add(Query.CreateTableTipoVendaQuery());
            lista.Add(Query.CreateTableIndicacaoQuery());
            lista.Add(Query.CreateTableVendedorQuery());
            lista.Add(Query.CreateTableParametroValorQuery());

            foreach (var item in lista)
            {
                SqlCommand _Comando = new SqlCommand(item, db.MinhaConexao());
                _Comando.CommandType = System.Data.CommandType.Text;
                int result = (int)_Comando.ExecuteNonQuery();
            }

            db.FechaConexao(db.MinhaConexao());

            return InsertTables();
        }
        public string InsertTables()
        {
            string sRetorno = "";

            ResetarTabelasSQLQuery Query = new ResetarTabelasSQLQuery();

            List<string> lista = new List<string>();

            lista.Add(Query.InsertTablesNcmQuery());
            lista.Add(Query.InsertTableParametrosQuery());
            lista.Add(Query.InsertTablesCentroCustoQuery());
            lista.Add(Query.InsertTablesPlanoContasQuery());
            lista.Add(Query.InsertTablesTipoVendaQuery());
            lista.Add(Query.InsertTablesIndicacaoQuery());

            foreach (var item in lista)
            {
                SqlCommand _Comando = new SqlCommand(item, db.MinhaConexao());
                _Comando.CommandType = System.Data.CommandType.Text;
                int result = (int)_Comando.ExecuteNonQuery();
            }

            return sRetorno;
        }
    }
}

