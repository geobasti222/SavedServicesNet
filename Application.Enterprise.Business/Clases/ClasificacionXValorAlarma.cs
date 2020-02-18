using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ClasificacionXValorProceso
    /// </summary>
    
    public class ClasificacionXValorAlarma : IClasificacionXValorAlarma
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ClasificacionXValorAlarma module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ClasificacionXValorAlarma()
        {
            module = new Application.Enterprise.Data.ClasificacionXValorAlarma();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ClasificacionXValorAlarma(string databaseName)
        {
            module = new Application.Enterprise.Data.ClasificacionXValorAlarma(databaseName);
        }

        #region Miembros de IClasificacionXValorAlarma

        /// <summary>
        /// LISTA TODAS LAS ALARMAS DE UN ESTADO Y/O NIT Y/O CAMPAÑA ESPECIFICO(A)(S)
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorAlarmaInfo> ListX(ClasificacionXValorAlarmaInfo item)
        {
            return module.ListX(item);
        }

        /// <summary>
        /// Ejecuta procedimiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ClasificacionXValorAlarmaInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Ejecuta procedimiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Proceso(ClasificacionXValorAlarmaInfo item)
        {
            try
            {
                return module.Proceso(item);
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
