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
    public class LogDependente
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogDependente()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogDependenteDto model)
        {
            _unitOfWork.GetRepository<LogDependenteDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogDependenteDto SaveGetItem(LogDependenteDto model)
        {
           _unitOfWork.GetRepository<LogDependenteDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogDependenteDto> model)
        {
            _unitOfWork.GetRepository<LogDependenteDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogDependenteDto model)
        {
            _unitOfWork.GetRepository<LogDependenteDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogDependenteDto GetItem(Expression<Func<LogDependenteDto, bool>> filter)
        {
            LogDependenteDto model;
            model = _unitOfWork.GetRepository<LogDependenteDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogDependenteDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogDependenteDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogDependenteDto> GetByFilters(Expression<Func<LogDependenteDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogDependenteDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogDependenteDto> GetByFilterAsQueryable(Expression<Func<LogDependenteDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogDependenteDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogDependenteDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogDependenteDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogDependenteDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

