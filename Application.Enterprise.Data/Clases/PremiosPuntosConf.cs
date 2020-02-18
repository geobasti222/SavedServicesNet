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
    public class PremiosPuntosConf
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosPuntosConf;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosPuntosConf(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosPuntosConf()
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
            commandPremiosPuntosConf = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_PUNTOSCONF");

            db.AddInParameter(commandPremiosPuntosConf, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosPuntosConf, "i_option", DbType.String);
            db.AddParameter(commandPremiosPuntosConf, "i_ptc_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);            
            db.AddInParameter(commandPremiosPuntosConf, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandPremiosPuntosConf, "i_ptc_campana", DbType.String);
            db.AddInParameter(commandPremiosPuntosConf, "i_ptc_tipoprecio", DbType.String);
            db.AddInParameter(commandPremiosPuntosConf, "i_ptc_puntos", DbType.Int32);

            db.AddOutParameter(commandPremiosPuntosConf, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosPuntosConf, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PremiosPuntosConf

        /// <summary>
        /// Realiza el registro de una configuracion de puntos.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosPuntosConfInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosPuntosConf, "i_operation", 'I');
                db.SetParameterValue(commandPremiosPuntosConf, "i_option", 'A');

                db.SetParameterValue(commandPremiosPuntosConf, "i_cam_id", item.IdCampo);
                db.SetParameterValue(commandPremiosPuntosConf, "i_ptc_campana", item.Campana);
                db.SetParameterValue(commandPremiosPuntosConf, "i_ptc_tipoprecio", item.TipoPrecio);
                db.SetParameterValue(commandPremiosPuntosConf, "i_ptc_puntos", item.Puntos);
                
                dr = db.ExecuteReader(commandPremiosPuntosConf);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandPremiosPuntosConf, "i_ptc_id"));

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
        ///Lista todos los puntos configuracion
        /// </summary>
        /// <returns></returns>
        public List<PremiosPuntosConfInfo> List()
        {
            db.SetParameterValue(commandPremiosPuntosConf, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosConf, "i_option", 'A');

            List<PremiosPuntosConfInfo> col = new List<PremiosPuntosConfInfo>();

            IDataReader dr = null;

            PremiosPuntosConfInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosConf);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosConf(dr);

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
        /// muestra la configuracion de los puntos por id de configuracion.
        /// </summary>
        /// <param name="IdConfiguracion"></param>
        /// <returns></returns>
        public PremiosPuntosConfInfo ListxIdConfiguracion(int IdConfiguracion)
        {
            db.SetParameterValue(commandPremiosPuntosConf, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosConf, "i_option", 'B');
            db.SetParameterValue(commandPremiosPuntosConf, "i_ptc_id", IdConfiguracion);

            IDataReader dr = null;

            PremiosPuntosConfInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosConf);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosConf(dr);
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
        /// muestra la configuracion de los puntos por id del campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public PremiosPuntosConfInfo ListxIdCampo(int IdCampo)
        {
            db.SetParameterValue(commandPremiosPuntosConf, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosConf, "i_option", 'C');
            db.SetParameterValue(commandPremiosPuntosConf, "i_cam_id", IdCampo);

            IDataReader dr = null;

            PremiosPuntosConfInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosConf);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosConf(dr);
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