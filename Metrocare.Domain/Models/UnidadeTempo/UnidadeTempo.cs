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
    public class UnidadeTempo
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public UnidadeTempo()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(UnidadeTempoDto model)
        {
            _unitOfWork.GetRepository<UnidadeTempoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual UnidadeTempoDto SaveGetItem(UnidadeTempoDto model)
        {
           _unitOfWork.GetRepository<UnidadeTempoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<UnidadeTempoDto> model)
        {
            _unitOfWork.GetRepository<UnidadeTempoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(UnidadeTempoDto model)
        {
            _unitOfWork.GetRepository<UnidadeTempoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual UnidadeTempoDto GetItem(Expression<Func<UnidadeTempoDto, bool>> filter)
        {
            UnidadeTempoDto model;
            model = _unitOfWork.GetRepository<UnidadeTempoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<UnidadeTempoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<UnidadeTempoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<UnidadeTempoDto> GetByFilters(Expression<Func<UnidadeTempoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<UnidadeTempoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<UnidadeTempoDto> GetByFilterAsQueryable(Expression<Func<UnidadeTempoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<UnidadeTempoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<UnidadeTempoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<UnidadeTempoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<UnidadeTempoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

