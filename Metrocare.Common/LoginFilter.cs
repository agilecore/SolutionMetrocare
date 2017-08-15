using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class LoginFilter : Base
    {
        public LoginFilter()
        {
            this.id_usuario = 0;
            this.nome = String.Empty;
            this.cpf = String.Empty;
            this.logradouro = String.Empty;
            this.complemento = String.Empty;
            this.numero = 0;
            this.cep = 0;
            this.bairro = String.Empty;
            this.cidade = String.Empty;
            this.uf = String.Empty;
            this.email = String.Empty;
            this.telefone = String.Empty;
            this.celular = String.Empty;
            this.contato = String.Empty;
            this.dt_cadastro = DateTime.Now;
            this.dt_nascimento = DateTime.Now;
            this.longitude = 0;
            this.latitude = 0;
            this.ibge = 0;
            this.senha = String.Empty;
            this.status = String.Empty;
        }

        public Int32 id_usuario { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public String logradouro { get; set; }
        public String complemento { get; set; }
        public Int32 numero { get; set; }
        public Int32 cep { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String uf { get; set; }
        public String email { get; set; }
        public String telefone { get; set; }
        public String celular { get; set; }
        public String contato { get; set; }
        public DateTime dt_cadastro { get; set; }
        public DateTime dt_nascimento { get; set; }
        public Int32 longitude { get; set; }
        public Int32 latitude { get; set; }
        public Int32 ibge { get; set; }
        public String senha { get; set; }
        public String status { get; set; }

        public String username { get; set; }

        public String password { get; set; }

    }
}
