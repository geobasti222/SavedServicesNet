using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Lider
    /// </summary>
    public class Lider : ILider
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Lider module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Lider()
        {
            module = new Application.Enterprise.Data.Lider();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Lider(string databaseName)
        {
            module = new Application.Enterprise.Data.Lider(databaseName);
        }

        #region Miembros de ILider
        /// <summary>
        /// Lista todos los lideres
        /// </summary>
        /// <returns></returns>
        public List<LiderInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los lideres x zona
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<LiderInfo> ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }
        
        /// <summary>
        /// Lista la informacion de un lider especifico.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public LiderInfo ListxIdLider(string IdLider)
        {
            return module.ListxIdLider(IdLider);
        }

        #endregion
    }
}
