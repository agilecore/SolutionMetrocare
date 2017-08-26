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
    public class Prestador
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Prestador()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(PrestadorDto model)
        {
            _unitOfWork.GetRepository<PrestadorDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual PrestadorDto SaveGetItem(PrestadorDto model)
        {
           _unitOfWork.GetRepository<PrestadorDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<PrestadorDto> model)
        {
            _unitOfWork.GetRepository<PrestadorDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(PrestadorDto model)
        {
            _unitOfWork.GetRepository<PrestadorDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual PrestadorDto GetItem(Expression<Func<PrestadorDto, bool>> filter)
        {
            PrestadorDto model;
            model = _unitOfWork.GetRepository<PrestadorDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<PrestadorDto, bool>> filter)
        {
             _unitOfWork.GetRepository<PrestadorDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<PrestadorDto> GetByFilters(Expression<Func<PrestadorDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PrestadorDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PrestadorDto> GetByFilterAsQueryable(Expression<Func<PrestadorDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PrestadorDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<PrestadorDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PrestadorDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<PrestadorDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

