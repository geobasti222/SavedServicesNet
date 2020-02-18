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
    public class ZonasMultiPedidos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandZonasMultiPedidos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ZonasMultiPedidos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ZonasMultiPedidos()
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
            commandZonasMultiPedidos = db.GetStoredProcCommand("PRC_SVDN_ZONAS_MULTI_PEDIDOS");

            db.AddInParameter(commandZonasMultiPedidos, "i_operation", DbType.String);
            db.AddInParameter(commandZonasMultiPedidos, "i_option", DbType.String);
            db.AddInParameter(commandZonasMultiPedidos, "i_zona", DbType.String);
            db.AddInParameter(commandZonasMultiPedidos, "i_estado", DbType.String);

            db.AddOutParameter(commandZonasMultiPedidos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandZonasMultiPedidos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Zonas Multi Pedidos

        /// <summary>
        /// Lista todos las zonas que pueden hacer multiples pedidos.
        /// </summary>
        /// <returns></returns>
        public List<ZonasMultiPedidosInfo> List()
        {
            db.SetParameterValue(commandZonasMultiPedidos, "i_operation", 'S');
            db.SetParameterValue(commandZonasMultiPedidos, "i_option", 'A');

            List<ZonasMultiPedidosInfo> col = new List<ZonasMultiPedidosInfo>();

            IDataReader dr = null;

            ZonasMultiPedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasMultiPedidos);

                while (dr.Read())
                {
                    m = Factory.GetZonaMultiPedidos(dr);

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
        /// Consulta si existe una zona para digitar multiples pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public ZonasMultiPedidosInfo ListxZona(string Zona)
        {
            db.SetParameterValue(commandZonasMultiPedidos, "i_operation", 'S');
            db.SetParameterValue(commandZonasMultiPedidos, "i_option", 'B');
            db.SetParameterValue(commandZonasMultiPedidos, "i_zona", Zona);

            IDataReader dr = null;

            ZonasMultiPedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasMultiPedidos);

                while (dr.Read())
                {
                    m = Factory.GetZonaMultiPedidos(dr);
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