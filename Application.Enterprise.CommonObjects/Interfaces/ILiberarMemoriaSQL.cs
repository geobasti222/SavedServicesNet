using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ILiberarMemoriaSQL
    /// </summary>
    public interface ILiberarMemoriaSQL
    {
        #region "Metodos de LiberarMemoriaSQL"

        /// <summary>
        /// Libera la memoria del SQL SERVER.
        /// </summary>
        /// <returns></returns>
        LiberarMemoriaSQLInfo LiberarMemoria();    
              
        #endregion
    }
}

