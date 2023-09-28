using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WEB.Model.Estoque.Atributos.Caracteristicas;

namespace UI.WEB.Model.Estoque.Atributos
{

    [Table("TB_AAT_ATRIBUTOS")]
    public class EntityAtributosProduto
    {
        public int AATID { get; set; }
        public int MATID { get; set; }
        public int ARLID { get; set; }
        public int ARCID { get; set; }
        public int ACNID { get; set; }
        public int ARMID { get; set; }
        public int ARGID { get; set; }
        public int AS1ID { get; set; }
        public int AS2ID { get; set; }
        public int ATOID { get; set; }
        public EntityCorNumericaProduto TbCorNumerica { get; set; }
        public EntityCorProduto TbCorProduto { get; set; }
        public EntityFabricanteProduto TbFabricante { get; set; }
        public EntityGrifeProduto TbGrife { get; set; }
        public EntityGrupoProduto TbGrupo { get; set; }
        public EntityLinhaProduto TbLinha { get; set; }
        public EntityModeloProduto TbModelo { get; set; }
        public EntitySublinha1Produto TbSublinha1 { get; set; }
        public EntitySublinha2Produto TbSublinha2 { get; set; }
        public EntityTamanhoProduto TbTamanho { get; set; }


        public EntityAtributosProduto()
        {
            TbCorNumerica = new EntityCorNumericaProduto();
            TbCorProduto = new EntityCorProduto();
            TbFabricante = new EntityFabricanteProduto();
            TbGrife = new EntityGrifeProduto();
            TbGrupo = new EntityGrupoProduto();
            TbLinha = new EntityLinhaProduto();
            TbModelo = new EntityModeloProduto();
            TbSublinha1 = new EntitySublinha1Produto();
            TbSublinha2 = new EntitySublinha2Produto();
            TbTamanho = new EntityTamanhoProduto();
        }
    }
}
