using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ProductosCatalogoInfo
    {
        private string idcatalogo;
        /// <summary>
        /// 
        /// </summary>
        public string IdCatalogo
        {
            get { return idcatalogo; }
            set { idcatalogo = value; }
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

        private string codubicacion;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoUbicacion
        {
            get { return codubicacion; }
            set { codubicacion = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string catalogo;
        /// <summary>
        /// 
        /// </summary>
        public string CatalogoCampana
        {
            get { return catalogo; }
            set { catalogo = value; }
        }

        private string pagina;
        /// <summary>
        /// 
        /// </summary>
        public string Pagina
        {
            get { return pagina; }
            set { pagina = value; }
        }

        private double preciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public double PrecioCatalogo
        {
            get { return preciocatalogo; }
            set { preciocatalogo = value; }
        }
    }
}
