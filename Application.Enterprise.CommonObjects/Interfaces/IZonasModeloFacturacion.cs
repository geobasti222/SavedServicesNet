using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IZonasModeloFacturacion
    {
        #region "Metodos de Zonas Modelo Facturacion"
        /// <summary>
        /// lista todas las ZonasModeloFacturacion existentes.
        /// </summary>
        /// <returns></returns>
        List<ZonasModeloFacturacionInfo> List();

        /// <summary>
        /// lista todas las ZonasModeloFacturacion existentes.
        /// </summary>
        /// <returns></returns>
        List<ZonasModeloFacturacionInfo> ListModelosYReserva(string zona = null);

        /// <summary>
        /// Lista las zonas que no esten en los modelos de facturacion y reserva en linea
        /// </summary>
        /// <returns></returns>
        List<ZonasModeloFacturacionInfo> ZonasSinReservaNiModeloFacturacion();


        /// <summary>
        /// Insercion del modelo de facturacion de una zona
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        bool InsertZonasModeloFacturacion(ZonasModeloFacturacionInfo objZonasModeloFacturacion);

        /// <summary>
        /// Actualizacion del modelo de facturacion de una zona
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        bool UpdateZonasModeloFacturacion(ZonasModeloFacturacionInfo objZonasModeloFacturacion);

        /// <summary>
        /// Eliminacion de una zona de la tabla de mosdelos de facturacion
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        bool EliminarZonasModeloFacturacion(string zona, string Usuario);

        #endregion
    }
}
