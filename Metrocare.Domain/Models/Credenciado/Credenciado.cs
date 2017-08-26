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
    public class Credenciado
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Credenciado()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(CredenciadoDto model)
        {
            _unitOfWork.GetRepository<CredenciadoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual CredenciadoDto SaveGetItem(CredenciadoDto model)
        {
           _unitOfWork.GetRepository<CredenciadoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<CredenciadoDto> model)
        {
            _unitOfWork.GetRepository<CredenciadoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(CredenciadoDto model)
        {
            _unitOfWork.GetRepository<CredenciadoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual CredenciadoDto GetItem(Expression<Func<CredenciadoDto, bool>> filter)
        {
            CredenciadoDto model;
            model = _unitOfWork.GetRepository<CredenciadoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<CredenciadoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<CredenciadoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<CredenciadoDto> GetByFilters(Expression<Func<CredenciadoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CredenciadoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CredenciadoDto> GetByFilterAsQueryable(Expression<Func<CredenciadoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CredenciadoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<CredenciadoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CredenciadoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<CredenciadoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

