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
    public class Especialidade
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Especialidade()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(EspecialidadeDto model)
        {
            _unitOfWork.GetRepository<EspecialidadeDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual EspecialidadeDto SaveGetItem(EspecialidadeDto model)
        {
           _unitOfWork.GetRepository<EspecialidadeDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<EspecialidadeDto> model)
        {
            _unitOfWork.GetRepository<EspecialidadeDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(EspecialidadeDto model)
        {
            _unitOfWork.GetRepository<EspecialidadeDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual EspecialidadeDto GetItem(Expression<Func<EspecialidadeDto, bool>> filter)
        {
            EspecialidadeDto model;
            model = _unitOfWork.GetRepository<EspecialidadeDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<EspecialidadeDto, bool>> filter)
        {
             _unitOfWork.GetRepository<EspecialidadeDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<EspecialidadeDto> GetByFilters(Expression<Func<EspecialidadeDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<EspecialidadeDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<EspecialidadeDto> GetByFilterAsQueryable(Expression<Func<EspecialidadeDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<EspecialidadeDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<EspecialidadeDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<EspecialidadeDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<EspecialidadeDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

