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
    public class HistoricoClienteResumen
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandHistoricoClienteResumen;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"></param>
        public HistoricoClienteResumen(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public HistoricoClienteResumen()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        private void Config()
        {
            commandHistoricoClienteResumen = db.GetStoredProcCommand("PRC_SVDN_CLIENTES_HISTORICO_RESUMEN");

            db.AddInParameter(commandHistoricoClienteResumen, "i_operation", DbType.String);
            db.AddInParameter(commandHistoricoClienteResumen, "i_option", DbType.String);
            db.AddInParameter(commandHistoricoClienteResumen, "i_campana", DbType.String);
            db.AddInParameter(commandHistoricoClienteResumen, "i_zona", DbType.String);
            db.AddInParameter(commandHistoricoClienteResumen, "i_reg_codregional", DbType.Int32);
            db.AddInParameter(commandHistoricoClienteResumen, "i_vendedor", DbType.String);
            db.AddInParameter(commandHistoricoClienteResumen, "i_esc_id", DbType.Int32);
            db.AddInParameter(commandHistoricoClienteResumen, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandHistoricoClienteResumen, "i_cantidad", DbType.Int32);

            db.AddOutParameter(commandHistoricoClienteResumen, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandHistoricoClienteResumen, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de Historico Clientes Resumen

        /// <summary>
        /// Cantidad de registros en Historico Resumen
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public HistoricoClienteResumenInfo CantidadRegistros(DateTime fecha)
        {
            db.SetParameterValue(commandHistoricoClienteResumen, "i_operation", 'S');
            db.SetParameterValue(commandHistoricoClienteResumen, "i_option", 'A');
            db.SetParameterValue(commandHistoricoClienteResumen, "i_fecha", fecha);

            IDataReader dr = null;

            HistoricoClienteResumenInfo m = null;

            try
            {                
                dr = db.ExecuteReader(commandHistoricoClienteResumen);

                while (dr.Read())
                {
                    m = Factory.GetHistoricoClienteResumen(dr);
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
        /// Insercion de los campos que se encuentran en SVDN_CLIENTES_HISTORICO y no se encuentran en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertFromHistoricoToResumen(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoClienteResumen, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_option", 'A');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_fecha", fecha);

                dr = db.ExecuteReader(commandHistoricoClienteResumen);

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

        /// <summary>
        /// Se realiza reseteo de registros de prospectos campaña actual en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool ResetProspectosResumen(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoClienteResumen, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_option", 'B');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_fecha", fecha);

                dr = db.ExecuteReader(commandHistoricoClienteResumen);

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

        /// <summary>
        /// Actualizacion de los agrupamientos de estados en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateCantidadEstados(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoClienteResumen, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_option", 'A');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_fecha", fecha);


                dr = db.ExecuteReader(commandHistoricoClienteResumen);

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

        /// <summary>
        /// Se eliminan los registros duplicados, dejando en todas las combinaciones una sola existencia de la tabla SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool DeleteRegistrosDuplicados(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoClienteResumen, "i_operation", 'D');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_option", 'A');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_fecha", fecha);


                dr = db.ExecuteReader(commandHistoricoClienteResumen);

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

        /// <summary>
        /// Eliminacion de todos los registros del resumen de la campaña  actual
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool VaciadoResumenCampanaActual(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoClienteResumen, "i_operation", 'D');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_option", 'B');
                db.SetParameterValue(commandHistoricoClienteResumen, "i_fecha", fecha);


                dr = db.ExecuteReader(commandHistoricoClienteResumen);

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
