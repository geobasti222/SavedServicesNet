using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para AuditoriaSaldosBodega
    /// </summary>
    public class AuditoriaSaldosBodega : IAuditoriaSaldosBodega
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.AuditoriaSaldosBodega module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AuditoriaSaldosBodega()
        {
            module = new Application.Enterprise.Data.AuditoriaSaldosBodega();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public AuditoriaSaldosBodega(string databaseName)
        {
            module = new Application.Enterprise.Data.AuditoriaSaldosBodega(databaseName);
        }

        #region Miembros de IAuditoriaSaldosBodega

        /// <summary>
        /// Lista todos errores de saldos bodega sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaSaldosBodegaInfo> ListErroresSinConfirmar()
        {
            return module.ListErroresSinConfirmar();
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
