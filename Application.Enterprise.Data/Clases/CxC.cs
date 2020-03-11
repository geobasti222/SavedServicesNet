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
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CxC
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCxC;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CxC(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CxC()
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
            commandCxC = db.GetStoredProcCommand("PRC_SVDN_CXC_2000");

            db.AddInParameter(commandCxC, "i_operation", DbType.String);
            db.AddInParameter(commandCxC, "i_option", DbType.String);

            db.AddInParameter(commandCxC, "i_numero", DbType.String);
            db.AddInParameter(commandCxC, "i_zona", DbType.String);
            db.AddInParameter(commandCxC, "i_mes", DbType.String);
            db.AddInParameter(commandCxC, "i_anulado", DbType.Int32);
            db.AddInParameter(commandCxC, "i_nit", DbType.String);
            db.AddInParameter(commandCxC, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandCxC, "i_vencimiento", DbType.DateTime);
            db.AddInParameter(commandCxC, "i_vendedor", DbType.String);
            db.AddInParameter(commandCxC, "i_lider", DbType.String);
            db.AddInParameter(commandCxC, "i_valor", DbType.Decimal);
            db.AddInParameter(commandCxC, "i_saldo_ini_mes", DbType.Decimal);
            db.AddInParameter(commandCxC, "i_debitos", DbType.Decimal);
            db.AddInParameter(commandCxC, "i_creditos", DbType.Decimal);
            db.AddInParameter(commandCxC, "i_saldo_inicial", DbType.Int32);
            db.AddInParameter(commandCxC, "i_cuentacontable", DbType.String);
            db.AddInParameter(commandCxC, "i_tasacambio", DbType.Decimal);
            db.AddInParameter(commandCxC, "i_estadocartera", DbType.String);
            db.AddInParameter(commandCxC, "i_fechacreacion", DbType.DateTime);
            db.AddInParameter(commandCxC, "i_hora", DbType.String);
            db.AddInParameter(commandCxC, "i_placa", DbType.String);
            db.AddInParameter(commandCxC, "i_fechasalida", DbType.DateTime);
            db.AddInParameter(commandCxC, "i_codigolider", DbType.String);
            db.AddInParameter(commandCxC, "i_saldo", DbType.Decimal);
            db.AddOutParameter(commandCxC, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCxC, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de CxC

        /// <summary>
        /// Lista todas las cuentas por cobrar (CxC).
        /// </summary>
        /// <returns></returns>
        public List<CxCInfo> List()
        {
            db.SetParameterValue(commandCxC, "i_operation", 'S');
            db.SetParameterValue(commandCxC, "i_option", 'A');

            List<CxCInfo> col = new List<CxCInfo>();

            IDataReader dr = null;

            CxCInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCxC);

                while (dr.Read())
                {
                    m = Factory.GetCxC(dr);

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
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public CxCInfo ListxNitxMes(string Nit, string Mes)
        {
            db.SetParameterValue(commandCxC, "i_operation", 'S');
            db.SetParameterValue(commandCxC, "i_option", 'B');
            db.SetParameterValue(commandCxC, "i_nit", Nit);
            db.SetParameterValue(commandCxC, "i_mes", Mes);

            List<CxCInfo> col = new List<CxCInfo>();

            IDataReader dr = null;

            CxCInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCxC);

                while (dr.Read())
                {
                    m = Factory.GetCxCxNitxMes(dr);
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
        /// Lista el saldo de cartera de Lideres por nit .
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<CxCInfo> ListCxCVendedor(string Vendedor)
        {
            db.SetParameterValue(commandCxC, "i_operation", 'S');
            db.SetParameterValue(commandCxC, "i_option", 'C');
            db.SetParameterValue(commandCxC, "i_vendedor", Vendedor);
         

            List<CxCInfo> col = new List<CxCInfo>();

            IDataReader dr = null;

            CxCInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCxC);

                while (dr.Read())
                {
                    m = Factory.GetCxCVendedor(dr);
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
        /// Lista el saldo de cartera de Lideres por nit .
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<CxCInfo> ListCxCLider(string Lider, string Nit)
        {
            db.SetParameterValue(commandCxC, "i_operation", 'S');
            db.SetParameterValue(commandCxC, "i_option", 'D');
            db.SetParameterValue(commandCxC, "i_lider", Lider);
            db.SetParameterValue(commandCxC, "i_nit", Nit);


            List<CxCInfo> col = new List<CxCInfo>();

            IDataReader dr = null;

            CxCInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCxC);

                while (dr.Read())
                {
                    m = Factory.GetCxCLider(dr);
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