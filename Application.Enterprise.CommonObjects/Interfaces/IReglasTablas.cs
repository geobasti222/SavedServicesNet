using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ReglasTablas
    /// </summary>
    public interface IReglasTablas
    {
        #region "Metodos de ReglasTablas"

        /// <summary>
        /// Lista todas las tablas de las reglas.
        /// </summary>
        /// <returns></returns>
        List<ReglasTablasInfo> List();

        /// <summary>
        /// Lista una tabla por id.
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        ReglasTablasInfo ListxId(int IdTabla);

        #endregion
    }
}

