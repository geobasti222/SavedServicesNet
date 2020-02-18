using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Tipo de Documento
    /// </summary>
    public interface ITipoDocumento
    {
        #region "Metodos de Tipo Documento"

        /// <summary>
        /// lista todos los tipo de documento existentes.
        /// </summary>
        /// <returns></returns>
        List<TipoDocumentoInfo> List();    
              
        #endregion
    }
}
