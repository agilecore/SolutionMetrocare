using System;																															
using System.Collections.Generic;                                                                                                     
using System.Linq;                                                                                                                    
using System.Linq.Expressions;                                                                                                        
using System.Text;                                                                                                                    
using System.Threading.Tasks;                                                                                                         
using System.Data;                                                                                                                    
using System.Data.Entity;                                                                                                             
using Metrocare.Data.Interface;                                                                                                           
                                                                                                                                      
namespace Metrocare.Data                                                                                                                  
{                                                                                                                                     
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class                                        
    {                                                                                                                                 
        private DbSet<TEntity> _dbSet;                                                                                                
                                                                                                                                      
        private MetrocareContext _dbContext;                                                                                                 
                                                                                                                                      
        internal Boolean _preConfig = false;                                                                                          
                                                                                                                                      
        public Repository(MetrocareContext dbContext)                                                                                        
        {                                                                                                                             
            InitializePreConfiguration(dbContext);                                                                                    
        }                                                                                                                             
                                                                                                                                      
        public IQueryable<TEntity> GetAll()                                                                                           
        {                                                                                                                             
            return _dbContext.Set<TEntity>();                                                                                         
        }                                                                                                                             
                                                                                                                                      
        public IQueryable<TEntity> GetByFilters(Expression<Func<TEntity, bool>> predicate)                                            
        {                                                                                                                             
            return _dbContext.Set<TEntity>().Where(predicate);                                                                        
        }                                                                                                                             
                                                                                                                                      
        public TEntity Find(params object[] key)                                                                                      
        {                                                                                                                             
            return _dbContext.Set<TEntity>().Find(key);                                                                               
        }                                                                                                                             
                                                                                                                                      
        public TEntity First(Expression<Func<TEntity, bool>> predicate)                                                               
        {                                                                                                                             
            return _dbContext.Set<TEntity>().Where(predicate).FirstOrDefault();                                                       
        }                                                                                                                             
                                                                                                                                      
        public void Add(TEntity entity)                                                                                               
        {                                                                                                                             
            _dbContext.Set<TEntity>().Add(entity);                                                                                    
        }                                                                                                                             
                                                                                                                                      
        public void AddAll(List<TEntity> collection)                                                                                  
        {                                                                                                                             
            foreach (var item in collection)                                                                                          
            {                                                                                                                         
                _dbContext.Set<TEntity>().Add(item);                                                                                  
            }                                                                                                                         
        }                                                                                                                             
                                                                                                                                      
        public void Update(TEntity entity)                                                                                            
        {                                                                                                                             
            _dbContext.Entry(entity).State = EntityState.Modified;                                                                    
        }                                                                                                                             
                                                                                                                                      
        public void Delete(Expression<Func<TEntity, bool>> predicate)                                                                 
        {                                                                                                                             
            _dbContext.Set<TEntity>()                                                                                                 
           .Where(predicate).ToList()                                                                                                 
           .ForEach(del => _dbContext.Set<TEntity>().Remove(del));                                                                    
        }                                                                                                                             
                                                                                                                                      
        /// <summary>                                                                                                                 
        /// Método inicial principal que é iniciado mediante as configuracoes, isso deixa o entity framework mais rapido ou mais lento
        /// Se "_preConfig" false nao entra aqui e continua com as configuracoes padrao do entity framework.                        
        /// </summary>                                                                                                                
        internal void InitializePreConfiguration(MetrocareContext dbContext)                                                       
        {                                                                                                                             
            this._dbSet = dbContext.Set<TEntity>();                                                                                   
            this._dbContext = dbContext;                                                                                              
                                                                                                                                      
            if (_preConfig)                                                                                                           
            {                                                                                                                         
                this._dbContext.Configuration.AutoDetectChangesEnabled = false;  // Atencão ao modificar!                             
                this._dbContext.Configuration.LazyLoadingEnabled = true;         // Atencão ao modificar!                             
                this._dbContext.Configuration.ProxyCreationEnabled = false;      // Atencão ao modificar!                             
                this._dbContext.Configuration.ValidateOnSaveEnabled = true;      // Atencão ao modificar!                             
                this._dbContext.Configuration.UseDatabaseNullSemantics = true;   // Atencão ao modificar!                             
            }                                                                                                                         
        }                                                                                                                             
                                                                                                                                      
        public void Dispose()                                                                                                         
        {                                                                                                                             
            if (_dbContext != null)                                                                                                   
            {                                                                                                                         
                _dbContext.Dispose();                                                                                                 
            }                                                                                                                         
            GC.SuppressFinalize(this);                                                                                                
        }                                                                                                                             
    }                                                                                                                                 
}                                                                                                                                     

