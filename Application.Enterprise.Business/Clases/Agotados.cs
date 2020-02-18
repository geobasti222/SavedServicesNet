using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Agotados
    /// </summary>
    public class Agotados : IAgotados
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Agotados module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Agotados()
        {
            module = new Application.Enterprise.Data.Agotados();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Agotados(string databaseName)
        {
            module = new Application.Enterprise.Data.Agotados(databaseName);
        }

        #region Miembros de IAgotados

        /// <summary>
        /// Guarda agotados de los pedidos de facturacion semanal que tienen x con visible pos.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los agotados de un pedido.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletexPedido(string NumeroPedido)
        {
            try
            {
                return module.DeletexPedido(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        #endregion
    }
}
