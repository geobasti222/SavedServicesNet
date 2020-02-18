using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Campaña JA
    /// </summary>
    public interface ICampana
    {
        #region "Metodos de Campaña"

        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> List();

        /// <summary>
        /// lista por una campaña especifica.
        /// </summary>
        /// <returns></returns>
        CampanaInfo ListxCampana(string Campana);

        /// <summary>
        /// Lista la campaña activa por en la que se encuenta la fecha actual.
        /// </summary>
        /// <returns></returns>
        CampanaInfo ListxGetDate();

        /// <summary>
        /// Lista la campaña final de un año.
        /// </summary>
        /// <param name="Anio"></param>
        /// <returns></returns>
        CampanaInfo ListUltimaCampanaxAnio(string Anio);

        /// <summary>
        /// Lista la capaña final del  año vigente
        /// </summary>
        /// <param name="Ano"></param>
        /// <returns></returns>
        CampanaInfo ListxCampanaFinal(string Ano);

        /// <summary>
        /// Lista las capañas del  año vigente
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanasAno();

        /// <summary>
        /// Lista las campañas de un catalogo
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanasXCatalogo(string catalogo);

        ///// <summary>
        ///// Lista una cantidad de campanas definidas desde la ultima
        ///// </summary>
        ///// <param name="cantidad">Cantidad de Campanas</param>
        ///// <returns></returns>
        //List<CampanaInfo> ListUltimas_X_Campanas(int cantidad);

        /// <summary>
        /// Lista las campañas del año actual
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanasAnoActual();

        /// <summary>
        /// Lista todas las campañas que se encuentren registradas desde la tabla de historico cliente
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanasHistoricoCliente();

        /// <summary>
        /// Lista por una campaña especifica, devuelve una lista.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<CampanaInfo> ListxCampanaLista(string Campana);

        /// <summary>
        /// Lista la campaña actual y la anterior.
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanaActualyAnterior();

        /// <summary>
        /// Lista las campañas que existan en el mailplan de facturacion de 21 dias abiertas.
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanaDeMailPlan();


        /// <summary>
        /// Lista las campañas del año actual filtradas.
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampanasAnoActualFiltradas();

        /// <summary>
        /// Lista las 3 ultimas campañas.
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListUltimasTresCampanas();

        /// <summary>
        /// Guarda una campana nueva.
        /// </summary>
        /// <param name="item"></param>
        int Insert(CampanaInfo item);

        /// <summary>
        /// Realiza la actualizacion de una campana existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(CampanaInfo item);

         /// <summary>
        /// Realiza la consulta de las campañas que se interponen con otras.
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <returns></returns>
        List<CampanaInfo> ListCampanasTrasponen(DateTime fechaini, DateTime fechafin);

         /// <summary>
        /// lista campañas preventa
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> Listxidpreventa(string campana);
        


        #endregion
    }
}

