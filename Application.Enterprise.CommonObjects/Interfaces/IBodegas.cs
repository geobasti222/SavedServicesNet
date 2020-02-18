using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Bodegas
    /// </summary>
    public interface IBodegas
    {
        #region "Metodos de Bodegas"

        /// <summary>
        /// lista todos las Bodegass existentes.
        /// </summary>
        /// <returns></returns>
        List<BodegasInfo> List();

        /// <summary>
        /// Guarda un proceso de Bodegas en el sistema.
        /// </summary>
        /// <param name="item"></param>
        BodegasInfo ListxBodega(string bodega);

        #endregion
    }
}

