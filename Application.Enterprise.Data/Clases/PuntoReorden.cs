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
    public class PuntoReorden
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPuntoReorden;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PuntoReorden(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PuntoReorden()
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
            commandPuntoReorden = db.GetStoredProcCommand("PRC_SVDN_PUNTOREORDEN");

            db.AddInParameter(commandPuntoReorden, "i_operation", DbType.String);
            db.AddInParameter(commandPuntoReorden, "i_option", DbType.String);
            db.AddInParameter(commandPuntoReorden, "i_plu", DbType.Int32);
            db.AddInParameter(commandPuntoReorden, "i_valoragotado", DbType.Int32);
            db.AddInParameter(commandPuntoReorden, "i_estado", DbType.Boolean);

            db.AddOutParameter(commandPuntoReorden, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPuntoReorden, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Punto de Reorden

        /// <summary>
        /// Lista todas las configuraciones de punto de reorden.
        /// </summary>
        /// <returns></returns>
        public List<PuntoReordenInfo> List()
        {
            db.SetParameterValue(commandPuntoReorden, "i_operation", 'S');
            db.SetParameterValue(commandPuntoReorden, "i_option", 'A');

            List<PuntoReordenInfo> col = new List<PuntoReordenInfo>();

            IDataReader dr = null;

            PuntoReordenInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPuntoReorden);

                while (dr.Read())
                {
                    m = Factory.GetPuntoReorden(dr);

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
        /// Lista la configuracion de un punto de reorden x plu.
        /// </summary>
        /// <param name="Plu"></param>
        /// <returns></returns>
        public PuntoReordenInfo ListxPlu(int Plu)
        {
            db.SetParameterValue(commandPuntoReorden, "i_operation", 'S');
            db.SetParameterValue(commandPuntoReorden, "i_option", 'B');
            db.SetParameterValue(commandPuntoReorden, "i_plu", Plu);

            IDataReader dr = null;

            PuntoReordenInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPuntoReorden);

                while (dr.Read())
                {
                    m = Factory.GetPuntoReorden(dr);
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
        /// Realiza el bloqueo de los plus por punto de reorden.
        /// </summary>
        /// <returns></returns>
        public bool BloquearxPuntoReorden()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPuntoReorden, "i_operation", 'S');
                db.SetParameterValue(commandPuntoReorden, "i_option", 'C');

                dr = db.ExecuteReader(commandPuntoReorden);

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
        /// Realiza la actualizacion de un punto de reorden.
        /// </summary>
        /// <param name="Plu"></param>
        /// <returns></returns>
        public bool Update(PuntoReordenInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPuntoReorden, "i_operation", 'U');
                db.SetParameterValue(commandPuntoReorden, "i_option", 'A');
                db.SetParameterValue(commandPuntoReorden, "i_plu", item.PLU);
                db.SetParameterValue(commandPuntoReorden, "i_valoragotado", item.ValorAgotado);

                dr = db.ExecuteReader(commandPuntoReorden);

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