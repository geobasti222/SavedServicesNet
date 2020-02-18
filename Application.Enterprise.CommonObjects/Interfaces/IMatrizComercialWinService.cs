using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de CommercialMatrix
    /// </summary>
    public interface IMatrizComercialWinService
    {
        
        /// <summary>
        /// Trae las dos ultimas campañas actuales
        /// </summary>       
        /// <returns></returns>
        DataTable traerInformacionDeCampanaParaProcesar();

        /// <summary>
       /// Primer proceso averiguar estados y almacenar en historico y resumen
       /// </summary>
       /// <param name="opcion"></param>
       /// <param name="rangoparanuevas"></param>
       /// <param name="campana"></param>
        void proceso01(int rangoparanuevas, string campana);

        /// <summary>
       /// Segundo proceso trae los valores de facturas pedidos y devoluciones y los pone en la empresaria correspondiente en el historico
       /// </summary>
       /// <param name="campana"></param>
        void proceso02(string campana);

        /// <summary>
        /// Tercer proceso trae los los valores de metas de cada zona y las pone en el resumen (corpus)
        /// </summary>
        /// <param name="campana"></param>
        void proceso03(string campana);
        

        /// <summary>
        /// CALCULA LOS VALORES(totalempresariasactivas,totalingresos,estencil,capitalizacion) CON BASE A LOS ESTADOS EN EL RESUMEN (CORPUS)
        /// </summary>
        /// <param name="campana"></param>
        void proceso04(string campana);

       /// <summary>
        /// PROCESO 05 CALCULA LOS PORCENTAJES Y PORCENTAJES DE CUMPLIMIENTO DE LOS ESTADOS
        /// </summary>
        /// <param name="campana"></param>
        void proceso05(string campana);
        
        /// <summary>
        /// PROCESO 06 CALCULA LOS VALORES( valorpedidos,numeropedidos,valorpedidosfacturado ) DE PEDIDOS EN LA TABLA RESUMEN (CORPUS)"));                        
        /// </summary>
        /// <param name="campana"></param>
        void proceso06(string campana);

         /// <summary>
        /// CALCULA LOS VALORES( ValorFacturado,ValorDevuelto,FacturacionNeta,OrdenPromedioEmpresaria,NivelServicio,NumeroFacturas,PorCumplFacturacion,FrecuenciaCompra ) DE FACTURA EN LA TABLA RESUMEN (CORPUS) POR CADA ZONA"));
        /// </summary>
        /// <param name="campana"></param>
        void proceso07(string campana);
        
        
        
        
          
    }
}
