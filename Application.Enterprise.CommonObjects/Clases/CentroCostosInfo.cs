using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CentroCostosInfo
    {
        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos.Trim(); }
            set { ccostos = value; }
        }

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private DateTime fecha;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string cuenta_ajusteinventarios;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaAjusteinventarios
        {
            get { return cuenta_ajusteinventarios; }
            set { cuenta_ajusteinventarios = value; }
        }

        private string cuenta_ajustecmv;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaAjusteCMV
        {
            get { return cuenta_ajustecmv; }
            set { cuenta_ajustecmv = value; }
        }

        private string centrocostos;
        /// <summary>
        /// 
        /// </summary>
        public string CentroCostos
        {
            get { return centrocostos.Trim(); }
            set { centrocostos = value; }
        }

        private decimal plu;
        /// <summary>
        /// 
        /// </summary>
        public decimal PLU
        {
            get { return plu; }
            set { plu = value; }
        }

        private string codubicacion;
        /// <summary>
        /// 
        /// </summary>
        public string CodUbicacion
        {
            get { return codubicacion.Trim(); }
            set { codubicacion = value; }
        }

    }
}
