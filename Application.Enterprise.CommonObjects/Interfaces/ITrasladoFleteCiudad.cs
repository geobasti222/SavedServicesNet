using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Traslado de Flete por Ciudad
    /// </summary>
    public interface ITrasladoFleteCiudad
    {
        #region "Metodos de Ciudad"

        /// <summary>
        /// lista todas los fletes vista previa existentes existentes.
        /// </summary>
        /// <returns></returns>
        List<TrasladoFleteCiudadinfo> List();


        /// <summary>
        /// Guarda Traslado de fletes para la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Insert(TrasladoFleteCiudadinfo item, string TipoCampo);

        

        /// <summary>
        /// Elimina Valores de la tabla Temporal Dimciudad
        /// </summary>
        /// <returns></returns>
        bool DeleteTempTransferflete();

        /// <summary>
        /// Actualiza los valores de la tabla dimciuada con la temporal de transferencia
        /// </summary>
        /// <returns></returns>
        bool ActualizaTransferflete();


        /// <summary>
        /// Elimina Valores de la tabla Temporal Dimciudad
        /// </summary>
        /// <param name="TipoCampo"></param>
        /// <returns></returns>
        bool DeleteTransferflete(string TipoCampo);
        #endregion
    }
}
