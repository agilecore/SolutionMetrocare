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
    public class LogContrato
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogContrato()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogContratoDto model)
        {
            _unitOfWork.GetRepository<LogContratoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogContratoDto SaveGetItem(LogContratoDto model)
        {
           _unitOfWork.GetRepository<LogContratoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogContratoDto> model)
        {
            _unitOfWork.GetRepository<LogContratoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogContratoDto model)
        {
            _unitOfWork.GetRepository<LogContratoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogContratoDto GetItem(Expression<Func<LogContratoDto, bool>> filter)
        {
            LogContratoDto model;
            model = _unitOfWork.GetRepository<LogContratoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogContratoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogContratoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogContratoDto> GetByFilters(Expression<Func<LogContratoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogContratoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogContratoDto> GetByFilterAsQueryable(Expression<Func<LogContratoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogContratoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogContratoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogContratoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogContratoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

