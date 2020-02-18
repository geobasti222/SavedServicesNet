using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class Pais : IPais
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Pais module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Pais()
        {
            module = new Application.Enterprise.Data.Pais();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Pais(string databaseName)
        {
            module = new Application.Enterprise.Data.Pais(databaseName);
        }

        #region Miembros de IPais
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PaisInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
