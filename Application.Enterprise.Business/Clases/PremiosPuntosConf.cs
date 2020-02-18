using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PremiosPuntosConf
    /// </summary>
    public class PremiosPuntosConf : IPremiosPuntosConf
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosPuntosConf module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosPuntosConf()
        {
            module = new Application.Enterprise.Data.PremiosPuntosConf();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosPuntosConf(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosPuntosConf(databaseName);
        }

        #region Miembros de IPremiosPuntosConf

         /// <summary>
        /// Realiza el registro de una configuracion de puntos.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosPuntosConfInfo item)
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
        ///Lista todos los puntos configuracion
        /// </summary>
        /// <returns></returns>
        public List<PremiosPuntosConfInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// muestra la configuracion de los puntos por id de configuracion.
        /// </summary>
        /// <param name="IdConfiguracion"></param>
        /// <returns></returns>
        public PremiosPuntosConfInfo ListxIdConfiguracion(int IdConfiguracion)
        {
            return module.ListxIdConfiguracion(IdConfiguracion);
        }

        /// <summary>
        /// muestra la configuracion de los puntos por id del campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public PremiosPuntosConfInfo ListxIdCampo(int IdCampo)
        {
            return module.ListxIdCampo(IdCampo);
        }

        #endregion
    }
}
