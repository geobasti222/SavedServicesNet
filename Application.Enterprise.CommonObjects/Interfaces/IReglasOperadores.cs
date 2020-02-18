using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ReglasOperadores
    /// </summary>
    public interface IReglasOperadores
    {
        #region "Metodos de ReglasOperadores"

        /// <summary>
        /// Lista todos los operadores para los campos de las reglas.
        /// </summary>
        /// <returns></returns>
        List<ReglasOperadoresInfo> List();

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        List<ReglasOperadoresInfo> ListxIdCampo(int IdCampo);

        /// <summary>
        /// Consulta un operador por ID.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        ReglasOperadoresInfo ListxId(int IdOperador);

        #endregion
    }
}

