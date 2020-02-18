using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para GrupoProducto
    /// </summary>
    public class GrupoProducto : IGrupoProducto
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.GrupoProducto module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public GrupoProducto()
        {
            module = new Application.Enterprise.Data.GrupoProducto();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public GrupoProducto(string databaseName)
        {
            module = new Application.Enterprise.Data.GrupoProducto(databaseName);
        }

        #region Miembros de IGrupoProducto
        /// <summary>
        /// Lista todos los grupos de los productos.
        /// </summary>
        /// <returns></returns>
        public List<GrupoProductoInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
