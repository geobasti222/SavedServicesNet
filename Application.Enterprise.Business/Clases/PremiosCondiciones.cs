using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Premios Condiciones
    /// </summary>
    public class PremiosCondiciones : IPremiosCondiciones
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosCondiciones module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosCondiciones()
        {
            module = new Application.Enterprise.Data.PremiosCondiciones();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosCondiciones(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosCondiciones(databaseName);
        }

        #region Miembros de IPremiosCondiciones
        /// <summary>
        /// lista todos las condiciones existentes.
        /// </summary>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos las condiciones de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdPremio(int IdPremio)
        {
            return module.ListxIdPremio(IdPremio);
        }

        /// <summary>
        /// Lista todos las reglas-condiciones (query's) activas.
        /// </summary>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxReglasPremios()
        {
            return module.ListxReglasPremios();
        }

        /// <summary>
        /// Lista un id de articulo por ID de condicion.
        /// </summary>
        /// <param name="IdCondicion"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdArticulo(int IdCondicion)
        {
            return module.ListxIdArticulo(IdCondicion);
        }

         /// <summary>
        /// Lista todos las condiciones que no son de niveles de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdPremioSinNiveles(int IdPremio)
        {
            return module.ListxIdPremioSinNiveles(IdPremio);
        }

         /// <summary>
        /// Lista todos las condiciones que solos son de niveles de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdPremioSoloNiveles(int IdPremio)
        {
            return module.ListxIdPremioSoloNiveles(IdPremio);
        }

        /// <summary>
        /// Realiza el registro de una condicion para los premios.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosCondicionesInfo item)
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

        /// <summary>
        /// Realiza la actualizacion de una condicion.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PremiosCondicionesInfo item)
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
        /// Elimina todas las condiciones de un premio.
        /// </summary>
        /// <param name="IdPremio">IdPremio</param>
        /// <returns></returns>
        public bool DeleteCondiciones(int IdPremio)
        {
            try
            {
                return module.DeleteCondiciones(IdPremio);
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
