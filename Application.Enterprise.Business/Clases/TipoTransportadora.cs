using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para TipoTransportadora
    /// </summary>
    public class TipoTransportadora : ITipoTransportadora
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TipoTransportadora module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoTransportadora()
        {
            module = new Application.Enterprise.Data.TipoTransportadora();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TipoTransportadora(string databaseName)
        {
            module = new Application.Enterprise.Data.TipoTransportadora(databaseName);
        }

        #region Miembros de ITipoTransportadora
        /// <summary>
        /// Lista todas los tipos de transportadora
        /// </summary>
        /// <returns></returns>
        public List<TipoTransportadoraInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
