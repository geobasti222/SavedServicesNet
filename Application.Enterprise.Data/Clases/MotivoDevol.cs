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
    public class MotivoDevol
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMotivo;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MotivoDevol(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MotivoDevol()
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
            commandMotivo = db.GetStoredProcCommand("PRC_MOTIVOSDEVOL");

            db.AddInParameter(commandMotivo, "i_operation", DbType.String);
            db.AddInParameter(commandMotivo, "i_option", DbType.String);
            db.AddInParameter(commandMotivo, "i_codmotivo", DbType.String);
            db.AddOutParameter(commandMotivo, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMotivo, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Motivo

        /// <summary>
        /// lista todos los Motivos de Devolucion.
        /// </summary>
        /// <returns></returns>
        public List<MotivoDevolInfo> List()
        {
            db.SetParameterValue(commandMotivo, "i_operation", 'S');
            db.SetParameterValue(commandMotivo, "i_option", 'A');

            List<MotivoDevolInfo> col = new List<MotivoDevolInfo>();

            IDataReader dr = null;

            MotivoDevolInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMotivo);

                while (dr.Read())
                {
                    m = Factory.GetMotivo(dr);

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