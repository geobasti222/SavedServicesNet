using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ReglasCondiciones
    /// </summary>
    public interface IReglasCondiciones
    {
        #region "Metodos de ReglasCondiciones"

        /// <summary>
        /// lista todos los Paises existentes.
        /// </summary>
        /// <returns></returns>
        List<ReglasCondicionesInfo> List();

        /// <summary>
        /// Lista todos las condiciones de una regla especifica.
        /// </summary>
        /// <param name="IdRegla"></param>
        /// <returns></returns>
        List<ReglasCondicionesInfo> ListxIdRegla(int IdRegla);

        /// <summary>
        /// Realiza el registro de una condicion para las reglas.
        /// </summary>
        /// <param name="item"></param>
        int Insert(ReglasCondicionesInfo item);

        /// <summary>
        /// Realiza la actualizacion de una condicion.
        /// </summary>
        /// <param name="item"></param>
        bool Update(ReglasCondicionesInfo item);

        /// <summary>
        /// Elimina todas las condiciones de una regla.
        /// </summary>
        /// <param name="IdRegla">Id Regla</param>
        /// <returns></returns>
        bool DeleteCondiciones(int IdRegla);


        #endregion
    }
}

