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
    public class Carteira
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Carteira()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(CarteiraDto model)
        {
            _unitOfWork.GetRepository<CarteiraDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual CarteiraDto SaveGetItem(CarteiraDto model)
        {
           _unitOfWork.GetRepository<CarteiraDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<CarteiraDto> model)
        {
            _unitOfWork.GetRepository<CarteiraDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(CarteiraDto model)
        {
            _unitOfWork.GetRepository<CarteiraDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual CarteiraDto GetItem(Expression<Func<CarteiraDto, bool>> filter)
        {
            CarteiraDto model;
            model = _unitOfWork.GetRepository<CarteiraDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<CarteiraDto, bool>> filter)
        {
             _unitOfWork.GetRepository<CarteiraDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<CarteiraDto> GetByFilters(Expression<Func<CarteiraDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CarteiraDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CarteiraDto> GetByFilterAsQueryable(Expression<Func<CarteiraDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CarteiraDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<CarteiraDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CarteiraDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<CarteiraDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

