using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Enumerador do tipo de nota fiscal se entrada ou saída.
    /// </summary>
    public enum ETipoNotaFiscal
    {
        [Description("NF de Entrada")]
        Entrada,   
        [Description("NF de Saída")]
        Saida      
    }


}
