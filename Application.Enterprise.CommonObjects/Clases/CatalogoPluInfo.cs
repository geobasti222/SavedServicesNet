using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CatalogoPluInfo
    {
        private string catalogo;
        /// <summary>
        /// 
        /// </summary>
        public string Catalogo
        {
            get { return catalogo; }
            set { catalogo = value; }
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

        private int plu;
        /// <summary>
        /// 
        /// </summary>
        public int PLU
        {
            get { return plu; }
            set { plu = value; }
        }

        private string idcodigocorto;
        /// <summary>
        /// 
        /// </summary>
        public string IdCodigoCorto
        {
            get { return idcodigocorto.ToUpper(); }
            set { idcodigocorto = value; }
        }

        private string catalogoreal;
        /// <summary>
        /// 
        /// </summary>
        public string CatalogoReal
        {
            get { return catalogoreal; }
            set { catalogoreal = value; }
        }

        private bool _activo;
        /// <summary>
        /// 
        /// </summary>
        public bool  Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }


        private int preciopuntos;
        /// <summary>
        /// 
        /// </summary>
        public int PrecioPuntos
        {
            get { return preciopuntos; }
            set { preciopuntos = value; }
        }
    }
}
