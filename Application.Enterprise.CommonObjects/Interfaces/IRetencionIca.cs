using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Retencion Ica
    /// </summary>
    public interface IRetencionIca
    {
        #region "Metodos de Retencion Ica"

        /// <summary>
        /// lista todas las Retenciones Ica existentes.
        /// </summary>
        /// <returns></returns>
        List<RetencionIcaInfo> List();    
              
        #endregion
    }
}
