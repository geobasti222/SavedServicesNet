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
    public class Reglas
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReglas;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Reglas(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Reglas()
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
            commandReglas = db.GetStoredProcCommand("PRC_SVDN_REGLAS");

            db.AddInParameter(commandReglas, "i_operation", DbType.String);
            db.AddInParameter(commandReglas, "i_option", DbType.String);            
            db.AddParameter(commandReglas, "i_reg_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);            
            db.AddInParameter(commandReglas, "i_reg_descripcion", DbType.String);
            db.AddInParameter(commandReglas, "i_reg_condiciones", DbType.String);
            db.AddInParameter(commandReglas, "i_reg_estado", DbType.Int32);
            db.AddInParameter(commandReglas, "i_reg_creado", DbType.DateTime);
            db.AddInParameter(commandReglas, "i_reg_modificado", DbType.DateTime);
            db.AddInParameter(commandReglas, "i_reg_orden", DbType.Int32);
            db.AddInParameter(commandReglas, "i_tab_id", DbType.Int32);
            db.AddInParameter(commandReglas, "i_reg_query", DbType.String);

            db.AddOutParameter(commandReglas, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandReglas, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de Reglas

        /// <summary>
        /// Lista todas las reglas.
        /// </summary>
        /// <returns></returns>
        public List<ReglasInfo> List()
        {
            db.SetParameterValue(commandReglas, "i_operation", 'S');
            db.SetParameterValue(commandReglas, "i_option", 'A');

            List<ReglasInfo> col = new List<ReglasInfo>();

            IDataReader dr = null;

            ReglasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglas);

                while (dr.Read())
                {
                    m = Factory.GetRegla(dr);

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
        /// Una regla especifica.
        /// </summary>
        /// <param name="IdRegla"></param>
        /// <returns></returns>
        public ReglasInfo ListxId(int IdRegla)
        {
            db.SetParameterValue(commandReglas, "i_operation", 'S');
            db.SetParameterValue(commandReglas, "i_option", 'B');
            db.SetParameterValue(commandReglas, "i_reg_id", IdRegla);

            IDataReader dr = null;

            ReglasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglas);

                if (dr.Read())
                {
                    m = Factory.GetRegla(dr);
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
        /// Lista las reglas ordenadas, activas para asignar los pedidos.
        /// </summary>
        /// <returns></returns>
        public List<ReglasInfo> ListAsignarPedidos()
        {
            db.SetParameterValue(commandReglas, "i_operation", 'S');
            db.SetParameterValue(commandReglas, "i_option", 'C');

            List<ReglasInfo> col = new List<ReglasInfo>();

            IDataReader dr = null;

            ReglasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglas);

                while (dr.Read())
                {
                    m = Factory.GetRegla(dr);

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
        /// Realiza el registro de una regla.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(ReglasInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglas, "i_operation", 'I');
                db.SetParameterValue(commandReglas, "i_option", 'A');
                  
                db.SetParameterValue(commandReglas, "i_reg_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglas, "i_reg_condiciones", item.Condiciones);
                db.SetParameterValue(commandReglas, "i_reg_estado", item.Estado);
                db.SetParameterValue(commandReglas, "i_reg_creado", item.Creado);
                db.SetParameterValue(commandReglas, "i_reg_modificado", item.Modificado);
                db.SetParameterValue(commandReglas, "i_reg_orden", item.Orden);
                db.SetParameterValue(commandReglas, "i_tab_id", item.IdTabla);
                db.SetParameterValue(commandReglas, "i_reg_query", item.Query);
                
                dr = db.ExecuteReader(commandReglas);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandReglas, "i_reg_id"));

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
        /// Realiza la actualizacion del registro de una regla.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(ReglasInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglas, "i_operation", 'U');
                db.SetParameterValue(commandReglas, "i_option", 'A');

                db.SetParameterValue(commandReglas, "i_reg_id", item.Id);
                db.SetParameterValue(commandReglas, "i_reg_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglas, "i_reg_condiciones", item.Condiciones);
                db.SetParameterValue(commandReglas, "i_reg_estado", item.Estado);                
                db.SetParameterValue(commandReglas, "i_reg_modificado", item.Modificado);
                db.SetParameterValue(commandReglas, "i_reg_orden", item.Orden);
                db.SetParameterValue(commandReglas, "i_tab_id", item.IdTabla);
                db.SetParameterValue(commandReglas, "i_reg_query", item.Query);

                dr = db.ExecuteReader(commandReglas);

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