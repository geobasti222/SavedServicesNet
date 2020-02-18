using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface Procesamientos Tipo
    /// </summary>
    public interface IProcesamientosTipo
    {
        #region "Metodos de Tipos Procesamientos"

        /// <summary>
        /// Mostrar todos los elementos de la tabla SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <returns></returns>
        List<ProcesamientosTipoInfo> List();

        /// <summary>
        /// Insercion de un tipo de procesamiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string InsertProcesamientoTipo(ProcesamientosTipoInfo item);

        /// <summary>
        /// Actualiza la descripcion de SVDN_PROCESAMIENTOS_TIPO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateProcesamientoTipo(ProcesamientosTipoInfo item);


        /// <summary>
        /// Elimina un elemento de SVDN_PROCESAMIENTOS_TIPO de acuerdo a una ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool DeleteProcesamientoTipo(ProcesamientosTipoInfo item);

        #endregion
    }
}
