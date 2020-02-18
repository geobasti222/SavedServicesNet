using System;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// Provee información sobre un parámetro de configuración del sistema
    /// </summary>
    
    public class ParametroConfiguracion
    {
        /// <summary>
        /// Nombre o identificador del parámetro de configuración
        /// </summary>
        public string Nombre;

        /// <summary>
        /// Valor del parámetro de configuración
        /// </summary>
        public string Valor;

        /// <summary>
        /// Inicializa una instancia vacía de la clase ParametroConfiguracion
        /// </summary>
        public ParametroConfiguracion()
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase ParametroConfiguracion
        /// </summary>
        /// <param name="nombre">Nombre o identificador del parámetro de configuración</param>
        /// <param name="valor">Valor del parámetro de configuración</param>
        public ParametroConfiguracion(string nombre, string valor)
        {
            this.Nombre = nombre;
            this.Valor  = valor;
        }
    }
}