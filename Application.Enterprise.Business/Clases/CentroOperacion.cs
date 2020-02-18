using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para CentroOperacion
    /// </summary>
    public class CentroOperacion : ICentroOperacion
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CentroOperacion module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CentroOperacion()
        {
            module = new Application.Enterprise.Data.CentroOperacion();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CentroOperacion(string databaseName)
        {
            module = new Application.Enterprise.Data.CentroOperacion(databaseName);
        }

        #region Miembros de ICentroOperacion
        /// <summary>
        /// lista todos los centro de operacion existentes activos.
        /// </summary>
        /// <returns></returns>
        public List<CentroOperacionInfo> List()
        {
            return module.List();
        }    
 
        /// <summary>
        /// lista un centro de operacion especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CentroOperacionInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        } 

        #endregion
    }
}
