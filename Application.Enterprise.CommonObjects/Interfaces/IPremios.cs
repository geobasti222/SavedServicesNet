using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Premios
    /// </summary>
    public interface IPremios
    {
        #region "Metodos de Premios"

        /// <summary>
        ///Lista todos los premios
        /// </summary>
        /// <returns></returns>
        List<PremiosInfo> List();

        /// <summary>
        /// Lista un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        PremiosInfo ListxId(int IdPremio);

        /// <summary>
        /// Lista los premios ordenados.
        /// </summary>
        /// <returns></returns>
        List<PremiosInfo> ListxOrden();

        /// <summary>
        /// busca un premio por nombre.
        /// </summary>
        /// <param name="NombrePremio"></param>
        /// <returns></returns>
        List<PremiosInfo> ListxNombre(string NombrePremio);

        /// <summary>
        /// Realiza el registro de un premio.
        /// </summary>
        /// <param name="item"></param>
        int Insert(PremiosInfo item);

        /// <summary>
        /// Realiza la actualizacion  de un premio.
        /// </summary>
        /// <param name="item"></param>
        bool Update(PremiosInfo item);

        /// <summary>
        /// Elimina un premio especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool DeletexIdPremio(int IdPremio);


        #endregion
    }
}

