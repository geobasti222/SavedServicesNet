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
    public class EstadosPedido
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEstadosPedido;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public EstadosPedido(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public EstadosPedido()
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
            commandEstadosPedido = db.GetStoredProcCommand("PRC_SVDN_ESTADOSPEDIDO");

            db.AddInParameter(commandEstadosPedido, "i_operation", DbType.String);
            db.AddInParameter(commandEstadosPedido, "i_option", DbType.String);
            db.AddInParameter(commandEstadosPedido, "i_esp_id", DbType.Int32);
            db.AddInParameter(commandEstadosPedido, "i_esp_nombre", DbType.String);
            db.AddInParameter(commandEstadosPedido, "i_esp_estado", DbType.Int32);

            db.AddOutParameter(commandEstadosPedido, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEstadosPedido, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Estados Pedido

        /// <summary>
        /// Lista todos los estados de un pedido activos.
        /// </summary>
        /// <returns></returns>
        public List<EstadosPedidoInfo> List()
        {
            db.SetParameterValue(commandEstadosPedido, "i_operation", 'S');
            db.SetParameterValue(commandEstadosPedido, "i_option", 'A');

            List<EstadosPedidoInfo> col = new List<EstadosPedidoInfo>();

            IDataReader dr = null;

            EstadosPedidoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstadosPedido);

                while (dr.Read())
                {
                    m = Factory.GetEstadosPedido(dr);

                    col.Add(m);
                }
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

            return col;
        }

        /// <summary>
        /// Lista un estado de un pedido activos especifico por id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EstadosPedidoInfo ListxId(int Id)
        {
            db.SetParameterValue(commandEstadosPedido, "i_operation", 'S');
            db.SetParameterValue(commandEstadosPedido, "i_option", 'B');
            db.SetParameterValue(commandEstadosPedido, "i_esp_id", Id);
                        
            IDataReader dr = null;

            EstadosPedidoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstadosPedido);

                while (dr.Read())
                {
                    m = Factory.GetEstadosPedido(dr);
                }
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

            return m;
        }

        #endregion
    }
}