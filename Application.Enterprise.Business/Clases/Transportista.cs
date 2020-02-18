using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Transportista
    /// </summary>
    public class Transportista : ITransportista
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Transportista module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Transportista()
        {
            module = new Application.Enterprise.Data.Transportista();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Transportista(string databaseName)
        {
            module = new Application.Enterprise.Data.Transportista(databaseName);
        }

        #region Miembros de ITransportista
        /// <summary>
        /// Lista todos los trasnportistas.
        /// </summary>
        /// <returns></returns>
        public List<TransportistaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los transportistas de una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<TransportistaInfo> ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }

        /// <summary>
        /// Lista un transportista x id.
        /// </summary>
        /// <param name="IdTransportista"></param>
        /// <returns></returns>
        public TransportistaInfo ListxId(string IdTransportista)
        {
            return module.ListxId(IdTransportista);
        }

        /// <summary>
        /// Lista todos los transportistas de una IdZona.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<TransportistaInfo> ListxIdZona(string IdZona)
        {
            return module.ListxIdZona(IdZona);
        }

        #endregion
    }
}
