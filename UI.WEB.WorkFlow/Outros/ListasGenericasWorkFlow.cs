using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WEB.Model.Estoque;
using UI.WEB.Model.Financeiro.Tabelas_Auxiliares;
using UI.WEB.Model.Fiscal.Tabelas_Auxiliares;
using UI.WEB.Model.Outros;

namespace UI.WEB.WorkFlow.Outros
{
    public class ListasGenericasWorkFlow : BaseWeb
    {
        public List<EntityCentroCusto> listaCentroCusto()
        {
            List<EntityCentroCusto> lista = new List<EntityCentroCusto>();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    CCUID");
            sb.AppendLine("  , CCUDESCRICAO");
            sb.AppendLine("FROM TB_CCU_CENTROCUSTO CCU");
            sb.AppendLine("    WHERE CCU.CCUSTATUS = 1");

            SqlDataReader dr = ListarDadosEntity(sb.ToString());

            while (dr.Read())
            {
                lista.Add(new EntityCentroCusto
                {
                    CCUID = int.Parse(dr["CCUID"].ToString()),
                    CCUDESCRICAO = dr["CCUDESCRICAO"].ToString()
                });
            }
            return lista;
        }
        public List<EntityPlanoContas> listaPlanoContas()
        {
            List<EntityPlanoContas> lista = new List<EntityPlanoContas>();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    PCTID");
            sb.AppendLine("  , PCTDESCRICAO");
            sb.AppendLine("FROM TB_PCT_PLANOCONTAS PCT");
            sb.AppendLine("    WHERE PCT.PCTSTATUS = 1");

            SqlDataReader dr = ListarDadosEntity(sb.ToString());

            while (dr.Read())
            {
                lista.Add(new EntityPlanoContas
                {
                    PCTID = int.Parse(dr["PCTID"].ToString()),
                    PCTDESCRICAO = dr["PCTDESCRICAO"].ToString()
                });
            }
            return lista;
        }
        public List<EntityPessoa> RetornaComboFornecedores()
        {
            List<EntityPessoa> lista = new List<EntityPessoa>();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("     SELECT");
            sb.AppendLine("              FORN.FORID");
            sb.AppendLine("             ,CONCAT(PES.PESNOME, ' - ', '(', PES.PESDOCFEDERAL, ')') AS PESNOME");
            sb.AppendLine("     FROM TB_PES_PESSOA PES");
            sb.AppendLine("         INNER JOIN TB_FOR_FORNECEDOR FORN ON FORN.PESID = PES.PESID");
            sb.AppendLine("         WHERE FORN.FORSTATUS = 1;");

            SqlDataReader dr = ListarDadosEntity(sb.ToString());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lista.Add(new EntityPessoa
                    {
                        PESID = int.Parse(dr["FORID"].ToString()),
                        PESNOME = dr["PESNOME"].ToString()
                    });
                }
            }

            return lista;
        }
        public List<EntityNCM> RetornaComboNCM()
        {
            List<EntityNCM> lista = new List<EntityNCM>();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("     SELECT");
            sb.AppendLine("               NCMID");
            sb.AppendLine("             ,CAST(NCMCODIGO AS VARCHAR) + ' - ' + NCMDESCRICAO AS NCMDESCRICAO");
            sb.AppendLine("     FROM TB_NCM_NCM NCM");
            sb.AppendLine("             WHERE NCM.NCMSTATUS = 1");

            SqlDataReader dr = ListarDadosEntity(sb.ToString());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lista.Add(new EntityNCM
                    {
                        NCMID = int.Parse(dr["NCMID"].ToString()),
                        NCMDESCRICAO = dr["NCMDESCRICAO"].ToString()
                    });
                }

            }
            return lista;
        }
    }
}

