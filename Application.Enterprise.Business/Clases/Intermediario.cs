using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Intermediario
    /// </summary>
    public class Intermediario : IIntermediario
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Intermediario module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Intermediario()
        {
            module = new Application.Enterprise.Data.Intermediario();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Intermediario(string databaseName)
        {
            module = new Application.Enterprise.Data.Intermediario(databaseName);
        }

        #region Miembros de IIntermediario
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IntermediarioInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
