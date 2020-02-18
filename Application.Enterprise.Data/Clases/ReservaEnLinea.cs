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
    public class ReservaEnLinea
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReservaEnLinea;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReservaEnLinea(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReservaEnLinea()
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
            commandReservaEnLinea = db.GetStoredProcCommand("PRC_SVDN_RESERVAENLINEA");

            db.AddInParameter(commandReservaEnLinea, "i_operation", DbType.String);
            db.AddInParameter(commandReservaEnLinea, "i_option", DbType.String);
            db.AddInParameter(commandReservaEnLinea, "i_cobrarEnvio", DbType.Int32);
            db.AddInParameter(commandReservaEnLinea, "i_numeropedido", DbType.String);
            
            //QUITAR PARA QUE FUNCIONE COLOMBIA Y ECUADOR

            db.AddInParameter(commandReservaEnLinea, "i_bodegass", DbType.String);

            db.AddOutParameter(commandReservaEnLinea, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandReservaEnLinea, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Rerserva En Linea
        /// <summary>
        /// Realiza la reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public string RealizarReservaEnLinea(string NumeroPedido)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReservaEnLinea, "i_operation", 'I');
                db.SetParameterValue(commandReservaEnLinea, "i_option", 'A');
                db.SetParameterValue(commandReservaEnLinea, "i_numeropedido", NumeroPedido);
                db.SetParameterValue(commandReservaEnLinea, "i_cobrarEnvio", 1);

                dr = db.ExecuteReader(commandReservaEnLinea);

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



        public string RealizarReservaEnLineaBorrador(string NumeroPedido, string bodega)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReservaEnLinea, "i_operation", 'I');
                db.SetParameterValue(commandReservaEnLinea, "i_option", 'B');
                db.SetParameterValue(commandReservaEnLinea, "i_numeropedido", NumeroPedido);
                //// comentar para que sirva colombia y ecuador
              db.SetParameterValue(commandReservaEnLinea, "i_bodegass", bodega);

                dr = db.ExecuteReader(commandReservaEnLinea);

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



        #region Metodos de Rerserva En Linea CON BODEGAS DIFERENTES JUTA
        /// <summary>
        /// Realiza la reserva en linea de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public string RealizarReservaEnLineaDifBodega(string NumeroPedido,string bodega)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReservaEnLinea, "i_operation", 'I');
                db.SetParameterValue(commandReservaEnLinea, "i_option", 'A');
                db.SetParameterValue(commandReservaEnLinea, "i_numeropedido", NumeroPedido);
                //// comentar para que sirva colombia y ecuador
              db.SetParameterValue(commandReservaEnLinea, "i_bodegass", bodega);

                dr = db.ExecuteReader(commandReservaEnLinea);

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