using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Productos de Catalogo
    /// </summary>
    public class ProductosCatalogo : IProductosCatalogo
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ProductosCatalogo module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ProductosCatalogo()
        {
            module = new Application.Enterprise.Data.ProductosCatalogo();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ProductosCatalogo(string databaseName)
        {
            module = new Application.Enterprise.Data.ProductosCatalogo(databaseName);
        }

        #region Miembros de IProductosCatalogo
        /// <summary>
        ///  Lista todos los productos del catalogo
        /// </summary>
        /// <returns></returns>
        public List<ProductosCatalogoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los productos de un catalogo de campaña especifico
        /// </summary>
        /// <param name="CatalogoCampana"></param>
        /// <returns></returns>
        public List<ProductosCatalogoInfo> ListxCatalogoCampana(string CatalogoCampana)
        {
            return module.ListxCatalogoCampana(CatalogoCampana);
        }

        #endregion

        
    }
}
