using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{

    [Table("TB_AND_ANDAR")]
    public class AndarEntity
    {
        public int ANDID { get; set; }
        public string ANDNUMERO { get; set; }
    }
}
