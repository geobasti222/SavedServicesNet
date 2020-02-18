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
    /// JA
    /// </summary>
    public class Bodega
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandBodega;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Bodega(string dataBase)
        {
            db = DatabaseFactory.CreateDatabase(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Bodega()
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
            commandBodega = db.GetStoredProcCommand("PRC_SION_BODEGA");

            db.AddInParameter(commandBodega, "i_operation",    DbType.String );
            db.AddInParameter(commandBodega, "i_option",       DbType.String );            
            
            db.AddOutParameter(commandBodega, "o_err_cod",     DbType.Int32, 1000);
            db.AddOutParameter(commandBodega, "o_err_msg",     DbType.String, 1000);

        }
        #endregion

        /// <summary>
        /// lista lso amarrados
        /// </summary>
        /// <returns></returns>
        public List<BodegaInfo> List()
        {
            db.SetParameterValue(commandBodega, "i_operation", 'S');
            db.SetParameterValue(commandBodega, "i_option", 'B');

            List<BodegaInfo> col = new List<BodegaInfo>();

            IDataReader dr = null;

            BodegaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandBodega);

                while (dr.Read())
                {
                    m = Factory.getbodegas(dr);

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
    }
}
