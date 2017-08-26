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
    public class Dependente
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Dependente()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(DependenteDto model)
        {
            _unitOfWork.GetRepository<DependenteDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual DependenteDto SaveGetItem(DependenteDto model)
        {
           _unitOfWork.GetRepository<DependenteDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<DependenteDto> model)
        {
            _unitOfWork.GetRepository<DependenteDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(DependenteDto model)
        {
            _unitOfWork.GetRepository<DependenteDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual DependenteDto GetItem(Expression<Func<DependenteDto, bool>> filter)
        {
            DependenteDto model;
            model = _unitOfWork.GetRepository<DependenteDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<DependenteDto, bool>> filter)
        {
             _unitOfWork.GetRepository<DependenteDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<DependenteDto> GetByFilters(Expression<Func<DependenteDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<DependenteDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<DependenteDto> GetByFilterAsQueryable(Expression<Func<DependenteDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<DependenteDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<DependenteDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<DependenteDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<DependenteDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

