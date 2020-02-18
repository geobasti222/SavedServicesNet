using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para TrasladoDet
    /// </summary>
    public class TrasladoDet : ITrasladoDet
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TrasladoDet module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TrasladoDet()
        {
            module = new Application.Enterprise.Data.TrasladoDet();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TrasladoDet(string databaseName)
        {
            module = new Application.Enterprise.Data.TrasladoDet(databaseName);
        }

        #region Miembros de ITrasladoDet

        /// <summary>
        /// Guarda un encabezado de traslado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Insert(TrasladoDetInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }


        /// <summary>
        /// Lista todos los detalles de traslados.
        /// </summary>
        /// <returns></returns>
        public List<TrasladoDetInfo> List()
        {
            return module.List();
        }

        #endregion
    }
}
