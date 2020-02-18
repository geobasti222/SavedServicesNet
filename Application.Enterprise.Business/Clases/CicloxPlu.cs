using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para CicloxPlu
    /// </summary>
    public class CicloxPlu : ICicloxPlu
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CicloxPlu module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CicloxPlu()
        {
            module = new Application.Enterprise.Data.CicloxPlu();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CicloxPlu(string databaseName)
        {
            module = new Application.Enterprise.Data.CicloxPlu(databaseName);
        }

        #region Miembros de ICicloxPlu

        /// <summary>
        /// Lista todos los Ciclos x Plu.
        /// </summary>
        /// <returns></returns>
        public List<CicloxPluInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista el consolidado de los plu e ciclo de vida.
        /// </summary>
        /// <returns></returns>
        public List<CicloxPluInfo> ListConsolidado()
        {
            return module.ListConsolidado();
        }

        /// <summary>
        /// Guarda un Ciclo x Plu nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CicloxPluInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }
        }

        #endregion
    }
}
