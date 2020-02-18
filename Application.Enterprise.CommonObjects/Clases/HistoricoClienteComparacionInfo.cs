using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class HistoricoClienteComparacionInfo
    {
        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        /*-------------------------------------------------
         *   VARIABLES DE LA CAMPAÑA ACTUAL
         -------------------------------------------------*/

        private int activasactual;
        /// <summary>
        /// 
        /// </summary>
        public int ActivasActual
        {
            get { return activasactual; }
            set { activasactual = value; }
        }

        private decimal capitalizacionactual;
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalizacionActual
        {
            get { return capitalizacionactual; }
            set { capitalizacionactual = value; }
        }

        private decimal stencilfinalactual;
        /// <summary>
        /// 
        /// </summary>
        public decimal StencilFinalActual
        {
            get { return stencilfinalactual; }
            set { stencilfinalactual = value; }
        }

        private decimal ordenpromedioactual;
        /// <summary>
        /// 
        /// </summary>
        public decimal OrdenPromedioActual
        {
            get { return ordenpromedioactual; }
            set { ordenpromedioactual = value; }
        }

        private decimal valorpedidosactual;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPedidosActual
        {
            get { return valorpedidosactual; }
            set { valorpedidosactual = value; }
        }

        private decimal actividadstencilfinalactual;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActividadStencilFinalActual
        {
            get { return actividadstencilfinalactual; }
            set { actividadstencilfinalactual = value; }
        }
            
        
        /*-------------------------------------------------
         *   VARIABLES DE LA CAMPAÑA ANTERIOR
         -------------------------------------------------*/
        
        private int activasanterior;
        /// <summary>
        /// 
        /// </summary>
        public int ActivasAnterior
        {
          get { return activasanterior; }
          set { activasanterior = value; }
        }

        private decimal capitalizacionanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalizacionAnterior
        {
            get { return capitalizacionanterior; }
            set { capitalizacionanterior = value; }
        }

        private decimal stencilfinalanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal StencilFinalAnterior
        {
            get { return stencilfinalanterior; }
            set { stencilfinalanterior = value; }
        }

        private decimal ordenpromedioanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal OrdenPromedioAnterior
        {
            get { return ordenpromedioanterior; }
            set { ordenpromedioanterior = value; }
        }

        private decimal valorpedidosanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPedidosAnterior
        {
            get { return valorpedidosanterior; }
            set { valorpedidosanterior = value; }
        }

        private decimal actividadstencilfinalanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActividadStencilFinalAnterior
        {
            get { return actividadstencilfinalanterior; }
            set { actividadstencilfinalanterior = value; }
        }
        
        
        /*------------------------------------------------------
         *   VARIABLES DE LA CAMPAÑA AÑO ANTERIOR
         -----------------------------------------------------*/

        private int activasanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public int ActivasAnoAnterior
        {
            get { return activasanoanterior; }
            set { activasanoanterior = value; }
        }

        private decimal capitalizacionanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalizacionAnoAnterior
        {
            get { return capitalizacionanoanterior; }
            set { capitalizacionanoanterior = value; }
        }

        private decimal stencilfinalanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal StencilFinalAnoAnterior
        {
            get { return stencilfinalanoanterior; }
            set { stencilfinalanoanterior = value; }
        }

        private decimal ordenpromedioanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal OrdenPromedioAnoAnterior
        {
            get { return ordenpromedioanoanterior; }
            set { ordenpromedioanoanterior = value; }
        }

        private decimal valorpedidosanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPedidosAnoAnterior
        {
            get { return valorpedidosanoanterior; }
            set { valorpedidosanoanterior = value; }
        }

        private decimal actividadstencilfinalanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActividadStencilFinalAnoAnterior
        {
            get { return actividadstencilfinalanoanterior; }
            set { actividadstencilfinalanoanterior = value; }
        }
        

        /*------------------------------------------------------
         *   VARIABLES COMPARATIVAS DE LA CAMPAÑA ANTERIOR
         -----------------------------------------------------*/

        private decimal activascomparativoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActivasComparativoAnterior
        {
            get { return activascomparativoanterior; }
            set { activascomparativoanterior = value; }
        }

        private decimal capitalizacioncomparativoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalizacionComparativoAnterior
        {
            get { return capitalizacioncomparativoanterior; }
            set { capitalizacioncomparativoanterior = value; }
        }

        private decimal stencilfinalcomparativoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal StencilFinalComparativoAnterior
        {
            get { return stencilfinalcomparativoanterior; }
            set { stencilfinalcomparativoanterior = value; }
        }

        private decimal ordenpromediocomparativoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal OrdenPromedioComparativoAnterior
        {
            get { return ordenpromediocomparativoanterior; }
            set { ordenpromediocomparativoanterior = value; }
        }

        private decimal valorpedidoscomparativoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPedidosComparativoAnterior
        {
            get { return valorpedidoscomparativoanterior; }
            set { valorpedidoscomparativoanterior = value; }
        }

        private decimal actividadstencilfinalcomparativoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActividadStencilFinalComparativoAnterior
        {
            get { return actividadstencilfinalcomparativoanterior; }
            set { actividadstencilfinalcomparativoanterior = value; }
        }


        /*------------------------------------------------------
         *   VARIABLES COMPARATIVAS DE LA CAMPAÑA AÑO ANTERIOR
         -----------------------------------------------------*/

        private decimal activascomparativoanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActivasComparativoAnoAnterior
        {
            get { return activascomparativoanoanterior; }
            set { activascomparativoanoanterior = value; }
        }

        private decimal capitalizacioncomparativoanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalizacionComparativoAnoAnterior
        {
            get { return capitalizacioncomparativoanoanterior; }
            set { capitalizacioncomparativoanoanterior = value; }
        }

        private decimal stencilfinalcomparativoanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal StencilFinalComparativoAnoAnterior
        {
            get { return stencilfinalcomparativoanoanterior; }
            set { stencilfinalcomparativoanoanterior = value; }
        }

        private decimal ordenpromediocomparativoanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal OrdenPromedioComparativoAnoAnterior
        {
            get { return ordenpromediocomparativoanoanterior; }
            set { ordenpromediocomparativoanoanterior = value; }
        }

        private decimal valorpedidoscomparativoanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPedidosComparativoAnoAnterior
        {
            get { return valorpedidoscomparativoanoanterior; }
            set { valorpedidoscomparativoanoanterior = value; }
        }

        private decimal actividadstencilfinalcomparativoanoanterior;
        /// <summary>
        /// 
        /// </summary>
        public decimal ActividadStencilFinalComparativoAnoAnterior
        {
            get { return actividadstencilfinalcomparativoanoanterior; }
            set { actividadstencilfinalcomparativoanoanterior = value; }
        }

    }
}
