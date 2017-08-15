using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Security.Models;

namespace Metrocare.Security.Interfaces
{
    /// <summary>
    /// Assinaturas gen�ricas para manipula��o de logs de acessso.
    /// </summary>
    public interface ILogOperation
    {
        /// <summary>
        /// Registra log de entrada na aplica��o.
        /// </summary>
        void AddStartAccess(AuthUser User);

        /// <summary>
        /// Registra log de saida da aplica��o.
        /// </summary>
        void AddFinishAccess();
    }
}