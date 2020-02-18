using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para GeografiaEcu
    /// </summary>
    public class GeografiaEcu : IGeografiaEcu
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.GeografiaEcu module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public GeografiaEcu()
        {
            module = new Application.Enterprise.Data.GeografiaEcu();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public GeografiaEcu(string databaseName)
        {
            module = new Application.Enterprise.Data.GeografiaEcu(databaseName);
        }

        #region Miembros de IGeografiaEcu
        /// <summary>
        /// Lista todos las geografias de ecuador
        /// </summary>
        /// <returns></returns>
        public List<GeografiaEcuInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todas las provincias de Ecuador.
        /// </summary>
        /// <returns></returns>
        public List<GeografiaEcuInfo> ListProvincias()
        {
            return module.ListProvincias();
        }

        /// <summary>
        /// Lista todos los cantones de una provincia especifica.
        /// </summary>
        /// <param name="CodProvincia"></param>
        /// <returns></returns>
        public List<GeografiaEcuInfo> ListCantonxProvincia(string CodProvincia)
        {
            return module.ListCantonxProvincia(CodProvincia);
        }

        /// <summary>
        /// Lista todas las parroquias de un canton especifico.
        /// </summary>
        /// <param name="CodCanton"></param>
        /// <returns></returns>
        public List<GeografiaEcuInfo> ListParroquiasxCanton(string CodProvincia, string CodCanton)
        {
            return module.ListParroquiasxCanton(CodProvincia, CodCanton);
        }


        #endregion
    }
}
