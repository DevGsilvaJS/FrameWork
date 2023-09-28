using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{

    [Table("TB_PES_PESSOA")]
    public class PessoaEntity
    {
        public int PESID { get; set; }
        public string PESNOME { get; set; }
        public string PESSOBRENOME { get; set; }
        public string PESDOCFEDERAL { get; set; }
        public string PESTIPO { get; set; }
    }
}
