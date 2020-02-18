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
    public class Parametros
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandParametros;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Parametros(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Parametros()
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
            commandParametros = db.GetStoredProcCommand("PRC_SVDN_PARAMETROS");

            db.AddInParameter(commandParametros, "i_operation", DbType.String);
            db.AddInParameter(commandParametros, "i_option", DbType.String);

            db.AddInParameter(commandParametros, "i_par_id", DbType.Int32);
            db.AddInParameter(commandParametros, "i_par_nombre", DbType.String);
            db.AddInParameter(commandParametros, "i_par_valor", DbType.String);
            db.AddInParameter(commandParametros, "i_par_concepto", DbType.String);
            db.AddInParameter(commandParametros, "i_par_tipo", DbType.String);
            db.AddInParameter(commandParametros, "i_par_estado", DbType.Boolean);            

            db.AddOutParameter(commandParametros, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandParametros, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Parametros

        /// <summary>
        /// Lista todos los parametros del sistema
        /// </summary>
        /// <returns></returns>
        public List<ParametrosInfo> List()
        {
            db.SetParameterValue(commandParametros, "i_operation", 'S');
            db.SetParameterValue(commandParametros, "i_option", 'A');

            List<ParametrosInfo> col = new List<ParametrosInfo>();

            IDataReader dr = null;

            ParametrosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandParametros);

                while (dr.Read())
                {
                    m = Factory.GetParametros(dr);

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
        /// Lista un parametro especifico del sistema
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ParametrosInfo ListxId(int Id)
        {
            db.SetParameterValue(commandParametros, "i_operation", 'S');
            db.SetParameterValue(commandParametros, "i_option", 'B');
            db.SetParameterValue(commandParametros, "i_par_id", Id);

            List<ParametrosInfo> col = new List<ParametrosInfo>();

            IDataReader dr = null;

            ParametrosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandParametros);

                while (dr.Read())
                {
                    m = Factory.GetParametros(dr);
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

        /// <summary>
        /// Realiza la actualizacion de un parametro del sistema.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ParametrosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandParametros, "i_operation", 'U');
                db.SetParameterValue(commandParametros, "i_option", 'A');
                db.SetParameterValue(commandParametros, "i_par_id", item.Id);
                db.SetParameterValue(commandParametros, "i_par_valor", item.Valor);
                
                dr = db.ExecuteReader(commandParametros);

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