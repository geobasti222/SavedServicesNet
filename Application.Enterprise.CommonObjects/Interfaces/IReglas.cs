using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Reglas
    /// </summary>
    public interface IReglas
    {
        #region "Metodos de Reglas"

        /// <summary>
        /// Lista todas las reglas.
        /// </summary>
        /// <returns></returns>
        List<ReglasInfo> List();

        /// <summary>
        /// Una regla especifica.
        /// </summary>
        /// <param name="IdRegla"></param>
        /// <returns></returns>
        ReglasInfo ListxId(int IdRegla);
        
        /// <summary>
        /// Lista las reglas ordenadas, activas para asignar los pedidos.
        /// </summary>
        /// <returns></returns>
        List<ReglasInfo> ListAsignarPedidos();        

        /// <summary>
        /// Realiza el registro de una regla.
        /// </summary>
        /// <param name="item"></param>
        int Insert(ReglasInfo item);

        /// <summary>
        /// Realiza la actualizacion del registro de una regla.
        /// </summary>
        /// <param name="item"></param>
        bool Update(ReglasInfo item);

        #endregion
    }
}

