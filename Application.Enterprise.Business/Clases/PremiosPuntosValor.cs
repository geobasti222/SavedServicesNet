using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PremiosPuntosValor
    /// </summary>
    public class PremiosPuntosValor : IPremiosPuntosValor
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosPuntosValor module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosPuntosValor()
        {
            module = new Application.Enterprise.Data.PremiosPuntosValor();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosPuntosValor(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosPuntosValor(databaseName);
        }

        #region Miembros de IPremiosPuntosValor
        /// <summary>
        /// Lista todos los valores para los puntos
        /// </summary>
        /// <returns></returns>
        public List<PremiosPuntosValorInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
