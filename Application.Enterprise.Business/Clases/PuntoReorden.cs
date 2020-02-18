using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class PuntoReorden : IPuntoReorden
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PuntoReorden module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PuntoReorden()
        {
            module = new Application.Enterprise.Data.PuntoReorden();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PuntoReorden(string databaseName)
        {
            module = new Application.Enterprise.Data.PuntoReorden(databaseName);
        }

        #region Miembros de IPuntoReorden
        /// <summary>
        /// Lista todas las configuraciones de punto de reorden.
        /// </summary>
        /// <returns></returns>
        public List<PuntoReordenInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista la configuracion de un punto de reorden x plu.
        /// </summary>
        /// <param name="Plu"></param>
        /// <returns></returns>
        public PuntoReordenInfo ListxPlu(int Plu)
        {
            return module.ListxPlu(Plu);
        }

        /// <summary>
        /// Realiza el bloqueo de los plus por punto de reorden.
        /// </summary>
        /// <returns></returns>
        public bool BloquearxPuntoReorden()
        {
            try
            {
                return module.BloquearxPuntoReorden();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }

        }

        /// <summary>
        /// Realiza la actualizacion de un punto de reorden.
        /// </summary>
        /// <param name="Plu"></param>
        /// <returns></returns>
        public bool Update(PuntoReordenInfo item)
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
        #endregion
    }
}
