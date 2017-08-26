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
    public class LogPrestador
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogPrestador()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogPrestadorDto model)
        {
            _unitOfWork.GetRepository<LogPrestadorDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogPrestadorDto SaveGetItem(LogPrestadorDto model)
        {
           _unitOfWork.GetRepository<LogPrestadorDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogPrestadorDto> model)
        {
            _unitOfWork.GetRepository<LogPrestadorDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogPrestadorDto model)
        {
            _unitOfWork.GetRepository<LogPrestadorDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogPrestadorDto GetItem(Expression<Func<LogPrestadorDto, bool>> filter)
        {
            LogPrestadorDto model;
            model = _unitOfWork.GetRepository<LogPrestadorDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogPrestadorDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogPrestadorDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogPrestadorDto> GetByFilters(Expression<Func<LogPrestadorDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogPrestadorDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogPrestadorDto> GetByFilterAsQueryable(Expression<Func<LogPrestadorDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogPrestadorDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogPrestadorDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogPrestadorDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogPrestadorDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

