using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Talla
    /// </summary>
    public class Talla : ITalla
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Talla module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Talla()
        {
            module = new Application.Enterprise.Data.Talla();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Talla(string databaseName)
        {
            module = new Application.Enterprise.Data.Talla(databaseName);
        }

        #region Miembros de ITalla
        /// <summary>
        /// Lista todos las Tallas
        /// </summary>
        /// <returns></returns>
        public List<TallaInfo> List()
        {
            return module.List();
        }     

        /// <summary>
        /// Lista una talla por referencia y color de articulo.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        public List<TallaInfo> ListxReferenciaxColor(string Referencia, string CodigoColor, string Catalogo)
        {
            return module.ListxReferenciaxColor(Referencia, CodigoColor, Catalogo);
        }

          /// <summary>
        /// Lista una talla por referencia y color de articulo para el catalogo outlet.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        public List<TallaInfo> ListxReferenciaxColorOutlet(string Referencia, string CodigoColor, string Catalogo)
        {
            return module.ListxReferenciaxColorOutlet(Referencia, CodigoColor, Catalogo);
        }

        #endregion
    }
}
