using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para VisitaPositiva
    /// </summary>
    public class LiberarMemoriaSQL : ILiberarMemoriaSQL
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.LiberarMemoriaSQL module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public LiberarMemoriaSQL()
        {
            module = new Application.Enterprise.Data.LiberarMemoriaSQL();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public LiberarMemoriaSQL(string databaseName)
        {
            module = new Application.Enterprise.Data.LiberarMemoriaSQL(databaseName);
        }

        #region Miembros de ILiberarMemoriaSQL
        /// <summary>
        /// Libera la memoria del SQL SERVER.
        /// </summary>
        /// <returns></returns>
        public LiberarMemoriaSQLInfo LiberarMemoria()
        {
            return module.LiberarMemoria();
        }     

        #endregion
    }
}
