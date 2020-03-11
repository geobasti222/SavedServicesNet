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
    public class CxC : ICxC
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CxC module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CxC()
        {
            module = new Application.Enterprise.Data.CxC();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CxC(string databaseName)
        {
            module = new Application.Enterprise.Data.CxC(databaseName);
        }

        #region Miembros de ICxC
        /// <summary>
        /// Lista todas las cuentas por cobrar (CxC).
        /// </summary>
        /// <returns></returns>
        public List<CxCInfo> List()
        {
            return module.List();
        }

         /// <summary>
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public CxCInfo ListxNitxMes(string Nit, string Mes)
        {
            return module.ListxNitxMes(Nit, Mes);
        }

        /// <summary>
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<CxCInfo> ListCxCVendedor(string Vendedor)
        {
            return module.ListCxCVendedor(Vendedor);
        }

        /// <summary>
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<CxCInfo> ListCxCLider(string Lider, string Nit)
        {
            return module.ListCxCLider(Lider, Nit);
        }
        #endregion
    }
}
