using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IReservaEnLinea
    /// </summary>
    public interface IReservaEnLinea
    {
        #region "Metodos de ReservaEnLinea"

        /// <summary>
        /// Realiza la reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        string RealizarReservaEnLinea(string NumeroPedido);


        /// <summary>
        /// Realiza la reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        //*string RealizarReservaEnLineaDifBodega(string NumeroPedido, string bodega);
        

        #endregion
    }
}

