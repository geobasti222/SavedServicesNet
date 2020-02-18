using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Sector
    /// </summary>
    public class Sector : ISector
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Sector module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Sector()
        {
            module = new Application.Enterprise.Data.Sector();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Sector(string databaseName)
        {
            module = new Application.Enterprise.Data.Sector(databaseName);
        }     
        
        #region Miembros de ISector

        /// <summary>
        /// lista los Sectores existentes por una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<SectorInfo> ListxCiudad(string CodCiudad)
        {
            return module.ListxCiudad(CodCiudad);
        }
                
        /// <summary>
        /// Lista los sectores de una zona y por ciudad.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <param name="CodZona"></param>
        /// <returns></returns>
        public List<SectorInfo> ListxZona(string CodCiudad, string CodZona)
        {
            return module.ListxZona(CodCiudad, CodZona);
        }

        #endregion
    }
}
