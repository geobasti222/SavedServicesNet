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
    public class SaldosBodega
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandSaldosBodega;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public SaldosBodega(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public SaldosBodega()
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
            commandSaldosBodega = db.GetStoredProcCommand("PRC_SVDN_SALDOSBODEGA_2000");

            db.AddInParameter(commandSaldosBodega, "i_operation", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_option", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_bodega", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_mes", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_ccostos", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_referencia", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_saldo_inicial", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_costo_inicial", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_ventas", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_compras", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_entradas_especiales", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_salidas_especiales", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_valor_ventas", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_valor_compras", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_costo_ponderado_final", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_proveedor_ultima_compra", DbType.String);
            db.AddInParameter(commandSaldosBodega, "i_fecha_ultima_compra", DbType.DateTime);
            db.AddInParameter(commandSaldosBodega, "i_valor_ultima_compra", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_reservascliente", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_costo_inicial_ajustado", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_costo_ponderado_final_ajustado", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_reservas_inicial", DbType.Decimal);
            db.AddInParameter(commandSaldosBodega, "i_costo_inicial_ajustado_mes", DbType.Decimal);
            db.AddOutParameter(commandSaldosBodega, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandSaldosBodega, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de SaldosBodega

        /// <summary>
        /// Lista todos los saldos bodega existentes.
        /// </summary>
        /// <returns></returns>
        public List<SaldosBodegaInfo> List()
        {
            db.SetParameterValue(commandSaldosBodega, "i_operation", 'S');
            db.SetParameterValue(commandSaldosBodega, "i_option", 'A');

            List<SaldosBodegaInfo> col = new List<SaldosBodegaInfo>();

            IDataReader dr = null;

            SaldosBodegaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSaldosBodega);

                while (dr.Read())
                {
                    m = Factory.GetSaldosBodega(dr);

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