using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Premios Campo Operador
    /// </summary>
    public class PremiosCampoOperador : IPremiosCampoOperador
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosCampoOperador module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosCampoOperador()
        {
            module = new Application.Enterprise.Data.PremiosCampoOperador();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosCampoOperador(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosCampoOperador(databaseName);
        }

        #region Miembros de IPremiosCampoOperador
        /// <summary>
        /// Lista todos los operadores por campos.
        /// </summary>
        /// <returns></returns>
        public List<PremiosCampoOperadorInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public List<PremiosCampoOperadorInfo> ListxIdCampo(int IdCampo)
        {
            return module.ListxIdCampo(IdCampo);
        }

        /// <summary>
        /// Lista todos los campos de un operador.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        public List<PremiosCampoOperadorInfo> ListxIdOperador(int IdOperador)
        {
            return module.ListxIdOperador(IdOperador);
        }     

        #endregion
    }
}
