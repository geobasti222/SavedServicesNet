using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TrasladoEnc
    /// </summary>
    public interface ITrasladoEnc
    {
        #region "Metodos de Encabezado de Traslado"

        /// <summary>
        /// Guarda un encabezado de traslado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string Insert(TrasladoEncInfo item);

        /// <summary>
        /// Lista todos los encabezados de traslados.
        /// </summary>
        /// <returns></returns>
        List<TrasladoEncInfo> List();

        #endregion
    }
}

