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
    public class LogCredenciado
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogCredenciado()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogCredenciadoDto model)
        {
            _unitOfWork.GetRepository<LogCredenciadoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogCredenciadoDto SaveGetItem(LogCredenciadoDto model)
        {
           _unitOfWork.GetRepository<LogCredenciadoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogCredenciadoDto> model)
        {
            _unitOfWork.GetRepository<LogCredenciadoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogCredenciadoDto model)
        {
            _unitOfWork.GetRepository<LogCredenciadoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogCredenciadoDto GetItem(Expression<Func<LogCredenciadoDto, bool>> filter)
        {
            LogCredenciadoDto model;
            model = _unitOfWork.GetRepository<LogCredenciadoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogCredenciadoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogCredenciadoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogCredenciadoDto> GetByFilters(Expression<Func<LogCredenciadoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogCredenciadoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogCredenciadoDto> GetByFilterAsQueryable(Expression<Func<LogCredenciadoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogCredenciadoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogCredenciadoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogCredenciadoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogCredenciadoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

