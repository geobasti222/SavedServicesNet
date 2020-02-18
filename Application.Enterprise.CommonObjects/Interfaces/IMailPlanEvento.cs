using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IMailPlanEvento
    {
        #region "Metodos de MailPlan Evento"

        /// <summary>
        /// Insercion de un Evento del MailPlan
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Insert(MailPlanEventoInfo item);

        /// <summary>
        /// Actualizacion de un Evento del MailPlan por Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(MailPlanEventoInfo item);

        /// <summary>
        /// Eliminacion de un Evento del MailPlan por Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Delete(MailPlanEventoInfo item);

        /// <summary>
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        List<MailPlanEventoInfo> List();

        /// <summary>
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        MailPlanEventoInfo EventoById(int id);

        /// <summary>
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        List<MailPlanEventoInfo> ListPorCiudad(string codciudad);

        /// <summary>
        /// Lista de todos los ID de un MailPlan
        /// </summary>
        /// <returns></returns>
        List<MailPlanEventoInfo> ListID();

        #endregion
    }
}
