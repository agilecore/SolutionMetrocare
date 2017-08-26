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
    public class LogAcesso
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogAcesso()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogAcessoDto model)
        {
            _unitOfWork.GetRepository<LogAcessoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogAcessoDto SaveGetItem(LogAcessoDto model)
        {
           _unitOfWork.GetRepository<LogAcessoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogAcessoDto> model)
        {
            _unitOfWork.GetRepository<LogAcessoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogAcessoDto model)
        {
            _unitOfWork.GetRepository<LogAcessoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogAcessoDto GetItem(Expression<Func<LogAcessoDto, bool>> filter)
        {
            LogAcessoDto model;
            model = _unitOfWork.GetRepository<LogAcessoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogAcessoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogAcessoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogAcessoDto> GetByFilters(Expression<Func<LogAcessoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogAcessoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogAcessoDto> GetByFilterAsQueryable(Expression<Func<LogAcessoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogAcessoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogAcessoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogAcessoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogAcessoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

