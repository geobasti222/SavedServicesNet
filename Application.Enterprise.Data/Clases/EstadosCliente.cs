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
    public class EstadosCliente
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEstadosCliente;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public EstadosCliente(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public EstadosCliente()
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
            commandEstadosCliente = db.GetStoredProcCommand("PRC_SVDN_ESTADOSCLIENTE");

            db.AddInParameter(commandEstadosCliente, "i_operation", DbType.String);
            db.AddInParameter(commandEstadosCliente, "i_option", DbType.String);
            db.AddInParameter(commandEstadosCliente, "i_esc_id", DbType.Int32);
            db.AddInParameter(commandEstadosCliente, "i_esc_nombre", DbType.String);

            db.AddOutParameter(commandEstadosCliente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEstadosCliente, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de EstadosCliente

        /// <summary>
        /// Lista todos los estados de cliente.
        /// </summary>
        /// <returns></returns>
        public List<EstadosClienteInfo> List()
        {
            db.SetParameterValue(commandEstadosCliente, "i_operation", 'S');
            db.SetParameterValue(commandEstadosCliente, "i_option", 'A');

            List<EstadosClienteInfo> col = new List<EstadosClienteInfo>();

            IDataReader dr = null;

            EstadosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstadosCliente);

                while (dr.Read())
                {
                    m = Factory.GetEstadosCliente(dr);

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
        /// Lista un estado especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<EstadosClienteInfo> ListxId(int Id)
        {
            db.SetParameterValue(commandEstadosCliente, "i_operation", 'S');
            db.SetParameterValue(commandEstadosCliente, "i_option", 'B');
            db.SetParameterValue(commandEstadosCliente, "i_esc_id", Id);

            List<EstadosClienteInfo> col = new List<EstadosClienteInfo>();

            IDataReader dr = null;

            EstadosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstadosCliente);

                while (dr.Read())
                {
                    m = Factory.GetEstadosCliente(dr);

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

        #endregion
    }
}