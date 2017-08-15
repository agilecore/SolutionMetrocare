using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class CredenciadoFilter
    {
        public CredenciadoFilter()
        {
                this.id_credenciado           = 0;     
                this.id_concelho_profissional = 0;
                this.nome                     = String.Empty;
                this.nro_concelho             = 0;
                this.uf_concelho              = String.Empty;
                this.cpf                      = String.Empty;
                this.rg                       = String.Empty;
                this.cnpj                     = String.Empty;
                this.email                    = String.Empty;
                this.telefone                 = String.Empty;
                this.celular                  = String.Empty;
                this.contato                  = String.Empty;
                this.dt_cadastro              = null;
                this.dt_nascimento            = null;
                this.longitude                = 0;
                this.latitude                 = 0;
                this.ibge                     = 0;
                this.prestador                = new List<PrestadorDto>();  
                this.especialidade            = new List<EspecialidadeDto>();
        }                                        
                    
        public Int32  id_credenciado           {get; set;}           
        public Int32  id_concelho_profissional {get; set;}           
        public String nome                     {get; set;}           
        public Int32  nro_concelho             {get; set;}           
        public String uf_concelho              {get; set;}           
        public String cpf                      {get; set;}
        public String rg                       { get; set; }   
        public String cnpj                     {get; set;}           
        public String email                    {get; set;}           
        public String telefone                 {get; set;}           
        public String celular                  {get; set;}           
        public String contato                  {get; set;}           
        public DateTime? dt_cadastro           {get; set;}
        public DateTime? dt_nascimento         {get; set;}      
        public Int32  longitude                {get; set;}           
        public Int32  latitude                 {get; set;}           
        public Int32  ibge                     {get; set;}
        public List<PrestadorDto> prestador    {get; set;}
        public List<EspecialidadeDto> especialidade { get; set; }
    }
}
                      
