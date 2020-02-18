using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ZonasModeloFacturacionInfo
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

        private bool modeloasignacioninventario;
        /// <summary>
        /// 
        /// </summary>
        public bool ModeloAsignacionInventario
        {
            get { return modeloasignacioninventario; }
            set { modeloasignacioninventario = value; }
        }

        private bool modeloreservalinea;
        /// <summary>
        /// 
        /// </summary>
        public bool ModeloReservaLinea
        {
            get { return modeloreservalinea; }
            set { modeloreservalinea = value; }
        }

        private bool diaria;
        /// <summary>
        /// 
        /// </summary>
        public bool Diaria
        {
            get { return diaria; }
            set { diaria = value; }
        }

        private bool veintedias;
        /// <summary>
        /// 
        /// </summary>
        public bool VeinteDias
        {
            get { return veintedias; }
            set { veintedias = value; }
        }

        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario.Trim(); }
            set { usuario = value; }
        }


    }
}
