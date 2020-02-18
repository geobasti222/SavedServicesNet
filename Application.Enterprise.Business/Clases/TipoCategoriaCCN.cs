using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class TipoCategoriaCCN : ITipoCategoriaCCN
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TipoCategoriaCCN module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoCategoriaCCN()
        {
            module = new Application.Enterprise.Data.TipoCategoriaCCN();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TipoCategoriaCCN(string databaseName)
        {
            module = new Application.Enterprise.Data.TipoCategoriaCCN(databaseName);
        }

        #region Miembros de ITipoCategoriaCCN
        /// <summary>
        /// Lista todos los tipos de categoria para el contactenos de CCN.
        /// </summary>
        /// <returns></returns>
        public List<TipoCategoriaCCNInfo> List()
        {
            return module.List();
        }

        #endregion
    }
}
