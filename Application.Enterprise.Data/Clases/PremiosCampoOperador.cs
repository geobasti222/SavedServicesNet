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
    public class PremiosCampoOperador
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosCampoOperador;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosCampoOperador(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosCampoOperador()
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
            commandPremiosCampoOperador = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_CAMPXOPER");

            db.AddInParameter(commandPremiosCampoOperador, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosCampoOperador, "i_option", DbType.String);
            db.AddInParameter(commandPremiosCampoOperador, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandPremiosCampoOperador, "i_ope_id", DbType.Int32);

            db.AddOutParameter(commandPremiosCampoOperador, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosCampoOperador, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PremiosCampoOperador

        /// <summary>
        /// Lista todos los operadores por campos.
        /// </summary>
        /// <returns></returns>
        public List<PremiosCampoOperadorInfo> List()
        {
            db.SetParameterValue(commandPremiosCampoOperador, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampoOperador, "i_option", 'A');

            List<PremiosCampoOperadorInfo> col = new List<PremiosCampoOperadorInfo>();

            IDataReader dr = null;

            PremiosCampoOperadorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampoOperador);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCampoOperador(dr);

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
        /// Lista todos los operadores de un campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        public List<PremiosCampoOperadorInfo> ListxIdCampo(int IdCampo)
        {
            db.SetParameterValue(commandPremiosCampoOperador, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampoOperador, "i_option", 'B');
            db.SetParameterValue(commandPremiosCampoOperador, "i_cam_id", IdCampo);

            List<PremiosCampoOperadorInfo> col = new List<PremiosCampoOperadorInfo>();

            IDataReader dr = null;

            PremiosCampoOperadorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampoOperador);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCampoOperador(dr);

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
        /// Lista todos los campos de un operador.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        public List<PremiosCampoOperadorInfo> ListxIdOperador(int IdOperador)
        {
            db.SetParameterValue(commandPremiosCampoOperador, "i_operation", 'S');
            db.SetParameterValue(commandPremiosCampoOperador, "i_option", 'C');
            db.SetParameterValue(commandPremiosCampoOperador, "i_ope_id", IdOperador);

            List<PremiosCampoOperadorInfo> col = new List<PremiosCampoOperadorInfo>();

            IDataReader dr = null;

            PremiosCampoOperadorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosCampoOperador);

                while (dr.Read())
                {
                    m = Factory.GetPremiosCampoOperador(dr);

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