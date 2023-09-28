using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{

    [Table("TB_TEL_TELEFONE")]
    public class TelefoneEntity
    {
        public int TELID { get; set; }
        public int PESID { get; set; }
        public string TELDDD { get; set; }
        public string TELNUMERO { get; set; }
    }
}
