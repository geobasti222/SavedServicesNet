using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IPremiosTablas
    /// </summary>
    public interface IPremiosTablas
    {
        #region "Metodos de IPremiosTablas"

        /// <summary>
        /// Lista todas las tablas de los premios.
        /// </summary>
        /// <returns></returns>
        List<PremiosTablasInfo> List();

        /// <summary>
        /// Lista una tabla por id.
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        PremiosTablasInfo ListxId(int IdTabla);

        /// <summary>
        /// Lista una tabla por Nombre.
        /// </summary>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        PremiosTablasInfo ListxNombre(string NombreTabla);


        #endregion
    }
}

