using System;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// Provee información sobre la clave de un usuario
    /// </summary>
    
    public class InfoClave
    {
		/// <summary>
		/// Indica si la clave es la asignada por el sistema
		/// </summary>
		public bool     ClaveInicial;

        /// <summary>
        /// Fecha en que expira la clave
        /// </summary>
        public DateTime FechaExpiracionClave;

        /// <summary>
        /// Dias restantes (con base en la fecha actual) para que expire la clave
        /// </summary>
        public short    DiasRestantesExpiracionClave;

        /// <summary>
        /// Inicializa una instancia vacía de la clase InfoClave
        /// </summary>
        public InfoClave()
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase InfoClave
        /// </summary>
        /// <param name="claveInicial">Indica si la clave es la asignada por el sistema</param>
        /// <param name="fechaExpiracionClave">Fecha en que expira la clave</param>
        /// <param name="diasRestantesExpiracionClave">Dias restantes (con base en la fecha actual) para que expire la clave</param>
        public InfoClave(bool claveInicial, DateTime fechaExpiracionClave, short diasRestantesExpiracionClave)
        {
			this.ClaveInicial                 = claveInicial;
            this.FechaExpiracionClave         = fechaExpiracionClave;
            this.DiasRestantesExpiracionClave = diasRestantesExpiracionClave;
        }
    }
}