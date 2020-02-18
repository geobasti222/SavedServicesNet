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
    public class PremiosCampos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosCampos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosCampos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosCampos()
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
            commandPremiosCampos = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_CAMPOS");

            db.AddInParameter(commandPremiosCampos, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_option", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandPremiosCampos, "i_cam_nombre", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_tab_id", DbType.Int32);
            db.AddInParameter(commandPremiosCampos, "i_cam_descripcion", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_cam_tipo", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_cam_tblpadre", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_cam_campopadre", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_cam_campopadrenombre", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_cam_queryinicial", DbType.String);
            db.AddInParameter(commandPremiosCampos, "i_tiw_id", DbType.Int32);
            db.AddInParameter(commandPremiosCampos, "i_cam_msjrequerido", DbType.String);

            db.AddOutParameter(commandPremiosCampos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosCampos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Premios Campos

        /// <summary>
        /// Lista todos los campos de tablas de premios
        /// </summary>
        /// <returns></returns>
        public List<PremiosCamposInfo> List()
        {
            db.SetParameterValue(commandPremiosCampos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampos, "i_option", 'A');

            List<PremiosCamposInfo> col = new List<PremiosCamposInfo>();

            IDataReader dr = null;

            PremiosCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampos);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCampos(dr);

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
        /// Lista todos los campos de una tabla especifica para los premios
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public List<PremiosCamposInfo> ListxIdTabla(int IdTabla)
        {
            db.SetParameterValue(commandPremiosCampos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampos, "i_option", 'B');
            db.SetParameterValue(commandPremiosCampos, "i_tab_id", IdTabla);

            List<PremiosCamposInfo> col = new List<PremiosCamposInfo>();

            IDataReader dr = null;

            PremiosCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampos);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCampos(dr);

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
        public PremiosCamposInfo ListxIdCampo(int IdCampo)
        {
            db.SetParameterValue(commandPremiosCampos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampos, "i_option", 'C');
            db.SetParameterValue(commandPremiosCampos, "i_cam_id", IdCampo);           

            IDataReader dr = null;

            PremiosCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampos);

                if (dr.Read())
                {
                    m = Factory.GetPremiosCampos(dr);                                      
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
        public List<PremiosCamposInfo> ListxComboGenerico(string IdCombo, string ValueCombo, string TablaCombo)
        {
            db.SetParameterValue(commandPremiosCampos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampos, "i_option", 'D');
            db.SetParameterValue(commandPremiosCampos, "i_cam_campopadre", IdCombo);
            db.SetParameterValue(commandPremiosCampos, "i_cam_campopadrenombre", ValueCombo);
            db.SetParameterValue(commandPremiosCampos, "i_cam_tblpadre", TablaCombo);

            List<PremiosCamposInfo> col = new List<PremiosCamposInfo>();

            IDataReader dr = null;

            PremiosCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampos);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCamposComboGenerico(dr);

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
        /// Lista un campo por nombre.
        /// </summary>
        /// <param name="NombreCampo"></param>
        /// <returns></returns>
        public PremiosCamposInfo ListxNombreCampo(string NombreCampo)
        {
            db.SetParameterValue(commandPremiosCampos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampos, "i_option", 'E');
            db.SetParameterValue(commandPremiosCampos, "i_cam_nombre", NombreCampo);

            IDataReader dr = null;

            PremiosCamposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampos);

                if (dr.Read())
                {
                    m = Factory.GetPremiosCampos(dr);
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