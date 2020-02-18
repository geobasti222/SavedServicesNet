using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para TipoVisita
    /// </summary>
    public class TipoVisita : ITipoVisita
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TipoVisita module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoVisita()
        {
            module = new Application.Enterprise.Data.TipoVisita();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TipoVisita(string databaseName)
        {
            module = new Application.Enterprise.Data.TipoVisita(databaseName);
        }

        #region Miembros de ITipoVisita
        /// <summary>
        /// lista todos los tipo de visitas existentes.
        /// </summary>
        /// <returns></returns>
        public List<TipoVisitaInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
