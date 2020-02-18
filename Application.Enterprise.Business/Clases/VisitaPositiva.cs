using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para VisitaPositiva
    /// </summary>
    public class VisitaPositiva : IVisitaPositiva
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.VisitaPositiva module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public VisitaPositiva()
        {
            module = new Application.Enterprise.Data.VisitaPositiva();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public VisitaPositiva(string databaseName)
        {
            module = new Application.Enterprise.Data.VisitaPositiva(databaseName);
        }

        #region Miembros de IVisitaPositiva
        /// <summary>
        /// Lista todos los tipo de visita positiva
        /// </summary>
        /// <returns></returns>
        public List<VisitaPositivaInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
