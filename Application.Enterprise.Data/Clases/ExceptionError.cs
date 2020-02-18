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
    public class ExceptionError
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandExceptionError;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ExceptionError(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ExceptionError()
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
            commandExceptionError = db.GetStoredProcCommand("PRC_SVDN_EXCEPTION_ERROR");

            db.AddInParameter(commandExceptionError, "i_operation", DbType.String);
            db.AddInParameter(commandExceptionError, "i_option", DbType.String);
            db.AddInParameter(commandExceptionError, "i_eer_id", DbType.Int32);
            db.AddInParameter(commandExceptionError, "i_eer_componente", DbType.String);
            db.AddInParameter(commandExceptionError, "i_eer_metodo", DbType.String);
            db.AddInParameter(commandExceptionError, "i_eer_descripcion", DbType.String);
            db.AddInParameter(commandExceptionError, "i_eer_usuario", DbType.String);   

            db.AddOutParameter(commandExceptionError, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandExceptionError, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de ExceptionError
        
     
        public bool RegistrarException(ExceptionErrorInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandExceptionError, "i_operation", 'I');
                db.SetParameterValue(commandExceptionError, "i_option", 'A');
                db.SetParameterValue(commandExceptionError, "i_eer_id", item.Id);
                db.SetParameterValue(commandExceptionError, "i_eer_componente", item.Componente);
                db.SetParameterValue(commandExceptionError, "i_eer_metodo", item.Metodo);
                db.SetParameterValue(commandExceptionError, "i_eer_descripcion", item.Descripcion);
                db.SetParameterValue(commandExceptionError, "i_eer_usuario", item.Usuario);

                dr = db.ExecuteReader(commandExceptionError);

                transOk = true;

            }
            catch (Exception ex)
            {
                transOk = false;

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