using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Nao alterar essa classe pois ela é o objeto identico a tabela do banco de dados.
    /// </summary>
    public class CredenciadoEspecialidadeDto : Base
    {
        public System.Int32 ID_CREDENCIADO { get; set; }
        public System.Int32 ID_ESPECIALIDADE { get; set; }
        public System.String PRINCIPAL { get; set; }
        public System.DateTime DT_ATIVACAO { get; set; }
        public System.DateTime DT_INATIVACAO { get; set; }
    }
}

