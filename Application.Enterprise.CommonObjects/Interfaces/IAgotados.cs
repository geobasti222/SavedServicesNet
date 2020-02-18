using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Agotados
    /// </summary>
    public interface IAgotados
    {
        #region "Metodos de Agotados"

        /// <summary>
        /// Guarda agotados de los pedidos de facturacion semanal que tienen x con visible pos.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Elimina todos los agotados de un pedido.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool DeletexPedido(string NumeroPedido);

        #endregion
    }
}

