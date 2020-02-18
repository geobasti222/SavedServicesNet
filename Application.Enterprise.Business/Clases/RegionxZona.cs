using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para RegionxZona
    /// </summary>
    public class RegionxZona : IRegionxZona
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.RegionxZona module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public RegionxZona()
        {
            module = new Application.Enterprise.Data.RegionxZona();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public RegionxZona(string databaseName)
        {
            module = new Application.Enterprise.Data.RegionxZona(databaseName);
        }

        #region Miembros de IRegionxZona
        /// <summary>
        /// Lista todos las zonas y regiones existentes.
        /// </summary>
        /// <returns></returns>
        public List<RegionxZonaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todas las zonas de una region especifica.
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<RegionxZonaInfo> ListxRegional(int CodigoRegional)
        {
            return module.ListxRegional(CodigoRegional);
        }

        /// <summary>
        /// Lista la region de una zona especifica.
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        public RegionxZonaInfo ListRegionalxZona(string CodigoZona)
        {
            return module.ListRegionalxZona(CodigoZona);
        }

        /// <summary>
        /// Lista la region de una zona especifica (MISMO METODO QUE EL ANTERIOR PERO CON EL FACTORY COMPLETO)
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        public RegionxZonaInfo ListRegionalxZonaFactoryCompleto(string CodigoZona)
        {
            return module.ListRegionalxZonaFactoryCompleto(CodigoZona);
        }

         /// <summary>
        /// Lista todas las zonas de una regional especifica.
        /// </summary>
        /// <param name="IdRegional"></param>
        /// <returns></returns>
        public List<RegionxZonaInfo> ListxIdRegional(string IdRegional)
        {
            return module.ListxIdRegional(IdRegional);
        }

        /// <summary>
        /// Elimina Regiones por Zona ya que solo puede haber una zona por region.
        /// </summary>
        /// <param name="codzon">codigo zona</param>
        /// <param name="usuario">usuario que elimina</param>
        /// <returns></returns>
        public bool ElminarRegionXzona(string codzon, string usuario)
        {
            return module.ElminarRegionXzona (codzon,usuario);
        }

        /// <summary>
        /// Inserta Regiones por Zona ya que solo puede haber una zona por region.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertarRegionXzona(RegionxZonaInfo item , string usuario)
        {
            return module.InsertaRegionXzona (item, usuario);
        }
        #endregion
    }
}
