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
    public class MailPlanEvento
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMailPlanEvento;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MailPlanEvento(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MailPlanEvento()
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
            commandMailPlanEvento = db.GetStoredProcCommand("PRC_SVDN_MAILPLAN_EVENTOS");

            db.AddInParameter(commandMailPlanEvento, "i_operation", DbType.String);
            db.AddInParameter(commandMailPlanEvento, "i_option", DbType.String);
            
            db.AddInParameter(commandMailPlanEvento, "i_mpe_id", DbType.Int32);
            db.AddInParameter(commandMailPlanEvento, "i_mpe_descripcion", DbType.String);
            db.AddInParameter(commandMailPlanEvento, "i_codciudad", DbType.String);
            db.AddInParameter(commandMailPlanEvento, "i_codestado", DbType.String);
            db.AddInParameter(commandMailPlanEvento, "i_mpe_fechaini", DbType.DateTime);
            db.AddInParameter(commandMailPlanEvento, "i_mpe_fechafin", DbType.DateTime);
            db.AddInParameter(commandMailPlanEvento, "i_mpe_observacion", DbType.String);

            db.AddOutParameter(commandMailPlanEvento, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMailPlanEvento, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de MailPlan Evento

        /// <summary>
        /// Insercion de un Evento del MailPlan
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(MailPlanEventoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            MailPlanEventoInfo m = null;

            try
            {
                db.SetParameterValue(commandMailPlanEvento, "i_operation", 'I');
                db.SetParameterValue(commandMailPlanEvento, "i_option", 'A');
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_descripcion", item.Descripcion);
                db.SetParameterValue(commandMailPlanEvento, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_fechaini", item.FechaInicial);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_fechafin", item.FechaFinal);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_observacion", item.Observacion);
                
                
                dr = db.ExecuteReader(commandMailPlanEvento);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanEvento(dr);
                }
                item.Id = m.Id; //En esta instruccion obtengo el consecutivo con el que se realizo la insercion del registro

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
        /// Actualizacion de un Evento del MailPlan por Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailPlanEventoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandMailPlanEvento, "i_operation", 'U');
                db.SetParameterValue(commandMailPlanEvento, "i_option", 'A');
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_id", item.Id);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_descripcion", item.Descripcion);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_observacion", item.Observacion);
                db.SetParameterValue(commandMailPlanEvento, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_fechaini", item.FechaInicial);
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_fechafin", item.FechaFinal);
                                    

                dr = db.ExecuteReader(commandMailPlanEvento);

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
        /// Eliminacion de un Evento del MailPlan por Id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete(MailPlanEventoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandMailPlanEvento, "i_operation", 'D');
                db.SetParameterValue(commandMailPlanEvento, "i_option", 'A');
                db.SetParameterValue(commandMailPlanEvento, "i_mpe_id", item.Id);                

                dr = db.ExecuteReader(commandMailPlanEvento);

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
        /// Lista todos los eventos de un MailPlan
        /// </summary>
        /// <returns></returns>
        public List<MailPlanEventoInfo> List()
        {
            db.SetParameterValue(commandMailPlanEvento, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanEvento, "i_option", 'A');

            List<MailPlanEventoInfo> col = new List<MailPlanEventoInfo>();

            IDataReader dr = null;

            MailPlanEventoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanEvento);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanEvento(dr);

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

        public MailPlanEventoInfo EventoById(int id)
        {
            db.SetParameterValue(commandMailPlanEvento, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanEvento, "i_option", 'B');
            db.SetParameterValue(commandMailPlanEvento, "i_mpe_id", id);
            
            IDataReader dr = null;

            MailPlanEventoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanEvento);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanEvento(dr);
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

        public List<MailPlanEventoInfo> ListPorCiudad(string codciudad)
        {
            db.SetParameterValue(commandMailPlanEvento, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanEvento, "i_option", 'C');
            db.SetParameterValue(commandMailPlanEvento, "i_codciudad", codciudad);

            List<MailPlanEventoInfo> col = new List<MailPlanEventoInfo>();

            IDataReader dr = null;

            MailPlanEventoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanEvento);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanEvento(dr);

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
                
        public List<MailPlanEventoInfo> ListID()
        {
            db.SetParameterValue(commandMailPlanEvento, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanEvento, "i_option", 'D');

            List<MailPlanEventoInfo> col = new List<MailPlanEventoInfo>();

            IDataReader dr = null;

            MailPlanEventoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanEvento);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanEvento(dr);

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
