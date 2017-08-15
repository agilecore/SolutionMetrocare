using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class DependenteFilter
    {
        public DependenteFilter()
        {
            this.id_dependente = 0;
            this.id_beneficiario = 0;
            this.id_parentesco = 0;
            this.id_carteira = 0;
            this.id_usuario = 0;
            this.nome = String.Empty;
            this.cpf = String.Empty;
            this.rg = String.Empty;
            this.logradouro = String.Empty;
            this.complemento = String.Empty;
            this.numero = 0;
            this.cep = 0;
            this.bairro = String.Empty;
            this.cidade = String.Empty;
            this.uf = String.Empty;
            this.email = String.Empty;
            this.dt_cadastro = null;
        }

        public Int32 id_dependente { get; set; }
        public Int32 id_beneficiario { get; set; }
        public Int32 id_parentesco { get; set; }
        public Int32 id_carteira { get; set; }
        public Int32 id_usuario { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public String logradouro { get; set; }
        public String complemento { get; set; }
        public Int32 numero { get; set; }
        public Int32 cep { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String uf { get; set; }
        public String email { get; set; }
        public DateTime? dt_cadastro { get; set; }  
        //public List<DependenteEnderecoFilter> {get;set; }  
    }
}
                      
