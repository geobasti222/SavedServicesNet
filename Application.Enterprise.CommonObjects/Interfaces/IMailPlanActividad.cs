using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IMailPlanActividad
    {
        #region "Metodos de MailPlanActividad"

        /// <summary>
        /// Lista todas las actividades
        /// </summary>
        /// <returns></returns>
        List<MailPlanActividadInfo> List();

        /// <summary>
        /// Lista por Id de Actividad
        /// </summary>
        /// <returns></returns>
        MailPlanActividadInfo ActividadPorId(int Id);

        /// <summary>
        /// Lista de Actividades por Zona
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        List<MailPlanActividadInfo> ListByMailGroup(string mailgroup, string campana);

        ///// <summary>
        ///// Lista el catalogo de la fecha actual.
        ///// </summary>
        ///// <returns></returns>
        //List<MailPlanActividadInfo> ListByDescripcion(string descripcion);

        /// <summary>
        /// Actualizacion de una actividad
        /// </summary>
        /// <returns></returns>
        bool Update(MailPlanActividadInfo item);

        /// <summary>
        /// Insercion de una actividad.
        /// </summary>
        /// <returns></returns>
        bool Insert(MailPlanActividadInfo item);

        /// <summary>
        /// Eliminacion de una Actividad.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Delete(MailPlanActividadInfo item);

        #endregion
    }
}
