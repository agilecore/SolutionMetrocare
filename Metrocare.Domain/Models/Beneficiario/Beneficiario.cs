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
    public class Beneficiario
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public Beneficiario()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(BeneficiarioDto model)
        {
            _unitOfWork.GetRepository<BeneficiarioDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual BeneficiarioDto SaveGetItem(BeneficiarioDto model)
        {
           _unitOfWork.GetRepository<BeneficiarioDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<BeneficiarioDto> model)
        {
            _unitOfWork.GetRepository<BeneficiarioDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(BeneficiarioDto model)
        {
            _unitOfWork.GetRepository<BeneficiarioDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual BeneficiarioDto GetItem(Expression<Func<BeneficiarioDto, bool>> filter)
        {
            BeneficiarioDto model;
            model = _unitOfWork.GetRepository<BeneficiarioDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<BeneficiarioDto, bool>> filter)
        {
             _unitOfWork.GetRepository<BeneficiarioDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<BeneficiarioDto> GetByFilters(Expression<Func<BeneficiarioDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<BeneficiarioDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<BeneficiarioDto> GetByFilterAsQueryable(Expression<Func<BeneficiarioDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<BeneficiarioDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<BeneficiarioDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<BeneficiarioDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<BeneficiarioDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

