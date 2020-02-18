using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Inventario
    /// </summary>
    public class Inventario : IInventario
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Inventario module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Inventario()
        {
            module = new Application.Enterprise.Data.Inventario();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Inventario(string databaseName)
        {
            module = new Application.Enterprise.Data.Inventario(databaseName);
        }

        #region Miembros de IInventario
        /// <summary>
        /// lista todos los Inventarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<InventarioInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los saldos bodega del mes actual.
        /// </summary>
        /// <returns></returns>
        public List<InventarioInfo> ListSaldosBodega()
        {
            return module.ListSaldosBodega();
        }

        /// <summary>
        /// Lista los inventarios por Referencia por CCostos y por Bodega.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        public InventarioInfo ListxBodegaxRefxCcostos(string Bodega, string Referencia, string CCostos)
        {
            return module.ListxBodegaxRefxCcostos(Bodega, Referencia, CCostos);
        }

        /// <summary>
        /// Lista los inventarios por Referencia por CCostos y por Bodega para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        public InventarioInfo ListxBodegaxRefxCcostosNivelServicio(string Bodega, string Referencia, string CCostos)
        {
            return module.ListxBodegaxRefxCcostosNivelServicio(Bodega, Referencia, CCostos);
        }


        /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico.
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        public InventarioInfo ListSaldosBodegaxPLU(int intPLU)
        {
            return module.ListSaldosBodegaxPLU(intPLU);
        }

        /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico x CO. SIESA. Para todas las bodegas facturables.
        /// </summary>
        /// <param name="intPLU"></param>
        /// <param name="IdCentroOperacion"></param>
        /// <returns></returns>
        public InventarioInfo ListSaldosBodegaxPLUxCO(int intPLU, string IdCentroOperacion)
        {
            return module.ListSaldosBodegaxPLUxCO(intPLU, IdCentroOperacion);
        }

        /// <summary>
        /// Realiza la actualizacion de la cantidad asignada del inventario.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidad(string Bodega, string Referencia, string CCostos, decimal Cantidad)
        {
            try
            {
                return module.UpdateCantidad(Bodega, Referencia, CCostos, Cantidad);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de la cantidad asignada del inventario para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidadNivelServicio(string Bodega, string Referencia, string CCostos, decimal Cantidad)
        {
            try
            {
                return module.UpdateCantidadNivelServicio(Bodega, Referencia, CCostos, Cantidad);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda el inventario de una bodega.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(InventarioInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda el inventario de una bodega para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertNivelServicio(InventarioInfo item)
        {
            try
            {
                return module.InsertNivelServicio(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los inventarios.
        /// </summary>
        /// <returns></returns>
        public bool DeleteAll()
        {
            try
            {
                return module.DeleteAll();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los inventarios del calculo de nivel de servicio.
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllNivelServicio()
        {
            try
            {
                return module.DeleteAllNivelServicio();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        #endregion



        /// METODOS NUEVOS JUTA
        /// /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico. y con bodega variable
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        public InventarioInfo ListSaldosBodegaxPLUVariable(int intPLU, string bodega)
        {
            return module.ListSaldosBodegaxPLUVariable(intPLU, bodega);
        }

        /// /// <summary>
        /// Busca la fecha que habra existencia de un producto agotado
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        public string BuscaFechaProducto(int intPLU, string campana)
        {
            return module.BuscaFechaProducto(intPLU, campana);
        }

        public InventarioInfo ListSaldosBodegaxPLUxEmpresaria(string bodega, int intPLU) =>
            this.module.ListSaldosBodegaxPLUxEmpresaria(bodega, intPLU);
    }
}
