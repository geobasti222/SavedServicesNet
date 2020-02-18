using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PedidosxPremio
    /// </summary>
    public interface IPedidosxPremio
    {
        #region "Metodos de PedidosxPremio"

        /// <summary>
        /// Lista todos los pedidos x premios
        /// </summary>
        /// <returns></returns>
        List<PedidosxPremioInfo> List();

        /// <summary>
        /// Lista un pedido especifico por numero de pedido.
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        PedidosxPremioInfo ListxNumero(string Numero);

        /// <summary>
        /// Realiza el registro de un pedido x premio.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(PedidosxPremioInfo item);

        #endregion
    }
}

