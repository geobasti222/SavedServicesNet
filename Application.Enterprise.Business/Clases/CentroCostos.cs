using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Centro Costos
    /// </summary>
    public class CentroCostos : ICentroCostos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CentroCostos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CentroCostos()
        {
            module = new Application.Enterprise.Data.CentroCostos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CentroCostos(string databaseName)
        {
            module = new Application.Enterprise.Data.CentroCostos(databaseName);
        }

        #region Miembros de ICentroCostos
        /// <summary>
        /// lista todos los centros de costos existentes.
        /// </summary>
        /// <returns></returns>
        public List<CentroCostosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un Centros de Costos por ccostos
        /// </summary>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        public CentroCostosInfo ListxCCostos(string CCostos)
        {
            return module.ListxCCostos(CCostos);
        }

        /// <summary>
        ///Guarda un centro de costos nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(CentroCostosInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }



        #endregion
    }
}
