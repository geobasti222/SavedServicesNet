using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Barrios
    /// </summary>
    public class DevolucionReservaEnLinea : IDevolucionReservaEnLinea
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.DevolucionReservaEnLinea module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public DevolucionReservaEnLinea()
        {
            module = new Application.Enterprise.Data.DevolucionReservaEnLinea();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public DevolucionReservaEnLinea(string databaseName)
        {
            module = new Application.Enterprise.Data.DevolucionReservaEnLinea(databaseName);
        }

        #region Miembros de IBarrios
        /// <summary>
        /// Lista todos los barrios
        /// </summary>
        /// <returns></returns>
        public DevolucionReservaEnLineaInfo UpdateDevolucionesReservaEnLinea()
        {
            return module.UpdateDevolucionesReservaEnLinea();
        }

        #endregion
    }
}
