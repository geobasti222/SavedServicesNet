using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Zonas Multi Pedidos
    /// </summary>
    public class ZonasMultiPedidos : IZonasMultiPedidos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ZonasMultiPedidos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ZonasMultiPedidos()
        {
            module = new Application.Enterprise.Data.ZonasMultiPedidos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ZonasMultiPedidos(string databaseName)
        {
            module = new Application.Enterprise.Data.ZonasMultiPedidos(databaseName);
        }

        #region Miembros de IZonasMultiPedidos
        /// <summary>
        /// Lista todos las zonas que pueden hacer multiples pedidos.
        /// </summary>
        /// <returns></returns>
        public List<ZonasMultiPedidosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Consulta si existe una zona para digitar multiples pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public ZonasMultiPedidosInfo ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }

        #endregion
    }
}
