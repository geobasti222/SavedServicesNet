using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para CostoMercancia
    /// </summary>
    public class CostoMercancia : ICostoMercancia
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CostoMercancia module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CostoMercancia()
        {
            module = new Application.Enterprise.Data.CostoMercancia();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CostoMercancia(string databaseName)
        {
            module = new Application.Enterprise.Data.CostoMercancia(databaseName);
        }

        #region Miembros de ICostoMercancia

        /// <summary>
        /// Lista todos los costos de mercancia.
        /// </summary>
        /// <returns></returns>
        public List<CostoMercanciaInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
