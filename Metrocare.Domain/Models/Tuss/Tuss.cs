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
    public class Tuss
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Tuss()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TussDto model)
        {
            _unitOfWork.GetRepository<TussDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TussDto SaveGetItem(TussDto model)
        {
           _unitOfWork.GetRepository<TussDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TussDto> model)
        {
            _unitOfWork.GetRepository<TussDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TussDto model)
        {
            _unitOfWork.GetRepository<TussDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TussDto GetItem(Expression<Func<TussDto, bool>> filter)
        {
            TussDto model;
            model = _unitOfWork.GetRepository<TussDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TussDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TussDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TussDto> GetByFilters(Expression<Func<TussDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TussDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TussDto> GetByFilterAsQueryable(Expression<Func<TussDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TussDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TussDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TussDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TussDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

