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
    public class LogBeneficiario
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public LogBeneficiario()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(LogBeneficiarioDto model)
        {
            _unitOfWork.GetRepository<LogBeneficiarioDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual LogBeneficiarioDto SaveGetItem(LogBeneficiarioDto model)
        {
           _unitOfWork.GetRepository<LogBeneficiarioDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<LogBeneficiarioDto> model)
        {
            _unitOfWork.GetRepository<LogBeneficiarioDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(LogBeneficiarioDto model)
        {
            _unitOfWork.GetRepository<LogBeneficiarioDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual LogBeneficiarioDto GetItem(Expression<Func<LogBeneficiarioDto, bool>> filter)
        {
            LogBeneficiarioDto model;
            model = _unitOfWork.GetRepository<LogBeneficiarioDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<LogBeneficiarioDto, bool>> filter)
        {
             _unitOfWork.GetRepository<LogBeneficiarioDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<LogBeneficiarioDto> GetByFilters(Expression<Func<LogBeneficiarioDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogBeneficiarioDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogBeneficiarioDto> GetByFilterAsQueryable(Expression<Func<LogBeneficiarioDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<LogBeneficiarioDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<LogBeneficiarioDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<LogBeneficiarioDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<LogBeneficiarioDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

