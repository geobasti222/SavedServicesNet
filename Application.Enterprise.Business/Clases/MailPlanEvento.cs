using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class MailPlanEvento : IMailPlanEvento
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MailPlanEvento module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MailPlanEvento()
        {
            module = new Application.Enterprise.Data.MailPlanEvento();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MailPlanEvento(string databaseName)
        {
            module = new Application.Enterprise.Data.MailPlanEvento(databaseName);
        }

        #region Miembros de IMailPlanEvento

        /// <summary>
        /// Insercion de un Evento del MailPlan
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(MailPlanEventoInfo item)
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
        /// Actualizacion de un Evento del MailPlan por Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailPlanEventoInfo item)
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
        /// Eliminacion de un Evento del MailPlan por Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete(MailPlanEventoInfo item)
        {
            try
            {
                return module.Delete(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        public List<MailPlanEventoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        public MailPlanEventoInfo EventoById(int id)
        {
            return module.EventoById(id);
        }

        /// <summary>
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        public List<MailPlanEventoInfo> ListPorCiudad(string codciudad)
        {
            return module.ListPorCiudad(codciudad);
        }

        /// <summary>
        /// Lista de todos los ID de un MailPlan
        /// </summary>
        /// <returns></returns>
        public List<MailPlanEventoInfo> ListID()
        {
            return module.ListID();
        }        

        #endregion
    }
}
