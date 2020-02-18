using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ZonasMultiPedidos
    /// </summary>
    public interface IZonasMultiPedidos
    {
        #region "Metodos de Zonas Multi Pedidos"

        /// <summary>
        /// Lista todos las zonas que pueden hacer multiples pedidos.
        /// </summary>
        /// <returns></returns>
        List<ZonasMultiPedidosInfo> List();

        /// <summary>
        /// Consulta si existe una zona para digitar multiples pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        ZonasMultiPedidosInfo ListxZona(string Zona);

        #endregion
    }
}

