using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    public class MailPlanActividad : IMailPlanActividad
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MailPlanActividad module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MailPlanActividad()
        {
            module = new Application.Enterprise.Data.MailPlanActividad();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MailPlanActividad(string databaseName)
        {
            module = new Application.Enterprise.Data.MailPlanActividad(databaseName);
        }

        #region "Metodos de MailPlanActividad"

        /// <summary>
        /// Lista todas las actividades
        /// </summary>
        /// <returns></returns>
        public List<MailPlanActividadInfo> List()
        {
            return module.List();
        }

        ///// <summary>
        ///// Lista el catalogo de la fecha actual.
        ///// </summary>
        ///// <returns></returns>
        //public List<MailPlanActividadInfo> ListByDescripcion(string descripcion)
        //{
        //    return module.ListByDescripcion(descripcion);
        //}

        /// <summary>
        /// Lista por Id de Actividad
        /// </summary>
        /// <returns></returns>
        public MailPlanActividadInfo ActividadPorId(int Id)
        {
            return module.ActividadPorId(Id);
        }

        /// <summary>
        /// Lista de Actividades por Zona
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<MailPlanActividadInfo> ListByMailGroup(string mailgroup, string campana)
        {
            return module.ListByMailGroup(mailgroup, campana);
        }

        /// <summary>
        /// Actualizacion de una actividad
        /// </summary>
        /// <returns></returns>
        public bool Update(MailPlanActividadInfo item)
        {
            return module.Update(item);
        }

        /// <summary>
        /// Insercion de una Actividad
        /// </summary>
        /// <returns></returns>
        public bool Insert(MailPlanActividadInfo item)
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
        /// Eliminacion de una Actividad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete(MailPlanActividadInfo item)
        {
            return module.Delete(item);
        }

        #endregion
    }
}
