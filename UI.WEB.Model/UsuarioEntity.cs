using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Model
{

    [Table("TB_USU_USUARIO")]
    public class UsuarioEntity
    {
        public int USUID { get; set; }
        public int PESID { get; set; }
        public string USUSENHA { get; set; }
        public string USUSTATUS { get; set; }
        public EmailEntity TbEmail { get; set; }
        public TelefoneEntity TbTelefone { get; set; }
        public PessoaEntity TbPessoa { get; set; }


        public UsuarioEntity()
        {
            TbEmail = new EmailEntity();
            TbTelefone = new TelefoneEntity();
            TbPessoa = new PessoaEntity();
        }
    }
}
