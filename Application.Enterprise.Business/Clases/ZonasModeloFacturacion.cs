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
    public class ZonasModeloFacturacion : IZonasModeloFacturacion
    {
        /// <summary>
        /// 
        /// </summary>
        private Application.Enterprise.Data.ZonasModeloFacturacion module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ZonasModeloFacturacion()
        {
            module = new Application.Enterprise.Data.ZonasModeloFacturacion();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName"></param>
        public ZonasModeloFacturacion(string databaseName)
        {
            module = new Application.Enterprise.Data.ZonasModeloFacturacion(databaseName);
        }

        #region Miembros de IZonasMultiPedidos
        /// <summary>
        /// lista todas las ZonasModeloFacturacion existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonasModeloFacturacionInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista todas las ZonasModeloFacturacion existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonasModeloFacturacionInfo> ListModelosYReserva(string zona = null)
        {
            return module.ListModelosYReserva(zona);
        }

        /// <summary>
        /// Lista las zonas que tienen pedidos activos
        /// </summary>
        /// <returns></returns>
        public bool ListZonasActivas(string zona )
        {
            return module.ListZonasActivas(zona);
        }

        /// <summary>
        /// Lista las zonas que no esten en los modelos de facturacion y reserva en linea
        /// </summary>
        /// <returns></returns>
        public List<ZonasModeloFacturacionInfo> ZonasSinReservaNiModeloFacturacion()
        { 
            return module.ZonasSinReservaNiModeloFacturacion();
        }

        /// <summary>
        /// Insercion del modelo de facturacion de una zona
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        public bool InsertZonasModeloFacturacion(ZonasModeloFacturacionInfo objZonasModeloFacturacion)
        {
            try
            {
                return module.InsertZonasModeloFacturacion(objZonasModeloFacturacion);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Actualizacion del modelo de facturacion de una zona
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        public bool UpdateZonasModeloFacturacion(ZonasModeloFacturacionInfo objZonasModeloFacturacion)
        {
            try
            {
                return module.UpdateZonasModeloFacturacion(objZonasModeloFacturacion);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Eliminacion de una zona de la tabla de mosdelos de facturacion
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public bool EliminarZonasModeloFacturacion(string zona, string Usuario)
        {
            try
            {
                return module.EliminarZonasModeloFacturacion(zona, Usuario);
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
