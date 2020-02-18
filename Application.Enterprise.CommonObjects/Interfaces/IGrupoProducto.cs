using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de GrupoProducto
    /// </summary>
    public interface IGrupoProducto
    {
        #region "Metodos de Grupo Producto"

        /// <summary>
        /// Lista todos los grupos de los productos.
        /// </summary>
        /// <returns></returns>
        List<GrupoProductoInfo> List();

        #endregion
    }
}

