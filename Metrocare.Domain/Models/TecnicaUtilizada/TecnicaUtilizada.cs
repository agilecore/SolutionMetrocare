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
    public class TecnicaUtilizada
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TecnicaUtilizada()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TecnicaUtilizadaDto model)
        {
            _unitOfWork.GetRepository<TecnicaUtilizadaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TecnicaUtilizadaDto SaveGetItem(TecnicaUtilizadaDto model)
        {
           _unitOfWork.GetRepository<TecnicaUtilizadaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TecnicaUtilizadaDto> model)
        {
            _unitOfWork.GetRepository<TecnicaUtilizadaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TecnicaUtilizadaDto model)
        {
            _unitOfWork.GetRepository<TecnicaUtilizadaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TecnicaUtilizadaDto GetItem(Expression<Func<TecnicaUtilizadaDto, bool>> filter)
        {
            TecnicaUtilizadaDto model;
            model = _unitOfWork.GetRepository<TecnicaUtilizadaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TecnicaUtilizadaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TecnicaUtilizadaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TecnicaUtilizadaDto> GetByFilters(Expression<Func<TecnicaUtilizadaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TecnicaUtilizadaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TecnicaUtilizadaDto> GetByFilterAsQueryable(Expression<Func<TecnicaUtilizadaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TecnicaUtilizadaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TecnicaUtilizadaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TecnicaUtilizadaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TecnicaUtilizadaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

