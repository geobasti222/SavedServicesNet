using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para SectorxBarrio
    /// </summary>
    public class SectorxBarrio : ISectorxBarrio
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.SectorxBarrio module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public SectorxBarrio()
        {
            module = new Application.Enterprise.Data.SectorxBarrio();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public SectorxBarrio(string databaseName)
        {
            module = new Application.Enterprise.Data.SectorxBarrio(databaseName);
        }

        #region Miembros de ISectorxBarrio
        /// <summary>
        /// lista todos los sectores x barrios existentes.
        /// </summary>
        /// <returns></returns>
        public List<SectorxBarrioInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista el sector de un barrio especifico.
        /// </summary>
        /// <returns></returns>
        public List<SectorxBarrioInfo> ListxBarrio(int CodigoBarrio)
        {
            return module.ListxBarrio(CodigoBarrio);
        }

        #endregion
    }
}
