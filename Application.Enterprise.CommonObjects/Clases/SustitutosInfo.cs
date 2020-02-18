using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SustitutosInfo
    {
        private string ref_sustituto;

        public string Ref_sustituto
        {
            get { return ref_sustituto; }
            set { ref_sustituto = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string id_corto;

        public string Id_corto
        {
            get { return id_corto; }
            set { id_corto = value; }
        }

        private decimal precioconiva;

        public decimal PrecioConIVA
        {
            get { return precioconiva; }
            set { precioconiva = value; }
        }

        private string pagina;

        public string Pagina
        {
            get { return pagina; }
            set { pagina = value; }
        }


        private String foto;
        /// <summary>
        /// 
        /// </summary>
        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }


    }
}
