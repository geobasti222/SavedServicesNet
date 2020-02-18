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
    public class TrasladoDet
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTrasladoDet;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TrasladoDet(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TrasladoDet()
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
            commandTrasladoDet = db.GetStoredProcCommand("PRC_SVDN_TRASLADOS2_2000");

            db.AddInParameter(commandTrasladoDet, "i_operation", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_option", DbType.String);
            db.AddParameter(commandTrasladoDet, "io_numero", DbType.String, 12, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandTrasladoDet, "i_anulado", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_id", DbType.Int32);
            db.AddInParameter(commandTrasladoDet, "i_referencia", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_descripcion", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_ensamblado", DbType.Int32);
            db.AddInParameter(commandTrasladoDet, "i_cantidad", DbType.Decimal);
            db.AddInParameter(commandTrasladoDet, "i_valor", DbType.Decimal);
            db.AddInParameter(commandTrasladoDet, "i_ccostos", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandTrasladoDet, "i_ccostosdesde", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_conceptocontable", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_centrocostos", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_serie", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_codtipo", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_nit", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_tarifaiva", DbType.Decimal);
            db.AddInParameter(commandTrasladoDet, "i_codubicacion", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_plu", DbType.Decimal);
            db.AddInParameter(commandTrasladoDet, "i_codigobarras", DbType.String);
            db.AddInParameter(commandTrasladoDet, "i_estado", DbType.Int32);
            db.AddInParameter(commandTrasladoDet, "i_estcan", DbType.Decimal);
            db.AddOutParameter(commandTrasladoDet, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTrasladoDet, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Detalle de Traslados

        /// <summary>
        /// Guarda un encabezado de traslado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Insert(TrasladoDetInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandTrasladoDet, "i_operation", 'I');
                db.SetParameterValue(commandTrasladoDet, "i_option", 'A');

                db.SetParameterValue(commandTrasladoDet, "io_numero", item.Numero);
                db.SetParameterValue(commandTrasladoDet, "i_anulado", item.Anulado);
                db.SetParameterValue(commandTrasladoDet, "i_id", 0);
                db.SetParameterValue(commandTrasladoDet, "i_referencia", item.Referencia);
                db.SetParameterValue(commandTrasladoDet, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandTrasladoDet, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandTrasladoDet, "i_cantidad", item.Cantidad);
                db.SetParameterValue(commandTrasladoDet, "i_valor", item.Valor);
                db.SetParameterValue(commandTrasladoDet, "i_ccostos", item.CCostos);
                db.SetParameterValue(commandTrasladoDet, "i_descuento", item.Descuento);
                db.SetParameterValue(commandTrasladoDet, "i_ccostosdesde", item.CCostosDesde);
                db.SetParameterValue(commandTrasladoDet, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandTrasladoDet, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandTrasladoDet, "i_serie", item.Serie);
                db.SetParameterValue(commandTrasladoDet, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandTrasladoDet, "i_nit", item.Nit);
                db.SetParameterValue(commandTrasladoDet, "i_tarifaiva", item.TarifaIva);
                db.SetParameterValue(commandTrasladoDet, "i_codubicacion", item.CodUbicacion);
                db.SetParameterValue(commandTrasladoDet, "i_plu", item.Plu);
                db.SetParameterValue(commandTrasladoDet, "i_codigobarras", item.CodigoBarras);
                db.SetParameterValue(commandTrasladoDet, "i_estado", item.Estado);
                db.SetParameterValue(commandTrasladoDet, "i_estcan", item.EstCan);

                dr = db.ExecuteReader(commandTrasladoDet);

                strid = System.Convert.ToString(db.GetParameterValue(commandTrasladoDet, "i_id")).Trim();
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
        /// Lista todos los detalles de traslados.
        /// </summary>
        /// <returns></returns>
        public List<TrasladoDetInfo> List()
        {
            db.SetParameterValue(commandTrasladoDet, "i_operation", 'S');
            db.SetParameterValue(commandTrasladoDet, "i_option", 'A');

            List<TrasladoDetInfo> col = new List<TrasladoDetInfo>();

            IDataReader dr = null;

            TrasladoDetInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTrasladoDet);

                while (dr.Read())
                {
                    m = Factory.GetTrasladoDet(dr);

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