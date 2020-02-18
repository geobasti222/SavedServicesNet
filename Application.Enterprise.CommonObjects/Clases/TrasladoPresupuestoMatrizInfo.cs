using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class TrasladoPresupuestoMatrizInfo
    {
        private string _campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return _campana; }
            set { _campana = value; }
        }

        private string _zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return _zona; }
            set { _zona = value; }
        }

        private string _descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _activo;
        /// <summary>
        /// 
        /// </summary>
        public int Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        private int _empresarias;
        /// <summary>
        /// 
        /// </summary>
        public int Empresarias
        {
            get { return _empresarias; }
            set { _empresarias = value; }
        }

        private int _nuevas;
        /// <summary>
        /// 
        /// </summary>
        public int Nuevas
        {
            get { return _nuevas; }
            set { _nuevas = value; }
        }

        private int _pegresos;
        /// <summary>
        /// 
        /// </summary>
        public int PEgresos
        {
            get { return _pegresos; }
            set { _pegresos = value; }
        }

        
        private int _retenidas;
        /// <summary>
        /// 
        /// </summary>
        public int Retenidas
        {
            get { return _retenidas; }
            set { _retenidas = value; }
        }

        private int _egresos;
        /// <summary>
        /// 
        /// </summary>
        public int Egresos
        {
            get { return _egresos; }
            set { _egresos = value; }
        }

        private int _inactivas;
        /// <summary>
        /// 
        /// </summary>
        public int Inactivas
        { 
            get { return _inactivas; }
            set { _inactivas = value; }
        }


        private int _reingresos;
        /// <summary>
        /// 
        /// </summary>
        public int Reingresos
        {
            get { return _reingresos; }
            set { _reingresos = value; }
        }

        private decimal _facturacion;
        /// <summary>
        /// 
        /// </summary>
        public decimal Facturacion
        {
            get { return _facturacion; }
            set { _facturacion = value; }
        }

        private string _usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }


        ///parametros cambiados y nuevos:
        
       

        private int npedidos;
        /// <summary>
        /// 
        /// </summary>
        public int NPedidos
        {
            get { return npedidos; }
            set { npedidos = value; }
        }

        private decimal vlr_presupuesto;
        /// <summary>
        /// 
        /// </summary>
        public decimal Vlr_Presupuesto
        {
            get { return vlr_presupuesto; }
            set { vlr_presupuesto = value; }
        }

        private decimal vlr_presupuesto_nivi;
        /// <summary>
        /// 
        /// </summary>
        public decimal Vlr_Presupuesto_Nivi
        {
            get { return vlr_presupuesto_nivi; }
            set { vlr_presupuesto_nivi = value; }
        }

        private decimal vlr_presupuesto_pisame;
        /// <summary>
        /// 
        /// </summary>
        public decimal Vlr_Presupuesto_Pisame
        {
            get { return vlr_presupuesto_pisame; }
            set { vlr_presupuesto_pisame = value; }
        }

        private decimal vlr_presupuesto_outlet;
        /// <summary>
        /// 
        /// </summary>
        public decimal Vlr_Presupuesto_Outlet
        {
            get { return vlr_presupuesto_outlet; }
            set { vlr_presupuesto_outlet = value; }
        }

    }
    
  
}
