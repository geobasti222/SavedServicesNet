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
    public class TipoCategoriaCCN
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTipoCategoriaCCN;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TipoCategoriaCCN(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TipoCategoriaCCN()
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
            commandTipoCategoriaCCN = db.GetStoredProcCommand("PRC_SVDN_TIPOCATEGORIACCN");

            db.AddInParameter(commandTipoCategoriaCCN, "i_operation", DbType.String);
            db.AddInParameter(commandTipoCategoriaCCN, "i_option", DbType.String);
            db.AddInParameter(commandTipoCategoriaCCN, "i_tic_id", DbType.Int32);
            db.AddInParameter(commandTipoCategoriaCCN, "i_tic_nombre", DbType.String);
            db.AddInParameter(commandTipoCategoriaCCN, "i_tic_estado", DbType.Boolean);

            db.AddOutParameter(commandTipoCategoriaCCN, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTipoCategoriaCCN, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Tipo Categoria CCN

        /// <summary>
        /// Lista todos los tipos de categoria para el contactenos de CCN.
        /// </summary>
        /// <returns></returns>
        public List<TipoCategoriaCCNInfo> List()
        {
            db.SetParameterValue(commandTipoCategoriaCCN, "i_operation", 'S');
            db.SetParameterValue(commandTipoCategoriaCCN, "i_option", 'A');

            List<TipoCategoriaCCNInfo> col = new List<TipoCategoriaCCNInfo>();

            IDataReader dr = null;

            TipoCategoriaCCNInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTipoCategoriaCCN);

                while (dr.Read())
                {
                    m = Factory.GetTipoCategoriaCCN(dr);

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