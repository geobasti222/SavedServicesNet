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
    public class InventarioMkt : IInventarioMkt
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.InventarioMkt module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public InventarioMkt()
        {
            module = new Application.Enterprise.Data.InventarioMkt();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public InventarioMkt(string databaseName)
        {
            module = new Application.Enterprise.Data.InventarioMkt(databaseName);
        }

        #region Miembros de IInventario
        /// <summary>
        /// lista todos los Inventarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<InventarioMktInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los saldos bodega del mes actual.
        /// </summary>
        /// <returns></returns>
        public List<InventarioMktInfo> ListSaldosBodega()
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
        public InventarioMktInfo ListxBodegaxRefxCcostos(string Bodega, string Referencia, string CCostos)
        {
            return module.ListxBodegaxRefxCcostos(Bodega, Referencia, CCostos);
        }

        /// <summary>
        /// Lista los inventarios de MKT disponibles.
        /// </summary>
        /// <returns></returns>
        public List<InventarioMktInfo> ListInventarioDisponible()
        {
            return module.ListInventarioDisponible();
        }


        /// <summary>
        /// Consulta el inventario MKT por referencia 
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public InventarioMktInfo ListInventarioMKTxReferencia(string Referencia)
        {
            return module.ListInventarioMKTxReferencia(Referencia);
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
        /// Guarda el inventario de una bodega.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(InventarioMktInfo item)
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
        /// Lista los saldos bodega del mes actual desde la bd de MKT y se insertan en la tabla de inventario de SVDN.
        /// </summary>
        /// <param name="item"></param>
        public bool ImportInventarioMKT()
        {
            try
            {
                return module.ImportInventarioMKT();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        #endregion
    }
}
