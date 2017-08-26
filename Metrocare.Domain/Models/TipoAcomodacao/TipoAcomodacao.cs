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
    public class TipoAcomodacao
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TipoAcomodacao()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TipoAcomodacaoDto model)
        {
            _unitOfWork.GetRepository<TipoAcomodacaoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TipoAcomodacaoDto SaveGetItem(TipoAcomodacaoDto model)
        {
           _unitOfWork.GetRepository<TipoAcomodacaoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TipoAcomodacaoDto> model)
        {
            _unitOfWork.GetRepository<TipoAcomodacaoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TipoAcomodacaoDto model)
        {
            _unitOfWork.GetRepository<TipoAcomodacaoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TipoAcomodacaoDto GetItem(Expression<Func<TipoAcomodacaoDto, bool>> filter)
        {
            TipoAcomodacaoDto model;
            model = _unitOfWork.GetRepository<TipoAcomodacaoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TipoAcomodacaoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TipoAcomodacaoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TipoAcomodacaoDto> GetByFilters(Expression<Func<TipoAcomodacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoAcomodacaoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoAcomodacaoDto> GetByFilterAsQueryable(Expression<Func<TipoAcomodacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoAcomodacaoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TipoAcomodacaoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoAcomodacaoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TipoAcomodacaoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

