using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Diagnostics;


namespace Application.Enterprise.Data
{
    public class ProcesamientosTipo
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandProcesamientosTipo;

        #region Constructor
        public ProcesamientosTipo(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        public ProcesamientosTipo()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }


        private void Config()
        {
            commandProcesamientosTipo = db.GetStoredProcCommand("PRC_SVDN_PROCESAMIENTOS_TIPO");

            db.AddInParameter(commandProcesamientosTipo, "i_operation", DbType.String);
            db.AddInParameter(commandProcesamientosTipo, "i_option", DbType.String);            
            db.AddInParameter(commandProcesamientosTipo, "i_prc_id", DbType.Int32);            
            db.AddInParameter(commandProcesamientosTipo, "i_prc_descripcion", DbType.String);
            db.AddOutParameter(commandProcesamientosTipo, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandProcesamientosTipo, "o_err_msg", DbType.String, 1000);
        }
        #endregion


        #region Metodos de ProcesamientosTipo

        public List<ProcesamientosTipoInfo> List()
        {
            db.SetParameterValue(commandProcesamientosTipo, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosTipo, "i_option", 'A');

            List<ProcesamientosTipoInfo> col = new List<ProcesamientosTipoInfo>();

            IDataReader dr = null;

            ProcesamientosTipoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosTipo);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosTipo(dr);

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


        public string InsertProcesamientoTipo(ProcesamientosTipoInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandProcesamientosTipo, "i_operation", 'I');
                db.SetParameterValue(commandProcesamientosTipo, "i_option", 'A');
                db.SetParameterValue(commandProcesamientosTipo, "i_prc_id", item.ProcesoId);
                db.SetParameterValue(commandProcesamientosTipo, "i_prc_descripcion", item.ProcesoDescripcion);
                dr = db.ExecuteReader(commandProcesamientosTipo);

                strid = System.Convert.ToString(db.GetParameterValue(commandProcesamientosTipo, "i_prc_id")).Trim();
                //Obtiene el identificador (consecutivo) del insert                

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

            return strid;
        }


        public bool UpdateProcesamientoTipo(ProcesamientosTipoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandProcesamientosTipo, "i_operation", 'U');
                db.SetParameterValue(commandProcesamientosTipo, "i_option", 'A');
                db.SetParameterValue(commandProcesamientosTipo, "i_prc_id", item.ProcesoId);
                db.SetParameterValue(commandProcesamientosTipo, "i_prc_descripcion", item.ProcesoDescripcion);

                dr = db.ExecuteReader(commandProcesamientosTipo);
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


        public bool DeleteProcesamientoTipo(ProcesamientosTipoInfo item)
        {
            bool transOk = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandProcesamientosTipo, "i_operation", 'D');
                db.SetParameterValue(commandProcesamientosTipo, "i_option", 'A');
                db.SetParameterValue(commandProcesamientosTipo, "i_prc_id", item.ProcesoId);
                dr = db.ExecuteReader(commandProcesamientosTipo);
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
