using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Application.Enterprise.CommonObjects
{

    
    public class Topmenos20Info
    {


        private string catalogo;

        public string Catalogo
        {
            get { return catalogo; }
            set { catalogo = value; }
        }

       

        private string referencia;

        public string Referencia    
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private String id_corto;

        public string Id_corto
        {
            get { return id_corto; }
            set { id_corto = value; }
        }


        private String descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


    }
}
