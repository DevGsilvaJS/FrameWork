using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Utilitarios
{
    public class UsuarioQuery
    {
        public string ListaDadosQuery()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("SELECT                                                              ");
            sb.AppendLine("  USU.USUID,                                                                    ");
            sb.AppendLine("  PES.PESID,                                                                    ");
            sb.AppendLine("  COALESCE(TEL.TELID, 0) AS TELID,                                              ");
            sb.AppendLine("  COALESCE(EML.EMLID, 0) AS EMLID,                                              ");
            sb.AppendLine("  USU.USUSTATUS,                                                                ");
            sb.AppendLine("  USU.USUSENHA,                                                                 ");
            sb.AppendLine("  PES.PESNOME,                                                                  ");
            sb.AppendLine("  PES.PESSOBRENOME,                                                             ");
            sb.AppendLine("  COALESCE(CAST(EML.EMLDESCRICAO AS VARCHAR(255)), '0') AS EMLDESCRICAO,        ");
            sb.AppendLine("  COALESCE(CAST(TEL.TELNUMERO AS VARCHAR(255)), '0') AS TELNUMERO,              ");
            sb.AppendLine("  COALESCE(CAST(TEL.TELDDD AS VARCHAR(255)), '0') AS TELDDD                     ");
            sb.AppendLine("FROM TB_USU_USUARIO USU                                                         ");
            sb.AppendLine("INNER JOIN TB_PES_PESSOA PES ON PES.PESID = USU.PESID                           ");
            sb.AppendLine("LEFT JOIN TB_EML_EMAIL EML ON EML.PESID = PES.PESID                             ");
            sb.AppendLine("LEFT JOIN TB_TEL_TELEFONE TEL ON TEL.PESID = PES.PESID                          ");


            return sb.ToString();

        }

        public string GetUsuarioByIDQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                                                           ");
            sb.AppendLine("    USU.USUID,                                                                               ");
            sb.AppendLine("    PES.PESID,                                                                               ");
            sb.AppendLine("    COALESCE(TEL.TELID, 0) AS TELID,                                                         ");
            sb.AppendLine("    COALESCE(EML.EMLID, 0) AS EMLID,                                                         ");
            sb.AppendLine("    USU.USUSTATUS,                                                                           ");
            sb.AppendLine("    USU.USUSENHA,                                                                            ");
            sb.AppendLine("    PES.PESNOME,                                                                             ");
            sb.AppendLine("    PES.PESSOBRENOME,                                                                        ");
            sb.AppendLine("    PES.PESDOCFEDERAL,                                                                        ");
            sb.AppendLine("    COALESCE(CAST(EML.EMLDESCRICAO AS VARCHAR(255)), '0') AS EMLDESCRICAO,                   ");
            sb.AppendLine("    COALESCE(CAST(TEL.TELNUMERO AS VARCHAR(255)), '0') AS TELNUMERO,                         ");
            sb.AppendLine("    COALESCE(CAST(TEL.TELDDD AS VARCHAR(255)), '0') AS TELDDD                                ");
            sb.AppendLine(" FROM TB_USU_USUARIO USU                                                                    ");
            sb.AppendLine(" INNER JOIN TB_PES_PESSOA PES ON PES.PESID = USU.PESID                                      ");
            sb.AppendLine(" LEFT JOIN TB_EML_EMAIL EML ON EML.PESID = PES.PESID                                        ");
            sb.AppendLine(" LEFT JOIN TB_TEL_TELEFONE TEL ON TEL.PESID = PES.PESID                                     ");
            sb.AppendLine("     WHERE USU.PESID = @PESID                                                                ");



            return sb.ToString();

        }
    }
}
