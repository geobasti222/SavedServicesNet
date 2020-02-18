using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Premios Operadores
    /// </summary>
    public class PremiosOperadores : IPremiosOperadores
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosOperadores module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosOperadores()
        {
            module = new Application.Enterprise.Data.PremiosOperadores();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosOperadores(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosOperadores(databaseName);
        }

        #region Miembros de IPremiosOperadores
        /// <summary>
        /// Lista todos los operadores para los campos de las reglas.
        /// </summary>
        /// <returns></returns>
        public List<PremiosOperadoresInfo> List()
        {
            return module.List();
        }     

        /// <summary>
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public List<PremiosOperadoresInfo> ListxIdCampo(int IdCampo)
        {
            return module.ListxIdCampo(IdCampo);
        }     

        /// <summary>
        /// Consulta un operador por ID.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        public PremiosOperadoresInfo ListxId(int IdOperador)
        {
            return module.ListxId(IdOperador);
        }

        /// <summary>
        /// Consulta un operador por valor.
        /// </summary>
        /// <param name="ValorOperador"></param>
        /// <returns></returns>
        public PremiosOperadoresInfo ListxValor(string ValorOperador)
        {
            return module.ListxValor(ValorOperador);
        }

        #endregion
    }
}
