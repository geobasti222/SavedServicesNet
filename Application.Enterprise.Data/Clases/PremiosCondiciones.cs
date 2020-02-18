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
    public class PremiosCondiciones
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosCondiciones;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosCondiciones(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosCondiciones()
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
            commandPremiosCondiciones = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_CONDICIONES");

            db.AddInParameter(commandPremiosCondiciones, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_option", DbType.String);
            db.AddParameter(commandPremiosCondiciones, "i_con_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);
            db.AddInParameter(commandPremiosCondiciones, "i_pre_id", DbType.Int32);
            db.AddInParameter(commandPremiosCondiciones, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandPremiosCondiciones, "i_con_descripcion", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_con_valor", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_ope_id", DbType.Int32);
            db.AddInParameter(commandPremiosCondiciones, "i_con_idchar", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_cam_descripcion", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_tab_concepto", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_ope_nombre", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_tab_id", DbType.Int32);
            db.AddInParameter(commandPremiosCondiciones, "i_con_query", DbType.String);
            db.AddInParameter(commandPremiosCondiciones, "i_con_orden", DbType.Int32);

            db.AddOutParameter(commandPremiosCondiciones, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosCondiciones, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PremiosCondiciones

        /// <summary>
        /// lista todos las condiciones existentes.
        /// </summary>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> List()
        {
            db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCondiciones, "i_option", 'A');

            List<PremiosCondicionesInfo> col = new List<PremiosCondicionesInfo>();

            IDataReader dr = null;

            PremiosCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCondiciones(dr);

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
        /// Lista todos las condiciones de un premio especifica.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdPremio(int IdPremio)
        {
            db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCondiciones, "i_option", 'B');
            db.SetParameterValue(commandPremiosCondiciones, "i_pre_id", IdPremio);

            List<PremiosCondicionesInfo> col = new List<PremiosCondicionesInfo>();

            IDataReader dr = null;

            PremiosCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCondiciones(dr);

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
        /// Lista todos las reglas-condiciones (query's) activas.
        /// </summary>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxReglasPremios()
        {
            db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCondiciones, "i_option", 'C');

            List<PremiosCondicionesInfo> col = new List<PremiosCondicionesInfo>();

            IDataReader dr = null;

            PremiosCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCondiciones(dr);

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
        /// Lista un id de articulo por ID de condicion.
        /// </summary>
        /// <param name="IdCondicion"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdArticulo(int IdCondicion)
        {
            db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCondiciones, "i_option", 'D');
            db.SetParameterValue(commandPremiosCondiciones, "i_con_id", IdCondicion);

            List<PremiosCondicionesInfo> col = new List<PremiosCondicionesInfo>();

            IDataReader dr = null;

            PremiosCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetIdArticuloxCondiciones(dr);

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
        /// Lista todos las condiciones que no son de niveles de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdPremioSinNiveles(int IdPremio)
        {
            db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCondiciones, "i_option", 'E');
            db.SetParameterValue(commandPremiosCondiciones, "i_pre_id", IdPremio);

            List<PremiosCondicionesInfo> col = new List<PremiosCondicionesInfo>();

            IDataReader dr = null;

            PremiosCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCondiciones(dr);

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
        /// Lista todos las condiciones que solos son de niveles de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosCondicionesInfo> ListxIdPremioSoloNiveles(int IdPremio)
        {
            db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCondiciones, "i_option", 'F');
            db.SetParameterValue(commandPremiosCondiciones, "i_pre_id", IdPremio);

            List<PremiosCondicionesInfo> col = new List<PremiosCondicionesInfo>();

            IDataReader dr = null;

            PremiosCondicionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCondiciones);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCondiciones(dr);

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
        /// Realiza el registro de una condicion para los premios.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosCondicionesInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'I');
                db.SetParameterValue(commandPremiosCondiciones, "i_option", 'A');

                db.SetParameterValue(commandPremiosCondiciones, "i_pre_id", item.IdPremio);
                db.SetParameterValue(commandPremiosCondiciones, "i_cam_id", item.IdCampo);
                db.SetParameterValue(commandPremiosCondiciones, "i_cam_descripcion", item.NombreCampo);
                db.SetParameterValue(commandPremiosCondiciones, "i_tab_id", item.IdConcepto);
                db.SetParameterValue(commandPremiosCondiciones, "i_tab_concepto", item.NombreConcepto);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_descripcion", item.Descripcion);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_valor", item.Valor);
                db.SetParameterValue(commandPremiosCondiciones, "i_ope_id", item.IdOperador);
                db.SetParameterValue(commandPremiosCondiciones, "i_ope_nombre", item.NombreOperador);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_idchar", item.IdCadena);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_query", item.Query);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_orden", item.Orden);

                dr = db.ExecuteReader(commandPremiosCondiciones);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandPremiosCondiciones, "i_con_id"));

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
        public bool Update(PremiosCondicionesInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'U');
                db.SetParameterValue(commandPremiosCondiciones, "i_option", 'A');

                db.SetParameterValue(commandPremiosCondiciones, "i_con_id", item.Id);
                db.SetParameterValue(commandPremiosCondiciones, "i_pre_id", item.IdPremio);
                db.SetParameterValue(commandPremiosCondiciones, "i_cam_id", item.IdCampo);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_descripcion", item.Descripcion);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_valor", item.Valor);
                db.SetParameterValue(commandPremiosCondiciones, "i_ope_id", item.IdOperador);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_idchar", item.IdCadena);
                db.SetParameterValue(commandPremiosCondiciones, "i_cam_descripcion", item.NombreCampo);
                db.SetParameterValue(commandPremiosCondiciones, "i_tab_concepto", item.NombreConcepto);
                db.SetParameterValue(commandPremiosCondiciones, "i_ope_nombre", item.NombreOperador);
                db.SetParameterValue(commandPremiosCondiciones, "i_con_query", item.Query);

                dr = db.ExecuteReader(commandPremiosCondiciones);

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
        /// Elimina todas las condiciones de un premio.
        /// </summary>
        /// <param name="IdPremio">IdPremio</param>
        /// <returns></returns>
        public bool DeleteCondiciones(int IdPremio)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosCondiciones, "i_operation", 'D');
                db.SetParameterValue(commandPremiosCondiciones, "i_option", 'A');
                db.SetParameterValue(commandPremiosCondiciones, "i_pre_id", IdPremio);

                dr = db.ExecuteReader(commandPremiosCondiciones);

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