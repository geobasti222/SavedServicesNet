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
    public class PremiosArticulos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosArticulos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosArticulos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosArticulos()
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
            commandPremiosArticulos = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_ARTICULOS");

            db.AddInParameter(commandPremiosArticulos, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosArticulos, "i_option", DbType.String);
            db.AddParameter(commandPremiosArticulos, "i_art_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);
            db.AddInParameter(commandPremiosArticulos, "i_art_nombre", DbType.String);
            db.AddInParameter(commandPremiosArticulos, "i_art_bodega", DbType.String);
            db.AddInParameter(commandPremiosArticulos, "i_art_referencia", DbType.String);
            db.AddInParameter(commandPremiosArticulos, "i_art_ccostos", DbType.String);
            db.AddInParameter(commandPremiosArticulos, "i_pre_id", DbType.Int32);
            db.AddInParameter(commandPremiosArticulos, "i_art_cantidad", DbType.Int32);

            db.AddOutParameter(commandPremiosArticulos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosArticulos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PremiosArticulos

        /// <summary>
        /// Lista todos los articulos de los premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosArticulosInfo> List()
        {
            db.SetParameterValue(commandPremiosArticulos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosArticulos, "i_option", 'A');

            List<PremiosArticulosInfo> col = new List<PremiosArticulosInfo>();

            IDataReader dr = null;

            PremiosArticulosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosArticulos);

                while (dr.Read())
                {
                    m = Factory.GetPremiosArticulos(dr);

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
        /// Lista un articulo de un id especifico.
        /// </summary>
        /// <param name="IdArticulo"></param>
        /// <returns></returns>
        public PremiosArticulosInfo ListxId(int IdArticulo)
        {
            db.SetParameterValue(commandPremiosArticulos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosArticulos, "i_option", 'B');
            db.SetParameterValue(commandPremiosArticulos, "i_art_id", IdArticulo);

            IDataReader dr = null;

            PremiosArticulosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosArticulos);

                if (dr.Read())
                {
                    m = Factory.GetPremiosArticulos(dr);
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
        /// Lista todos los articulos de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosArticulosInfo> ListxPremio(int IdPremio)
        {
            db.SetParameterValue(commandPremiosArticulos, "i_operation", 'S');
            db.SetParameterValue(commandPremiosArticulos, "i_option", 'C');
            db.SetParameterValue(commandPremiosArticulos, "i_pre_id", IdPremio);

            List<PremiosArticulosInfo> col = new List<PremiosArticulosInfo>();

            IDataReader dr = null;

            PremiosArticulosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosArticulos);

                while (dr.Read())
                {
                    m = Factory.GetPremiosArticulos(dr);

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
        /// Realiza el registro de articulo para un premio.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosArticulosInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosArticulos, "i_operation", 'I');
                db.SetParameterValue(commandPremiosArticulos, "i_option", 'A');

                db.SetParameterValue(commandPremiosArticulos, "i_art_nombre", item.Nombre);
                db.SetParameterValue(commandPremiosArticulos, "i_art_bodega", item.Bodega);
                db.SetParameterValue(commandPremiosArticulos, "i_art_referencia", item.Referencia);
                db.SetParameterValue(commandPremiosArticulos, "i_art_ccostos", item.Ccostos);
                db.SetParameterValue(commandPremiosArticulos, "i_pre_id", item.IdPremio);
                db.SetParameterValue(commandPremiosArticulos, "i_art_cantidad", item.Cantidad);
                
                dr = db.ExecuteReader(commandPremiosArticulos);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandPremiosArticulos, "i_art_id"));

            }
            catch (Exception ex)
            {
                id = 0;

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

            return id;
        }

        #endregion
    }
}