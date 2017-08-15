using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Data;

namespace Metrocare.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório genérico com assinaturas de métodos de manibulação de entidades modelo do banco.
    /// </summary>
    /// <typeparam name="TEntity">Entidade modelo do banco de dados.</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : new()
    {
        #region "Métodos de manipulação"
                                    
        /// <summary>
        /// Retorna uma lista de objetos buscada..
        /// </summary>
        /// <param name="filters">Condições para retorno da lista de objetos.</param>
        List<TEntity> GetByFilter(object filters);

        /// <summary>
        /// Retorna um item buscado.
        /// </summary>
        /// <param name="filters">Condições para retorno do objeto.</param>
        TEntity GetItem(object filters);

        /// <summary>
        /// Adiciona um novo objeto no banco de dados.
        /// </summary>
        /// <param name="model">Objeto para ser adicionado.</param>
        bool Add(TEntity model);

        /// <summary>
        /// Deleta um objeto existente no banco de dados pelo numero do Id.
        /// </summary>
        /// <param name="Id">Id da tabela do objeto para ser deletado</param>
        bool Delete(Int32 Id);

        /// <summary>
        /// Atualiza um objeto no banco de dados.
        /// </summary>
        /// <param name="model">Objeto com as alterações para ser atualizado no banco de dados</param>
        bool Update(TEntity model);

        #endregion  
    }   
}
