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
    public class CredenciadoEndereco
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public CredenciadoEndereco()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(CredenciadoEnderecoDto model)
        {
            _unitOfWork.GetRepository<CredenciadoEnderecoDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual CredenciadoEnderecoDto SaveGetItem(CredenciadoEnderecoDto model)
        {
           _unitOfWork.GetRepository<CredenciadoEnderecoDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<CredenciadoEnderecoDto> model)
        {
            _unitOfWork.GetRepository<CredenciadoEnderecoDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(CredenciadoEnderecoDto model)
        {
            _unitOfWork.GetRepository<CredenciadoEnderecoDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual CredenciadoEnderecoDto GetItem(Expression<Func<CredenciadoEnderecoDto, bool>> filter)
        {
            CredenciadoEnderecoDto model;
            model = _unitOfWork.GetRepository<CredenciadoEnderecoDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<CredenciadoEnderecoDto, bool>> filter)
        {
             _unitOfWork.GetRepository<CredenciadoEnderecoDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<CredenciadoEnderecoDto> GetByFilters(Expression<Func<CredenciadoEnderecoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CredenciadoEnderecoDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CredenciadoEnderecoDto> GetByFilterAsQueryable(Expression<Func<CredenciadoEnderecoDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<CredenciadoEnderecoDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<CredenciadoEnderecoDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<CredenciadoEnderecoDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<CredenciadoEnderecoDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

