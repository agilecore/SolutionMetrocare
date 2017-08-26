using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Metrocare.Data;
using Metrocare.Common;

/// <summary>
/// Esta classe contem metodos de negocios (domain) principais, prontos para uso em controllers, porem se esse objeto
/// necessita de um metodo customizado (particular), fazer a implementacao na classe Specialized, e nao aqui.
/// </summary>
namespace Metrocare.Domain
{
    public class TabelaProced
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TabelaProced()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TabelaProcedDto model)
        {
            _unitOfWork.GetRepository<TabelaProcedDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TabelaProcedDto SaveGetItem(TabelaProcedDto model)
        {
           _unitOfWork.GetRepository<TabelaProcedDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TabelaProcedDto> model)
        {
            _unitOfWork.GetRepository<TabelaProcedDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TabelaProcedDto model)
        {
            _unitOfWork.GetRepository<TabelaProcedDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TabelaProcedDto GetItem(Expression<Func<TabelaProcedDto, bool>> filter)
        {
            TabelaProcedDto model;
            model = _unitOfWork.GetRepository<TabelaProcedDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TabelaProcedDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TabelaProcedDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TabelaProcedDto> GetByFilters(Expression<Func<TabelaProcedDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TabelaProcedDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TabelaProcedDto> GetByFilterAsQueryable(Expression<Func<TabelaProcedDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TabelaProcedDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TabelaProcedDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TabelaProcedDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TabelaProcedDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

