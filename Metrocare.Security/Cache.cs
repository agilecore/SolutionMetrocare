using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metrocare.Security.Models;
using Metrocare.Security.Interfaces;
using System.Web.Caching;

namespace Metrocare.Security
{
    /// <summary>
    /// Métodos genéricos para manipulação de sessão dentro da aplicação.
    /// </summary>
    public class Cache : ICacheOperation
    {
        /// <summary>
        /// Adiciona um valor a cache
        /// </summary>
        public void Add(string Value)
        {
            var Expiration = System.Web.Caching.Cache.NoAbsoluteExpiration;
            HttpContext.Current.Cache.Insert("MetronicCache", Value, null, Expiration, new TimeSpan(0, 0, 15));
        }

        /// <summary>
        /// Adiciona um valor a cache e um nome para a cache
        /// </summary>
        public void Add(string CacheName, string CacheValue)
        {
            var Expiration = System.Web.Caching.Cache.NoAbsoluteExpiration;
            HttpContext.Current.Cache.Insert(CacheName, CacheValue, null, Expiration, new TimeSpan(0, 0, 15));
        }

        /// <summary>
        /// Limpa cache
        /// </summary>
        public void Clear(string CacheName)
        {
            HttpContext.Current.Cache.Remove(CacheName);
        }
        
        /// <summary>
        /// Retorna quantidade de itens de uma cache
        /// </summary>
        public int Count()
        {
            return (HttpContext.Current.Cache.Count);
        }

        /// <summary>
        /// Retorna dados de um item da cache
        /// </summary>
        public TEntity Get<TEntity>(string CacheName)
        {
            return ((HttpContext.Current.Cache[CacheName] is TEntity) ? (TEntity)HttpContext.Current.Cache[CacheName] : default(TEntity));
        }

        /// <summary>
        /// Remove uma cache do sistemas.
        /// </summary>
        public void Remove(string CacheName)
        {
            if (HttpContext.Current.Cache[CacheName] != null) { HttpContext.Current.Cache.Remove(CacheName); }
        }
    }
}