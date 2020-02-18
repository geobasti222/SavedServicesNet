using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Reglas Campos
    /// </summary>
    public interface IReglasCampos
    {
        #region "Metodos de Regla sCampos"

        /// <summary>
        /// Lista todos los campos de tablas de reglas
        /// </summary>
        /// <returns></returns>
        List<ReglasCamposInfo> List();

        /// <summary>
        /// Lista todos los campos de una tabla especifica
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        List<ReglasCamposInfo> ListxIdTabla(int IdTabla);

        /// <summary>
        /// Lista un campo por id.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        ReglasCamposInfo ListxIdCampo(int IdCampo);

        /// <summary>
        ///  Lista los valores de un combo genericamente.
        /// </summary>
        /// <param name="IdCombo"></param>
        /// <param name="ValueCombo"></param>
        /// <param name="TablaCombo"></param>
        /// <returns></returns>
        List<ReglasCamposInfo> ListxComboGenerico(string IdCombo, string ValueCombo, string TablaCombo);
        

        #endregion
    }
}

