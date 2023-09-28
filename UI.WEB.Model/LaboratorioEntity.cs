using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{

    [Table("TB_LAB_LABORATORIO")]
    public class LaboratorioEntity
    {
        public int LABID { get; set; }
        public int ANDID { get; set; }
        public string LABDESCRICAO { get; set; }
        public string LABSTATUS { get; set; }
        public AndarEntity TbAndar { get; set; }


        public LaboratorioEntity()
        {
            TbAndar = new AndarEntity();
        }
    }
}
