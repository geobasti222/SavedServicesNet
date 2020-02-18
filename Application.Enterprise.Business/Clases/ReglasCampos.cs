using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReglasCampos
    /// </summary>
    public class ReglasCampos : IReglasCampos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglasCampos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasCampos()
        {
            module = new Application.Enterprise.Data.ReglasCampos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasCampos(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglasCampos(databaseName);
        }

        #region Miembros de IReglasCampos
        /// <summary>
        /// Lista todos los campos de tablas de reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglasCamposInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los campos de una tabla especifica
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public List<ReglasCamposInfo> ListxIdTabla(int IdTabla)
        {
            return module.ListxIdTabla(IdTabla);
        }

        /// <summary>
        /// Lista un campo por id.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public ReglasCamposInfo ListxIdCampo(int IdCampo)
        {
            return module.ListxIdCampo(IdCampo);
        }

        /// <summary>
        ///  Lista los valores de un combo genericamente.
        /// </summary>
        /// <param name="IdCombo"></param>
        /// <param name="ValueCombo"></param>
        /// <param name="TablaCombo"></param>
        /// <returns></returns>
        public List<ReglasCamposInfo> ListxComboGenerico(string IdCombo, string ValueCombo, string TablaCombo)
        {
            return module.ListxComboGenerico(IdCombo, ValueCombo, TablaCombo);
        }

        #endregion
    }
}
