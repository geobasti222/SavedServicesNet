using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReservaEnLinea
    /// </summary>
    public class ReservaEnLinea : IReservaEnLinea
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReservaEnLinea module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReservaEnLinea()
        {
            module = new Application.Enterprise.Data.ReservaEnLinea();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReservaEnLinea(string databaseName)
        {
            module = new Application.Enterprise.Data.ReservaEnLinea(databaseName);
        }

        #region Miembros de IReservaEnLinea
        
        /// <summary>
        /// Realiza la reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public string RealizarReservaEnLinea(string NumeroPedido)
        {
            try
            {
                return module.RealizarReservaEnLinea(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return "";
            }
        }



        #endregion
    }
}
