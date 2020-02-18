using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TarifaIVA
    /// </summary>
    public interface ITarifaIVA
    {
        #region "Metodos de TarifaIVA"

        /// <summary>
        /// Lista todas las tarifas de iva
        /// </summary>
        /// <returns></returns>
        List<TarifaIVAInfo> List();

        /// <summary>
        /// Lista la tarifa de iva por id
        /// </summary>
        /// <param name="IdTarifaIVA"></param>
        /// <returns></returns>
        TarifaIVAInfo ListxId(string IdTarifaIVA);    
              
        #endregion
    }
}

