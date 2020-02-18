using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Ciudad
    /// </summary>
    public interface ICiudad
    {
        #region "Metodos de Ciudad"

        /// <summary>
        /// lista todas las ciudades existentes.
        /// </summary>
        /// <returns></returns>
        List<CiudadInfo> List();

        /// <summary>
        /// lista todas las ciudades existentes por codigo de departamento.
        /// </summary>
        /// <returns></returns>
        List<CiudadInfo> ListByEstado(string CodEstado);

        /// <summary>
        /// lista una ciudad por codigo.
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        CiudadInfo ListxCodCiudad(string CodCiudad);

        /// <summary>
        /// Lista todas las ciudades que tengan relacionadas un estado
        /// </summary>
        /// <returns></returns>
        List<CiudadInfo> ListCiudadesConEstado(string CodEstado);

        /// <summary>
        /// Lista una ciudad especifica x codigo.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        CiudadInfo ListCiudadxId(string CodCiudad);

        /// <summary>
        /// lista todas las ciudades existentes por codigo de departamento.
        /// </summary>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        List<CiudadInfo> ListByCanton(string CodCanton, string codprovincia);

        /// <summary>
        /// Lista una ciudad especifica x codigo. para sacar el pedidomin
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        CiudadInfo ListCiudadxIdPedMin(string CodCiudad);

        #endregion
    }
}
