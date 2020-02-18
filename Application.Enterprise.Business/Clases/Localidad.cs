using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para localidad
    /// </summary>
    public class Localidad : ILocalidad
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Localidad module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Localidad()
        {
            module = new Application.Enterprise.Data.Localidad();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Localidad(string databaseName)
        {
            module = new Application.Enterprise.Data.Localidad(databaseName);
        }

        #region Miembros de ILocalidad
        /// <summary>
        /// Lista todos las localidades
        /// </summary>
        /// <returns></returns>
        public List<LocalidadInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todas las localidades de una ciudad.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public List<LocalidadInfo> ListxCiudad(string CodCiudad)
        {
            return module.ListxCiudad(CodCiudad);
        }
    
        #endregion
    }
}
