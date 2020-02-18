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
    public class MailPlanActividad
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMailPlanActividad;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MailPlanActividad(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MailPlanActividad()
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
            commandMailPlanActividad = db.GetStoredProcCommand("PRC_SVDN_MAILPLAN_ACTIVIDADES");

            db.AddInParameter(commandMailPlanActividad, "i_operation", DbType.String);
            db.AddInParameter(commandMailPlanActividad, "i_option", DbType.String);

            db.AddInParameter(commandMailPlanActividad, "i_mpa_id", DbType.Int32);
            db.AddInParameter(commandMailPlanActividad, "i_mailgroup", DbType.Int32);
            //db.AddInParameter(commandMailPlanActividad, "i_zona", DbType.String);
            db.AddInParameter(commandMailPlanActividad, "i_mpa_comienzo", DbType.DateTime);
            db.AddInParameter(commandMailPlanActividad, "i_mpa_fin", DbType.DateTime);
            db.AddInParameter(commandMailPlanActividad, "i_mpa_descripcion", DbType.String);
            db.AddInParameter(commandMailPlanActividad, "i_mpa_observacion", DbType.String);
            db.AddInParameter(commandMailPlanActividad, "i_campana", DbType.String);

            db.AddOutParameter(commandMailPlanActividad, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMailPlanActividad, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de MailPlanActividad

        /// <summary>
        /// Lista todas las actividades
        /// </summary>
        /// <returns></returns>
        public List<MailPlanActividadInfo> List()
        {
            db.SetParameterValue(commandMailPlanActividad, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanActividad, "i_option", 'A');

            List<MailPlanActividadInfo> col = new List<MailPlanActividadInfo>();

            IDataReader dr = null;

            MailPlanActividadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanActividad);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanActividad(dr);

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
        /// Lista por Id de Actividad.
        /// </summary>
        /// <returns></returns>
        public MailPlanActividadInfo ActividadPorId(int Id)
        {
            db.SetParameterValue(commandMailPlanActividad, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanActividad, "i_option", 'B');
            db.SetParameterValue(commandMailPlanActividad, "i_mpa_id", Id);

            IDataReader dr = null;

            MailPlanActividadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanActividad);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanActividad(dr);
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
        /// Lista de Actividades por Zona.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<MailPlanActividadInfo> ListByMailGroup(string mailgroup, string campana)
        {
            db.SetParameterValue(commandMailPlanActividad, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanActividad, "i_option", 'C');
            db.SetParameterValue(commandMailPlanActividad, "i_mailgroup", mailgroup);
            db.SetParameterValue(commandMailPlanActividad, "i_campana", campana);           

            List<MailPlanActividadInfo> col = new List<MailPlanActividadInfo>();

            IDataReader dr = null;

            MailPlanActividadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanActividad);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanActividad(dr);

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
        /// Actualizacion de una actividad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailPlanActividadInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandMailPlanActividad, "i_operation", 'U');
                db.SetParameterValue(commandMailPlanActividad, "i_option", 'A');                
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_id", item.Id);
                db.SetParameterValue(commandMailPlanActividad, "i_mailgroup", item.MailGroup);
                //db.SetParameterValue(commandMailPlanActividad, "i_zona", item.Zona);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_comienzo", item.FechaComienzo);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_fin", item.FechaFin);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_descripcion", item.Descripcion);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_observacion", item.Observacion);
                

                dr = db.ExecuteReader(commandMailPlanActividad);

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
        /// Insercion de una actividad y obtencion del Id que inserto.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(MailPlanActividadInfo item)
        {
            bool transOk = false; 

            IDataReader dr = null;            
            MailPlanActividadInfo m = null;            

            try
            {
                db.SetParameterValue(commandMailPlanActividad, "i_operation", 'I');
                db.SetParameterValue(commandMailPlanActividad, "i_option", 'A');                
                db.SetParameterValue(commandMailPlanActividad, "i_mailgroup", item.MailGroup);                
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_comienzo", item.FechaComienzo);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_fin", item.FechaFin);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_descripcion", item.Descripcion);
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_observacion", item.Observacion);
                                
               
                dr = db.ExecuteReader(commandMailPlanActividad);
                
                while (dr.Read())
                {
                    m = Factory.GetMailPlanActividadId(dr); //Obtengo el Id o llave despues de la insercion
                }
                item.Id = m.Id;

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

            //return m;
            return transOk;
        }

        /// <summary>
        /// Eliminacion de una Actividad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete(MailPlanActividadInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandMailPlanActividad, "i_operation", 'D');
                db.SetParameterValue(commandMailPlanActividad, "i_option", 'A');
                db.SetParameterValue(commandMailPlanActividad, "i_mpa_id", item.Id);

                dr = db.ExecuteReader(commandMailPlanActividad);

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
