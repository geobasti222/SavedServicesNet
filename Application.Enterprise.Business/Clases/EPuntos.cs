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
    public class EPuntos : IEPuntos

    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.EPuntos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public EPuntos()
        {
            module = new Application.Enterprise.Data.EPuntos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public EPuntos(string databaseName)
        {
            module = new Application.Enterprise.Data.EPuntos(databaseName);
        }

        #region Miembros de IEPuntos
       

         

        /// <summary>
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<EPuntosInfo> ListPuntosEmpresarias(string Nit, string Lider,string Vendedor)
        {
            return module.ListPuntosEmpresarias(Nit,Lider,Vendedor);
        }


        /// <summary>
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<EPuntosInfo> ListDetallePuntosEmpresarias(string Nit)
        {
            return module.ListDetallePuntosEmpresarias(Nit);
        }


        #endregion
    }
}
