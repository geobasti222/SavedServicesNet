using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de CiudadSVDN
    /// </summary>
    public interface ICiudadSVDN
    {
        #region "Metodos de CiudadSVDN"

        /// <summary>
        /// Lista todos las ciudades de svdn existentes.
        /// </summary>
        /// <returns></returns>
        List<CiudadSVDNInfo> List();

        /// <summary>
        /// Lista todos las ciudades de una regional existentes.
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        List<CiudadSVDNInfo> ListxRegional(int CodigoRegional);

        /// <summary>
        /// Lista una ciudad por codigo.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        CiudadSVDNInfo ListxCodigoCiudad(int CodigoCiudad);



        #endregion
    }
}

