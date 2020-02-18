using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ContactenosInfo
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int categoria;

        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }

        }

        private string asunto;

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private bool resuelto;

        public bool Resuelto
        {
            get { return resuelto; }
            set { resuelto = value; }
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
