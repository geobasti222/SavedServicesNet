using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Catalogo Interes
    /// </summary>
    public class CatalogoInteres : ICatalogoInteres
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CatalogoInteres module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CatalogoInteres()
        {
            module = new Application.Enterprise.Data.CatalogoInteres();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CatalogoInteres(string databaseName)
        {
            module = new Application.Enterprise.Data.CatalogoInteres(databaseName);
        }

        #region Miembros de ICatalogoInteres
        /// <summary>
        /// lista todos los catalogos de interes existentes activos.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInteresInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
