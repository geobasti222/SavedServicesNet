using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para TipoRed
    /// </summary>
    public class TipoRed : ITipoRed
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TipoRed module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoRed()
        {
            module = new Application.Enterprise.Data.TipoRed();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TipoRed(string databaseName)
        {
            module = new Application.Enterprise.Data.TipoRed(databaseName);
        }

        #region Miembros de ITipoRed
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TipoRedInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
