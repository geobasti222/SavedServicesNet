using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Zonas Multi Pedidos
    /// </summary>
    public class ZonasReservaEnLinea : IZonasReservaEnLinea
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ZonasReservaEnLinea module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ZonasReservaEnLinea()
        {
            module = new Application.Enterprise.Data.ZonasReservaEnLinea();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ZonasReservaEnLinea(string databaseName)
        {
            module = new Application.Enterprise.Data.ZonasReservaEnLinea(databaseName);
        }

        #region Miembros de IZonasReservaEnLinea
        /// <summary>
        /// Lista todos las zonas que pueden hacer multiples pedidos.
        /// </summary>
        /// <returns></returns>
        public List<ZonasReservaEnLineaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Consulta si existe una zona para digitar multiples pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public ZonasReservaEnLineaInfo ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }

        /// <summary>
        /// Actualizacion de zona de Reserva en linea
        /// </summary>
        /// <param name="objZonasReservaEnLinea"></param>
        /// <returns></returns>
        public bool UpdateZonaReservaEnLinea(ZonasReservaEnLineaInfo objZonasReservaEnLinea)
        {
            try
            {
                return module.UpdateZonasReservaEnLinea(objZonasReservaEnLinea);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        public bool InsertZonasReservaEnLinea(ZonasReservaEnLineaInfo objZonasReservaEnLinea)
        {
            try
            {
                return module.InsertZonasReservaEnLinea(objZonasReservaEnLinea);
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
