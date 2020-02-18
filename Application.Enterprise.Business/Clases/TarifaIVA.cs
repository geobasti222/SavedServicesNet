using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para TarifaIVA
    /// </summary>
    public class TarifaIVA : ITarifaIVA
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TarifaIVA module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TarifaIVA()
        {
            module = new Application.Enterprise.Data.TarifaIVA();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TarifaIVA(string databaseName)
        {
            module = new Application.Enterprise.Data.TarifaIVA(databaseName);
        }

        #region Miembros de ITarifaIVA
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TarifaIVAInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista la tarifa de iva por id
        /// </summary>
        /// <param name="IdTarifaIVA"></param>
        /// <returns></returns>
        public TarifaIVAInfo ListxId(string IdTarifaIVA) 
        {
            return module.ListxId(IdTarifaIVA);
        } 

        #endregion
    }
}
