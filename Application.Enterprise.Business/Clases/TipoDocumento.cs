using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para tipo documento
    /// </summary>
    public class TipoDocumento : ITipoDocumento
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TipoDocumento module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoDocumento()
        {
            module = new Application.Enterprise.Data.TipoDocumento();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TipoDocumento(string databaseName)
        {
            module = new Application.Enterprise.Data.TipoDocumento(databaseName);
        }

        #region Miembros de ITipoDocumento
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TipoDocumentoInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
