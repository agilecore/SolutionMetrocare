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
    public class Cbo
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Cbo()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(CboDto model)
        {
            _unitOfWork.GetRepository<CboDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual CboDto SaveGetItem(CboDto model)
        {
           _unitOfWork.GetRepository<CboDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<CboDto> model)
        {
            _unitOfWork.GetRepository<CboDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(CboDto model)
        {
            _unitOfWork.GetRepository<CboDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual CboDto GetItem(Expression<Func<CboDto, bool>> filter)
        {
            CboDto model;
            model = _unitOfWork.GetRepository<CboDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<CboDto, bool>> filter)
        {
             _unitOfWork.GetRepository<CboDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<CboDto> GetByFilters(Expression<Func<CboDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CboDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CboDto> GetByFilterAsQueryable(Expression<Func<CboDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CboDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<CboDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CboDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<CboDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

