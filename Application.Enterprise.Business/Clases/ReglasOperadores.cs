using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReglasOperadores
    /// </summary>
    public class ReglasOperadores : IReglasOperadores
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglasOperadores module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasOperadores()
        {
            module = new Application.Enterprise.Data.ReglasOperadores();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasOperadores(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglasOperadores(databaseName);
        }

        #region Miembros de IReglasOperadores
         /// <summary>
        /// Lista todos los operadores para los campos de las reglas.
        /// </summary>
        /// <returns></returns>
        public List<ReglasOperadoresInfo> List()
        {
            return module.List();
        }     

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public List<ReglasOperadoresInfo> ListxIdCampo(int IdCampo)
        {
            return module.ListxIdCampo(IdCampo);
        }     

        /// <summary>
        /// Consulta un operador por ID.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        public ReglasOperadoresInfo ListxId(int IdOperador)
        {
            return module.ListxId(IdOperador);
        }

        #endregion
    }
}
