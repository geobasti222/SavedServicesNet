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
    public class UsuarioVendedor
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandUsuarioVendedor;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public UsuarioVendedor(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public UsuarioVendedor()
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
            commandUsuarioVendedor = db.GetStoredProcCommand("PRC_SVDN_SUSUARIOSXVENDEDOR");

            db.AddInParameter(commandUsuarioVendedor, "i_operation", DbType.String);
            db.AddInParameter(commandUsuarioVendedor, "i_option", DbType.String);
            db.AddInParameter(commandUsuarioVendedor, "i_clave_acce", DbType.String);
            db.AddInParameter(commandUsuarioVendedor, "i_vendedor", DbType.String);

            db.AddOutParameter(commandUsuarioVendedor, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandUsuarioVendedor, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de UsuarioVendedor

        /// <summary>
        /// Lista todos los usuario x vendedor
        /// </summary>
        /// <returns></returns>
        public List<UsuarioVendedorInfo> List()
        {
            db.SetParameterValue(commandUsuarioVendedor, "i_operation", 'S');
            db.SetParameterValue(commandUsuarioVendedor, "i_option", 'A');

            List<UsuarioVendedorInfo> col = new List<UsuarioVendedorInfo>();

            IDataReader dr = null;

            UsuarioVendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarioVendedor);

                while (dr.Read())
                {
                    m = Factory.GetUsuarioVendedor(dr);

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
        /// Lista un usuario x vendedor por clave y id vendedor
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public UsuarioVendedorInfo ListxClavexIdVendedor(string Clave, string IdVendedor)
        {
            db.SetParameterValue(commandUsuarioVendedor, "i_operation", 'S');
            db.SetParameterValue(commandUsuarioVendedor, "i_option", 'B');
            db.SetParameterValue(commandUsuarioVendedor, "i_clave_acce", Clave);
            db.SetParameterValue(commandUsuarioVendedor, "i_vendedor", IdVendedor);
                        
            IDataReader dr = null;

            UsuarioVendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarioVendedor);

                if (dr.Read())
                {
                    m = Factory.GetUsuarioVendedor(dr);                   
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
        ///  Lista un usuario x vendedor por clave
        /// </summary>
        /// <param name="Clave"></param>
        /// <returns></returns>
        public UsuarioVendedorInfo ListxClave(string Clave)
        {
            db.SetParameterValue(commandUsuarioVendedor, "i_operation", 'S');
            db.SetParameterValue(commandUsuarioVendedor, "i_option", 'C');
            db.SetParameterValue(commandUsuarioVendedor, "i_clave_acce", Clave);
            
            IDataReader dr = null;

            UsuarioVendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarioVendedor);

                if (dr.Read())
                {
                    m = Factory.GetUsuarioVendedor(dr);
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