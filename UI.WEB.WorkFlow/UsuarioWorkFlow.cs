using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using UI.WEB.Model;
using UI.WEB.Query.Utilitarios;
using UI.WEB.WorkFlow.Outros;

namespace WorkFlow.Utilitarios
{
    public class UsuarioWorkFlow : BaseWeb
    {
        DBComando db = new DBComando();

        public UsuarioEntity ValidaUsuario(string email, string senha)
        {
            UsuarioEntity _ObjUsuario = new UsuarioEntity();
            //Classe que retorna uma conexao com banco de dados

            UsuarioEntity _Usuario = new UsuarioEntity();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   SELECT EML.EMLDESCRICAO, USU.USUSENHA                                                   ");
            sb.AppendLine("       FROM TB_PES_PESSOA PES                                                                       ");
            sb.AppendLine("        INNER JOIN TB_USU_USUARIO USU ON USU.PESID = PES.PESID      ");
            sb.AppendLine("        INNER JOIN TB_EML_EMAIL EML ON EML.PESID = PES.PESID           ");
            sb.AppendLine("        WHERE EML.EMLDESCRICAO ='" + email + "'AND USU.USUSENHA = " + senha + "");

            SqlDataReader _DataReader = ListarDadosEntity(sb.ToString());

            if (_DataReader.HasRows)
            {
                //Verifica se tem dados na linha
                while (_DataReader.Read())
                {
                    _ObjUsuario.TbEmail.EMLDESCRICAO = _DataReader["EMLDESCRICAO"].ToString();
                    _ObjUsuario.USUSENHA = _DataReader["USUSENHA"].ToString();
                }
            }

            db.FechaConexao(db.MinhaConexao());

            return _ObjUsuario;
        }
        public UsuarioEntity RetornaObjInclusao()
        {
            UsuarioEntity _obj = new UsuarioEntity();

            return _obj;
        }
        public string GravarUsuario(UsuarioEntity _Usuario)
        {

            string retorno = "NOTOK";

            if (_Usuario.TbPessoa.PESID > 0)
            {
                AtualizarUsuario(_Usuario);
            }
            else
            {
<<<<<<< HEAD:UI.WEB.WorkFlow/UsuarioWorkFlow.cs

                string verificaEmailCadastrado = RetornaObjeto("TB_EML_EMAIL", "EMLDESCRICAO", _Usuario.TbEmail.EMLDESCRICAO);

                if (!string.IsNullOrEmpty(verificaEmailCadastrado))
                {
                    return "EMAIL JÁ CADASTRADO!";
                }

=======
>>>>>>> 825958046166c5c65fc273ff1447db11abf082b6:UI.WEB.WorkFlow/Utilitarios/UsuarioWorkFlow.cs

                AddListaSalvar(_Usuario.TbPessoa);

                int PESID = _Usuario.TbPessoa.PESID;
                _Usuario.PESID = PESID;

                AddListaSalvar(_Usuario);


                if (_Usuario.TbTelefone.TELNUMERO != null || _Usuario.TbTelefone.TELNUMERO != null)
                {
                    _Usuario.TbTelefone.PESID = PESID;
                    AddListaSalvar(_Usuario.TbTelefone);
                }

                if (_Usuario.TbEmail.EMLDESCRICAO != null)
                {
                    _Usuario.TbEmail.PESID = PESID;
                    AddListaSalvar(_Usuario.TbEmail);
                }


                
            }

            ExecuteTransacao();

            return retorno;

        }
        public string AtualizarUsuario(UsuarioEntity _Usuario)
        {
            string sRetorno = "NOTOK";

            AddListaAtualizar(_Usuario.TbPessoa);

            _Usuario.PESID = _Usuario.TbPessoa.PESID;
            _Usuario.TbEmail.PESID = _Usuario.TbPessoa.PESID;
            _Usuario.TbTelefone.PESID = _Usuario.TbPessoa.PESID;
            AddListaAtualizar(_Usuario);

            string sEmail = RetornaObjeto("TB_EML_EMAIL", "PESID", _Usuario.TbPessoa.PESID);

            if (!string.IsNullOrEmpty(sEmail))
            {
                AddListaAtualizar(_Usuario.TbEmail);
            }
            else
            {
                AddListaSalvar(_Usuario.TbEmail);
            }


            string sTelefone = RetornaObjeto("TB_TEL_TELEFONE", "PESID", _Usuario.TbPessoa.PESID);

            if (!string.IsNullOrEmpty(sTelefone))
            {
                AddListaAtualizar(_Usuario.TbTelefone);
            }



            return sRetorno;
        }
        public List<UsuarioEntity> ListaDados()
        {
            List<UsuarioEntity> lsUsuarios = new List<UsuarioEntity>();
            try
            {

                UsuarioQuery Query = new UsuarioQuery();

                SqlDataReader dr = ListarDadosEntity(Query.ListaDadosQuery());


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEntity _Usuario = new UsuarioEntity();

                        _Usuario.PESID = int.Parse(dr["PESID"].ToString());
                        _Usuario.TbPessoa.PESNOME = dr["PESNOME"].ToString();
                        _Usuario.TbEmail.EMLDESCRICAO = dr["EMLDESCRICAO"].ToString();
                        _Usuario.USUSTATUS = dr["USUSTATUS"].ToString();
                        lsUsuarios.Add(_Usuario);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return lsUsuarios;

        }
        public UsuarioEntity GetUsuarioByID(int pesid)
        {

            UsuarioEntity _ObjUsuario = new UsuarioEntity();
            UsuarioQuery Query = new UsuarioQuery();



            SqlCommand _Comando = new SqlCommand(Query.GetUsuarioByIDQuery(), db.MinhaConexao());

            SqlParameter parameter = new SqlParameter("@PESID", pesid);
            _Comando.Parameters.Add(parameter);
            _Comando.CommandType = CommandType.Text;
            SqlDataReader dr = _Comando.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    _ObjUsuario.USUID = int.Parse(dr["USUID"].ToString());
                    _ObjUsuario.TbPessoa.PESID = int.Parse(dr["PESID"].ToString());
                    _ObjUsuario.TbPessoa.PESNOME = dr["PESNOME"].ToString();
                    _ObjUsuario.TbPessoa.PESDOCFEDERAL = dr["PESDOCFEDERAL"].ToString();
                    _ObjUsuario.TbTelefone.TELID = int.Parse(dr["TELID"].ToString());
                    _ObjUsuario.TbEmail.EMLID = int.Parse(dr["EMLID"].ToString());
                    _ObjUsuario.USUSTATUS = dr["USUSTATUS"].ToString();
                    _ObjUsuario.USUSENHA = dr["USUSENHA"].ToString();
                    _ObjUsuario.TbEmail.EMLDESCRICAO = dr["EMLDESCRICAO"].ToString();
                    _ObjUsuario.TbTelefone.TELDDD = dr["TELDDD"].ToString();
                    _ObjUsuario.TbTelefone.TELNUMERO = dr["TELNUMERO"].ToString();
                    _ObjUsuario.TbTelefone.TELDDD = dr["TELDDD"].ToString();

                }
            }

            return _ObjUsuario;
        }
        public string ExcluirUsuario(int pesid)
        {
            string sRetornoEmail = RetornaObjeto("TB_EML_EMAIL", "PESID", pesid);

            if (!string.IsNullOrEmpty(sRetornoEmail))
            {
                string email = RetornaQueryDelete("TB_EML_EMAIL", "PESID", pesid);
                AddListaDeletar(email);
            }

            string sRetornaTelefone = RetornaObjeto("TB_TEL_TELEFONE", "PESID", pesid);

            if (!string.IsNullOrEmpty(sRetornaTelefone))
            {
                string telefone = RetornaQueryDelete("TB_TEL_TELEFONE", "PESID", pesid);
                AddListaDeletar(telefone);
            }

            string sUsuario = RetornaQueryDelete("TB_USU_USUARIO", "PESID", pesid);
            AddListaDeletar(sUsuario);

            string sPessoa = RetornaQueryDelete("TB_PES_PESSOA", "PESID", pesid);
            AddListaDeletar(sPessoa);

            ExecuteTransacao();

            return "";

        }
        public string VerificaDocumentoCadastrado(string pesdocfederal)
        {

            string sDocumento = RetornaObjeto("TB_PES_PESSOA", "PESDOCFEDERAL", pesdocfederal);

            if (!string.IsNullOrEmpty(sDocumento))
            {
                return "CPF/CNPJ já cadastrado!";
            }
            else
            {
                return "OK";
            }
        }


    }
}
