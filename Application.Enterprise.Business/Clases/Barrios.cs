using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Barrios
    /// </summary>
    public class Barrios : IBarrios
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Barrios module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Barrios()
        {
            module = new Application.Enterprise.Data.Barrios();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Barrios(string databaseName)
        {
            module = new Application.Enterprise.Data.Barrios(databaseName);
        }

        #region Miembros de IBarrios
        /// <summary>
        /// Lista todos los barrios
        /// </summary>
        /// <returns></returns>
        public List<BarriosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los barrios de una ciudad especifica.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        public List<BarriosInfo> ListxCiudad(int CodigoCiudad)
        {
            return module.ListxCiudad(CodigoCiudad);
        }

        #endregion
    }
}
