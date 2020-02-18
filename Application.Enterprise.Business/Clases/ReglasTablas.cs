using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReglasTablas
    /// </summary>
    public class ReglasTablas : IReglasTablas
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglasTablas module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasTablas()
        {
            module = new Application.Enterprise.Data.ReglasTablas();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasTablas(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglasTablas(databaseName);
        }

        #region Miembros de IReglasTablas
        /// <summary>
        /// Lista todas las tablas de las reglas.
        /// </summary>
        /// <returns></returns>
        public List<ReglasTablasInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista una tabla por id.
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public ReglasTablasInfo ListxId(int IdTabla)
        {
            return module.ListxId(IdTabla);
        }

        #endregion
    }
}
