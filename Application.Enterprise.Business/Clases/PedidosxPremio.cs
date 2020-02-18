using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PedidosxPremio
    /// </summary>
    public class PedidosxPremio : IPedidosxPremio
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PedidosxPremio module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PedidosxPremio()
        {
            module = new Application.Enterprise.Data.PedidosxPremio();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PedidosxPremio(string databaseName)
        {
            module = new Application.Enterprise.Data.PedidosxPremio(databaseName);
        }

        #region Miembros de IPedidosxPremio


        /// <summary>
        /// Lista todos los pedidos x premios
        /// </summary>
        /// <returns></returns>
        public List<PedidosxPremioInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un pedido especifico por numero de pedido.
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public PedidosxPremioInfo ListxNumero(string Numero)
        {
            return module.ListxNumero(Numero);
        }

        /// <summary>
        /// Realiza el registro de un pedido x premio.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(PedidosxPremioInfo item)
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

        #endregion
    }
}
