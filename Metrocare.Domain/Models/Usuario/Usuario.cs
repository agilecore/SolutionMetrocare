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
    public class Usuario
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Usuario()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(UsuarioDto model)
        {
            _unitOfWork.GetRepository<UsuarioDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual UsuarioDto SaveGetItem(UsuarioDto model)
        {
           _unitOfWork.GetRepository<UsuarioDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<UsuarioDto> model)
        {
            _unitOfWork.GetRepository<UsuarioDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(UsuarioDto model)
        {
            _unitOfWork.GetRepository<UsuarioDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual UsuarioDto GetItem(Expression<Func<UsuarioDto, bool>> filter)
        {
            UsuarioDto model;
            model = _unitOfWork.GetRepository<UsuarioDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<UsuarioDto, bool>> filter)
        {
             _unitOfWork.GetRepository<UsuarioDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<UsuarioDto> GetByFilters(Expression<Func<UsuarioDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<UsuarioDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<UsuarioDto> GetByFilterAsQueryable(Expression<Func<UsuarioDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<UsuarioDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<UsuarioDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<UsuarioDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<UsuarioDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

