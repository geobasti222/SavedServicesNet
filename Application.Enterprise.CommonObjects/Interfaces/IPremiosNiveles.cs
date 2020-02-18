using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Premios Niveles
    /// </summary>
    public interface IPremiosNiveles
    {
        #region "Metodos de Premios Niveles"

        /// <summary>
        /// Lista todos los Niveles.
        /// </summary>
        /// <returns></returns>
        List<PremiosNivelesInfo> List();

        /// <summary>
        /// Lista todos los Niveles de un premio especifico.  Se debe ordenar por puntos para validar la asignacion de premios.
        /// </summary>
        /// <returns></returns>
        List<PremiosNivelesInfo> ListxPremio(int IdPremio);

        /// <summary>
        /// Realiza el registro del nivel de un premio.
        /// </summary>
        /// <param name="item"></param>
        int Insert(PremiosNivelesInfo item);


        #endregion
    }
}

