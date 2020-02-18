using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IMailPlanActividadDetalle
    {
        #region "Metodos de MailPlanActividad"

        /// <summary>
        /// Lista todos los catalogos.
        /// </summary>
        /// <returns></returns>
        List<MailPlanActividadDetalleInfo> List();

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        List<MailPlanActividadDetalleInfo> ListById(int Id);

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        bool Update(MailPlanActividadDetalleInfo item);

        /// <summary>
        /// Lista el catalogo de NIVI de la fecha actual.
        /// </summary>
        /// <returns></returns>
        bool Insert(MailPlanActividadDetalleInfo item);


        #endregion
    }
}
