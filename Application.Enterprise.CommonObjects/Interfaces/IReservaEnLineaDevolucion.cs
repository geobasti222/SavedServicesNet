using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IReservaEnLineaDevolucion
    /// </summary>
    public interface IReservaEnLineaDevolucion
    {
        #region "Metodos de Devolucion de ReservaEnLinea"

        /// <summary>
        /// Realiza la anulacion de los pedidos que se deben anular por fecha de cierre.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool AnularPedidosxFechaCierre();

        /// <summary>
        /// Realiza la devolucion de reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        string RealizarDevolucionReservaEnLinea(string NumeroPedido);

        #endregion
    }
}

