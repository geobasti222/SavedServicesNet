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
    public class TipoVisita
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTipoVisita;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TipoVisita(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TipoVisita()
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
            commandTipoVisita = db.GetStoredProcCommand("PRC_SVDN_TIPOVISITA");

            db.AddInParameter(commandTipoVisita, "i_operation", DbType.String);
            db.AddInParameter(commandTipoVisita, "i_option", DbType.String);
            db.AddInParameter(commandTipoVisita, "i_tvi_id", DbType.Int32);
            db.AddInParameter(commandTipoVisita, "i_tvi_nombre", DbType.String);
            db.AddInParameter(commandTipoVisita, "i_tvi_estado", DbType.Boolean);

            db.AddOutParameter(commandTipoVisita, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTipoVisita, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Tipo de Visita

        /// <summary>
        /// lista todos los tipo de visitas existentes.
        /// </summary>
        /// <returns></returns>
        public List<TipoVisitaInfo> List()
        {
            db.SetParameterValue(commandTipoVisita, "i_operation", 'S');
            db.SetParameterValue(commandTipoVisita, "i_option", 'A');

            List<TipoVisitaInfo> col = new List<TipoVisitaInfo>();

            IDataReader dr = null;

            TipoVisitaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTipoVisita);

                while (dr.Read())
                {
                    m = Factory.GetTipoVisita(dr);

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