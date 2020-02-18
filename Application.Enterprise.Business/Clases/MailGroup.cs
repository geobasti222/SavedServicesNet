using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para MailGroup
    /// </summary>
    public class MailGroup : IMailGroup
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MailGroup module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MailGroup()
        {
            module = new Application.Enterprise.Data.MailGroup();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MailGroup(string databaseName)
        {
            module = new Application.Enterprise.Data.MailGroup(databaseName);
        }

        #region Miembros de IMailGroup

        /// <summary>
        /// lista todos los MailGroup existentes.
        /// </summary>
        /// <returns></returns>
        public List<MailGroupInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Obtiene los mailgroup que se encuentran abiertos para procesar de la fecha.
        /// </summary>
        /// <returns></returns>
        public List<MailGroupInfo> ListxFechaActual()
        {
            return module.ListxFechaActual();
        }

        /// <summary>
        ///Obtiene los mailgroup que se encuentran abiertos para procesar de la fecha para la facturacion.
        /// </summary>
        /// <returns></returns>
        public List<MailGroupInfo> ListxFechaActualFacturacion()
        {
            return module.ListxFechaActualFacturacion();
        }

        /// <summary>
        /// Realiza la actualizacion de un mailplan del sistema por mailgroup.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailGroupInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// Realiza la actualizacion de un mailplan para factuacion del sistema por mailgroup. Lo deja en estado abierto para facturar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateEstadoFacturacionAbierto(MailGroupInfo item)
        {
            try
            {
                return module.UpdateEstadoFacturacionAbierto(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de un mailplan para factuacion del sistema por mailgroup. Lo deja en estado cerrado y no se puede facturar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateEstadoFacturacionCerrado(MailGroupInfo item)
        {
            try
            {
                return module.UpdateEstadoFacturacionCerrado(item);
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
