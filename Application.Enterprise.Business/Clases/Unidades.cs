using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ciudad
    /// </summary>
    public class Unidades : IUnidades
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Unidades  module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Unidades()
        {
            module = new Application.Enterprise.Data.Unidades();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Unidades(string databaseName)
        {
            module = new Application.Enterprise.Data.Unidades(databaseName);
        }
        
        #region Miembros de IUnidadees
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UnidadesInfo> List()
        {
            return module.List();
        }

       
        #endregion
    }
}
