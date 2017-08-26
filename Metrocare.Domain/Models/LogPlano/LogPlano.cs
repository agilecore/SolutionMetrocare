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
    public class LogPlano
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogPlano()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogPlanoDto model)
        {
            _unitOfWork.GetRepository<LogPlanoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogPlanoDto SaveGetItem(LogPlanoDto model)
        {
           _unitOfWork.GetRepository<LogPlanoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogPlanoDto> model)
        {
            _unitOfWork.GetRepository<LogPlanoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogPlanoDto model)
        {
            _unitOfWork.GetRepository<LogPlanoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogPlanoDto GetItem(Expression<Func<LogPlanoDto, bool>> filter)
        {
            LogPlanoDto model;
            model = _unitOfWork.GetRepository<LogPlanoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogPlanoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogPlanoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogPlanoDto> GetByFilters(Expression<Func<LogPlanoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogPlanoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogPlanoDto> GetByFilterAsQueryable(Expression<Func<LogPlanoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogPlanoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogPlanoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogPlanoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogPlanoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

