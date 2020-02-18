using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ClasificacionXValorProceso
    /// </summary>
    public class MatrizComercialWinService : IMatrizComercialWinService
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MatrizComercialWinService module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MatrizComercialWinService()
        {
            module = new Application.Enterprise.Data.MatrizComercialWinService();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MatrizComercialWinService(string databaseName)
        {
            module = new Application.Enterprise.Data.MatrizComercialWinService(databaseName);
        }

         /// <summary>
        /// Trae las dos ultimas campañas actuales
        /// </summary>
        /// <returns></returns>
        public DataTable traerInformacionDeCampanaParaProcesar()
        {
            return module.traerInformacionDeCampanaParaProcesar();
        }

       /// <summary>
       /// Primer proceso averiguar estados y almacenar en historico y resumen
       /// </summary>
       /// <param name="opcion"></param>
       /// <param name="rangoparanuevas"></param>
       /// <param name="campana"></param>
        public void proceso01( int rangoparanuevas, string campana)
        {
            module.proceso01( rangoparanuevas, campana);
        }

       /// <summary>
       /// Segundo proceso trae los valores de facturas pedidos y devoluciones y los pone en la empresaria correspondiente en el historico
       /// </summary>
       /// <param name="campana"></param>
        public void proceso02( string campana)
        {
            module.proceso02(campana);
        }

        /// <summary>
        /// PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS ESTADOSANTERIORES POR LA MATRIZ VIEJA FEA-
        /// </summary>
        /// <param name="campana"></param>
        public void proceso03(string campana)
        {
            module.proceso03(campana);
        }

        /// <summary>
        /// CALCULA LOS VALORES(totalempresariasactivas,totalingresos,estencil,capitalizacion) CON BASE A LOS ESTADOS EN EL RESUMEN (CORPUS)
        /// </summary>
        /// <param name="campana"></param>
        public void proceso04(string campana)
        {
            module.proceso04(campana);
        }

        /// <summary>
        /// PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA Y CAMPANA DE METAS EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso05(string campana)
        {
            module.proceso05(campana);
        }

        /// <summary>
        /// EGIN VARIABLES CALCULADAS CON BASE A ESTADOS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso06(string campana)
        {
            module.proceso06(campana);
        }

         /// <summary>
        ///  BEGIN PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA PORCENTAJES Y CAMPANA DE PORCENTAJES EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso07(string campana)
        {
            module.proceso07(campana);
        }

         /// <summary>
        ///  BEGIN PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA DE PEDIDOS Y CAMPANA DE PEDIDOS EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso08(string campana)
        {
            module.proceso08(campana);
        }

         /// <summary>
        /// BEGIN PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA Y CAMPANA DE FACTURAS EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso09(string campana)
        {
             module.proceso09(campana);
        }
        
    }
}
