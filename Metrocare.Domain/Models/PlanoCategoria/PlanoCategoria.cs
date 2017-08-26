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
    public class PlanoCategoria
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public PlanoCategoria()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(PlanoCategoriaDto model)
        {
            _unitOfWork.GetRepository<PlanoCategoriaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual PlanoCategoriaDto SaveGetItem(PlanoCategoriaDto model)
        {
           _unitOfWork.GetRepository<PlanoCategoriaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<PlanoCategoriaDto> model)
        {
            _unitOfWork.GetRepository<PlanoCategoriaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(PlanoCategoriaDto model)
        {
            _unitOfWork.GetRepository<PlanoCategoriaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual PlanoCategoriaDto GetItem(Expression<Func<PlanoCategoriaDto, bool>> filter)
        {
            PlanoCategoriaDto model;
            model = _unitOfWork.GetRepository<PlanoCategoriaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<PlanoCategoriaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<PlanoCategoriaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<PlanoCategoriaDto> GetByFilters(Expression<Func<PlanoCategoriaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PlanoCategoriaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PlanoCategoriaDto> GetByFilterAsQueryable(Expression<Func<PlanoCategoriaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PlanoCategoriaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<PlanoCategoriaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PlanoCategoriaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<PlanoCategoriaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

