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
    public class Intermediario
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandIntermediario;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Intermediario(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Intermediario()
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
            commandIntermediario = db.GetStoredProcCommand("PRC_SVDN_INTERMEDIARIO");

            db.AddInParameter(commandIntermediario, "i_operation", DbType.String);
            db.AddInParameter(commandIntermediario, "i_option", DbType.String);
            db.AddInParameter(commandIntermediario, "i_int_id", DbType.Int32);
            db.AddInParameter(commandIntermediario, "i_int_nombre", DbType.String);
            db.AddInParameter(commandIntermediario, "i_int_estado", DbType.Int32);

            db.AddOutParameter(commandIntermediario, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandIntermediario, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Intermediario

        /// <summary>
        /// Lista todos los intermediarios
        /// </summary>
        /// <returns></returns>
        public List<IntermediarioInfo> List()
        {
            db.SetParameterValue(commandIntermediario, "i_operation", 'S');
            db.SetParameterValue(commandIntermediario, "i_option", 'A');

            List<IntermediarioInfo> col = new List<IntermediarioInfo>();

            IDataReader dr = null;

            IntermediarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandIntermediario);

                while (dr.Read())
                {
                    m = Factory.GetIntermediario(dr);

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