using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Venda.TabelasAuxiliares
{
    public class ConvenioQuery
    {
        public string ListaDadosQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                                              ");
            sb.AppendLine("    CVN.CVNID,                                                       ");
            sb.AppendLine("    CVN.CVNCONTRATO,                                                 ");
            sb.AppendLine("    PES.PESNOME,                                                     ");
            sb.AppendLine("    CVN.CVNDESCONTO,                                                 ");
            sb.AppendLine("    TEL.TELNUMERO,                                                   ");
            sb.AppendLine("    CVN.CVNNAOAPARECEVENDA,                                          ");
            sb.AppendLine("    CONCAT(TEL.TELDDDC, TEL.TELCELULAR) AS TELEFONE                  ");
            sb.AppendLine(" FROM TB_CVN_CONVENIO CVN                                            ");
            sb.AppendLine("    JOIN TB_PES_PESSOA PES ON PES.PESID = CVN.PESID                  ");
            sb.AppendLine("    LEFT JOIN TB_TEL_TELEFONE TEL ON TEL.PESID = PES.PESID           ");
            sb.AppendLine("    LEFT JOIN TB_EDN_ENDERECO EDN ON EDN.PESID = PES.PESID           ");

            return sb.ToString();
        }

        public string EditarConvenioQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                                     ");
            sb.AppendLine("     CVN.CVNID,                                             ");
            sb.AppendLine("	    PES.PESID,                                             ");
            sb.AppendLine("	    TEL.TELID,                                             ");
            sb.AppendLine("	    EDN.EDNID,                                             ");
            sb.AppendLine("	    CVN.CVNCONTRATO,                                       ");
            sb.AppendLine("	    CVN.CVNDESCONTO,                                       ");
            sb.AppendLine("	    CVN.CVNOBSERVACAO,                                     ");
            sb.AppendLine("	    CVN.CVNNAOAPARECEVENDA,                                ");
            sb.AppendLine("	    PES.PESNOME,                                           ");
            sb.AppendLine("	    EDN.EDNCEP,                                            ");
            sb.AppendLine("	    EDN.EDNCIDADE,                                         ");
            sb.AppendLine("	    EDN.EDNLOGRADOURO,                                     ");
            sb.AppendLine("	    EDN.EDNBAIRRO,                                         ");
            sb.AppendLine("	    EDN.EDNNUMERO,                                         ");
            sb.AppendLine("	    EDN.EDNUF,                                             ");
            sb.AppendLine("	    EDN.EDNCOMPLEMENTO,                                    ");
            sb.AppendLine("	    TEL.TELNUMERO,                                         ");
            sb.AppendLine("	    TEL.TELDDD,                                            ");
            sb.AppendLine("	    TEL.TELCELULAR,                                        ");
            sb.AppendLine("	    TEL.TELDDDC                                            ");
            sb.AppendLine("  FROM TB_CVN_CONVENIO CVN                                  ");
            sb.AppendLine("     JOIN TB_PES_PESSOA PES ON PES.PESID = CVN.PESID        ");
            sb.AppendLine("     LEFT JOIN TB_TEL_TELEFONE TEL ON TEL.PESID = PES.PESID ");
            sb.AppendLine("     LEFT JOIN TB_EDN_ENDERECO EDN ON EDN.PESID = PES.PESID ");
            sb.AppendLine("  WHERE CVN.CVNID = @CVNID                                  ");

            return sb.ToString();
        }


    }
}
