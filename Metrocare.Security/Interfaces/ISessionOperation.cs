using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Security.Interfaces
{
    /// <summary>
    /// Assinaturas genéricas para manipulação de sessão utilizado na classe SessionManager.
    /// </summary>
    public interface ISessionOperation<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inicia uma sessão de acesso autorizado a aplicação.
        /// </summary>
        void Start(TEntity arg);

        /// <summary>
        /// Finaliza uma sessão de acesso autorizado a aplicação.
        /// </summary>
        void Finish();

        /// <summary>
        /// Retorna [true] se a sessão estiver ativa ou [false] se a sessão estiver inativa.
        /// </summary>
        bool IsActive();

        /// <summary>
        /// Retorna o id da sessão autorizada.
        /// </summary>
        string GetSessionId();

        /// <summary>
        /// Retorna o objeto AuthenticatedUser armazenado na sessão atual.
        /// </summary>
        TEntity GetUser();

        /// <summary>
        /// Retorna o tempo de duração em minutos configurado na aplicação.
        /// </summary>
        Int32 GetSessionTimeOut();

        /// <summary>
        /// Método que retorna o objeto mediante a verificação de seu tipo
        /// </summary>
        //TEntity Get<TEntity>(string SessionName);

        /// <summary>
        /// Remove uma sessão específica
        /// </summary>
        void Remove(string SessionName);
    }
}