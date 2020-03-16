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
    public class PLU
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPLU;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PLU(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PLU()
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
            commandPLU = db.GetStoredProcCommand("PRC_SVDN_PLU_2020");

            db.AddInParameter(commandPLU, "i_operation", DbType.String);
            db.AddInParameter(commandPLU, "i_option", DbType.String);
            db.AddInParameter(commandPLU, "i_plu", DbType.Int32);
            db.AddInParameter(commandPLU, "i_referencia", DbType.String);
            db.AddInParameter(commandPLU, "i_campana", DbType.String);
            db.AddInParameter(commandPLU, "i_codigocolor", DbType.String);
            db.AddInParameter(commandPLU, "i_codigotalla", DbType.String);
            db.AddInParameter(commandPLU, "i_codigototal", DbType.String);
            db.AddInParameter(commandPLU, "i_codigobarras", DbType.String);
            db.AddInParameter(commandPLU, "i_option_tipo", DbType.String);

            db.AddOutParameter(commandPLU, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPLU, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PLU

        /// <summary>
        /// Lista todos los PLU existentes.
        /// </summary>
        /// <returns></returns>
        public List<PLUInfo> List()
        {
            db.SetParameterValue(commandPLU, "i_operation", 'S');
            db.SetParameterValue(commandPLU, "i_option", 'A');

            List<PLUInfo> col = new List<PLUInfo>();

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPLU);

                while (dr.Read())
                {
                    m = Factory.GetPLU(dr);

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
        /// Lista todos los PLU de una referencia existentes.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<PLUInfo> ListxReferencia(string Referencia)
        {
            db.SetParameterValue(commandPLU, "i_operation", 'S');
            db.SetParameterValue(commandPLU, "i_option", 'B');
            db.SetParameterValue(commandPLU, "i_referencia", Referencia);

            List<PLUInfo> col = new List<PLUInfo>();

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPLU);

                while (dr.Read())
                {
                    m = Factory.GetPLU(dr);

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
        /// Consulta el articulo por medio del PLU.
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public PLUInfo ListxArticulosxPLU(int PLU)
        {
            db.SetParameterValue(commandPLU, "i_operation", 'S');
            db.SetParameterValue(commandPLU, "i_option", 'C');
            db.SetParameterValue(commandPLU, "i_plu", PLU);

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPLU);

                while (dr.Read())
                {
                    m = Factory.GetArticuloxPLU(dr);
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
        /// Consulta el articulo por medio del PLU por el tipo de precio. (Empresaria, Catalogo, Especial, Credito)
        /// </summary>
        /// <param name="PLU"></param>
        /// <param name="TipoPrecio"></param>
        /// <returns></returns>
        public PLUInfo ListxArticulosxPLUxTipoPrecio(int PLU, string TipoPrecio)
        {
            db.SetParameterValue(commandPLU, "i_operation", 'S');
            db.SetParameterValue(commandPLU, "i_option", 'D');
            db.SetParameterValue(commandPLU, "i_plu", PLU);
            db.SetParameterValue(commandPLU, "i_option_tipo", TipoPrecio);
            
            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPLU);

                while (dr.Read())
                {
                    m = Factory.GetArticuloxPLUxTipoPrecio(dr);
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
        /// Consulta el articulo por medio del PLU por el tipo de precio. (Empresaria, Catalogo, Especial, Credito)
        /// </summary>
        /// <param name="PLU"></param>
        /// <param name="TipoPrecio"></param>
        /// <returns></returns>
        public PLUInfo ListxArticulosxPLUxTipoPrecioJUTA(int PLU, string TipoPrecio,string campana)
        {
            db.SetParameterValue(commandPLU, "i_operation", 'S');
            db.SetParameterValue(commandPLU, "i_option", 'D');
            db.SetParameterValue(commandPLU, "i_plu", PLU);
            db.SetParameterValue(commandPLU, "i_option_tipo", TipoPrecio);
            db.SetParameterValue(commandPLU, "i_codigocolor", campana);

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPLU);

                while (dr.Read())
                {
                    m = Factory.GetArticuloxPLUxTipoPrecio(dr);
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
        /// Lista todos los PLU existentes.
        /// </summary>
        /// <returns></returns>
        public List<PLUInfo> ListCatalogoActual(string Campana)
        {
            db.SetParameterValue(commandPLU, "i_operation", 'S');
            db.SetParameterValue(commandPLU, "i_option", 'E');
            db.SetParameterValue(commandPLU, "i_campana", Campana);

            List<PLUInfo> col = new List<PLUInfo>();

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPLU);

                while (dr.Read())
                {
                    m = Factory.GetCatalogovigente (dr);

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