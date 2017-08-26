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
    public class Atendimento
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Atendimento()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(AtendimentoDto model)
        {
            _unitOfWork.GetRepository<AtendimentoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual AtendimentoDto SaveGetItem(AtendimentoDto model)
        {
           _unitOfWork.GetRepository<AtendimentoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<AtendimentoDto> model)
        {
            _unitOfWork.GetRepository<AtendimentoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(AtendimentoDto model)
        {
            _unitOfWork.GetRepository<AtendimentoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual AtendimentoDto GetItem(Expression<Func<AtendimentoDto, bool>> filter)
        {
            AtendimentoDto model;
            model = _unitOfWork.GetRepository<AtendimentoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<AtendimentoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<AtendimentoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<AtendimentoDto> GetByFilters(Expression<Func<AtendimentoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<AtendimentoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<AtendimentoDto> GetByFilterAsQueryable(Expression<Func<AtendimentoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<AtendimentoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<AtendimentoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<AtendimentoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<AtendimentoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

