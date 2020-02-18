using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de RegionxZona
    /// </summary>
    public interface IRegionxZona
    {
        #region "Metodos de RegionxZona"

        /// <summary>
        /// Lista todos las zonas y regiones existentes.
        /// </summary>
        /// <returns></returns>
        List<RegionxZonaInfo> List();
        
        /// <summary>
        /// Lista todas las zonas de una region especifica.
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        List<RegionxZonaInfo> ListxRegional(int CodigoRegional);

        /// <summary>
        /// Lista la region de una zona especifica.
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        RegionxZonaInfo ListRegionalxZona(string CodigoZona);

        /// <summary>
        /// Lista la region de una zona especifica (MISMO METODO QUE EL ANTERIOR PERO CON EL FACTORY COMPLETO)
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        RegionxZonaInfo ListRegionalxZonaFactoryCompleto(string CodigoZona);

        /// <summary>
        /// Lista todas las zonas de una regional especifica.
        /// </summary>
        /// <param name="IdRegional"></param>
        /// <returns></returns>
        List<RegionxZonaInfo> ListxIdRegional(string IdRegional);

        /// <summary>
        /// Elimina Regiones por Zona ya que solo puede haber una zona por region.
        /// </summary>
        /// <param name="codzon"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool ElminarRegionXzona(string codzon, string usuario);

        #endregion
    }
}

