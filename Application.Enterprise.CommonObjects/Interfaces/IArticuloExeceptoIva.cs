using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Articulo Execepto de iva 
    /// </summary>
    public interface IArticuloExeceptoIva
    {
        #region "Metodos de  Articulo Execepto de iva"

        /// <summary>
        /// Lista la vista previa de los Articulos Exceptos
        /// </summary>
        /// <returns></returns>
        List<ArticuloExeceptoIvaInfo> List();

        /// <summary>
        /// Lista los datos que se van a actualizar en la tabla principal de la Temporal
        /// </summary>
        /// <returns></returns>
        List<ArticuloExeceptoIvaInfo> ListTemp();

        /// <summary>
        /// Guarda Traslado de fletes para la tabla temporal.
        /// </summary>
        /// <param name="campos"></param>
        /// <param name="Tipocampo"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool InsertaTablasTemporales(string campos, string Tipocampo, string usuario);

        /// <summary>
        /// inserta Todas las tablas temporales en una para que ejecute correctamente el grid
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool InsertTablaTemporalPrincipal(string usuario);

        /// <summary>
        /// Borra la tabla Temporal
        /// </summary>
        /// <returns></returns>
        bool DeleteTempArticulosExeptos();

        /// <summary>
        /// Borra Tabla En caso de que hayan quedado mal grabadas
        /// </summary>
        /// <param name="TipoCampo"></param>
        /// <returns></returns>
        bool DeleteTempArticulosExeptosXCiudad(string TipoCampo);

        bool DeleteTempArticulosExeptosXRegistro(string codciudad, int PLU, string Usuario);

        bool ActualizaArticulosExceptos(string Usuario);

        #endregion
    }
}
