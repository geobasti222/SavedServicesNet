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
    public class FacturaDetalle
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;

        private DbCommand commandFacturaDetalle;

        #region Constructor

        public FacturaDetalle(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public FacturaDetalle()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }



        private void Config()
        {
            commandFacturaDetalle = db.GetStoredProcCommand("PRC_SVDN_FACTURA2_2000");

            db.AddInParameter(commandFacturaDetalle, "i_operation", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_option", DbType.String);

            db.AddInParameter(commandFacturaDetalle, "i_id", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_numero", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_referencia", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_descripcion", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_valor", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_cantidad", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_tarifaiva", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_numeroremision", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_ensamblado", DbType.Int32);
            db.AddInParameter(commandFacturaDetalle, "i_anulado", DbType.Int32);
            db.AddInParameter(commandFacturaDetalle, "i_numeropedido", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_ccostos", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_conceptocontable", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_serie", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_impoconsumo", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_centrocostos", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_id_doc_fuente", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_codigobarras", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_valorconiva", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_codubicacion", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_plu", DbType.Decimal);
            db.AddInParameter(commandFacturaDetalle, "i_pedidonecsac", DbType.String);
            db.AddInParameter(commandFacturaDetalle, "i_cantidadpedida", DbType.Decimal);

            db.AddOutParameter(commandFacturaDetalle, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandFacturaDetalle, "o_err_msg", DbType.String, 1000);
        }


         #endregion

        #region Metodos de Factura Detalle
        /// <summary>
        /// Obtiene el detalle de una factura por numero
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public List<FacturaDetalleInfo> ListxNumero(string NumeroFactura)
        {
            db.SetParameterValue(commandFacturaDetalle, "i_operation", 'S');
            db.SetParameterValue(commandFacturaDetalle, "i_option", 'A');
            db.SetParameterValue(commandFacturaDetalle, "i_numero", NumeroFactura);

            List<FacturaDetalleInfo> col = new List<FacturaDetalleInfo>();

            IDataReader dr = null;

            FacturaDetalleInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandFacturaDetalle);

                while (dr.Read())
                {
                    m = Factory.GetFacturaDetalle(dr);

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
