using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Inventario MKT
    /// </summary>
    public interface IInventarioMkt
    {
        #region "Metodos de Inventario MKT"

        /// <summary>
        /// lista todos los Inventarios existentes.
        /// </summary>
        /// <returns></returns>
        List<InventarioMktInfo> List();

        /// <summary>
        /// Lista los saldos bodega del mes actual.
        /// </summary>
        /// <returns></returns>
        List<InventarioMktInfo> ListSaldosBodega();

        /// <summary>
        /// Lista los inventarios por Referencia por CCostos y por Bodega.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        InventarioMktInfo ListxBodegaxRefxCcostos(string Bodega, string Referencia, string CCostos);

        /// <summary>
        /// Lista los inventarios de MKT disponibles.
        /// </summary>
        /// <returns></returns>
        List<InventarioMktInfo> ListInventarioDisponible();

        /// <summary>
        /// Consulta el inventario MKT por referencia 
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        InventarioMktInfo ListInventarioMKTxReferencia(string Referencia);


        /// <summary>
        /// Realiza la actualizacion de la cantidad asignada del inventario.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        bool UpdateCantidad(string Bodega, string Referencia, string CCostos, decimal Cantidad);

        /// <summary>
        /// Guarda el inventario de una bodega.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(InventarioMktInfo item);

        /// <summary>
        /// Elimina todos los inventarios.
        /// </summary>
        /// <returns></returns>
        bool DeleteAll();

        /// <summary>
        /// Lista los saldos bodega del mes actual desde la bd de MKT y se insertan en la tabla de inventario de SVDN.
        /// </summary>
        /// <param name="item"></param>
        bool ImportInventarioMKT();

        #endregion
    }
}

