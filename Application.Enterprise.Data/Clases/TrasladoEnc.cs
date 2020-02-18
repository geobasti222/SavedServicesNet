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
    public class TrasladoEnc
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTrasladoEnc;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TrasladoEnc(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TrasladoEnc()
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
            commandTrasladoEnc = db.GetStoredProcCommand("PRC_SVDN_TRASLADOS1_2000");

            db.AddInParameter(commandTrasladoEnc, "i_operation", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_option", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "io_numero", DbType.String);
            db.AddParameter(commandTrasladoEnc, "io_numero", DbType.String, 12, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandTrasladoEnc, "i_mes", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_anulado", DbType.Int32);
            db.AddInParameter(commandTrasladoEnc, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandTrasladoEnc, "i_bodegahacia", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_observaciones", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_bodega", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_fechacreacion", DbType.DateTime);
            db.AddInParameter(commandTrasladoEnc, "i_claveusuario", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_traslado_pyg", DbType.Int32);
            db.AddInParameter(commandTrasladoEnc, "i_num_doc_espera", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_zona", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_espera", DbType.Int32);
            db.AddInParameter(commandTrasladoEnc, "i_codigo_numeracion", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_transmitido", DbType.Int32);
            db.AddInParameter(commandTrasladoEnc, "i_codtipo", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_devol", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_nit", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_catalogo", DbType.String);
            db.AddInParameter(commandTrasladoEnc, "i_unidades", DbType.Int32);
            db.AddInParameter(commandTrasladoEnc, "i_totalseparados", DbType.Decimal);
            db.AddInParameter(commandTrasladoEnc, "i_separado", DbType.Int32);            
            db.AddOutParameter(commandTrasladoEnc, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTrasladoEnc, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Encabezado de Traslado

        /// <summary>
        /// Guarda un encabezado de traslado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Insert(TrasladoEncInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandTrasladoEnc, "i_operation", 'I');
                db.SetParameterValue(commandTrasladoEnc, "i_option", 'A');

                db.SetParameterValue(commandTrasladoEnc, "io_numero", 0);
                db.SetParameterValue(commandTrasladoEnc, "i_mes", item.Mes);
                db.SetParameterValue(commandTrasladoEnc, "i_anulado", item.Anulado);
                db.SetParameterValue(commandTrasladoEnc, "i_fecha", item.Fecha);
                db.SetParameterValue(commandTrasladoEnc, "i_bodegahacia", item.BodegaHacia);
                db.SetParameterValue(commandTrasladoEnc, "i_observaciones", item.Observaciones);
                db.SetParameterValue(commandTrasladoEnc, "i_bodega", item.Bodega);
                db.SetParameterValue(commandTrasladoEnc, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandTrasladoEnc, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandTrasladoEnc, "i_traslado_pyg", item.TrasladoPyG);
                db.SetParameterValue(commandTrasladoEnc, "i_num_doc_espera", item.NumeroDocEspera);
                db.SetParameterValue(commandTrasladoEnc, "i_zona", item.Zona);
                db.SetParameterValue(commandTrasladoEnc, "i_espera", item.Espera);
                db.SetParameterValue(commandTrasladoEnc, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandTrasladoEnc, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandTrasladoEnc, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandTrasladoEnc, "i_devol", item.Devol);
                db.SetParameterValue(commandTrasladoEnc, "i_nit", item.Nit);
                db.SetParameterValue(commandTrasladoEnc, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandTrasladoEnc, "i_unidades", item.Unidades);
                db.SetParameterValue(commandTrasladoEnc, "i_totalseparados", item.TotalSeparados);
                db.SetParameterValue(commandTrasladoEnc, "i_separado", item.Separado);
      
                dr = db.ExecuteReader(commandTrasladoEnc);

                strid = System.Convert.ToString(db.GetParameterValue(commandTrasladoEnc, "io_numero")).Trim();
            }
            catch (Exception ex)
            {
                strid = null;

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
            return strid;
        }

        /// <summary>
        /// Lista todos los encabezados de traslados.
        /// </summary>
        /// <returns></returns>
        public List<TrasladoEncInfo> List()
        {
            db.SetParameterValue(commandTrasladoEnc, "i_operation", 'S');
            db.SetParameterValue(commandTrasladoEnc, "i_option", 'A');

            List<TrasladoEncInfo> col = new List<TrasladoEncInfo>();

            IDataReader dr = null;

            TrasladoEncInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTrasladoEnc);

                while (dr.Read())
                {
                    m = Factory.GetTrasladoEnc(dr);

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