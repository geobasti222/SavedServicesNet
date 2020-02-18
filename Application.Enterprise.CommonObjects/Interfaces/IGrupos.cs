using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Grupos
    /// </summary>
    public interface IGrupos
    {
        #region "Metodos de Grupos"

        /// <summary>
        /// Lista todos los grupos.
        /// </summary>
        /// <returns></returns>
        List<GruposInfo> List();

        /// <summary>
        /// Lista un grupo por id.
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns></returns>
        GruposInfo ListxId(string IdGrupo);    
              
        #endregion
    }
}

