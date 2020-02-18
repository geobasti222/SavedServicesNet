using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Premios Campos
    /// </summary>
    public interface IPremiosCampos
    {
        #region "Metodos de Premios Campos"

        /// <summary>
        /// Lista todos los campos de tablas de premios
        /// </summary>
        /// <returns></returns>
        List<PremiosCamposInfo> List();

        /// <summary>
        /// Lista todos los campos de una tabla especifica para los premios
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        List<PremiosCamposInfo> ListxIdTabla(int IdTabla);

        /// <summary>
        /// Lista un campo por id.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        PremiosCamposInfo ListxIdCampo(int IdCampo);

        /// <summary>
        ///  Lista los valores de un combo genericamente.
        /// </summary>
        /// <param name="IdCombo"></param>
        /// <param name="ValueCombo"></param>
        /// <param name="TablaCombo"></param>
        /// <returns></returns>
        List<PremiosCamposInfo> ListxComboGenerico(string IdCombo, string ValueCombo, string TablaCombo);

        /// <summary>
        /// Lista un campo por nombre.
        /// </summary>
        /// <param name="NombreCampo"></param>
        /// <returns></returns>
        PremiosCamposInfo ListxNombreCampo(string NombreCampo);


        #endregion
    }
}

