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
    public class MailPlanActividadDetalle
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMailPlanActividadDetalle;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MailPlanActividadDetalle(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MailPlanActividadDetalle()
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
            commandMailPlanActividadDetalle = db.GetStoredProcCommand("PRC_SVDN_MAILPLAN_ADETALLE");

            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpa_id", DbType.Int32);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_MAILGROUP", DbType.Int32);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_zona", DbType.String);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpad_comienzo", DbType.String);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpad_fin", DbType.String);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpad_repeticion", DbType.String);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpa_id_anterior", DbType.String);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpa_id_siguiente", DbType.String);
            db.AddInParameter(commandMailPlanActividadDetalle, "i_mpad_notas", DbType.String);

            db.AddOutParameter(commandMailPlanActividadDetalle, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMailPlanActividadDetalle, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de MailPlanActividadDetalle

        /// <summary>
        /// lista todos las Actividades existentes.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanActividadDetalleInfo> List()
        {
            db.SetParameterValue(commandMailPlanActividadDetalle, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanActividadDetalle, "i_option", 'A');

            List<MailPlanActividadDetalleInfo> col = new List<MailPlanActividadDetalleInfo>();

            IDataReader dr = null;

            MailPlanActividadDetalleInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanActividadDetalle);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanActividadDetalle(dr);

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
        /// lista todos los Estados existentes por codigo de pais.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanActividadDetalleInfo> ListById(int Id)
        {
            db.SetParameterValue(commandMailPlanActividadDetalle, "i_operation", 'S');
            db.SetParameterValue(commandMailPlanActividadDetalle, "i_option", 'B');
            db.SetParameterValue(commandMailPlanActividadDetalle, "mpa_id", Id);

            List<MailPlanActividadDetalleInfo> col = new List<MailPlanActividadDetalleInfo>();

            IDataReader dr = null;

            MailPlanActividadDetalleInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlanActividadDetalle);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanActividadDetalle(dr);

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
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Update(MailPlanActividadDetalleInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_operation", 'U');
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_option", 'A');

                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpa_id", item.Id);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_MAILGROUP", item.MailGroup);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_zona", item.Zona);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_comienzo", item.Comienzo);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_fin", item.Fin);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_repeticion", item.Repeticion);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpa_id_anterior", item.Anterior);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpa_id_siguiente", item.Id);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_notas", item.Id);

                dr = db.ExecuteReader(commandMailPlanActividadDetalle);

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
        /// Guarda los datos de un cliente en la tabla de Nivi en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(MailPlanActividadDetalleInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_operation", 'I');
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_option", 'A');

                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpa_id", item.Id);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_MAILGROUP", item.MailGroup);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_zona", item.Zona);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_comienzo", item.Comienzo);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_fin", item.Fin);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_repeticion", item.Repeticion);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpa_id_anterior", item.Anterior);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpa_id_siguiente", item.Id);
                db.SetParameterValue(commandMailPlanActividadDetalle, "i_mpad_notas", item.Id);

                dr = db.ExecuteReader(commandMailPlanActividadDetalle);

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
