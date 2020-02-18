using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de SectorZona
    /// </summary>
    public interface ISectorZona
    {
        #region "Metodos de SectorZona"

        /// <summary>
        /// lista los todos los Sectores por Zona.
        /// </summary>
        /// <returns></returns>
        List<SectorZonaInfo> List();

        /// <summary>
        /// Lista las zonas de un sector especifico.
        /// </summary>
        /// <returns></returns>
        List<SectorZonaInfo> ListxSector(string CodSector);    

         /// <summary>
        /// Lista los sectores de una zona especifica.
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        List<SectorZonaInfo> ListSectorxZona(string CodigoZona);
        
              
        #endregion
    }
}
