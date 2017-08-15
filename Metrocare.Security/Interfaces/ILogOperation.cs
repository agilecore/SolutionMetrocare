using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Security.Models;

namespace Metrocare.Security.Interfaces
{
    /// <summary>
    /// Assinaturas genéricas para manipulação de logs de acessso.
    /// </summary>
    public interface ILogOperation
    {
        /// <summary>
        /// Registra log de entrada na aplicação.
        /// </summary>
        void AddStartAccess(AuthUser User);

        /// <summary>
        /// Registra log de saida da aplicação.
        /// </summary>
        void AddFinishAccess();
    }
}