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
    public class PlanoInativacao
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public PlanoInativacao()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(PlanoInativacaoDto model)
        {
            _unitOfWork.GetRepository<PlanoInativacaoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual PlanoInativacaoDto SaveGetItem(PlanoInativacaoDto model)
        {
           _unitOfWork.GetRepository<PlanoInativacaoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<PlanoInativacaoDto> model)
        {
            _unitOfWork.GetRepository<PlanoInativacaoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(PlanoInativacaoDto model)
        {
            _unitOfWork.GetRepository<PlanoInativacaoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual PlanoInativacaoDto GetItem(Expression<Func<PlanoInativacaoDto, bool>> filter)
        {
            PlanoInativacaoDto model;
            model = _unitOfWork.GetRepository<PlanoInativacaoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<PlanoInativacaoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<PlanoInativacaoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<PlanoInativacaoDto> GetByFilters(Expression<Func<PlanoInativacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PlanoInativacaoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PlanoInativacaoDto> GetByFilterAsQueryable(Expression<Func<PlanoInativacaoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PlanoInativacaoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<PlanoInativacaoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PlanoInativacaoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<PlanoInativacaoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}
