using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Fletes Lider
    /// </summary>
    public class FleteLider : IFleteLider 
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.FleteLider module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public FleteLider()
        {
            module = new Application.Enterprise.Data.FleteLider();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public FleteLider(string databaseName)
        {
            module = new Application.Enterprise.Data.FleteLider(databaseName);
        }

        #region Miembros de IFleteLider
        /// <summary>
        /// Lista todos los catalogos x plus.
        /// </summary>
        /// <returns></returns>
        public FleteLiderInfo List(string Lider)
        {
            return module.List(Lider);
        }

        #endregion
    }
}
