using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Grupos
    /// </summary>
    public class Grupos : IGrupos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Grupos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Grupos()
        {
            module = new Application.Enterprise.Data.Grupos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Grupos(string databaseName)
        {
            module = new Application.Enterprise.Data.Grupos(databaseName);
        }

        #region Miembros de IGrupos
        /// <summary>
        /// Lista todos los grupos.
        /// </summary>
        /// <returns></returns>
        public List<GruposInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un grupo por id.
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns></returns>
        public GruposInfo ListxId(string IdGrupo) 
        {
            return module.ListxId(IdGrupo);
        } 

        #endregion
    }
}
