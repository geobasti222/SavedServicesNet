using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class GeografiaEcuInfo
    {
        private string codigo;
        /// <summary>
        /// 
        /// </summary>
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string codprovincia;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoProvincia
        {
            get { return codprovincia; }
            set { codprovincia = value; }
        }

        private string nomprovincia;
        /// <summary>
        /// 
        /// </summary>
        public string NombreProvincia
        {
            get { return nomprovincia; }
            set { nomprovincia = value; }
        }

        private string codcanton;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCanton
        {
            get { return codcanton; }
            set { codcanton = value; }
        }

        private string nomcanton;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCanton
        {
            get { return nomcanton; }
            set { nomcanton = value; }
        }

        private string codparroquia;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoParroquia
        {
            get { return codparroquia; }
            set { codparroquia = value; }
        }

        private string nomparroquia;
        /// <summary>
        /// 
        /// </summary>
        public string NombreParroquia
        {
            get { return nomparroquia; }
            set { nomparroquia = value; }
        }

        private decimal hombres;
        /// <summary>
        /// 
        /// </summary>
        public decimal Hombres
        {
            get { return hombres; }
            set { hombres = value; }
        }

        private decimal mujer;
        /// <summary>
        /// 
        /// </summary>
        public decimal Mujer
        {
            get { return mujer; }
            set { mujer = value; }
        }

        private decimal total;
        /// <summary>
        /// 
        /// </summary>
        public decimal Total
        {
            get { return total; }
            set { total = value; }
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

      
    }
}
