using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de GruposUsuarios
    /// </summary>
    public interface IGruposUsuarios
    {
        #region "Metodos de GruposUsuarios"

        /// <summary>
        /// lista todas las GruposUsuarios existentes.
        /// </summary>
        /// <returns></returns>
        List<GruposUsuariosInfo> List();

        #endregion
    }
}
