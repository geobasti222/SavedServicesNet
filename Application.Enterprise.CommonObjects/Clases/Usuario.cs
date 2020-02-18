using System;

namespace Application.Enterprise.CommonObjects
{
    public class Usuario
    {
       
        public virtual int Id
        {
            get;
            set;
        }

        public virtual string UserName
        {
            get;
            set;
        }

        public virtual string Passwordd
        {
            get;
            set;
        }

        public virtual string Salt
        {
            get;
            set;
        }

        public virtual string Hash
        {
            get;
            set;
        }

        public virtual int Email
        {
            get;
            set;
        }

        public virtual int Id_Cliente
        {
            get;
            set;
        }

        public virtual int Id_Perfil
        {
            get;
            set;
        }

        public virtual bool Estado
        {
            get;
            set;
        }

        public virtual bool CambiarClave
        {
            get;
            set;
        }

        public virtual DateTime FechaCreacion
        {
            get;
            set;
        }

        public virtual string Imagen
        {
            get;
            set;
        }

        

    }
}
