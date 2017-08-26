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
    public class TipoInternacao
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TipoInternacao()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TipoInternacaoDto model)
        {
            _unitOfWork.GetRepository<TipoInternacaoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TipoInternacaoDto SaveGetItem(TipoInternacaoDto model)
        {
           _unitOfWork.GetRepository<TipoInternacaoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TipoInternacaoDto> model)
        {
            _unitOfWork.GetRepository<TipoInternacaoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TipoInternacaoDto model)
        {
            _unitOfWork.GetRepository<TipoInternacaoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TipoInternacaoDto GetItem(Expression<Func<TipoInternacaoDto, bool>> filter)
        {
            TipoInternacaoDto model;
            model = _unitOfWork.GetRepository<TipoInternacaoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TipoInternacaoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TipoInternacaoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TipoInternacaoDto> GetByFilters(Expression<Func<TipoInternacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoInternacaoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoInternacaoDto> GetByFilterAsQueryable(Expression<Func<TipoInternacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoInternacaoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TipoInternacaoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoInternacaoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TipoInternacaoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

