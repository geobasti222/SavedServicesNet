using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para UsuarioVendedor
    /// </summary>
    public class UsuarioVendedor : IUsuarioVendedor
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.UsuarioVendedor module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public UsuarioVendedor()
        {
            module = new Application.Enterprise.Data.UsuarioVendedor();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public UsuarioVendedor(string databaseName)
        {
            module = new Application.Enterprise.Data.UsuarioVendedor(databaseName);
        }

        #region Miembros de IUsuarioVendedor
        /// <summary>
        /// Lista todos los usuario x vendedor
        /// </summary>
        /// <returns></returns>
        public List<UsuarioVendedorInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un usuario x vendedor por clave y id vendedor
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public UsuarioVendedorInfo ListxClavexIdVendedor(string Clave, string IdVendedor)
        {
            return module.ListxClavexIdVendedor(Clave, IdVendedor);
        }

        /// <summary>
        ///  Lista un usuario x vendedor por clave
        /// </summary>
        /// <param name="Clave"></param>
        /// <returns></returns>
        public UsuarioVendedorInfo ListxClave(string Clave)
        {
            return module.ListxClave(Clave);
        }

        #endregion
    }
}
