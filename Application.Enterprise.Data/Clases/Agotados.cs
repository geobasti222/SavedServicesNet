using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Agotados
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAgotados;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Agotados(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Agotados()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        /// <summary>
        ///  Metodo para configurar el comando de la DatabaseFactory
        /// </summary>
        private void Config()
        {
            commandAgotados = db.GetStoredProcCommand("PRC_SVDN_AGOTADOS");

            db.AddInParameter(commandAgotados, "i_operation", DbType.String);
            db.AddInParameter(commandAgotados, "i_option", DbType.String);
            db.AddInParameter(commandAgotados, "i_campana", DbType.String);
            db.AddInParameter(commandAgotados, "i_numeropedido", DbType.String);
            db.AddInParameter(commandAgotados, "i_fechacreacion", DbType.DateTime);
            db.AddInParameter(commandAgotados, "i_nit", DbType.String);
            db.AddInParameter(commandAgotados, "i_zona", DbType.String);
            db.AddInParameter(commandAgotados, "i_plu", DbType.Decimal);
            db.AddInParameter(commandAgotados, "i_ccostos", DbType.String);
            db.AddInParameter(commandAgotados, "i_referencia", DbType.String);
            db.AddInParameter(commandAgotados, "i_descripcion", DbType.String);
            db.AddInParameter(commandAgotados, "i_valor", DbType.Decimal);
            db.AddInParameter(commandAgotados, "i_cantidadpedida", DbType.String);
            db.AddInParameter(commandAgotados, "i_tarifaiva", DbType.Decimal);
            db.AddInParameter(commandAgotados, "i_catalogoreal", DbType.String);
            db.AddInParameter(commandAgotados, "i_codigorapido", DbType.String);
            db.AddOutParameter(commandAgotados, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAgotados, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Agotados

        /// <summary>
        /// Guarda agotados de los pedidos de facturacion semanal que tienen x con visible pos.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(PedidosDetalleClienteInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAgotados, "i_operation", 'I');
                db.SetParameterValue(commandAgotados, "i_option", 'A');

                db.SetParameterValue(commandAgotados, "i_campana", item.Campana);
                db.SetParameterValue(commandAgotados, "i_numeropedido", item.Numero);
                db.SetParameterValue(commandAgotados, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandAgotados, "i_nit", item.Nit);
                db.SetParameterValue(commandAgotados, "i_zona", item.Zona);
                db.SetParameterValue(commandAgotados, "i_plu", item.PLU);
                db.SetParameterValue(commandAgotados, "i_ccostos", item.Lote);
                db.SetParameterValue(commandAgotados, "i_referencia", item.Referencia);
                db.SetParameterValue(commandAgotados, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandAgotados, "i_valor", item.Valor);
                db.SetParameterValue(commandAgotados, "i_cantidadpedida", item.Cantidad);
                db.SetParameterValue(commandAgotados, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandAgotados, "i_catalogoreal", item.CatalogoReal);
                db.SetParameterValue(commandAgotados, "i_codigorapido", item.IdCodigoCorto);

                dr = db.ExecuteReader(commandAgotados);

                okTrans = true;
            }
            catch (Exception ex)
            {
                okTrans = false;

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return okTrans;
        }
        
        /// <summary>
        /// Elimina todos los agotados de un pedido.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletexPedido(string NumeroPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAgotados, "i_operation", 'D');
                db.SetParameterValue(commandAgotados, "i_option", 'A');
                db.SetParameterValue(commandAgotados, "i_numeropedido", NumeroPedido);

                dr = db.ExecuteReader(commandAgotados);

                transOk = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }



        #endregion
    }
}