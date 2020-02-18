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
    public class CostoMercancia
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCostoMercancia;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CostoMercancia(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CostoMercancia()
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
            commandCostoMercancia = db.GetStoredProcCommand("PRC_SVDN_COSTO_MERCANCIA_2000");

            db.AddInParameter(commandCostoMercancia, "i_operation", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_option", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_id", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_bodega", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_ccostos", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_mes", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_referencia", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_numero", DbType.String);
            db.AddInParameter(commandCostoMercancia, "i_ensamblado", DbType.Int32);
            db.AddInParameter(commandCostoMercancia, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandCostoMercancia, "i_saldo_inicial", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_costo_inicial", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_saldo_acumulado", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_cantidad", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_valor", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_costo_mercancia", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_ultimo_costo", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_orden", DbType.Int32);
            db.AddInParameter(commandCostoMercancia, "i_anulado", DbType.Int32);
            db.AddInParameter(commandCostoMercancia, "i_costo_inicial_ajustado", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_costo_mercancia_ajustado", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_ultimo_costo_ajustado", DbType.Decimal);
            db.AddInParameter(commandCostoMercancia, "i_fechadoc", DbType.DateTime);
            db.AddOutParameter(commandCostoMercancia, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCostoMercancia, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Costos de Mercancia

        /// <summary>
        /// Lista todos los costos de mercancia.
        /// </summary>
        /// <returns></returns>
        public List<CostoMercanciaInfo> List()
        {
            db.SetParameterValue(commandCostoMercancia, "i_operation", 'S');
            db.SetParameterValue(commandCostoMercancia, "i_option", 'A');

            List<CostoMercanciaInfo> col = new List<CostoMercanciaInfo>();

            IDataReader dr = null;

            CostoMercanciaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCostoMercancia);

                while (dr.Read())
                {
                    m = Factory.GetCostoMercancia(dr);

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