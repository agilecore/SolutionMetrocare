using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Enumerador de diversas bandeiras mais utilziadas atualmente de cartões de credito.
    /// </summary>
    public enum EBandeiras
    {
        [Description("Cartao de Crédito Visa")]
        Visa,          
        [Description("Cartao de Crédito Master")]
        MasterCard,     
        [Description("Cartao de Crédito American Express")]
        AmericanExpress,
        [Description("Cartao de Crédito Hiper")]
        Hiper,
        [Description("Cartao de Crédito HiperCard")]
        HiperCard,
        [Description("Cartao de Crédito Elo")]
        Elo,
        [Description("Cartao de Crédito de Outras Bandeiras")]
        Outros
    }
}
