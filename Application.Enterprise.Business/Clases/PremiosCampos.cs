using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Premios Campos
    /// </summary>
    public class PremiosCampos : IPremiosCampos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosCampos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosCampos()
        {
            module = new Application.Enterprise.Data.PremiosCampos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosCampos(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosCampos(databaseName);
        }

        #region Miembros de IPremiosCampos
        /// <summary>
        /// Lista todos los campos de tablas de premios
        /// </summary>
        /// <returns></returns>
        public List<PremiosCamposInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los campos de una tabla especifica para premios.
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public List<PremiosCamposInfo> ListxIdTabla(int IdTabla)
        {
            return module.ListxIdTabla(IdTabla);
        }

        /// <summary>
        /// Lista un campo por id.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public PremiosCamposInfo ListxIdCampo(int IdCampo)
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
        public List<PremiosCamposInfo> ListxComboGenerico(string IdCombo, string ValueCombo, string TablaCombo)
        {
            return module.ListxComboGenerico(IdCombo, ValueCombo, TablaCombo);
        }

        /// <summary>
        /// Lista un campo por nombre.
        /// </summary>
        /// <param name="NombreCampo"></param>
        /// <returns></returns>
        public PremiosCamposInfo ListxNombreCampo(string NombreCampo)
        {
            return module.ListxNombreCampo(NombreCampo);
        }

        #endregion
    }
}
