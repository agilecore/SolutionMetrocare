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
    public class TempoDoenca
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TempoDoenca()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TempoDoencaDto model)
        {
            _unitOfWork.GetRepository<TempoDoencaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TempoDoencaDto SaveGetItem(TempoDoencaDto model)
        {
           _unitOfWork.GetRepository<TempoDoencaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TempoDoencaDto> model)
        {
            _unitOfWork.GetRepository<TempoDoencaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TempoDoencaDto model)
        {
            _unitOfWork.GetRepository<TempoDoencaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TempoDoencaDto GetItem(Expression<Func<TempoDoencaDto, bool>> filter)
        {
            TempoDoencaDto model;
            model = _unitOfWork.GetRepository<TempoDoencaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TempoDoencaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TempoDoencaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TempoDoencaDto> GetByFilters(Expression<Func<TempoDoencaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TempoDoencaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TempoDoencaDto> GetByFilterAsQueryable(Expression<Func<TempoDoencaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TempoDoencaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TempoDoencaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TempoDoencaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TempoDoencaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

