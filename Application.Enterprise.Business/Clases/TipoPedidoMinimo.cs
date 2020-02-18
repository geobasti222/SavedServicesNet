using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para TipoPedidoMinimo
    /// </summary>
    public class TipoPedidoMinimo : ITipoPedidoMinimo
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TipoPedidoMinimo module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoPedidoMinimo()
        {
            module = new Application.Enterprise.Data.TipoPedidoMinimo();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TipoPedidoMinimo(string databaseName)
        {
            module = new Application.Enterprise.Data.TipoPedidoMinimo(databaseName);
        }

        #region Miembros de ITipoPedidoMinimo
        /// <summary>
        /// -Lista todos los tipos de pedido minimo.
        /// </summary>
        /// <returns></returns>
        public List<TipoPedidoMinimoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un tipo de pedido minimo x id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TipoPedidoMinimoInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }
                  
        /// <summary>
        /// Realiza la actualizacion de los valores de un tipo de pedido minimo.
        /// </summary>
        /// <param name="objTipoPedidoMinimoInfo"></param>
        /// <returns></returns>
        public bool Update(TipoPedidoMinimoInfo objTipoPedidoMinimoInfo)
        {
            try
            {
                return module.Update(objTipoPedidoMinimoInfo);
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
