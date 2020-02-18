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
    public class ReglasCampos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReglasCampos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReglasCampos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReglasCampos()
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
            commandReglasCampos = db.GetStoredProcCommand("PRC_SVDN_REGLAS_CAMPOS");

            db.AddInParameter(commandReglasCampos, "i_operation", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_option", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandReglasCampos, "i_cam_nombre", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_tab_id", DbType.Int32);
            db.AddInParameter(commandReglasCampos, "i_cam_descripcion", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_cam_tipo", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_cam_tblpadre", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_cam_campopadre", DbType.String);
            db.AddInParameter(commandReglasCampos, "i_cam_campopadrenombre", DbType.String);

            db.AddOutParameter(commandReglasCampos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandReglasCampos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de ReglasCampos

        /// <summary>
        /// Lista todos los campos de tablas de reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglasCamposInfo> List()
        {
            db.SetParameterValue(commandReglasCampos, "i_operation", 'S');
            db.SetParameterValue(commandReglasCampos, "i_option", 'A');

            List<ReglasCamposInfo> col = new List<ReglasCamposInfo>();

            IDataReader dr = null;

            ReglasCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasCampos);

                while (dr.Read())
                {
                    m = Factory.GetReglasCampos(dr);

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
        /// Lista todos los campos de una tabla especifica
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public List<ReglasCamposInfo> ListxIdTabla(int IdTabla)
        {
            db.SetParameterValue(commandReglasCampos, "i_operation", 'S');
            db.SetParameterValue(commandReglasCampos, "i_option", 'B');
            db.SetParameterValue(commandReglasCampos, "i_tab_id", IdTabla);

            List<ReglasCamposInfo> col = new List<ReglasCamposInfo>();

            IDataReader dr = null;

            ReglasCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasCampos);

                while (dr.Read())
                {
                    m = Factory.GetReglasCampos(dr);

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
        /// Lista un campo por id.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public ReglasCamposInfo ListxIdCampo(int IdCampo)
        {
            db.SetParameterValue(commandReglasCampos, "i_operation", 'S');
            db.SetParameterValue(commandReglasCampos, "i_option", 'C');
            db.SetParameterValue(commandReglasCampos, "i_cam_id", IdCampo);           

            IDataReader dr = null;

            ReglasCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasCampos);

                if (dr.Read())
                {
                    m = Factory.GetReglasCampos(dr);                                      
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
        ///  Lista los valores de un combo genericamente.
        /// </summary>
        /// <param name="IdCombo"></param>
        /// <param name="ValueCombo"></param>
        /// <param name="TablaCombo"></param>
        /// <returns></returns>
        public List<ReglasCamposInfo> ListxComboGenerico(string IdCombo, string ValueCombo, string TablaCombo)
        {
            db.SetParameterValue(commandReglasCampos, "i_operation", 'S');
            db.SetParameterValue(commandReglasCampos, "i_option", 'D');
            db.SetParameterValue(commandReglasCampos, "i_cam_campopadre", IdCombo);
            db.SetParameterValue(commandReglasCampos, "i_cam_campopadrenombre", ValueCombo);
            db.SetParameterValue(commandReglasCampos, "i_cam_tblpadre", TablaCombo);

            List<ReglasCamposInfo> col = new List<ReglasCamposInfo>();

            IDataReader dr = null;

            ReglasCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasCampos);

                while (dr.Read())
                {
                    m = Factory.GetReglasCamposComboGenerico(dr);

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