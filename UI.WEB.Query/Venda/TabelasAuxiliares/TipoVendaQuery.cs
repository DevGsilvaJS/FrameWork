using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Venda.TabelasAuxiliares
{
    public class TipoVendaQuery
    {
        public string ListaDadosQuery()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("     TPV.TPVID");
            sb.AppendLine(" 	, TPV.TPVDESCRICAO");
            sb.AppendLine(" 	, TPV.TPVDEFAULTVENDA");
            sb.AppendLine(" FROM TB_TPV_TIPOVENDA TPV");

            return sb.ToString();


        }

        public string EditarTipoVendaQuery()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT                                  ");
            sb.AppendLine("    TPV.TPVID                                  ");
            sb.AppendLine("	, TPV.TPVDESCRICAO                   ");
            sb.AppendLine("	, TPV.TPVDEFAULTVENDA           ");
            sb.AppendLine("FROM TB_TPV_TIPOVENDA TPV ");
            sb.AppendLine("    WHERE TPV.TPVID = @TPVID   ");

            return sb.ToString();
        }
    }
}
