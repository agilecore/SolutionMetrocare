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
    public class ConcelhoProfissional
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public ConcelhoProfissional()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(ConcelhoProfissionalDto model)
        {
            _unitOfWork.GetRepository<ConcelhoProfissionalDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual ConcelhoProfissionalDto SaveGetItem(ConcelhoProfissionalDto model)
        {
           _unitOfWork.GetRepository<ConcelhoProfissionalDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<ConcelhoProfissionalDto> model)
        {
            _unitOfWork.GetRepository<ConcelhoProfissionalDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(ConcelhoProfissionalDto model)
        {
            _unitOfWork.GetRepository<ConcelhoProfissionalDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual ConcelhoProfissionalDto GetItem(Expression<Func<ConcelhoProfissionalDto, bool>> filter)
        {
            ConcelhoProfissionalDto model;
            model = _unitOfWork.GetRepository<ConcelhoProfissionalDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<ConcelhoProfissionalDto, bool>> filter)
        {
             _unitOfWork.GetRepository<ConcelhoProfissionalDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<ConcelhoProfissionalDto> GetByFilters(Expression<Func<ConcelhoProfissionalDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<ConcelhoProfissionalDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<ConcelhoProfissionalDto> GetByFilterAsQueryable(Expression<Func<ConcelhoProfissionalDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<ConcelhoProfissionalDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<ConcelhoProfissionalDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<ConcelhoProfissionalDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<ConcelhoProfissionalDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

