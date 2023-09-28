using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query.Fiscal
{

    [Table("TB_COP_CFOP")]
    public class EntityCfop
    {
        public int COPID { get; set; }
        public string COPCODIGO { get; set; }
        public string COPDESCRICAO { get; set; }
        public string COPSTATUS { get; set; }
        public string COPTIPO { get; set; }
    }
}
