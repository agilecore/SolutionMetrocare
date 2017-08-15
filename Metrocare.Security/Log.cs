using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Security.Interfaces;

namespace Metrocare.Security
{
    /// <summary>
    /// Métodos genéricos para manipulação de Logs dentro da aplicação.
    /// </summary>
    public class Log : ILogOperation
    {
        /// <summary>
        /// Registra log de entrada na aplicação.
        /// </summary>
        public void AddStartAccess(Models.AuthUser User)
        {
            throw new NotImplementedException();
            // camada de dados

            //try
            //{

            //}
            //catch (Exception Ex)
            //{
                
            //    throw;
            //}
        }

        /// <summary>
        /// Registra log de saida da aplicação.
        /// </summary>
        public void AddFinishAccess()
        {
            throw new NotImplementedException();
            // camada de dados

            //try
            //{

            //}
            //catch (Exception Ex)
            //{

            //    throw;
            //}
        }
    }
}
