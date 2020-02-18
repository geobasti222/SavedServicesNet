using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IGeografiaEcu
    /// </summary>
    public interface IGeografiaEcu
    {
        #region "Metodos de IGeografiaEcu"

        /// <summary>
        /// Lista todos las geografias de ecuador
        /// </summary>
        /// <returns></returns>
        List<GeografiaEcuInfo> List();

        /// <summary>
        /// Lista todas las provincias de Ecuador.
        /// </summary>
        /// <returns></returns>
        List<GeografiaEcuInfo> ListProvincias();

        /// <summary>
        /// Lista todos los cantones de una provincia especifica.
        /// </summary>
        /// <param name="CodProvincia"></param>
        /// <returns></returns>
        List<GeografiaEcuInfo> ListCantonxProvincia(string CodProvincia);

         /// <summary>
        /// Lista todas las parroquias de un canton especifico.
        /// </summary>
        /// <param name="CodCanton"></param>
        /// <returns></returns>
        List<GeografiaEcuInfo> ListParroquiasxCanton(string CodProvincia, string CodCanton);


        #endregion
    }
}

