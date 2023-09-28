using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Estoque
{
    public class ProdutoQuery
    {
        public string ListaProdutosQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine("         MAT.MATID");
            sb.AppendLine("     ,   MAT.MATSEQUENCIAL");
            sb.AppendLine("     ,   MAT.MATFANTASIA");
            sb.AppendLine("     ,   MPC.MPCPRECOCUSTO");
            sb.AppendLine("     ,   MPV.MPVPRECOVENDA");
            sb.AppendLine("     ,   ARG.ARGDESCRICAO");
            sb.AppendLine("     ,   MAT.MATDTCADASTRO");
            sb.AppendLine("   FROM TB_MAT_MATERIAL MAT");
            sb.AppendLine("         JOIN TB_MPC_MATPRECOCUSTO MPC ON MPC.MATID = MAT.MATID");
            sb.AppendLine("         JOIN TB_MPV_MATPRECOVENDA MPV ON MPV.MATID = MAT.MATID");
            sb.AppendLine("         JOIN TB_AAT_ATRIBUTOS AAT ON AAT.MATID = MAT.MATID");
            sb.AppendLine("         JOIN TB_ARG_ATRGRIFE ARG ON ARG.ARGID = AAT.ARGID");


            return sb.ToString();
        }

        public string EditarProdutoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("      MAT.MATID                     ");
            sb.AppendLine("	,	MAT.MATSEQUENCIAL        ");
            sb.AppendLine("	,	MAT.MATRECSOL                 ");
            sb.AppendLine("	,	MAT.NCMID                          ");
            sb.AppendLine("	,	MAT.MATDESCRICAO          ");
            sb.AppendLine("	,	MAT.MATDESCRICAOECF    ");
            sb.AppendLine("	,	MAT.FORID                            ");
            sb.AppendLine("	,	MAT.MATCONTROLAEST    ");
            sb.AppendLine("	,	MAT.MATVENDA                  ");
            sb.AppendLine("	,	MAT.MATACEITANEGATIVO");
            sb.AppendLine("	,	AAT.AATID                             ");
            sb.AppendLine("	,   AAT.ARLID                             ");
            sb.AppendLine("	,	AAT.ARCID                             ");
            sb.AppendLine("	,	AAT.ACNID                            ");
            sb.AppendLine("	,	AAT.ARMID                           ");
            sb.AppendLine("	,	AAT.ARGID                            ");
            sb.AppendLine("	,	AAT.AS1ID                             ");
            sb.AppendLine("	,	AAT.AS2ID                             ");
            sb.AppendLine("	,	AAT.ATOID                             ");
            sb.AppendLine("	,	ARL.ARLDESCRICAO            ");
            sb.AppendLine("	,	ARG.ARGDESCRICAO          ");
            sb.AppendLine("	,	ARM.ARMDESCRICAO        ");
            sb.AppendLine("	,	ARC.ARCDESCRICAO           ");
            sb.AppendLine("	,	ACN.ACNDESCRICAO          ");
            sb.AppendLine("	,	AS1.AS1DESCRICAO            ");
            sb.AppendLine("	,	AS2.AS2DESCRICAO            ");
            sb.AppendLine("	,	ATO.ATODESCRICAO            ");
            sb.AppendLine("	,	MPC.MPCPRECOCUSTO     ");
            sb.AppendLine("	,	MPV.MPVPRECOVENDA     ");
            sb.AppendLine("	,	MPV.MPVMARKUP              ");
            sb.AppendLine("	FROM TB_MAT_MATERIAL MAT");
            sb.AppendLine("	    JOIN TB_AAT_ATRIBUTOS AAT ON AAT.MATID = MAT.MATID");
            sb.AppendLine("	    JOIN TB_NCM_NCM NCM ON NCM.NCMID = MAT.NCMID");
            sb.AppendLine("	    JOIN TB_FOR_FORNECEDOR FORN ON FORN.FORID = MAT.FORID");
            sb.AppendLine("	    JOIN TB_ARL_ATRLINHAPROD ARL ON ARL.ARLID = AAT.ARLID");
            sb.AppendLine("	    JOIN TB_ARG_ATRGRIFE ARG ON ARG.ARGID = AAT.ARGID");
            sb.AppendLine("	    JOIN TB_ARM_ATRMODELO ARM ON ARM.ARMID = AAT.ARMID");
            sb.AppendLine("	    JOIN TB_ARC_ATRCOR ARC ON ARC.ARCID = AAT.ARCID");
            sb.AppendLine("	    JOIN TB_ACN_ATRCORNUMERICA ACN ON ACN.ACNID = AAT.ACNID");
            sb.AppendLine("	    JOIN TB_AS1_ATRSUBLINHA1 AS1 ON AS1.AS1ID = AAT.AS2ID");
            sb.AppendLine("	    JOIN TB_AS2_ATRSUBLINHA2 AS2 ON AS2.AS2ID = AAT.AS2ID");
            sb.AppendLine("	    JOIN TB_ATO_ATRTAMANHO ATO ON ATO.ATOID = AAT.ATOID");
            sb.AppendLine("	    JOIN TB_MPC_MATPRECOCUSTO MPC ON MPC.MATID = MAT.MATID");
            sb.AppendLine("	    JOIN TB_MPV_MATPRECOVENDA MPV ON MPV.MPVID = MAT.MATID");
            sb.AppendLine("    WHERE MAT.MATID = @MATID");

            return sb.ToString();
        }
    }
}
