using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Sector
    /// </summary>
    public interface ISector
    {
        #region "Metodos de Sector"
       
        /// <summary>
        /// lista los todos los Sectores de una ciudad.
        /// </summary>
        /// <returns></returns>
        List<SectorInfo> ListxCiudad(string CodCiudad);

        /// <summary>
        /// Lista los sectores de una zona y por ciudad.
        /// </summary>
        /// <returns></returns>
        List<SectorInfo> ListxZona(string CodCiudad, string CodZona);   
              
        #endregion
    }
}
