using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ZonasReservaEnLinea.
    /// </summary>
    public interface IZonasReservaEnLinea
    {
        #region "Metodos de Zonas Reserva En Linea"

        /// <summary>
        /// Lista todos las zonas que pueden hacer multiples pedidos.
        /// </summary>
        /// <returns></returns>
        List<ZonasReservaEnLineaInfo> List();

        /// <summary>
        /// Consulta si existe una zona para digitar multiples pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        ZonasReservaEnLineaInfo ListxZona(string Zona);

        /// <summary>
        /// Actualizacion de zona de Reserva en linea
        /// </summary>
        /// <param name="objZonasReservaEnLinea"></param>
        /// <returns></returns>
        bool UpdateZonaReservaEnLinea(ZonasReservaEnLineaInfo objZonasReservaEnLinea);

        /// <summary>
        /// Insercion de zona de Reserva en linea
        /// </summary>
        /// <param name="objZonasReservaEnLinea"></param>
        /// <returns></returns>
        bool InsertZonasReservaEnLinea(ZonasReservaEnLineaInfo objZonasReservaEnLinea);

        #endregion
    }
}

