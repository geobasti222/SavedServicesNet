using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de UsuarioVendedor
    /// </summary>
    public interface IUsuarioVendedor
    {
        #region "Metodos de UsuarioVendedor"

        /// <summary>
        /// Lista todos los usuario x vendedor
        /// </summary>
        /// <returns></returns>
        List<UsuarioVendedorInfo> List();

        /// <summary>
        /// Lista un usuario x vendedor por clave y id vendedor
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        UsuarioVendedorInfo ListxClavexIdVendedor(string Clave, string IdVendedor);

        /// <summary>
        ///  Lista un usuario x vendedor por clave
        /// </summary>
        /// <param name="Clave"></param>
        /// <returns></returns>
        UsuarioVendedorInfo ListxClave(string Clave);


        #endregion
    }
}

