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
    public class ReservaEnLineaDevolucion
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReservaEnLineaDevolucion;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReservaEnLineaDevolucion(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReservaEnLineaDevolucion()
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
            commandReservaEnLineaDevolucion = db.GetStoredProcCommand("PRC_SVDN_RESERVAENLINEA_DEVOLUCION");

            db.AddInParameter(commandReservaEnLineaDevolucion, "i_operation", DbType.String);
            db.AddInParameter(commandReservaEnLineaDevolucion, "i_option", DbType.String);
            db.AddInParameter(commandReservaEnLineaDevolucion, "i_numeropedido", DbType.String);

            db.AddOutParameter(commandReservaEnLineaDevolucion, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandReservaEnLineaDevolucion, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Devolucion de Rerserva En Linea

        /// <summary>
        /// Realiza la anulacion de los pedidos que se deben anular por fecha de cierre.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool AnularPedidosxFechaCierre()
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReservaEnLineaDevolucion, "i_operation", 'U');
                db.SetParameterValue(commandReservaEnLineaDevolucion, "i_option", 'A');

                commandReservaEnLineaDevolucion.CommandTimeout = 360;

                dr = db.ExecuteReader(commandReservaEnLineaDevolucion);
                
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
        /// Realiza la devolucion de reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public string RealizarDevolucionReservaEnLinea(string NumeroPedido)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReservaEnLineaDevolucion, "i_operation", 'I');
                db.SetParameterValue(commandReservaEnLineaDevolucion, "i_option", 'A');
                db.SetParameterValue(commandReservaEnLineaDevolucion, "i_numeropedido", NumeroPedido);

                dr = db.ExecuteReader(commandReservaEnLineaDevolucion);

                strid = NumeroPedido;

            }
            catch (Exception ex)
            {
                strid = null;

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
            return strid;
        }

        #endregion
    }
}