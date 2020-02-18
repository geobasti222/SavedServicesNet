using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class EstadosPedido : IEstadosPedido
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.EstadosPedido module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public EstadosPedido()
        {
            module = new Application.Enterprise.Data.EstadosPedido();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public EstadosPedido(string databaseName)
        {
            module = new Application.Enterprise.Data.EstadosPedido(databaseName);
        }

        #region Miembros de IEstadosPedido
        /// <summary>
        /// Lista todos los estados de un pedido activos.
        /// </summary>
        /// <returns></returns>
        public List<EstadosPedidoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un estado de un pedido activos especifico por id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EstadosPedidoInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }

        #endregion
    }
}
