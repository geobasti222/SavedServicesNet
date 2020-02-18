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
    public class RetencionIca
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandRetencionIca;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public RetencionIca(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public RetencionIca()
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
            commandRetencionIca = db.GetStoredProcCommand("PRC_SVDN_RETENCIONICA");

            db.AddInParameter(commandRetencionIca, "i_operation", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_option", DbType.String);
           
            db.AddInParameter(commandRetencionIca, "i_rete_ica", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_descripción", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_porcentaje", DbType.Double);
            db.AddInParameter(commandRetencionIca, "i_cuenta_contable", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_cuenta_db", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_cuenta_cr", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_detalle_db", DbType.String);
            db.AddInParameter(commandRetencionIca, "i_detalle_cr", DbType.String);

            db.AddOutParameter(commandRetencionIca, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandRetencionIca, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de Retencion Ica

        /// <summary>
        /// lista todas las Retenciones Ica existentes.
        /// </summary>
        /// <returns></returns>
        public List<RetencionIcaInfo> List()
        {
            db.SetParameterValue(commandRetencionIca, "i_operation", 'S');
            db.SetParameterValue(commandRetencionIca, "i_option", 'A');

            List<RetencionIcaInfo> col = new List<RetencionIcaInfo>();

            IDataReader dr = null;

            RetencionIcaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRetencionIca);

                while (dr.Read())
                {
                    m = Factory.GetRetencionIca(dr);

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