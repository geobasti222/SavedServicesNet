using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Campaña JA
    /// </summary>
    public class Campana : ICampana
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Campana module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Campana()
        {
            module = new Application.Enterprise.Data.Campana();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Campana(string databaseName)
        {
            module = new Application.Enterprise.Data.Campana(databaseName);
        }

        #region Miembros de ICampana
        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> List()
        {
            return module.List();
        }

        public List<CampanaInfo>  ListCampanasPresenteFutura()
        {
        return module.ListCampanasPresenteFutura(); 
        }

       

        /// <summary>
        /// lista por una campaña especifica.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public CampanaInfo ListxCampana(string Campana)
        {
            return module.ListxCampana(Campana);
        }

        /// <summary>
        /// Lista la campaña activa por en la que se encuenta la fecha actual.
        /// </summary>
        /// <returns></returns>
        public CampanaInfo ListxGetDate()
        {
            return module.ListxGetDate();
        }

        /// <summary>
        /// Lista la campaña final de un año.
        /// </summary>
        /// <param name="Anio"></param>
        /// <returns></returns>
        public CampanaInfo ListUltimaCampanaxAnio(string Anio)
        {
            return module.ListUltimaCampanaxAnio(Anio);
        }

        /// <summary>
        /// Lista la capaña final del  año vigente
        /// </summary>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public CampanaInfo ListxCampanaFinal(string Ano)
        {
            return module.ListxCampanaFinal(Ano);
        }

        /// <summary>
        /// Lista las capañas del  año vigente
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasAno()
        {
            return module.ListCampanasAno();
        }

        /// <summary>
        /// Lista las campañas de un catalogo
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasXCatalogo(string catalogo)
        {
            return module.ListCampanasXCatalogo(catalogo);
        }


        /// <summary>
        /// Lista las ultimas 10 campañas
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListUltimasCampanas()
        {
            return module.ListUltimasCampanas();
        }

        ///// <summary>
        ///// Lista una cantidad de campanas definidas desde la ultima
        ///// </summary>
        ///// <param name="cantidad">Cantidad de Campanas</param>
        ///// <returns></returns>
        //public List<CampanaInfo> ListUltimas_X_Campanas(int cantidad)
        //{
        //    return module.ListUltimas_X_Campanas(cantidad);
        //}

        /// <summary>
        /// Lista la campaña activa en la que se encuenta la fecha actual y la campaña anterior.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanaActualAnterior()
        {
            return module.ListCampanaActualAnterior();
        }

        /// <summary>
        /// Lista las campañas del año actual
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasAnoActual()
        {
            return module.ListCampanasAnoActual();
        }

        /// <summary>
        /// Lista todas las campañas que se encuentren registradas desde la tabla de historico cliente
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasHistoricoCliente()
        {
            return module.ListCampanasHistoricoCliente();
        }

        /// <summary>
        /// Lista por una campaña especifica, devuelve una lista.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<CampanaInfo> ListxCampanaLista(string Campana)
        {
            return module.ListxCampanaLista(Campana);
        }

        /// <summary>
        /// Lista la campaña actual y la anterior.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanaActualyAnterior()
        {
            return module.ListCampanaActualyAnterior();
        }

         /// <summary>
        /// Lista las campañas que existan en el mailplan de facturacion de 21 dias abiertas.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanaDeMailPlan()
        {
            return module.ListCampanaDeMailPlan();
        }

        public List<CampanaInfo> ListCampanasAnoActualFiltradas()
        {
            return module.ListCampanasAnoActualFiltradas();
        }

        /// <summary>
        /// Lista las 3 ultimas campañas.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListUltimasTresCampanas()
        {
            return module.ListUltimasTresCampanas();
        }

        /// <summary>
        /// Guarda una campana nueva.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CampanaInfo item)
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
        /// Realiza la actualizacion de una campana existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(CampanaInfo item)
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
        /// Realiza la consulta de las campañas que se interponen con otras.
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <returns></returns>
         public List<CampanaInfo> ListCampanasTrasponen(DateTime fechaini, DateTime fechafin)
        {
            return module.ListCampanasTrasponen(fechaini,fechafin);
        }


         /// <summary>
        /// lista campañas preventa
        /// </summary>
        /// <returns></returns>
         public List<CampanaInfo> Listxidpreventa(string campana)
         {
             return module.Listxidpreventa(campana);
         }
        #endregion
    }
}
