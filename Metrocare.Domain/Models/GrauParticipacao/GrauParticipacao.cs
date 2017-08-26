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
    public class GrauParticipacao
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public GrauParticipacao()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(GrauParticipacaoDto model)
        {
            _unitOfWork.GetRepository<GrauParticipacaoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual GrauParticipacaoDto SaveGetItem(GrauParticipacaoDto model)
        {
           _unitOfWork.GetRepository<GrauParticipacaoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<GrauParticipacaoDto> model)
        {
            _unitOfWork.GetRepository<GrauParticipacaoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(GrauParticipacaoDto model)
        {
            _unitOfWork.GetRepository<GrauParticipacaoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual GrauParticipacaoDto GetItem(Expression<Func<GrauParticipacaoDto, bool>> filter)
        {
            GrauParticipacaoDto model;
            model = _unitOfWork.GetRepository<GrauParticipacaoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<GrauParticipacaoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<GrauParticipacaoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<GrauParticipacaoDto> GetByFilters(Expression<Func<GrauParticipacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<GrauParticipacaoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<GrauParticipacaoDto> GetByFilterAsQueryable(Expression<Func<GrauParticipacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<GrauParticipacaoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<GrauParticipacaoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<GrauParticipacaoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<GrauParticipacaoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

