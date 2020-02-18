using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ComoTeEnteraste
    /// </summary>
    public class ComoTeEnteraste : IComoTeEnteraste
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ComoTeEnteraste module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ComoTeEnteraste()
        {
            module = new Application.Enterprise.Data.ComoTeEnteraste();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ComoTeEnteraste(string databaseName)
        {
            module = new Application.Enterprise.Data.ComoTeEnteraste(databaseName);
        }

        #region Miembros de IComoTeEnteraste
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ComoTeEnterasteInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
