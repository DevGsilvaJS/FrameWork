using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WEB.Model.Estoque.TabelaPrecos;
using UI.WEB.Model.Fiscal.Tabelas_Auxiliares;

namespace UI.WEB.Model.Estoque
{
    public class EntityNotaFiscal
    {

        public int MVNID { get; set; }
        public int FORID { get; set; }
        public string MVNDATAENTRADA { get; set; }
        public string MVNNUMNOTA { get; set; }
        public string MVNMODELONOTA { get; set; }
        public string MVNSERIENOTA { get; set; }
        public string MVNSUBSERIENOTA { get; set; }
        public string MVNTOTALNOTA { get; set; }
        public EntityItensEntrada TbItensEntrada { get; set; }
        public EntityCFOP TbCfop { get; set; }
        public EntityFornecedor TbFornecedor { get; set; }
        public EntityProduto TbProduto { get; set; }
        public EntityMPV TbMpv { get; set; }
        public EntiyMPC TbMpc { get; set; }
        public List<EntityItensEntrada> ListaEntrada { get; set; }

        public EntityNotaFiscal()
        {
            ListaEntrada = new List<EntityItensEntrada>();
            TbItensEntrada = new EntityItensEntrada();
            TbCfop = new EntityCFOP();
            TbFornecedor = new EntityFornecedor();
            TbProduto = new EntityProduto();
            TbMpc = new EntiyMPC();
            TbMpv = new EntityMPV();
        }
    }
}
