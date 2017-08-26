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
    public class PlanoTabela
    {
        public UnitOfWork _unitOfWork {get; set;}

        /// <summary>
        /// Construtor
        /// </summary>
        public PlanoTabela()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Salva um objeto<T>
        /// </summary>
        public virtual void Save(PlanoTabelaDto model)
        {
            _unitOfWork.GetRepository<PlanoTabelaDto>().Add(model);
        }

        /// <summary>
        /// Salva e retorna o objeto<T> salvo
        /// </summary>
        public virtual PlanoTabelaDto SaveGetItem(PlanoTabelaDto model)
        {
           _unitOfWork.GetRepository<PlanoTabelaDto>().Add(model);
           return (model);
        }

        /// <summary>
        /// Salva uma lista de objetos List<T>
        /// </summary>
        public virtual void SaveAll(List<PlanoTabelaDto> model)
        {
            _unitOfWork.GetRepository<PlanoTabelaDto>().AddAll(model);
        }

        /// <summary>
        /// Salva a edição de um objeto<T>
        /// </summary>
        public virtual void Update(PlanoTabelaDto model)
        {
            _unitOfWork.GetRepository<PlanoTabelaDto>().Update(model);
        }

        /// <summary>
        /// Retorna um único objeto<T> buscado por expressão Lambda
        /// </summary>
        public virtual PlanoTabelaDto GetItem(Expression<Func<PlanoTabelaDto, bool>> filter)
        {
            PlanoTabelaDto model;
            model = _unitOfWork.GetRepository<PlanoTabelaDto>().GetByFilters(filter).FirstOrDefault();
            return (model);
        }

        /// <summary>
        /// Deleta um ou uma lista de objetos
        /// </summary>
        public virtual void Delete(Expression<Func<PlanoTabelaDto, bool>> filter)
        {
             _unitOfWork.GetRepository<PlanoTabelaDto>().Delete(filter);
        }

        /// <summary>
        /// Retorna uma lista List(T) de objetos buscados pela expressão Lambda
        /// </summary>
        public List<PlanoTabelaDto> GetByFilters(Expression<Func<PlanoTabelaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PlanoTabelaDto>().GetByFilters(Filter);
            return (Collection.ToList());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <param name="Filter">Filtro exemplo: GetByFilter(obj => obj.ID, null).</param>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PlanoTabelaDto> GetByFilterAsQueryable(Expression<Func<PlanoTabelaDto, bool>> Filter = null)
        {
            var Collection = _unitOfWork.GetRepository<PlanoTabelaDto>().GetByFilters(Filter);
            return (Collection.AsQueryable<PlanoTabelaDto>());
        }

        /// <summary>
        /// Retorna um objeto IQueryable manipulavel em tempo de execução.
        /// </summary>
        /// <returns>Retorna um objeto IQueryable</returns>
        public IQueryable<PlanoTabelaDto> GetAll()
        {
            var model = _unitOfWork.GetRepository<PlanoTabelaDto>().GetAll().AsQueryable();
            return (model);
        }

    }
}

