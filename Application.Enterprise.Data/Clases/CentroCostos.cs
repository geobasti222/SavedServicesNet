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
    public class CentroCostos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCentroCostos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CentroCostos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CentroCostos()
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
            commandCentroCostos = db.GetStoredProcCommand("PRC_SVDN_CENTROCOSTOS");

            db.AddInParameter(commandCentroCostos, "i_operation", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_option", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_ccostos", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_descripcion", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandCentroCostos, "i_cuenta_ajusteinventarios", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_cuenta_ajustecmv", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_centrocostos", DbType.String);
            db.AddInParameter(commandCentroCostos, "i_plu", DbType.Decimal);
            db.AddInParameter(commandCentroCostos, "i_codubicacion", DbType.String);

            db.AddOutParameter(commandCentroCostos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCentroCostos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de CentroCostos

        /// <summary>
        /// lista todos los centros de costos existentes.
        /// </summary>
        /// <returns></returns>
        public List<CentroCostosInfo> List()
        {
            db.SetParameterValue(commandCentroCostos, "i_operation", 'S');
            db.SetParameterValue(commandCentroCostos, "i_option", 'A');

            List<CentroCostosInfo> col = new List<CentroCostosInfo>();

            IDataReader dr = null;

            CentroCostosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCentroCostos);

                while (dr.Read())
                {
                    m = Factory.GetCentroCostos(dr);

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
        /// Lista un Centros de Costos por ccostos
        /// </summary>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        public CentroCostosInfo ListxCCostos(string CCostos)
        {
            db.SetParameterValue(commandCentroCostos, "i_operation", 'S');
            db.SetParameterValue(commandCentroCostos, "i_option", 'B');
            db.SetParameterValue(commandCentroCostos, "i_ccostos", CCostos);

            IDataReader dr = null;

            CentroCostosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCentroCostos);

                while (dr.Read())
                {
                    m = Factory.GetCentroCostos(dr);
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
        ///Guarda un centro de costos nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(CentroCostosInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCentroCostos, "i_operation", 'I');
                db.SetParameterValue(commandCentroCostos, "i_option", 'A');

                db.SetParameterValue(commandCentroCostos, "i_ccostos", item.CCostos);
                db.SetParameterValue(commandCentroCostos, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandCentroCostos, "i_fecha", item.Fecha);
                db.SetParameterValue(commandCentroCostos, "i_cuenta_ajusteinventarios", item.CuentaAjusteinventarios);
                db.SetParameterValue(commandCentroCostos, "i_cuenta_ajustecmv", item.CuentaAjusteCMV);
                db.SetParameterValue(commandCentroCostos, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandCentroCostos, "i_plu", item.PLU);
                db.SetParameterValue(commandCentroCostos, "i_codubicacion", item.CodUbicacion);

                dr = db.ExecuteReader(commandCentroCostos);

                okTrans = true;
            }
            catch (Exception ex)
            {
                okTrans = false;

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
            return okTrans;
        }

        #endregion
    }
}