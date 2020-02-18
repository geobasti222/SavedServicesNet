using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para DescuentoPrivilegio
    /// </summary>
    public class DescuentoPrivilegio : IDescuentoPrivilegio
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.DescuentoPrivilegio module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public DescuentoPrivilegio()
        {
            module = new Application.Enterprise.Data.DescuentoPrivilegio();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public DescuentoPrivilegio(string databaseName)
        {
            module = new Application.Enterprise.Data.DescuentoPrivilegio(databaseName);
        }

        #region Miembros de IDescuentoPrivilegio

        /// <summary>
        /// Lista todos los DescuentoPrivilegios.
        /// </summary>
        /// <returns></returns>
        public List<DescuentoPrivilegioInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un DescuentoPrivilegio x id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DescuentoPrivilegioInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }

        /// <summary>
        /// Lista un DescuentoPrivilegio x rango de valor del pedido y unidad de negocio de un articulo.
        /// </summary>
        /// <param name="ValorPedido"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="GrupoProducto"></param>
        /// <returns></returns>
        public DescuentoPrivilegioInfo ListxValorPedido(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana)
        {
            return module.ListxValorPedido(ValorPedido, UnidadNegocio, GrupoProducto, Campana);
        }

        /// <summary>
        /// Lista un descuento x rango de valor del pedido y unidad de negocio de un articulo con privilegio con producto estrella.
        /// </summary>
        /// <param name="ValorPedido"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="GrupoProducto"></param>
        /// <param name="Campana"></param>
        /// <param name="ProdEstrella"></param>
        /// <returns></returns>
        public DescuentoPrivilegioInfo ListxValorPedidoPrivilegio(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella)
        {
            return module.ListxValorPedidoPrivilegio(ValorPedido, UnidadNegocio, GrupoProducto, Campana, ProdEstrella);
        }

        /// <summary>
        /// Guarda un DescuentoPrivilegio nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(DescuentoPrivilegioInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de un DescuentoPrivilegio existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(DescuentoPrivilegioInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina un DescuentoPrivilegio.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Delete(int Id, string Usuario)
        {
            try
            {
                return module.Delete(Id, Usuario);
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
