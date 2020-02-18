using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Barrios
    /// </summary>
    public interface IDevolucionReservaEnLinea
    {
        #region "Metodos de DevolucionReservaEnLinea"

        /// <summary>
        /// Lista todos los barrios de una ciudad especifica.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        DevolucionReservaEnLineaInfo UpdateDevolucionesReservaEnLinea();

        #endregion
    }
}

