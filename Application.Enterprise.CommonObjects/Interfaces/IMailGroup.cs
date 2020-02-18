using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de MailGroup
    /// </summary>
    public interface IMailGroup
    {
        #region "Metodos de MailGroup"

        /// <summary>
        /// lista todos los MailGroup existentes.
        /// </summary>
        /// <returns></returns>
        List<MailGroupInfo> List();

        /// <summary>
        /// Obtiene los mailgroup que se encuentran abiertos para procesar de la fecha.
        /// </summary>
        /// <returns></returns>
        List<MailGroupInfo> ListxFechaActual();

        /// <summary>
        ///Obtiene los mailgroup que se encuentran abiertos para procesar de la fecha para la facturacion.
        /// </summary>
        /// <returns></returns>
        List<MailGroupInfo> ListxFechaActualFacturacion();

        /// <summary>
        /// Realiza la actualizacion de un mailplan del sistema por mailgroup.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(MailGroupInfo item);

        /// <summary>
        /// Realiza la actualizacion de un mailplan para factuacion del sistema por mailgroup. Lo deja en estado abierto para facturar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateEstadoFacturacionAbierto(MailGroupInfo item);

        /// <summary>
        /// Realiza la actualizacion de un mailplan para factuacion del sistema por mailgroup. Lo deja en estado cerrado y no se puede facturar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateEstadoFacturacionCerrado(MailGroupInfo item);


        #endregion
    }
}

