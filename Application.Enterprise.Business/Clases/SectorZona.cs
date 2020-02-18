using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para SectorZona
    /// </summary>
    public class SectorZona : ISectorZona
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.SectorZona module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public SectorZona()
        {
            module = new Application.Enterprise.Data.SectorZona();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public SectorZona(string databaseName)
        {
            module = new Application.Enterprise.Data.SectorZona(databaseName);
        }

        #region Miembros de ISectorZona

        /// <summary>
        ///  lista los todos los Sectores por Zona.
        /// </summary>
        /// <returns></returns>
        public List<SectorZonaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        ///  Lista las zonas de un sector especifico.
        /// </summary>
        /// <returns></returns>
        public List<SectorZonaInfo> ListxSector(string CodSector)
        {
            return module.ListxSector(CodSector);
        }

         /// <summary>
        /// Lista los sectores de una zona especifica.
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        public List<SectorZonaInfo> ListSectorxZona(string CodigoZona)
        {
            return module.ListSectorxZona(CodigoZona);
        }

        #endregion
              
    }
}
