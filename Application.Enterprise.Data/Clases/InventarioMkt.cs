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
    public class InventarioMkt
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandInventarioMkt;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public InventarioMkt(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public InventarioMkt()
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
            commandInventarioMkt = db.GetStoredProcCommand("PRC_SVDN_INVENTARIO_MKT");

            db.AddInParameter(commandInventarioMkt, "i_operation", DbType.String);
            db.AddInParameter(commandInventarioMkt, "i_option", DbType.String);
            db.AddInParameter(commandInventarioMkt, "i_inv_bodega", DbType.String);
            db.AddInParameter(commandInventarioMkt, "i_inv_referencia", DbType.String);
            db.AddInParameter(commandInventarioMkt, "i_inv_ccostos", DbType.String);
            db.AddInParameter(commandInventarioMkt, "i_inv_saldo", DbType.Decimal);

            db.AddOutParameter(commandInventarioMkt, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandInventarioMkt, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Inventario MKT

        /// <summary>
        /// lista todos los Inventarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<InventarioMktInfo> List()
        {
            db.SetParameterValue(commandInventarioMkt, "i_operation", 'S');
            db.SetParameterValue(commandInventarioMkt, "i_option", 'A');

            List<InventarioMktInfo> col = new List<InventarioMktInfo>();

            IDataReader dr = null;

            InventarioMktInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventarioMkt);

                while (dr.Read())
                {
                    m = Factory.GetInventarioMkt(dr);

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
        /// Lista los saldos bodega del mes actual.
        /// </summary>
        /// <returns></returns>
        public List<InventarioMktInfo> ListSaldosBodega()
        {
            db.SetParameterValue(commandInventarioMkt, "i_operation", 'S');
            db.SetParameterValue(commandInventarioMkt, "i_option", 'B');

            List<InventarioMktInfo> col = new List<InventarioMktInfo>();

            IDataReader dr = null;

            InventarioMktInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventarioMkt);

                while (dr.Read())
                {
                    m = Factory.GetInventarioMkt(dr);

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
        /// Lista los inventarios por Referencia por CCostos y por Bodega.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        public InventarioMktInfo ListxBodegaxRefxCcostos(string Bodega, string Referencia, string CCostos)
        {
            db.SetParameterValue(commandInventarioMkt, "i_operation", 'S');
            db.SetParameterValue(commandInventarioMkt, "i_option", 'C');
            db.SetParameterValue(commandInventarioMkt, "i_inv_bodega", Bodega);
            db.SetParameterValue(commandInventarioMkt, "i_inv_referencia", Referencia);
            db.SetParameterValue(commandInventarioMkt, "i_inv_ccostos", CCostos);

            IDataReader dr = null;

            InventarioMktInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventarioMkt);

                if (dr.Read())
                {
                    m = Factory.GetInventarioMkt(dr);
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
        /// Lista los inventarios de MKT disponibles.
        /// </summary>
        /// <returns></returns>
        public List<InventarioMktInfo> ListInventarioDisponible()
        {
            db.SetParameterValue(commandInventarioMkt, "i_operation", 'S');
            db.SetParameterValue(commandInventarioMkt, "i_option", 'D');

            List<InventarioMktInfo> col = new List<InventarioMktInfo>();

            IDataReader dr = null;

            InventarioMktInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventarioMkt);

                while (dr.Read())
                {
                    m = Factory.GetInventarioMkt(dr);

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
        /// Realiza la actualizacion de la cantidad asignada del inventario.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidad(string Bodega, string Referencia, string CCostos, decimal Cantidad)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventarioMkt, "i_operation", 'U');
                db.SetParameterValue(commandInventarioMkt, "i_option", 'A');
                db.SetParameterValue(commandInventarioMkt, "i_inv_bodega", Bodega);
                db.SetParameterValue(commandInventarioMkt, "i_inv_referencia", Referencia);
                db.SetParameterValue(commandInventarioMkt, "i_inv_ccostos", CCostos);
                db.SetParameterValue(commandInventarioMkt, "i_inv_saldo", Cantidad);

                dr = db.ExecuteReader(commandInventarioMkt);

                transOk = true;

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

            return transOk;
        }


        /// <summary>
        /// Consulta el inventario MKT por referencia 
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public InventarioMktInfo ListInventarioMKTxReferencia(string Referencia)
        {
            db.SetParameterValue(commandInventarioMkt, "i_operation", 'S');
            db.SetParameterValue(commandInventarioMkt, "i_option", 'E');
            db.SetParameterValue(commandInventarioMkt, "i_inv_referencia", Referencia);
            
            IDataReader dr = null;

            InventarioMktInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventarioMkt);

                while (dr.Read())
                {
                    m = Factory.GetInventarioMkt(dr);                                       
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
        /// Guarda el inventario de una bodega.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(InventarioMktInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventarioMkt, "i_operation", 'I');
                db.SetParameterValue(commandInventarioMkt, "i_option", 'A');

                db.SetParameterValue(commandInventarioMkt, "i_inv_bodega", item.Bodega);
                db.SetParameterValue(commandInventarioMkt, "i_inv_referencia", item.Referencia);
                db.SetParameterValue(commandInventarioMkt, "i_inv_ccostos", item.CCostos);
                db.SetParameterValue(commandInventarioMkt, "i_inv_saldo", item.Saldo);

                dr = db.ExecuteReader(commandInventarioMkt);

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

        /// <summary>
        /// Elimina todos los inventarios.
        /// </summary>
        /// <returns></returns>
        public bool DeleteAll()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventarioMkt, "i_operation", 'D');
                db.SetParameterValue(commandInventarioMkt, "i_option", 'A');

                dr = db.ExecuteReader(commandInventarioMkt);

                transOk = true;
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

            return transOk;
        }

        /// <summary>
        /// Lista los saldos bodega del mes actual desde la bd de MKT y se insertan en la tabla de inventario de SVDN.
        /// </summary>
        /// <param name="item"></param>
        public bool ImportInventarioMKT()
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventarioMkt, "i_operation", 'I');
                db.SetParameterValue(commandInventarioMkt, "i_option", 'A');

                dr = db.ExecuteReader(commandInventarioMkt);

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