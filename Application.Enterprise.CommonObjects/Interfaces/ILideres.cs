using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Lideres
    /// </summary>
    public interface ILideres
    {
        #region "Metodos de Lideres"

        /// <summary>
        /// Lista todos las lideres.
        /// </summary>
        /// <returns></returns>
        List<LideresInfo> List();

        /// <summary>
        /// Lista todos las lideres x zona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        List<LideresInfo> ListxZona(string IdZona);

        /// <summary>
        /// Lista todos las lideres x zona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        List<LideresInfo> ListLideresxZona(string IdZona);

        /// <summary>
        /// Lista un lider x cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        LideresInfo ListxCedula(string Cedula);

        /// <summary>
        /// Guarda un lider nuevo.
        /// </summary>
        /// <param name="item"></param>
        int Insert(LideresInfo item);

        /// <summary>
        /// Realiza la actualizacion de un lider existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(LideresInfo item);

        /// <summary>
        /// Elimina un lider.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        bool Delete(string Cedula, string Usuario);

        #endregion
    }
}

