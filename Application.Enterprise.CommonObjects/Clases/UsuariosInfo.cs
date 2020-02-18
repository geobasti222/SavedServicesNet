using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class UsuariosInfo
    {
        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string clave;
        /// <summary>
        /// 
        /// </summary>
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
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

        private string idgrupo;
        /// <summary>
        /// 
        /// </summary>
        public string IdGrupo
        {
            get { return idgrupo; }
            set { idgrupo = value; }
        }

        private DateTime vencimiento;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Vencimiento
        {
            get { return vencimiento; }
            set { vencimiento = value; }
        }

        private int activo;
        /// <summary>
        /// 
        /// </summary>
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private string codigo;
        /// <summary>
        /// 
        /// </summary>
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private bool accesoweb;
        /// <summary>
        /// 
        /// </summary>
        public bool AccesoWeb
        {
            get { return accesoweb; }
            set { accesoweb = value; }
        }

        private string email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string nombregrupo;
        /// <summary>
        /// 
        /// </summary>
        public string NombreGrupo
        {
            get { return nombregrupo.Trim(); }
            set { nombregrupo = value; }
        }

        private string nombreusuario;
        /// <summary>
        /// 
        /// </summary>
        public string NombreUsuario
        {
            get { return nombreusuario.Trim(); }
            set { nombreusuario = value; }
        }

        private string clavenueva;
        /// <summary>
        /// 
        /// </summary>
        public string ClaveNueva
        {
            get { return clavenueva; }
            set { clavenueva = value; }
        }

        private string idvendedor;
        /// <summary>
        /// 
        /// </summary>
        public string IdVendedor
        {
            get { return idvendedor; }
            set { idvendedor = value; }
        }

        private bool reiniciar;
        /// <summary>
        /// 
        /// </summary>
        public bool Reiniciar
        {
            get { return reiniciar; }
            set { reiniciar = value; }
        }

    }
}
