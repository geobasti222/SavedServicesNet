using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Estados Pedido
    /// </summary>
    public interface IEstadosPedido
    {
        #region "Metodos de EstadosCliente"

        /// <summary>
        /// Lista todos los estados de un pedido activos.
        /// </summary>
        /// <returns></returns>
        List<EstadosPedidoInfo> List();

        /// <summary>
        /// Lista un estado de un pedido activos especifico por id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EstadosPedidoInfo ListxId(int Id);

        #endregion
    }
}