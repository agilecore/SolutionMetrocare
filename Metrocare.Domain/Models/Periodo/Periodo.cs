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
    public class Periodo
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Periodo()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(PeriodoDto model)
        {
            _unitOfWork.GetRepository<PeriodoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual PeriodoDto SaveGetItem(PeriodoDto model)
        {
           _unitOfWork.GetRepository<PeriodoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<PeriodoDto> model)
        {
            _unitOfWork.GetRepository<PeriodoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(PeriodoDto model)
        {
            _unitOfWork.GetRepository<PeriodoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual PeriodoDto GetItem(Expression<Func<PeriodoDto, bool>> filter)
        {
            PeriodoDto model;
            model = _unitOfWork.GetRepository<PeriodoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<PeriodoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<PeriodoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<PeriodoDto> GetByFilters(Expression<Func<PeriodoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PeriodoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PeriodoDto> GetByFilterAsQueryable(Expression<Func<PeriodoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PeriodoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<PeriodoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PeriodoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<PeriodoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

