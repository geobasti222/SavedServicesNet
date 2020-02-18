using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Localidad
    /// </summary>
    public interface ILocalidad
    {
        #region "Metodos de Localidad"

        /// <summary>
        /// Lista todos las localidades
        /// </summary>
        /// <returns></returns>
        List<LocalidadInfo> List();

        /// <summary>
        /// Lista todas las localidades de una ciudad.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        List<LocalidadInfo> ListxCiudad(string CodCiudad);

        #endregion
    }
}
