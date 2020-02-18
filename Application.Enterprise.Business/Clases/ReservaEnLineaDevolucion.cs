using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReservaEnLineaDevolucion
    /// </summary>
    public class ReservaEnLineaDevolucion : IReservaEnLineaDevolucion
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReservaEnLineaDevolucion module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReservaEnLineaDevolucion()
        {
            module = new Application.Enterprise.Data.ReservaEnLineaDevolucion();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReservaEnLineaDevolucion(string databaseName)
        {
            module = new Application.Enterprise.Data.ReservaEnLineaDevolucion(databaseName);
        }

        #region Miembros de IReservaEnLineaDevolucion

        /// <summary>
        /// Realiza la anulacion de los pedidos que se deben anular por fecha de cierre.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool AnularPedidosxFechaCierre()
        {
            try
            {
                return module.AnularPedidosxFechaCierre();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la devolucion de reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public string RealizarDevolucionReservaEnLinea(string NumeroPedido)
        {
            try
            {
                return module.RealizarDevolucionReservaEnLinea(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return "";
            }
        }

        #endregion
    }
}
