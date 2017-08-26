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
    public class TipoDoenca
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TipoDoenca()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TipoDoencaDto model)
        {
            _unitOfWork.GetRepository<TipoDoencaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TipoDoencaDto SaveGetItem(TipoDoencaDto model)
        {
           _unitOfWork.GetRepository<TipoDoencaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TipoDoencaDto> model)
        {
            _unitOfWork.GetRepository<TipoDoencaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TipoDoencaDto model)
        {
            _unitOfWork.GetRepository<TipoDoencaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TipoDoencaDto GetItem(Expression<Func<TipoDoencaDto, bool>> filter)
        {
            TipoDoencaDto model;
            model = _unitOfWork.GetRepository<TipoDoencaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TipoDoencaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TipoDoencaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TipoDoencaDto> GetByFilters(Expression<Func<TipoDoencaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoDoencaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoDoencaDto> GetByFilterAsQueryable(Expression<Func<TipoDoencaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoDoencaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TipoDoencaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoDoencaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TipoDoencaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

