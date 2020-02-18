using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TipoVisita
    /// </summary>
    public interface ITipoVisita
    {
        #region "Metodos de TipoVisita"

        /// <summary>
        /// lista todos los tipo de visitas existentes.
        /// </summary>
        /// <returns></returns>
        List<TipoVisitaInfo> List();    
              
        #endregion
    }
}

