using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Color
    /// </summary>
    public class Color : IColor
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Color module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Color()
        {
            module = new Application.Enterprise.Data.Color();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Color(string databaseName)
        {
            module = new Application.Enterprise.Data.Color(databaseName);
        }

        #region Miembros de IColor
        /// <summary>
        /// Lista todos los colores
        /// </summary>
        /// <returns></returns>
        public List<ColorInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los colores por referencia de articulo.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<ColorInfo> ListxRefencia(string Referencia, string Catalogo)
        {
            return module.ListxRefencia(Referencia, Catalogo);
        }

        /// <summary>
        /// Lista los colores por referencia de articulo para el catalogo outlet.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<ColorInfo> ListxRefenciaOutlet(string Referencia, string Catalogo)
        {
            return module.ListxRefenciaOutlet(Referencia, Catalogo);
        }

        #endregion
    }
}
