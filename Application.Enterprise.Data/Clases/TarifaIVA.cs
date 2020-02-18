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
    public class TarifaIVA
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTarifaIVA;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TarifaIVA(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TarifaIVA()
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
            commandTarifaIVA = db.GetStoredProcCommand("PRC_SVDN_TARIFAIVA");

            db.AddInParameter(commandTarifaIVA, "i_operation", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_option", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_tarifaiva", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_porcentaje", DbType.Decimal);
            db.AddInParameter(commandTarifaIVA, "i_cuentacompras", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_detallecompras", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_cuentaventas", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_detalleventas", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_devolucionventas", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_detalledevventas", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_devolucioncompras", DbType.String);
            db.AddInParameter(commandTarifaIVA, "i_detalledevcompras", DbType.String);

            db.AddOutParameter(commandTarifaIVA, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTarifaIVA, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de TarifaIVA

        /// <summary>
        /// Lista todas las tarifas de iva
        /// </summary>
        /// <returns></returns>
        public List<TarifaIVAInfo> List()
        {
            db.SetParameterValue(commandTarifaIVA, "i_operation", 'S');
            db.SetParameterValue(commandTarifaIVA, "i_option", 'A');

            List<TarifaIVAInfo> col = new List<TarifaIVAInfo>();

            IDataReader dr = null;

            TarifaIVAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTarifaIVA);

                while (dr.Read())
                {
                    m = Factory.GetTarifaIVA(dr);

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
        /// Lista la tarifa de iva por id
        /// </summary>
        /// <param name="IdTarifaIVA"></param>
        /// <returns></returns>
        public TarifaIVAInfo ListxId(string IdTarifaIVA) 
        {
            db.SetParameterValue(commandTarifaIVA, "i_operation", 'S');
            db.SetParameterValue(commandTarifaIVA, "i_option", 'B');
            db.SetParameterValue(commandTarifaIVA, "i_tarifaiva", IdTarifaIVA);

            IDataReader dr = null;

            TarifaIVAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTarifaIVA);

                if (dr.Read())
                {
                    m = Factory.GetTarifaIVA(dr);
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