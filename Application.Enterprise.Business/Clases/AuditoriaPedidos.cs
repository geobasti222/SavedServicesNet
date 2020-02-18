using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para AuditoriaPedidos
    /// </summary>
    public class AuditoriaPedidos : IAuditoriaPedidos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.AuditoriaPedidos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AuditoriaPedidos()
        {
            module = new Application.Enterprise.Data.AuditoriaPedidos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public AuditoriaPedidos(string databaseName)
        {
            module = new Application.Enterprise.Data.AuditoriaPedidos(databaseName);
        }

        #region Miembros de IAuditoriaPedidos

        /// <summary>
        /// Lista todos errores de pedidos sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaPedidosInfo> ListErroresSinConfirmar()
        {
            return module.ListErroresSinConfirmar();
        }

        /// <summary>
        /// Guarda si existe un pedido en la auditoria marcada sin confirmar.
        /// </summary>
        /// <returns></returns>
        public bool InsertarPedidos()
        {
            try
            {
                return module.InsertarPedidos();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateIdConfirmado(int Id)
        {
            try
            {
                return module.UpdateIdConfirmado(Id);
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
