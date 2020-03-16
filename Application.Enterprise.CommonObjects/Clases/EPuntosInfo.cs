﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class EPuntosInfo

    {
        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit ; }
            set { nit = value; }
        }

        private string nombreempresaria;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEmpresaria
        {
            get { return nombreempresaria ; }
            set { nombreempresaria = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona ; }
            set { zona = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private string nombrevendedor;
        /// <summary>
        /// 
        /// </summary>
        public string NombreVendedor
        {
            get { return nombrevendedor ; }
            set { nombrevendedor = value; }
        }

        
        private string lider;
        /// <summary>
        /// 
        /// </summary>
        public string Lider
        {
            get { return lider ; }
            set { lider = value; }
        }

        private string nombrelider;
        /// <summary>
        /// 
        /// </summary>
        public string NombreLider
        {
            get { return nombrelider; }
            set { nombrelider = value; }
        }

        private int puntosefectivos;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosEfectivos
        {
            get { return puntosefectivos; }
            set { puntosefectivos = value; }
        }

        private int puntospedidos;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosPedidos
        {
            get { return puntospedidos; }
            set { puntospedidos = value; }
        }

        private int puntosredimidos;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosRedimidos
        {
            get { return puntosredimidos; }
            set { puntosredimidos = value; }
        }
        private int puntostotal;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosTotal
        {
            get { return puntostotal; }
            set { puntostotal = value; }
        }
        public virtual Error Error
        {
            get;
            set;
        }
    }
}
