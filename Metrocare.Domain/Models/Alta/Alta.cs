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
    public class Alta
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Alta()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(AltaDto model)
        {
            _unitOfWork.GetRepository<AltaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual AltaDto SaveGetItem(AltaDto model)
        {
           _unitOfWork.GetRepository<AltaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<AltaDto> model)
        {
            _unitOfWork.GetRepository<AltaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(AltaDto model)
        {
            _unitOfWork.GetRepository<AltaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual AltaDto GetItem(Expression<Func<AltaDto, bool>> filter)
        {
            AltaDto model;
            model = _unitOfWork.GetRepository<AltaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<AltaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<AltaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<AltaDto> GetByFilters(Expression<Func<AltaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<AltaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<AltaDto> GetByFilterAsQueryable(Expression<Func<AltaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<AltaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<AltaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<AltaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<AltaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

