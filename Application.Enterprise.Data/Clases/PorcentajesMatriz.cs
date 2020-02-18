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
    public class PorcentajesMatriz
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPorcentajesMatriz;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PorcentajesMatriz(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PorcentajesMatriz()
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
            commandPorcentajesMatriz = db.GetStoredProcCommand("PRC_SVDN_PORCENTAJES_MATRIZ");

            db.AddInParameter(commandPorcentajesMatriz, "i_operation", DbType.String);
            db.AddInParameter(commandPorcentajesMatriz, "i_option", DbType.String);
            db.AddInParameter(commandPorcentajesMatriz, "i_pom_id", DbType.Int32);
            db.AddInParameter(commandPorcentajesMatriz, "i_pom_concepto", DbType.String);
            db.AddInParameter(commandPorcentajesMatriz, "i_pom_valormenor", DbType.Decimal);
            db.AddInParameter(commandPorcentajesMatriz, "i_pom_valormayor", DbType.Decimal);
            db.AddInParameter(commandPorcentajesMatriz, "i_pom_estado", DbType.Int32);

            db.AddOutParameter(commandPorcentajesMatriz, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPorcentajesMatriz, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Porcentajes Matriz

        /// <summary>
        /// lista todos los Porcentanjes de Matriz existentes.
        /// </summary>
        /// <returns></returns>
        public List<PorcentajesMatrizInfo> List()
        {
            db.SetParameterValue(commandPorcentajesMatriz, "i_operation", 'S');
            db.SetParameterValue(commandPorcentajesMatriz, "i_option", 'A');

            List<PorcentajesMatrizInfo> col = new List<PorcentajesMatrizInfo>();

            IDataReader dr = null;

            PorcentajesMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPorcentajesMatriz);

                while (dr.Read())
                {
                    m = Factory.GetPorcentajesMatriz(dr);

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
        /// Lista el procentaje de un concept especifico de la matriz comercial por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PorcentajesMatrizInfo ListxId(int Id)
        {
            db.SetParameterValue(commandPorcentajesMatriz, "i_operation", 'S');
            db.SetParameterValue(commandPorcentajesMatriz, "i_option", 'B');
            db.SetParameterValue(commandPorcentajesMatriz, "i_pom_id", Id);

            IDataReader dr = null;

            PorcentajesMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPorcentajesMatriz);

                while (dr.Read())
                {
                    m = Factory.GetPorcentajesMatriz(dr);
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