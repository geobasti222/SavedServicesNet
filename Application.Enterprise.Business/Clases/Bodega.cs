using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;


namespace Application.Enterprise.Business
{
    /// <summary>
    /// JA
    /// </summary>
    public class Bodega : IBodega
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Bodega module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Bodega()
        {
            module = new Application.Enterprise.Data.Bodega();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Bodega(string databaseName)
        {
            module = new Application.Enterprise.Data.Bodega(databaseName);
        }

         /// <summary>
        /// lista lso amarrados
        /// </summary>
        /// <returns></returns>
        public List<BodegaInfo> List()
        {
            return module.List();
        }

    }
}
