using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para AuditoriaReserva
    /// </summary>
    public class AuditoriaReserva : IAuditoriaReserva
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.AuditoriaReserva module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AuditoriaReserva()
        {
            module = new Application.Enterprise.Data.AuditoriaReserva();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public AuditoriaReserva(string databaseName)
        {
            module = new Application.Enterprise.Data.AuditoriaReserva(databaseName);
        }

        #region Miembros de IAuditoriaReserva

        /// <summary>
        /// Lista todos errores de reserva en linea sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaReservaInfo> ListErroresSinConfirmar()
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
