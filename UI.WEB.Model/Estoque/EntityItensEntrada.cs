using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model.Estoque
{
    public class EntityItensEntrada
    {

		public int MVMID { get; set; }
        public int MVNID { get; set; }
        public int COPID { get; set; }
        public int MATID { get; set; }
        public string MVMQUANTIDADE { get; set; }
        public string MVMVALUNITARIO { get; set; }
        public string MVMVALIPI { get; set; }
        public string MVMVALCUSTO { get; set; }
        public string MVMMARKUP { get; set; }
        public string MVMVALVENDA { get; set; }

    }
}
