using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query
{
    public class ProdutoQuery
    {
        public string ListaProdutos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine("     MAT.MATID");
            sb.AppendLine("  ,  MAT.MATSEQUENCIAL");
            sb.AppendLine("  ,  MAT.MATFANTASIA");
            sb.AppendLine("  ,  MPC.MPCPRECOCUSTO");
            sb.AppendLine("  ,  MPV.MPVPRECOVENDA");
            sb.AppendLine("  ,  ARG.ARGDESCRICAO");
            sb.AppendLine("  ,  MAT.MATDTCADASTRO");
            sb.AppendLine("   FROM TB_MAT_MATERIAL MAT");
            sb.AppendLine("     JOIN TB_MPC_MATPRECOCUSTO MPC ON MPC.MATID = MAT.MATID");
            sb.AppendLine("     JOIN TB_MPV_MATPRECOVENDA MPV ON MPV.MATID = MAT.MATID");
            sb.AppendLine("     JOIN TB_AAT_ATRIBUTOS AAT ON AAT.MATID = MAT.MATID");
            sb.AppendLine("     JOIN TB_ARG_ATRGRIFE ARG ON ARG.ARGID = AAT.ARGID");

            return sb.ToString();
        }
    }
}
