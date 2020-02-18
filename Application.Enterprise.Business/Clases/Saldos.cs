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
    public class Saldos : ISaldos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Saldos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Saldos()
        {
            module = new Application.Enterprise.Data.Saldos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Saldos(string databaseName)
        {
            module = new Application.Enterprise.Data.Saldos(databaseName);
        }

        #region Miembros de ISaldos
        /// <summary>
        /// Lista todos los saldos de una empresaria x campana detallado.
        /// </summary>
        /// <param name="objSaldos"></param>
        /// <returns></returns>
        public List<SaldosInfo> ListxNitxCampana(SaldosInfo objSaldos)
        {
            return module.ListxNitxCampana(objSaldos);
        }     

        #endregion
    }
}
