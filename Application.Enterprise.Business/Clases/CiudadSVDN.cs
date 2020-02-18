using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class CiudadSVDN : ICiudadSVDN
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CiudadSVDN module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CiudadSVDN()
        {
            module = new Application.Enterprise.Data.CiudadSVDN();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CiudadSVDN(string databaseName)
        {
            module = new Application.Enterprise.Data.CiudadSVDN(databaseName);
        }

        #region Miembros de ICiudadSVDN
        /// <summary>
        /// Lista todos las ciudades de svdn existentes.
        /// </summary>
        /// <returns></returns>
        public List<CiudadSVDNInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos las ciudades de una regional existentes.
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<CiudadSVDNInfo> ListxRegional(int CodigoRegional)
        {
            return module.ListxRegional(CodigoRegional);
        }

        /// <summary>
        /// Lista una ciudad por codigo.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        public CiudadSVDNInfo ListxCodigoCiudad(int CodigoCiudad)
        {
            return module.ListxCodigoCiudad(CodigoCiudad);
        }

        #endregion
    }
}
