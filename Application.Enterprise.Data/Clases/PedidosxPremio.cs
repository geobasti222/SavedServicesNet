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
    public class PedidosxPremio
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPedidosxPremio;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PedidosxPremio(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PedidosxPremio()
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
            commandPedidosxPremio = db.GetStoredProcCommand("PRC_SVDN_PEDIDOSXPREMIOS");

            db.AddInParameter(commandPedidosxPremio, "i_operation", DbType.String);
            db.AddInParameter(commandPedidosxPremio, "i_option", DbType.String);
            db.AddInParameter(commandPedidosxPremio, "i_pre_id", DbType.Int32);
            db.AddInParameter(commandPedidosxPremio, "i_numero", DbType.String);

            db.AddOutParameter(commandPedidosxPremio, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPedidosxPremio, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Pedidos x Premio

        /// <summary>
        /// Lista todos los pedidos x premios
        /// </summary>
        /// <returns></returns>
        public List<PedidosxPremioInfo> List()
        {
            db.SetParameterValue(commandPedidosxPremio, "i_operation", 'S');
            db.SetParameterValue(commandPedidosxPremio, "i_option", 'A');

            List<PedidosxPremioInfo> col = new List<PedidosxPremioInfo>();

            IDataReader dr = null;

            PedidosxPremioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosxPremio);

                while (dr.Read())
                {
                    m = Factory.GetPedidosxPremio(dr);

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
        /// Lista un pedido especifico por numero de pedido.
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public PedidosxPremioInfo ListxNumero(string Numero)
        {
            db.SetParameterValue(commandPedidosxPremio, "i_operation", 'S');
            db.SetParameterValue(commandPedidosxPremio, "i_option", 'B');
            db.SetParameterValue(commandPedidosxPremio, "i_numero", Numero);

            IDataReader dr = null;

            PedidosxPremioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosxPremio);

                while (dr.Read())
                {
                    m = Factory.GetPedidosxPremio(dr);
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
        /// Realiza el registro de un pedido x premio.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(PedidosxPremioInfo item)
        {

            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosxPremio, "i_operation", 'I');
                db.SetParameterValue(commandPedidosxPremio, "i_option", 'A');
                db.SetParameterValue(commandPedidosxPremio, "i_pre_id", item.IdPremio);
                db.SetParameterValue(commandPedidosxPremio, "i_numero", item.Numero);
                dr = db.ExecuteReader(commandPedidosxPremio);

                okTrans = true;

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

            return okTrans;
        }


        #endregion
    }
}