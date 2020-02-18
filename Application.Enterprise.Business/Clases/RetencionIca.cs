using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para retencion ica
    /// </summary>
    public class RetencionIca : IRetencionIca
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.RetencionIca module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public RetencionIca()
        {
            module = new Application.Enterprise.Data.RetencionIca();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public RetencionIca(string databaseName)
        {
            module = new Application.Enterprise.Data.RetencionIca(databaseName);
        }

        #region Miembros de IRetencionIca
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RetencionIcaInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
