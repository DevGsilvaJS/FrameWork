using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Venda.TabelasAuxiliares
{
    public class IndicacaoQuery
    {
        public string EditarIndicacaoQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("     IND.INDID");
            sb.AppendLine("    ,IND.INDDESCRICAO");
            sb.AppendLine("	,IND.INDDEFAULTVENDA");
            sb.AppendLine("	,IND.INDSTATUS");
            sb.AppendLine("FROM TB_IND_INDICACAO IND ");
            sb.AppendLine("    WHERE IND.INDID = @INDID  ");

            return sb.ToString();
        }

        public string ListaDadosQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("     IND.INDID");
            sb.AppendLine("    ,IND.INDDESCRICAO");
            sb.AppendLine("	,IND.INDDEFAULTVENDA");
            sb.AppendLine("	,IND.INDSTATUS");
            sb.AppendLine("FROM TB_IND_INDICACAO IND ");
            sb.AppendLine("    WHERE IND.INDSTATUS > 0  ");

            return sb.ToString();
        }
    }
}
