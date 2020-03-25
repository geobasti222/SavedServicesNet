using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PLU
    /// </summary>
    public class PLU : IPLU
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PLU module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PLU()
        {
            module = new Application.Enterprise.Data.PLU();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PLU(string databaseName)
        {
            module = new Application.Enterprise.Data.PLU(databaseName);
        }

        #region Miembros de IPLU
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PLUInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los PLU de una referencia existentes
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<PLUInfo> ListxReferencia(string Referencia)
        {
            return module.ListxReferencia(Referencia);
        }

        /// <summary>
        /// Consulta el articulo por medio del PLU.
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public PLUInfo ListxArticulosxPLU(int PLU)
        {
            return module.ListxArticulosxPLU(PLU);
        }


        /// <summary>
        /// Consulta el articulo por medio del PLU por el tipo de precio. (Empresaria, Catalogo, Especial, Credito)
        /// </summary>
        /// <param name="PLU"></param>
        /// <param name="TipoPrecio"></param>
        /// <returns></returns>
        public PLUInfo ListxArticulosxPLUxTipoPrecio(int PLU, string TipoPrecio)
        {
            return module.ListxArticulosxPLUxTipoPrecio(PLU, TipoPrecio);
        }


        /// <summary>
        /// Consulta el articulo por medio del PLU por el tipo de precio. (Empresaria, Catalogo, Especial, Credito)
        /// </summary>
        /// <param name="PLU"></param>
        /// <param name="TipoPrecio"></param>
        /// <returns></returns>
        public PLUInfo ListxArticulosxPLUxTipoPrecioJUTA(int PLU, string TipoPrecio, string campana)
        {
            return module.ListxArticulosxPLUxTipoPrecioJUTA(PLU, TipoPrecio, campana);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PLUInfoDto> ListCatalogoActual(string Campana)
        {
            return module.ListCatalogoActual(Campana);
        }
        #endregion
    }
}