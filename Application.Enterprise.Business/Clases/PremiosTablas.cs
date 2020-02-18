using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Premios Tablas
    /// </summary>
    public class PremiosTablas : IPremiosTablas
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosTablas module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosTablas()
        {
            module = new Application.Enterprise.Data.PremiosTablas();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosTablas(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosTablas(databaseName);
        }

        #region Miembros de IPremiosTablas
        /// <summary>
        /// Lista todas las tablas de los premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosTablasInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista una tabla por id.
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public PremiosTablasInfo ListxId(int IdTabla)
        {
            return module.ListxId(IdTabla);
        }
         
        /// <summary>
        /// Lista una tabla por Nombre.
        /// </summary>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public PremiosTablasInfo ListxNombre(string NombreTabla)
        {
            return module.ListxNombre(NombreTabla);
        }

        #endregion
    }
}