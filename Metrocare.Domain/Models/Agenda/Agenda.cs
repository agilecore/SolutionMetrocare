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
    public class Agenda
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Agenda()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(AgendaDto model)
        {
            _unitOfWork.GetRepository<AgendaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual AgendaDto SaveGetItem(AgendaDto model)
        {
           _unitOfWork.GetRepository<AgendaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<AgendaDto> model)
        {
            _unitOfWork.GetRepository<AgendaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(AgendaDto model)
        {
            _unitOfWork.GetRepository<AgendaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual AgendaDto GetItem(Expression<Func<AgendaDto, bool>> filter)
        {
            AgendaDto model;
            model = _unitOfWork.GetRepository<AgendaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<AgendaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<AgendaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<AgendaDto> GetByFilters(Expression<Func<AgendaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<AgendaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<AgendaDto> GetByFilterAsQueryable(Expression<Func<AgendaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<AgendaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<AgendaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<AgendaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<AgendaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

