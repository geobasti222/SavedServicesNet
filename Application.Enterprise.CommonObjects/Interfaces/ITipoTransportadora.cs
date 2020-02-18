using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TipoTransportadora
    /// </summary>
    public interface ITipoTransportadora
    {
        #region "Metodos de TipoTransportadora"

        /// <summary>
        /// Lista todas los tipos de transportadora
        /// </summary>
        /// <returns></returns>
        List<TipoTransportadoraInfo> List();    
              
        #endregion
    }
}

