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
    public class GrauParentesco
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public GrauParentesco()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(GrauParentescoDto model)
        {
            _unitOfWork.GetRepository<GrauParentescoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual GrauParentescoDto SaveGetItem(GrauParentescoDto model)
        {
           _unitOfWork.GetRepository<GrauParentescoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<GrauParentescoDto> model)
        {
            _unitOfWork.GetRepository<GrauParentescoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(GrauParentescoDto model)
        {
            _unitOfWork.GetRepository<GrauParentescoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual GrauParentescoDto GetItem(Expression<Func<GrauParentescoDto, bool>> filter)
        {
            GrauParentescoDto model;
            model = _unitOfWork.GetRepository<GrauParentescoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<GrauParentescoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<GrauParentescoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<GrauParentescoDto> GetByFilters(Expression<Func<GrauParentescoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<GrauParentescoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<GrauParentescoDto> GetByFilterAsQueryable(Expression<Func<GrauParentescoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<GrauParentescoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<GrauParentescoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<GrauParentescoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<GrauParentescoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

