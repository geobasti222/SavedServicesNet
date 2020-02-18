using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ReglasCampoOperador
    /// </summary>
    public interface IReglasCampoOperador
    {
        #region "Metodos de ReglasCampoOperador"

        /// <summary>
        /// Lista todos los operadores por campos.
        /// </summary>
        /// <returns></returns>
        List<ReglasCampoOperadorInfo> List();

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        List<ReglasCampoOperadorInfo> ListxIdCampo(int IdCampo);

        /// <summary>
        /// Lista todos los campos de un operador.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        List<ReglasCampoOperadorInfo> ListxIdOperador(int IdOperador);

        #endregion
    }
}

