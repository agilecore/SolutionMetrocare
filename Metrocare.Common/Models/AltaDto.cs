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
    public class AltaDto : Base
    {
        public System.Int32 ID_ALTA { get; set; }
        public System.String NOME { get; set; }
    }
}

