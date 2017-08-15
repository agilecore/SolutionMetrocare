using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Common;
using Metrocare.Data;

namespace Metrocare.Domain
{
    /// <summary>
    /// Classe de domínio contendo métodos de negócio. 
    /// </summary>
    public class CredenciadoBus
    {
        private CredenciadoRep   _repositorio { get; set; }
        private bool _saveLastGetByFilter { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        public CredenciadoBus()
        {
            _repositorio = new CredenciadoRep();
        }

        /// <summary>
        /// Obtém um item mediante a objeto filter passado. Se nao encontrado mediante o filtro retorna null.
        /// </summary>
        /// <param name="filter">Objeto filter.</param>
        public CredenciadoDto GetItem(CredenciadoFilter filter)
        {
            var result = _repositorio.GetItem(filter);
            return ((result != null) ? result : null);
        }

        /// <summary>
        /// Salva objeto e retorna boleano, se salvo (true) se não (false).
        /// </summary>
        /// <param name="model">Objeto a ser salvo.</param>
        public bool Add(CredenciadoDto model)
        {
            var result = _repositorio.Add(model);
            return ((result) ? true : false);
        }

        /// <summary>
        /// Salva um objeto e retorna ele mesmo depois de salvo a tela, para ocasiões especiais, quando é preciso salva e retornar o objeto salvo no mesmo momento, se nao salvar o objeto retorna null.
        /// </summary>
        /// <param name="model">Objeto a ser salvo.</param>
        public CredenciadoDto AddGetItem(CredenciadoDto model)
        {
            var result = _repositorio.Add(model);
            return ((result) ? model : null);
        }

        /// <summary>
        /// Obtém resultados mediante o objeto filter passado.
        /// </summary>
        /// <param name="filter">Objeto filter.</param>
        public List<CredenciadoDto> GetByFilter(CredenciadoFilter filter)
        {                   
            return (_repositorio.GetByFilter(filter));
        }         

        /// <summary>
        /// Obtem resultados mediante o objeto filter passado.
        /// </summary>
        /// <param name="filter">Parâmetro de objeto filter.</param>
        /// <param name="saveLastGetByFilter">Parâmetro boleano que indica se a filtro executado sera salvo, para ser requisitada posteriormente pelo usuário.</param>
        public List<CredenciadoDto> GetByFilter(CredenciadoFilter filter, bool saveLastGetByFilter)
        {
            if (saveLastGetByFilter) 
            { 
                //... salva a ultima busca executada para ser requisitada posteriormente pelo usuario
            }
            return (_repositorio.GetByFilter(filter));
        }

    }
}
