using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Zona JA
    /// </summary>
    public interface IZona
    {
        #region "Metodos de Zona"

        /// <summary>
        /// lista todas las Zonas existentes.
        /// </summary>
        /// <returns></returns>
        List<ZonaInfo> List();

        /// <summary>
        /// Lista las zonas de un sector.
        /// </summary>
        /// <returns></returns>
        List<ZonaInfo> ListxSector(string CodSector);

        /// <summary>
        /// Lista las zonas de un mailgroup.
        /// </summary>
        /// <returns></returns>
        List<ZonaInfo> ListxMailGroup(string MailGroup);

        /// <summary>
        /// Lista una zona especifica por id de zona.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        ZonaInfo ListxIdZona(string IdZona);

        /// <summary>
        /// Lista las zonas de una gerente regional.
        /// </summary>
        /// <param name="Regional"></param>
        /// <returns></returns>
        List<ZonaInfo> ListxRegional(string Regional);

        /// <summary>
        /// Lista la informacion completa de todas las zonas existentes.
        /// </summary>
        /// <returns></returns>
        List<ZonaInfo> ListxInformacionZonas();

        /// <summary>
        /// Lista una zona especifica incluyendo zona maestra.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        ZonaInfo ListxIdZonaxZonaMaestra(string IdZona);

        /// <summary>
        /// Realiza la actualizacion del valor del flete de una zona .
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="ValorFlete"></param>
        /// <returns></returns>
        bool UpdateValorFlete(string Zona, decimal ValorFlete, string Usuario);

        /// <summary>
        /// Realiza la actualizacion de los dias borrador, reserva y de gracia.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="DiasBorrador"></param>
        /// <param name="DiasReserva"></param>
        /// <param name="DiasdeGracia"></param>
        /// <returns></returns>
        bool UpdateDiasBorradoReservaGracia(string Zona, int DiasBorrador, int DiasReserva, int DiasdeGracia, string Usuario);


        /// <summary>
        /// Actualiza la informacion de una zona
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(ZonaInfo item);


        /// <summary>
        /// Guarda un Zona nueva.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int Insert(ZonaInfo item);


        /// <summary>
        /// lista todas las Zonas existentes mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <returns></returns>
        List<ZonaInfo> ListAll();

        /// <summary>
        /// lista una Zona en especifico mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// /// <param name="zona"></param>
        /// <returns></returns>
        ZonaInfo ListxZona(string zona);


        /// <summary>
        /// obtiene una Zona existente basado en un vendedor mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        List<ZonaInfo> ListxVendedor(String vendedor);

        #endregion
    }
}
