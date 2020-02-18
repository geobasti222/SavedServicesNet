using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Premios Condiciones
    /// </summary>
    public interface IPremiosCondiciones
    {
        #region "Metodos de Premios Condiciones"

        /// <summary>
        /// lista todas las condiciones existentes.
        /// </summary>
        /// <returns></returns>
        List<PremiosCondicionesInfo> List();

        /// <summary>
        /// Lista todos las condiciones de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosCondicionesInfo> ListxIdPremio(int IdPremio);

        /// <summary>
        /// Lista todos las reglas-condiciones (query's) activas.
        /// </summary>
        /// <returns></returns>
        List<PremiosCondicionesInfo> ListxReglasPremios();

        /// <summary>
        /// Lista un id de articulo por ID de condicion.
        /// </summary>
        /// <param name="IdCondicion"></param>
        /// <returns></returns>
        List<PremiosCondicionesInfo> ListxIdArticulo(int IdCondicion);

        /// <summary>
        /// Lista todos las condiciones que no son de niveles de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosCondicionesInfo> ListxIdPremioSinNiveles(int IdPremio);

        /// <summary>
        /// Lista todos las condiciones que solos son de niveles de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosCondicionesInfo> ListxIdPremioSoloNiveles(int IdPremio);

        /// <summary>
        /// Realiza el registro de una condicion para los premios.
        /// </summary>
        /// <param name="item"></param>
        int Insert(PremiosCondicionesInfo item);

        /// <summary>
        /// Realiza la actualizacion de una condicion.
        /// </summary>
        /// <param name="item"></param>
        bool Update(PremiosCondicionesInfo item);

        /// <summary>
        /// Elimina todas las condiciones de un premio.
        /// </summary>
        /// <param name="IdPremio">Id Premio</param>
        /// <returns></returns>
        bool DeleteCondiciones(int IdPremio);


        #endregion
    }
}

