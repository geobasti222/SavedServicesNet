using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para zona
    /// </summary>
    public class GruposUsuarios : IGruposUsuarios
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.GruposUsuarios module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public GruposUsuarios()
        {
            module = new Application.Enterprise.Data.GruposUsuarios();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public GruposUsuarios(string databaseName)
        {
            module = new Application.Enterprise.Data.GruposUsuarios(databaseName);
        }

        #region Miembros de IGruposUsuarios
        /// <summary>
        /// lista todas las GruposUsuarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<GruposUsuariosInfo> List()
        {
            return module.List();
        }

        #endregion
    }
}
