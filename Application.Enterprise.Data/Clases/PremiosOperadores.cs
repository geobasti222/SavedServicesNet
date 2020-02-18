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
    public class PremiosOperadores
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosOperadores;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosOperadores(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosOperadores()
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
            commandPremiosOperadores = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_OPERADORES");

            db.AddInParameter(commandPremiosOperadores, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosOperadores, "i_option", DbType.String);
            db.AddInParameter(commandPremiosOperadores, "i_ope_id", DbType.Int32);
            db.AddInParameter(commandPremiosOperadores, "i_ope_nombre", DbType.String);
            db.AddInParameter(commandPremiosOperadores, "i_ope_valor", DbType.String);
            db.AddInParameter(commandPremiosOperadores, "i_cam_id", DbType.Int32);
            db.AddInParameter(commandPremiosOperadores, "i_ope_simple", DbType.Int32);

            db.AddOutParameter(commandPremiosOperadores, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosOperadores, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Premios Operadores

        /// <summary>
        /// Lista todos los operadores para los campos de los premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosOperadoresInfo> List()
        {
            db.SetParameterValue(commandPremiosOperadores, "i_operation", 'S');
            db.SetParameterValue(commandPremiosOperadores, "i_option", 'A');

            List<PremiosOperadoresInfo> col = new List<PremiosOperadoresInfo>();

            IDataReader dr = null;

            PremiosOperadoresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosOperadores);

                while (dr.Read())
                {
                    m = Factory.GetPremiosOperadores(dr);

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
        public List<PremiosOperadoresInfo> ListxIdCampo(int IdCampo)
        {
            db.SetParameterValue(commandPremiosOperadores, "i_operation", 'S');
            db.SetParameterValue(commandPremiosOperadores, "i_option", 'B');
            db.SetParameterValue(commandPremiosOperadores, "i_cam_id", IdCampo);

            List<PremiosOperadoresInfo> col = new List<PremiosOperadoresInfo>();

            IDataReader dr = null;

            PremiosOperadoresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosOperadores);

                while (dr.Read())
                {
                    m = Factory.GetPremiosOperadores(dr);

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
        /// Consulta un operador por ID.
        /// </summary>
        /// <param name="IdOperador"></param>
        /// <returns></returns>
        public PremiosOperadoresInfo ListxId(int IdOperador)
        {
            db.SetParameterValue(commandPremiosOperadores, "i_operation", 'S');
            db.SetParameterValue(commandPremiosOperadores, "i_option", 'C');
            db.SetParameterValue(commandPremiosOperadores, "i_ope_id", IdOperador);
                      
            IDataReader dr = null;

            PremiosOperadoresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosOperadores);

                if (dr.Read())
                {
                    m = Factory.GetPremiosOperadores(dr);                  
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
        /// Consulta un operador por valor.
        /// </summary>
        /// <param name="ValorOperador"></param>
        /// <returns></returns>
        public PremiosOperadoresInfo ListxValor(string ValorOperador)
        {
            db.SetParameterValue(commandPremiosOperadores, "i_operation", 'S');
            db.SetParameterValue(commandPremiosOperadores, "i_option", 'D');
            db.SetParameterValue(commandPremiosOperadores, "i_ope_valor", ValorOperador);

            IDataReader dr = null;

            PremiosOperadoresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosOperadores);

                if (dr.Read())
                {
                    m = Factory.GetPremiosOperadores(dr);
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