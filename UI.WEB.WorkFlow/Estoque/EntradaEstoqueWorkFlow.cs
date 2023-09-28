using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WEB.Model.Estoque;
using UI.WEB.Model.Fiscal.Tabelas_Auxiliares;
using UI.WEB.Query.Estoque;
using UI.WEB.Query.Fiscal;
using UI.WEB.WorkFlow.Outros;

namespace UI.WEB.WorkFlow.Estoque
{
    public class EntradaEstoqueWorkFlow : BaseWeb
    {

        DBComando db = new DBComando();

        public EntityNotaFiscal RetornaObjInclusao()
        {
            EntityNotaFiscal obj = new EntityNotaFiscal();

            return obj;
        }
        public List<EntityFornecedor> RetornaComboFornecedores()
        {
            List<EntityFornecedor> listaFornecedores = new List<EntityFornecedor>();
            EntradaEstoqueQuery Query = new EntradaEstoqueQuery();

            SqlDataReader dr = ListarDadosEntity(Query.listaFornecedoresQuery());


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EntityFornecedor Fornecedor = new EntityFornecedor();

                    Fornecedor.FORID = int.Parse(dr["FORID"].ToString());
                    Fornecedor.TbPessoa.PESNOME = dr["PESNOME"].ToString();

                    listaFornecedores.Add(Fornecedor);
                }
            }

            return listaFornecedores;
        }
        public List<EntityCFOP> RetornaComboCfops()
        {
            List<EntityCFOP> listaCfops = new List<EntityCFOP>();
            EntradaEstoqueQuery Query = new EntradaEstoqueQuery();

            SqlDataReader dr = ListarDadosEntity(Query.listaCfopQuery());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EntityCFOP Cfop = new EntityCFOP();

                    Cfop.COPID = int.Parse(dr["COPID"].ToString());
                    Cfop.COPDESCRICAO = dr["COPDESCRICAO"].ToString();

                    listaCfops.Add(Cfop);
                }
            }

            return listaCfops;
        }
        public EntityProduto RetornaProduto(string produto)
        {
            EntityProduto Produto = new EntityProduto();




            return Produto;
        }
        public List<EntityProduto> RetornaEntityProduto(string produto)
        {
            List<EntityProduto> listaProduto = new List<EntityProduto>();

            EntradaEstoqueQuery Query = new EntradaEstoqueQuery();

            SqlCommand _Comando = new SqlCommand(Query.buscaProdutoQuery(), db.MinhaConexao());

            SqlParameter parameter = new SqlParameter("@produto", produto);
            _Comando.Parameters.Add(parameter);
            _Comando.CommandType = CommandType.Text;
            SqlDataReader dr = _Comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EntityProduto Produto = new EntityProduto();

                    Produto.MATID = int.Parse(dr["MATID"].ToString());
                    Produto.MATSEQUENCIAL = dr["MATSEQUENCIAL"].ToString();
                    Produto.MATFANTASIA = dr["MATFANTASIA"].ToString();
                    Produto.TbGrife.ARGDESCRICAO = dr["ARGDESCRICAO"].ToString();
                    Produto.TbCor.ARCDESCRICAO = dr["ARCDESCRICAO"].ToString();
                    
                    listaProduto.Add(Produto);
                }
            }


            return listaProduto;


        }

        public string SalvarEntradaEstoque(EntityNotaFiscal EntradaEstoque)
        {
            string sRetorno = "";

            //MVN
            AddListaSalvar(EntradaEstoque);

            //MVM
            AddListaSalvar(EntradaEstoque.TbItensEntrada);


            //Itens da entrada
            foreach (var item in EntradaEstoque.ListaEntrada)
            {
                AddListaAtualizar(item);
            }

            //MEC


            return sRetorno;
        }

    }
}
