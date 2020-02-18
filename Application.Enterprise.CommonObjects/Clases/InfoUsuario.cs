using System;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// Provee información sobre un usuario
    /// </summary>
    
    public class InfoUsuario
    {
        /// <summary>
        /// Identificador único del usuario
        /// </summary>
        public string    Id;

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string    Nombre;

        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string    Apellidos;

        /// <summary>
        /// Perfil del usuario
        /// </summary>
        //public PerfilUsuario Perfil;

        /// <summary>
        /// Información sobre la clave del usuario
        /// </summary>
        public InfoClave InfoClave;

        /// <summary>
        /// Información del cliente que representa
        /// </summary>
        public InfoCliente InfoCliente;

        /// <summary>
        /// Indica el estado del usuario
        /// </summary>
        //public EstadoUsuario Estado;

		/// <summary>
		/// Indica el Login del Usuario de Soporte del Cliente
		/// </summary>
		public string UsuarioSoporte ;


        /// <summary>
        /// Indica si es necesario mostrar el disclaimer al usuario
        /// </summary>
        public bool ShowDisclaimer;

        public bool IsCertified;

        public string ErrorServicio;
        public string CodigoBolsa;
        public string NumeroDocumento;
        public string TipoDocumento;
        public string Telefono;
        public string Email;

        public string TipoComercialUDF = "N";


        /// <summary>
        /// Inicializa una instancia vacía de la clase InfoUsuario
        /// </summary>
        public InfoUsuario()
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase InfoUsuario con un Id determinado
        /// </summary>
        /// <param name="id">Identificador único del usuario</param>
        public InfoUsuario(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Inicializa una instancia de la clase InfoUsuario con un Id y Cliente determinado
        /// </summary>
        /// <param name="id">Identificador único del usuario</param>
        /// <param name="infoCliente">Información del cliente que representa</param>
        public InfoUsuario(string id, InfoCliente infoCliente)
        {
            this.Id          = id;
            this.InfoCliente = infoCliente;
        }
        /// <summary>
        /// Inicializa una instancia de la clase InfoUsuario
        /// </summary>
        /// <param name="id">Identificador único del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellidos">Apellidos del usuario</param>
        /// <param name="perfil">Perfil de usuario</param>
        /// <param name="infoClave">Información sobre la clave del usuario</param>
        /// <param name="infoCliente">Información del cliente que representa</param>
        /// <param name="estado">Estado del usuario</param>
        public InfoUsuario(string id, string nombre, string apellidos, InfoClave infoClave, InfoCliente infoCliente)
        {
            this.Id          = id;
            this.Nombre      = nombre;
            this.Apellidos   = apellidos;
            //this.Perfil      = perfil;
            this.InfoClave   = infoClave;
            this.InfoCliente = infoCliente;
            //this.Estado      = estado;
        }
    } 


}