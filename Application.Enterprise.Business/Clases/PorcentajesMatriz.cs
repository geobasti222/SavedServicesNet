using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class PorcentajesMatriz : IPorcentajesMatriz
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PorcentajesMatriz module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PorcentajesMatriz()
        {
            module = new Application.Enterprise.Data.PorcentajesMatriz();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PorcentajesMatriz(string databaseName)
        {
            module = new Application.Enterprise.Data.PorcentajesMatriz(databaseName);
        }

        #region Miembros de IPais
        /// <summary>
        /// lista todos los Porcentanjes de Matriz existentes.
        /// </summary>
        /// <returns></returns>
        public List<PorcentajesMatrizInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista el procentaje de un concept especifico de la matriz comercial por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PorcentajesMatrizInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }

        #endregion
    }
}
