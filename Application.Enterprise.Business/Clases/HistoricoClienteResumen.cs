using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class HistoricoClienteResumen : IHistoricoClienteResumen
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.HistoricoClienteResumen module;

        /// <summary>
        /// 
        /// </summary>
        public HistoricoClienteResumen()
        {
            module = new Application.Enterprise.Data.HistoricoClienteResumen();
        }

        public HistoricoClienteResumen(string databaseName)
        {
            module = new Application.Enterprise.Data.HistoricoClienteResumen(databaseName);
        }

        #region Miembros de IHistoricoClienteResumen

        /// <summary>
        /// Cantidad de registros en Historico Resumen
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public HistoricoClienteResumenInfo CantidadRegistros(DateTime fecha)
        {
            return module.CantidadRegistros(fecha);
        }

        /// <summary>
        /// Insercion de los campos que se encuentran en SVDN_CLIENTES_HISTORICO y no se encuentran en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertFromHistoricoToResumen(DateTime fecha)
        {
            try
            {
                return module.InsertFromHistoricoToResumen(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// Se realiza reseteo de registros de prospectos campaña actual en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool ResetProspectosResumen(DateTime fecha)
        {
            try
            {
                return module.ResetProspectosResumen(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }
        

        /// <summary>
        /// Actualizacion de los agrupamientos de estados en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateCantidadEstados(DateTime fecha)
        {
            try
            {
                return module.UpdateCantidadEstados(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Se eliminan los registros duplicados, dejando en todas las combinaciones una sola existencia de la tabla SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool DeleteRegistrosDuplicados(DateTime fecha)
        {
            try
            {
                return module.DeleteRegistrosDuplicados(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }
        
        /// <summary>
        /// Eliminacion de todos los registros del resumen de la campaña  actual
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool VaciadoResumenCampanaActual(DateTime fecha)
        {
            try
            {
                return module.VaciadoResumenCampanaActual(fecha);
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
