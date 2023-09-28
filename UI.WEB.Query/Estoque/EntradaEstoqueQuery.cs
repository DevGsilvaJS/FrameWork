using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Estoque
{
    public class EntradaEstoqueQuery
    {
        public string listaFornecedoresQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                            ");
            sb.AppendLine("     FORID,                                        ");
            sb.AppendLine("     PES.PESNOME                                   ");
            sb.AppendLine(" FROM TB_FOR_FORNECEDOR FORN                       ");
            sb.AppendLine(" JOIN TB_PES_PESSOA PES ON PES.PESID = FORN.PESID  ");
            sb.AppendLine(" WHERE FORN.FORSTATUS = 1                          ");

            return sb.ToString();
        }

        public string listaCfopQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                                                                ");
            sb.AppendLine("     COP.COPID,                                                                        ");
            sb.AppendLine("     CAST(COP.COPCODIGO AS VARCHAR(10)) + ' - ' + COP.COPDESCRICAO AS COPDESCRICAO     ");
            sb.AppendLine(" FROM TB_COP_CFOP COP                                                                  ");
            sb.AppendLine(" WHERE COP.COPSTATUS = 1 AND COP.COPTIPO = 'E'                                         ");


            return sb.ToString();
        }

        public string buscaProdutoQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  SELECT                                                 ");
            sb.AppendLine("     MAT.MATID,                                          ");
            sb.AppendLine("     MAT.MATSEQUENCIAL,                                  ");
            sb.AppendLine("	    MAT.MATFANTASIA,                                    ");
            sb.AppendLine("	    ARG.ARGDESCRICAO,                                   ");
            sb.AppendLine("	    ARC.ARCDESCRICAO                                    ");
            sb.AppendLine(" FROM TB_MAT_MATERIAL MAT                                ");
            sb.AppendLine(" JOIN TB_AAT_ATRIBUTOS AAT ON AAT.MATID = MAT.MATID      ");
            sb.AppendLine(" JOIN TB_ARG_ATRGRIFE ARG ON ARG.ARGID = AAT.ARGID       ");
            sb.AppendLine(" JOIN TB_ARC_ATRCOR ARC ON ARC.ARCID = AAT.ARCID         ");
            sb.AppendLine(" WHERE MAT.MATFANTASIA LIKE @produto + '%';              ");


            return sb.ToString();
        }
    }
}
