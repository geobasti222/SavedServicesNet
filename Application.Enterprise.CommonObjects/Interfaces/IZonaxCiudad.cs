using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ZonaxCiudad
    /// </summary>
    public interface IZonaxCiudad
    {
        #region "Metodos de ZonaxCiudad"

        /// <summary>
        /// Lista todos las zonas y ciudades existentes.
        /// </summary>
        /// <returns></returns>
        List<ZonaxCiudadInfo> List();

        /// <summary>
        /// Lista todas las ciudades de una zona especifica.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        List<ZonaxCiudadInfo> ListxZona(string Zona);


        /// <summary>
        /// Lista todas las ciudades de una zona especifica de las tablas de G&G.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        List<ZonaxCiudadInfo> ListxZonaGYG(string Zona);
        
        /// <summary>
        /// Lista todas las ciudades de un departamento especifico con tablas de G&G.
        /// </summary>
        /// <param name="IdDepto"></param>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        List<ZonaxCiudadInfo> ListxZonaGYGxDepartamento(string IdDepto, string IdZona);

        #endregion
    }
}

