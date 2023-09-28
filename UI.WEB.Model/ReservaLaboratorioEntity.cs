using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{

    [Table("TB_REL_RESERVALABORATORIO")]
    public class ReservaLaboratorioEntity
    {
        public int RELID { get; set; }
        public int LABID { get; set; }
        public int USUID { get; set; }
        public string RELDATA { get; set; }
        public string RELHORARIO { get; set; }
    }
}
