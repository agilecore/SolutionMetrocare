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
    public class IndicadorAcidente
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public IndicadorAcidente()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(IndicadorAcidenteDto model)
        {
            _unitOfWork.GetRepository<IndicadorAcidenteDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual IndicadorAcidenteDto SaveGetItem(IndicadorAcidenteDto model)
        {
           _unitOfWork.GetRepository<IndicadorAcidenteDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<IndicadorAcidenteDto> model)
        {
            _unitOfWork.GetRepository<IndicadorAcidenteDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(IndicadorAcidenteDto model)
        {
            _unitOfWork.GetRepository<IndicadorAcidenteDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual IndicadorAcidenteDto GetItem(Expression<Func<IndicadorAcidenteDto, bool>> filter)
        {
            IndicadorAcidenteDto model;
            model = _unitOfWork.GetRepository<IndicadorAcidenteDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<IndicadorAcidenteDto, bool>> filter)
        {
             _unitOfWork.GetRepository<IndicadorAcidenteDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<IndicadorAcidenteDto> GetByFilters(Expression<Func<IndicadorAcidenteDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<IndicadorAcidenteDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<IndicadorAcidenteDto> GetByFilterAsQueryable(Expression<Func<IndicadorAcidenteDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<IndicadorAcidenteDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<IndicadorAcidenteDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<IndicadorAcidenteDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<IndicadorAcidenteDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

