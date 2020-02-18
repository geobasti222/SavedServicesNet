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
    public class ReglasCondiciones
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReglasCondiciones;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReglasCondiciones(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReglasCondiciones()
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
            commandReglasCondiciones = db.GetStoredProcCommand("PRC_SVDN_REGLAS_CONDICIONES");

            db.AddInParameter(commandReglasCondiciones, "i_operation", DbType.String);
            db.AddInParameter(commandReglasCondiciones, "i_option", DbType.String);
            db.AddParameter(commandReglasCondiciones, "i_con_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);            
            db.AddInParameter(commandReglasCondiciones, "i_reg_id", DbType.Int32);
            db.AddInParameter(commandReglasCondiciones, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandReglasCondiciones, "i_con_descripcion", DbType.String);            
            db.AddInParameter(commandReglasCondiciones, "i_con_valor", DbType.String);
            db.AddInParameter(commandReglasCondiciones, "i_ope_id", DbType.Int32);
            db.AddInParameter(commandReglasCondiciones, "i_con_idchar", DbType.String);            
            db.AddInParameter(commandReglasCondiciones, "i_cam_descripcion", DbType.String);
            db.AddInParameter(commandReglasCondiciones, "i_tab_concepto", DbType.String);
            db.AddInParameter(commandReglasCondiciones, "i_ope_nombre", DbType.String);
            db.AddInParameter(commandReglasCondiciones, "i_tab_id", DbType.Int32);

            db.AddOutParameter(commandReglasCondiciones, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandReglasCondiciones, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de ReglasCondiciones

        /// <summary>
        /// lista todos los Paises existentes.
        /// </summary>
        /// <returns></returns>
        public List<ReglasCondicionesInfo> List()
        {
            db.SetParameterValue(commandReglasCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandReglasCondiciones, "i_option", 'A');

            List<ReglasCondicionesInfo> col = new List<ReglasCondicionesInfo>();

            IDataReader dr = null;

            ReglasCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetReglasCondiciones(dr);

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
        /// Lista todos las condiciones de una regla especifica.
        /// </summary>
        /// <param name="IdRegla"></param>
        /// <returns></returns>
        public List<ReglasCondicionesInfo> ListxIdRegla(int IdRegla)
        {
            db.SetParameterValue(commandReglasCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandReglasCondiciones, "i_option", 'B');
            db.SetParameterValue(commandReglasCondiciones, "i_reg_id", IdRegla);

            List<ReglasCondicionesInfo> col = new List<ReglasCondicionesInfo>();

            IDataReader dr = null;

            ReglasCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetReglasCondiciones(dr);

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
        /// Realiza el registro de una condicion para las reglas.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(ReglasCondicionesInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasCondiciones, "i_operation", 'I');
                db.SetParameterValue(commandReglasCondiciones, "i_option", 'A');
                                
                db.SetParameterValue(commandReglasCondiciones, "i_reg_id", item.IdRegla);
                db.SetParameterValue(commandReglasCondiciones, "i_cam_id", item.IdCampo);
                db.SetParameterValue(commandReglasCondiciones, "i_con_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglasCondiciones, "i_con_valor", item.Valor);
                db.SetParameterValue(commandReglasCondiciones, "i_ope_id", item.IdOperador);
                db.SetParameterValue(commandReglasCondiciones, "i_con_idchar", item.IdCadena);
                db.SetParameterValue(commandReglasCondiciones, "i_cam_descripcion", item.NombreCampo);
                db.SetParameterValue(commandReglasCondiciones, "i_tab_concepto", item.NombreConcepto);
                db.SetParameterValue(commandReglasCondiciones, "i_ope_nombre", item.NombreOperador);
                db.SetParameterValue(commandReglasCondiciones, "i_tab_id", item.IdConcepto);

                dr = db.ExecuteReader(commandReglasCondiciones);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandReglasCondiciones, "i_con_id"));

            }
            catch (Exception ex)
            {
                id = 0;

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

            return id;

        }

        /// <summary>
        /// Realiza la actualizacion de una condicion.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(ReglasCondicionesInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasCondiciones, "i_operation", 'U');
                db.SetParameterValue(commandReglasCondiciones, "i_option", 'A');

                db.SetParameterValue(commandReglasCondiciones, "i_con_id", item.Id);
                db.SetParameterValue(commandReglasCondiciones, "i_reg_id", item.IdRegla);
                db.SetParameterValue(commandReglasCondiciones, "i_cam_id", item.IdCampo);
                db.SetParameterValue(commandReglasCondiciones, "i_con_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglasCondiciones, "i_con_valor", item.Valor);
                db.SetParameterValue(commandReglasCondiciones, "i_ope_id", item.IdOperador);
                db.SetParameterValue(commandReglasCondiciones, "i_con_idchar", item.IdCadena);
                db.SetParameterValue(commandReglasCondiciones, "i_cam_descripcion", item.NombreCampo);
                db.SetParameterValue(commandReglasCondiciones, "i_tab_concepto", item.NombreConcepto);
                db.SetParameterValue(commandReglasCondiciones, "i_ope_nombre", item.NombreOperador);

                dr = db.ExecuteReader(commandReglasCondiciones);

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
        /// Elimina todas las condiciones de una regla.
        /// </summary>
        /// <param name="IdRegla">Id Regla</param>
        /// <returns></returns>
        public bool DeleteCondiciones(int IdRegla)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasCondiciones, "i_operation", 'D');
                db.SetParameterValue(commandReglasCondiciones, "i_option", 'A');
                db.SetParameterValue(commandReglasCondiciones, "i_reg_id", IdRegla);

                dr = db.ExecuteReader(commandReglasCondiciones);

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