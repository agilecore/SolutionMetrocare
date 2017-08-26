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
    public class Dia
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Dia()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(DiaDto model)
        {
            _unitOfWork.GetRepository<DiaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual DiaDto SaveGetItem(DiaDto model)
        {
           _unitOfWork.GetRepository<DiaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<DiaDto> model)
        {
            _unitOfWork.GetRepository<DiaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(DiaDto model)
        {
            _unitOfWork.GetRepository<DiaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual DiaDto GetItem(Expression<Func<DiaDto, bool>> filter)
        {
            DiaDto model;
            model = _unitOfWork.GetRepository<DiaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<DiaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<DiaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<DiaDto> GetByFilters(Expression<Func<DiaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<DiaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<DiaDto> GetByFilterAsQueryable(Expression<Func<DiaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<DiaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<DiaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<DiaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<DiaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

