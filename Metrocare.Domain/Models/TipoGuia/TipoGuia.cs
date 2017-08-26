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
    public class TipoGuia
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TipoGuia()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TipoGuiaDto model)
        {
            _unitOfWork.GetRepository<TipoGuiaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TipoGuiaDto SaveGetItem(TipoGuiaDto model)
        {
           _unitOfWork.GetRepository<TipoGuiaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TipoGuiaDto> model)
        {
            _unitOfWork.GetRepository<TipoGuiaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TipoGuiaDto model)
        {
            _unitOfWork.GetRepository<TipoGuiaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TipoGuiaDto GetItem(Expression<Func<TipoGuiaDto, bool>> filter)
        {
            TipoGuiaDto model;
            model = _unitOfWork.GetRepository<TipoGuiaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TipoGuiaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TipoGuiaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TipoGuiaDto> GetByFilters(Expression<Func<TipoGuiaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoGuiaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoGuiaDto> GetByFilterAsQueryable(Expression<Func<TipoGuiaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoGuiaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TipoGuiaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoGuiaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TipoGuiaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

