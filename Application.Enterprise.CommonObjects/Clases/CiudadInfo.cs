using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CiudadInfo
    {
        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }

        private string nombreciudad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad
        {
            get { return nombreciudad; }
            set { nombreciudad = value; }
        }

        private string codestado;
        /// <summary>
        /// 
        /// </summary>
        public string CodEstado
        {
            get { return codestado; }
            set { codestado = value; }
        }

        private string reteica;
        /// <summary>
        /// 
        /// </summary>
        public string ReteIca
        {
            get { return reteica; }
            set { reteica = value; }
        }

        private string codigociudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudad
        {
            get { return codigociudad; }
            set { codigociudad = value; }
        }

        private string codigoserv;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoServientrega
        {
            get { return codigoserv; }
            set { codigoserv = value; }
        }

        private decimal valorflete;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFlete
        {
            get { return valorflete; }
            set { valorflete = value; }
        }

        private int excluidoiva;
        /// <summary>
        /// 
        /// </summary>
        public int ExcluidoIVA
        {
            get { return excluidoiva; }
            set { excluidoiva = value; }
        }

        private decimal iva;
        /// <summary>
        /// 
        /// </summary>
        public decimal IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        private int pedidomin;
        /// <summary>
        /// 
        /// </summary>
        public int PedidoMin
        {
            get { return pedidomin; }
            set { pedidomin = value; }
        }

        private decimal valorfletefull;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFleteFull
        {
            get { return valorfletefull; }
            set { valorfletefull = value; }
        }

        private string codigociudaddespacho;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudadDespacho
        {
            get { return codigociudaddespacho; }
            set { codigociudaddespacho = value; }
        }
    }
    
    public class ZonadeCiudadInfo
    {
        private string zonasasignadaxciudad;
        /// <summary>
        /// 
        /// </summary>
        public string ZonasAsignadaxCiudad
        {
            get { return zonasasignadaxciudad; }
            set { zonasasignadaxciudad = value; }
        }
    }
}
