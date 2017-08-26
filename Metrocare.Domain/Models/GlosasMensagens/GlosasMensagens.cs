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
    public class GlosasMensagens
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public GlosasMensagens()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(GlosasMensagensDto model)
        {
            _unitOfWork.GetRepository<GlosasMensagensDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual GlosasMensagensDto SaveGetItem(GlosasMensagensDto model)
        {
           _unitOfWork.GetRepository<GlosasMensagensDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<GlosasMensagensDto> model)
        {
            _unitOfWork.GetRepository<GlosasMensagensDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(GlosasMensagensDto model)
        {
            _unitOfWork.GetRepository<GlosasMensagensDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual GlosasMensagensDto GetItem(Expression<Func<GlosasMensagensDto, bool>> filter)
        {
            GlosasMensagensDto model;
            model = _unitOfWork.GetRepository<GlosasMensagensDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<GlosasMensagensDto, bool>> filter)
        {
             _unitOfWork.GetRepository<GlosasMensagensDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<GlosasMensagensDto> GetByFilters(Expression<Func<GlosasMensagensDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<GlosasMensagensDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<GlosasMensagensDto> GetByFilterAsQueryable(Expression<Func<GlosasMensagensDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<GlosasMensagensDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<GlosasMensagensDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<GlosasMensagensDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<GlosasMensagensDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

