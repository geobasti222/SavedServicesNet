using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Inventario
    /// </summary>
    public interface IInventario
    {
        #region "Metodos de Inventario"

        /// <summary>
        /// lista todos los Inventarios existentes.
        /// </summary>
        /// <returns></returns>
        List<InventarioInfo> List();

        /// <summary>
        /// Lista los saldos bodega del mes actual.
        /// </summary>
        /// <returns></returns>
        List<InventarioInfo> ListSaldosBodega();

        /// <summary>
        /// Lista los inventarios por Referencia por CCostos y por Bodega.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        InventarioInfo ListxBodegaxRefxCcostos(string Bodega, string Referencia, string CCostos);

        /// <summary>
        /// Lista los inventarios por Referencia por CCostos y por Bodega para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        InventarioInfo ListxBodegaxRefxCcostosNivelServicio(string Bodega, string Referencia, string CCostos);

         /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico.
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        InventarioInfo ListSaldosBodegaxPLU(int intPLU);

        /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico x CO. SIESA. Para todas las bodegas facturables.
        /// </summary>
        /// <param name="intPLU"></param>
        /// <param name="IdCentroOperacion"></param>
        /// <returns></returns>
        InventarioInfo ListSaldosBodegaxPLUxCO(int intPLU, string IdCentroOperacion);

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
        /// Realiza la actualizacion de la cantidad asignada del inventario para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        bool UpdateCantidadNivelServicio(string Bodega, string Referencia, string CCostos, decimal Cantidad);

        /// <summary>
        /// Guarda el inventario de una bodega.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(InventarioInfo item);

        /// <summary>
        /// Guarda el inventario de una bodega para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="item"></param>
        bool InsertNivelServicio(InventarioInfo item);

        /// <summary>
        /// Elimina todos los inventarios.
        /// </summary>
        /// <returns></returns>
        bool DeleteAll();

        /// <summary>
        /// Elimina todos los inventarios del calculo de nivel de servicio.
        /// </summary>
        /// <returns></returns>
        bool DeleteAllNivelServicio();


        /// /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico. y con bodega variable
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        InventarioInfo ListSaldosBodegaxPLUVariable(int intPLU, string bodega);


        /// /// <summary>
        /// Busca la fecha que habra existencia de un producto agotado
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        string BuscaFechaProducto(int intPLU, string campana);
        
        
        #endregion
    }
}

