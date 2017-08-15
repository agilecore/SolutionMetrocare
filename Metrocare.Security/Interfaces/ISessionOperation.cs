using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Security.Interfaces
{
    /// <summary>
    /// Assinaturas gen�ricas para manipula��o de sess�o utilizado na classe SessionManager.
    /// </summary>
    public interface ISessionOperation<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inicia uma sess�o de acesso autorizado a aplica��o.
        /// </summary>
        void Start(TEntity arg);

        /// <summary>
        /// Finaliza uma sess�o de acesso autorizado a aplica��o.
        /// </summary>
        void Finish();

        /// <summary>
        /// Retorna [true] se a sess�o estiver ativa ou [false] se a sess�o estiver inativa.
        /// </summary>
        bool IsActive();

        /// <summary>
        /// Retorna o id da sess�o autorizada.
        /// </summary>
        string GetSessionId();

        /// <summary>
        /// Retorna o objeto AuthenticatedUser armazenado na sess�o atual.
        /// </summary>
        TEntity GetUser();

        /// <summary>
        /// Retorna o tempo de dura��o em minutos configurado na aplica��o.
        /// </summary>
        Int32 GetSessionTimeOut();

        /// <summary>
        /// M�todo que retorna o objeto mediante a verifica��o de seu tipo
        /// </summary>
        //TEntity Get<TEntity>(string SessionName);

        /// <summary>
        /// Remove uma sess�o espec�fica
        /// </summary>
        void Remove(string SessionName);
    }
}