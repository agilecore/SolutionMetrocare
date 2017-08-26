using System;                                                                       
using System.Collections.Generic;                                                   
using System.Linq;                                                                  
using System.Linq.Expressions;                                                      
using System.Text;                                                                  
using System.Threading.Tasks;                                                       
                                                                                    
namespace Metrocare.Data.Interface                                        
{                                                                                   
    public interface IRepository<TEntity> where TEntity : class                     
    {                                                                               
        IQueryable<TEntity> GetAll();                                               
        IQueryable<TEntity> GetByFilters(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(params object[] key);                                          
        TEntity First(Expression<Func<TEntity, bool>> predicate);                   
        void Add(TEntity entity);                                                   
        void Delete(Expression<Func<TEntity, bool>> predicate);                     
        void Dispose();                                                             
    }                                                                               
}                                                                                   

