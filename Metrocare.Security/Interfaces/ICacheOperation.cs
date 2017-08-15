using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Security.Interfaces
{
    /// <summary>
    /// Assinaturas genéricas para manipulação de cache.
    /// </summary>
    public interface ICacheOperation
    {
        /// <summary>
        /// Adiciona um valor a cache
        /// </summary>
        void Add(string value);

        /// <summary>
        /// Adiciona um valor a cache e um nome para a cache
        /// </summary>
        void Add(string CacheName, string CacheValue);

        /// <summary>
        /// Limpa cache
        /// </summary>
        void Clear(string CacheName);

        /// <summary>
        /// Retorna quantidade de itens de uma cache
        /// </summary>
        int Count();

        /// <summary>
        /// Retorna dados de um item da cache
        /// </summary>
        TEntity Get<TEntity>(string CacheName);

        /// <summary>
        /// Remove uma cache do sistemas.
        /// </summary>
        void Remove(string CacheName);
    }
}