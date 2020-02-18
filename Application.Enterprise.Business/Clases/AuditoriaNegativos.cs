using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para AuditoriaNegativos
    /// </summary>
    public class AuditoriaNegativos : IAuditoriaNegativos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.AuditoriaNegativos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AuditoriaNegativos()
        {
            module = new Application.Enterprise.Data.AuditoriaNegativos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public AuditoriaNegativos(string databaseName)
        {
            module = new Application.Enterprise.Data.AuditoriaNegativos(databaseName);
        }

        #region Miembros de IAuditoriaNegativos

        /// <summary>
        /// Lista todos errores de negativos sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaNegativosInfo> ListErroresSinConfirmar()
        {
            return module.ListErroresSinConfirmar();
        }

        /// <summary>
        /// Guarda si existe un negativo en la auditoria marcada sin confirmar.
        /// </summary>
        /// <returns></returns>
        public bool InsertarNegativos()
        {
            try
            {
                return module.InsertarNegativos();
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
