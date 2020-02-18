using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de GerenteRegional JA
    /// </summary>
    public interface IGerenteRegional
    {
        #region "Metodos de GerenteRegional"

        /// <summary>
        /// lista todos los GerentesRegionales existentes.
        /// </summary>
        /// <returns></returns>
        List<GerenteRegionalInfo> List();

        /// <summary>
        /// lista por GerentesRegionale especifico.
        /// </summary>
        /// /// <param name="Gerente"></param>
        /// <returns></returns>
        GerenteRegionalInfo ListxGerente(string Gerente);
        

        /// <summary>
        /// Guarda un GerentesRegionale nuevo.
        /// </summary>
        /// <param name="item"></param>
        /// /// <returns></returns>
        int Insert(GerenteRegionalInfo item);

        /// <summary>
        /// Realiza la actualizacion de un GerentesRegionale existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(GerenteRegionalInfo item);       


        #endregion
    }
}

