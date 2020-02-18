using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReglasCampoOperador
    /// </summary>
    public class ReglasCampoOperador : IReglasCampoOperador
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglasCampoOperador module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasCampoOperador()
        {
            module = new Application.Enterprise.Data.ReglasCampoOperador();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasCampoOperador(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglasCampoOperador(databaseName);
        }

        #region Miembros de IReglasCampoOperador
        /// <summary>
        /// Lista todos los operadores por campos.
        /// </summary>
        /// <returns></returns>
        public List<ReglasCampoOperadorInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public List<ReglasCampoOperadorInfo> ListxIdCampo(int IdCampo)
        {
            return module.ListxIdCampo(IdCampo);
        }

        /// <summary>
        /// Lista todos los campos de un operador.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        public List<ReglasCampoOperadorInfo> ListxIdOperador(int IdOperador)
        {
            return module.ListxIdOperador(IdOperador);
        }     

        #endregion
    }
}
