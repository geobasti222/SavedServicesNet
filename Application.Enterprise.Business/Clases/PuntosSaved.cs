using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PuntosSaved
    /// </summary>
    public class PuntosSaved : IPuntosSaved
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PuntosSaved module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PuntosSaved()
        {
            module = new Application.Enterprise.Data.PuntosSaved();
        }

            /// <summary>
            /// Constructor de la clase.
            /// </summary>
            /// <param name="databaseName">Nombre de la Base de Datos.</param>
            public PuntosSaved(string databaseName)
        {
            module = new Application.Enterprise.Data.PuntosSaved(databaseName);
        }

        #region Miembros de IPuntosSaved

        /// <summary>
        /// lista los puntos efectivos de una empresaria
        /// </summary>
        /// <returns></returns>
        public int ConsultarPuntosEfectivosEmpresaria(string nit)
        {
            return module.ConsultarPuntosEfectivosEmpresaria(nit);
        }

        /// <summary>
        /// Guarda un InsertDetallePuntos nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertDetallePuntos(PuntosSavedInfo item)
        {
            try
            {
                return module.InsertDetallePuntos(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda un InsertPuntosTotal nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertPuntosTotal(PuntosSavedInfo item)
        {
            try
            {
                return module.InsertPuntosTotal(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// Guarda un InsertDetallePuntosAdicionales nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertDetallePuntosAdicionales(PuntosSavedInfo item)
        {
            try
            {
                return module.InsertDetallePuntosAdicionales(item);
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
