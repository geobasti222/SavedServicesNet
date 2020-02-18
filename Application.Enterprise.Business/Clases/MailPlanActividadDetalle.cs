using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    public class MailPlanActividadDetalle:IMailPlanActividadDetalle
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MailPlanActividadDetalle module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MailPlanActividadDetalle()
        {
            module = new Application.Enterprise.Data.MailPlanActividadDetalle();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MailPlanActividadDetalle(string databaseName)
        {
            module = new Application.Enterprise.Data.MailPlanActividadDetalle(databaseName);
        }

        #region "Metodos de MailPlanActividad"

        /// <summary>
        /// Lista todos los catalogos.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanActividadDetalleInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanActividadDetalleInfo> ListById(int Id) 
        {
            return module.ListById(Id);
        }

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public bool Update(MailPlanActividadDetalleInfo item)
        {
            return module.Update(item);
        }

        /// <summary>
        /// Lista el catalogo de NIVI de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public bool Insert(MailPlanActividadDetalleInfo item)
        {
            return module.Insert(item);
        }


        #endregion
    }
}
