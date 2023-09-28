using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model.Fiscal.Tabelas_Auxiliares
{
    [Table("TB_NCM_NCM")]
    public class EntityNCM
    {
        public int NCMID { get; set; }
        public string NCMCODIGO { get; set; }
        public string NCMDESCRICAO { get; set; }
        public string NCMSTATUS { get; set; }
    }
}
