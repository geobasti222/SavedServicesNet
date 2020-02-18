using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Bodegas
    /// </summary>
    public class Bodegas : IBodegas
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Bodegas module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Bodegas()
        {
            module = new Application.Enterprise.Data.Bodegas();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Bodegas(string databaseName)
        {
            module = new Application.Enterprise.Data.Bodegas(databaseName);
        }

        #region Miembros de IBodegas
        /// <summary>
        /// lista todos las Bodegass existentes.
        /// </summary>
        /// <returns></returns>
        public List<BodegasInfo> List()
        {
            return module.List();
        }

        public BodegasInfo ListxBodega(string bodega)
        {
            return module.ListxBodega(bodega);
        }

        #endregion
    }
}
