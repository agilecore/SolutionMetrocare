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
    public class TipoAtendimento
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public TipoAtendimento()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(TipoAtendimentoDto model)
        {
            _unitOfWork.GetRepository<TipoAtendimentoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual TipoAtendimentoDto SaveGetItem(TipoAtendimentoDto model)
        {
           _unitOfWork.GetRepository<TipoAtendimentoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<TipoAtendimentoDto> model)
        {
            _unitOfWork.GetRepository<TipoAtendimentoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(TipoAtendimentoDto model)
        {
            _unitOfWork.GetRepository<TipoAtendimentoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual TipoAtendimentoDto GetItem(Expression<Func<TipoAtendimentoDto, bool>> filter)
        {
            TipoAtendimentoDto model;
            model = _unitOfWork.GetRepository<TipoAtendimentoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<TipoAtendimentoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<TipoAtendimentoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<TipoAtendimentoDto> GetByFilters(Expression<Func<TipoAtendimentoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoAtendimentoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoAtendimentoDto> GetByFilterAsQueryable(Expression<Func<TipoAtendimentoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<TipoAtendimentoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<TipoAtendimentoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<TipoAtendimentoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<TipoAtendimentoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

