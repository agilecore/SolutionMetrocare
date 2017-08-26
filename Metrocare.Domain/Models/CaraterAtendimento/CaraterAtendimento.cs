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
    public class CaraterAtendimento
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public CaraterAtendimento()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(CaraterAtendimentoDto model)
        {
            _unitOfWork.GetRepository<CaraterAtendimentoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual CaraterAtendimentoDto SaveGetItem(CaraterAtendimentoDto model)
        {
           _unitOfWork.GetRepository<CaraterAtendimentoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<CaraterAtendimentoDto> model)
        {
            _unitOfWork.GetRepository<CaraterAtendimentoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(CaraterAtendimentoDto model)
        {
            _unitOfWork.GetRepository<CaraterAtendimentoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual CaraterAtendimentoDto GetItem(Expression<Func<CaraterAtendimentoDto, bool>> filter)
        {
            CaraterAtendimentoDto model;
            model = _unitOfWork.GetRepository<CaraterAtendimentoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<CaraterAtendimentoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<CaraterAtendimentoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<CaraterAtendimentoDto> GetByFilters(Expression<Func<CaraterAtendimentoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CaraterAtendimentoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CaraterAtendimentoDto> GetByFilterAsQueryable(Expression<Func<CaraterAtendimentoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CaraterAtendimentoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<CaraterAtendimentoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CaraterAtendimentoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<CaraterAtendimentoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

