using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Lider
    /// </summary>
    public interface ILider
    {
        #region "Metodos de Lider"

        /// <summary>
        /// Lista todos los lideres
        /// </summary>
        /// <returns></returns>
        List<LiderInfo> List();

        /// <summary>
        /// Lista todos los lideres x zona
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        List<LiderInfo> ListxZona(string Zona);

         /// <summary>
        /// Lista la informacion de un lider especifico.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        LiderInfo ListxIdLider(string IdLider);



        #endregion
    }
}

