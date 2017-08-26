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
    public class Contrato
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Contrato()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(ContratoDto model)
        {
            _unitOfWork.GetRepository<ContratoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual ContratoDto SaveGetItem(ContratoDto model)
        {
           _unitOfWork.GetRepository<ContratoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<ContratoDto> model)
        {
            _unitOfWork.GetRepository<ContratoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(ContratoDto model)
        {
            _unitOfWork.GetRepository<ContratoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual ContratoDto GetItem(Expression<Func<ContratoDto, bool>> filter)
        {
            ContratoDto model;
            model = _unitOfWork.GetRepository<ContratoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<ContratoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<ContratoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<ContratoDto> GetByFilters(Expression<Func<ContratoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<ContratoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<ContratoDto> GetByFilterAsQueryable(Expression<Func<ContratoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<ContratoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<ContratoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<ContratoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<ContratoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

