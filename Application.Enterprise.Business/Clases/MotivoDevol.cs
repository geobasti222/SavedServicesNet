using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para MotivoDevol
    /// </summary>
    public class MotivoDevol
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MotivoDevol module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MotivoDevol()
        {
            module = new Application.Enterprise.Data.MotivoDevol();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MotivoDevol(string databaseName)
        {
            module = new Application.Enterprise.Data.MotivoDevol(databaseName);
        }

        #region Miembros de MotivoDevol
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MotivoDevolInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
