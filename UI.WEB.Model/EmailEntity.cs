using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{
    [Table("TB_EML_EMAIL")]
    public class EmailEntity
    {
        public int EMLID { get; set; }
        public int PESID { get; set; }
        public string EMLDESCRICAO { get; set; }
    }
}
