using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ITrasladoDet
    /// </summary>
    public interface ITrasladoDet
    {
        #region "Metodos de TrasladoDet"

        /// <summary>
        /// Guarda un encabezado de traslado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string Insert(TrasladoDetInfo item);

        /// <summary>
        /// Lista todos los detalles de traslados.
        /// </summary>
        /// <returns></returns>
        List<TrasladoDetInfo> List();

        #endregion
    }
}

