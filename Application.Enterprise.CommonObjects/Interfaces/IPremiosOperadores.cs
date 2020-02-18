using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PremiosOperadores
    /// </summary>
    public interface IPremiosOperadores
    {
        #region "Metodos de PremiosOperadores"

        /// <summary>
        /// Lista todos los operadores para los campos de los premios.
        /// </summary>
        /// <returns></returns>
        List<PremiosOperadoresInfo> List();

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        List<PremiosOperadoresInfo> ListxIdCampo(int IdCampo);

        /// <summary>
        /// Consulta un operador por ID.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        PremiosOperadoresInfo ListxId(int IdOperador);

        /// <summary>
        /// Consulta un operador por valor.
        /// </summary>
        /// <param name="ValorOperador"></param>
        /// <returns></returns>
        PremiosOperadoresInfo ListxValor(string ValorOperador);

        #endregion
    }
}

