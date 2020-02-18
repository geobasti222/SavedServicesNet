using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ArtExcentosxCiudad
    /// </summary>
    public class ArtExcentosxCiudad : IArtExcentosxCiudad
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ArtExcentosxCiudad module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ArtExcentosxCiudad()
        {
            module = new Application.Enterprise.Data.ArtExcentosxCiudad();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ArtExcentosxCiudad(string databaseName)
        {
            module = new Application.Enterprise.Data.ArtExcentosxCiudad(databaseName);
        }

        #region Miembros de IArtExcentosxCiudad
        /// <summary>
        /// Lista todos los articulos exentos x ciudad.
        /// </summary>
        /// <returns></returns>
        public List<ArtExcentosxCiudadInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los articulos exentos x ciudad.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <param name="Plu"></param>
        /// <returns></returns>
        public ArtExcentosxCiudadInfo ListxCiudadxPlu(string CodigoCiudad, int Plu)
        {
            return module.ListxCiudadxPlu(CodigoCiudad, Plu);
        }     

        #endregion
    }
}
