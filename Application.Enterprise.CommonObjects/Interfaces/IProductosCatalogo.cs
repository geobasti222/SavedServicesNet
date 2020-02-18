using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Productos de Catalogo
    /// </summary>
    public interface IProductosCatalogo
    {
        #region "Metodos de Productos del Catalogo"

        /// <summary>
        /// Lista todos los productos del catalogo
        /// </summary>
        /// <returns></returns>
        List<ProductosCatalogoInfo> List();

        /// <summary>
        /// Lista los productos de un catalogo de campaña especifico
        /// </summary>
        /// <returns></returns>
        List<ProductosCatalogoInfo> ListxCatalogoCampana(string CatalogoCampana);    
              
        #endregion
    }
}

