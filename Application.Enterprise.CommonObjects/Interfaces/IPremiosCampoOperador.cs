using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PremiosCampoOperador
    /// </summary>
    public interface IPremiosCampoOperador
    {
        #region "Metodos de PremiosCampoOperador"

        /// <summary>
        /// Lista todos los operadores por campos.
        /// </summary>
        /// <returns></returns>
        List<PremiosCampoOperadorInfo> List();

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        List<PremiosCampoOperadorInfo> ListxIdCampo(int IdCampo);

        /// <summary>
        /// Lista todos los campos de un operador.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        List<PremiosCampoOperadorInfo> ListxIdOperador(int IdOperador);

        #endregion
    }
}

