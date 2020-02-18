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
    public class Inventario
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandInventario;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Inventario(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Inventario()
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
            commandInventario = db.GetStoredProcCommand("PRC_SVDN_INVENTARIO");

            db.AddInParameter(commandInventario, "i_operation", DbType.String);
            db.AddInParameter(commandInventario, "i_option", DbType.String);
            db.AddInParameter(commandInventario, "i_inv_bodega", DbType.String);
            db.AddInParameter(commandInventario, "i_inv_referencia", DbType.String);
            db.AddInParameter(commandInventario, "i_inv_ccostos", DbType.String);
            db.AddInParameter(commandInventario, "i_inv_saldo", DbType.Decimal);
            db.AddInParameter(commandInventario, "i_plu", DbType.Int32);
            //--COMENTAR PARA HACER FUNCIONAR ECUADOR Y COLOMBIA ACTUAL  
           // db.AddInParameter(commandInventario, "i_codigocentroop", DbType.String);

            db.AddOutParameter(commandInventario, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandInventario, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Inventario

        /// <summary>
        /// lista todos los Inventarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<InventarioInfo> List()
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'A');

            List<InventarioInfo> col = new List<InventarioInfo>();

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                while (dr.Read())
                {
                    m = Factory.GetInventario(dr);

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
        public List<InventarioInfo> ListSaldosBodega()
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'B');

            List<InventarioInfo> col = new List<InventarioInfo>();

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                while (dr.Read())
                {
                    m = Factory.GetInventario(dr);

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
        public InventarioInfo ListxBodegaxRefxCcostos(string Bodega, string Referencia, string CCostos)
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'C');
            db.SetParameterValue(commandInventario, "i_inv_bodega", Bodega);
            db.SetParameterValue(commandInventario, "i_inv_referencia", Referencia);
            db.SetParameterValue(commandInventario, "i_inv_ccostos", CCostos);

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                if (dr.Read())
                {
                    m = Factory.GetInventario(dr);
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
        /// Lista los inventarios por Referencia por CCostos y por Bodega para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        public InventarioInfo ListxBodegaxRefxCcostosNivelServicio(string Bodega, string Referencia, string CCostos)
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'D');
            db.SetParameterValue(commandInventario, "i_inv_bodega", Bodega);
            db.SetParameterValue(commandInventario, "i_inv_referencia", Referencia);
            db.SetParameterValue(commandInventario, "i_inv_ccostos", CCostos);

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                if (dr.Read())
                {
                    m = Factory.GetInventario(dr);
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
        /// Lista los saldos bodega del mes actual de un plu especifico.
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        public InventarioInfo ListSaldosBodegaxPLU(int intPLU)
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'E');
            db.SetParameterValue(commandInventario, "i_plu", intPLU);

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                while (dr.Read())
                {
                    m = Factory.GetInventario(dr);
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
        /// Lista los saldos bodega del mes actual de un plu especifico x CO. SIESA. Para todas las bodegas facturables.
        /// </summary>
        /// <param name="intPLU"></param>
        /// <param name="IdCentroOperacion"></param>
        /// <returns></returns>
        public InventarioInfo ListSaldosBodegaxPLUxCO(int intPLU, string IdCentroOperacion)
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'F');
            db.SetParameterValue(commandInventario, "i_plu", intPLU);
            db.SetParameterValue(commandInventario, "i_codigocentroop", IdCentroOperacion);

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                while (dr.Read())
                {
                    m = Factory.GetInventario(dr);
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
                db.SetParameterValue(commandInventario, "i_operation", 'U');
                db.SetParameterValue(commandInventario, "i_option", 'A');
                db.SetParameterValue(commandInventario, "i_inv_bodega", Bodega);
                db.SetParameterValue(commandInventario, "i_inv_referencia", Referencia);
                db.SetParameterValue(commandInventario, "i_inv_ccostos", CCostos);
                db.SetParameterValue(commandInventario, "i_inv_saldo", Cantidad);

                dr = db.ExecuteReader(commandInventario);

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
        /// Realiza la actualizacion de la cantidad asignada del inventario para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="Bodega"></param>
        /// <param name="Referencia"></param>
        /// <param name="CCostos"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidadNivelServicio(string Bodega, string Referencia, string CCostos, decimal Cantidad)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventario, "i_operation", 'U');
                db.SetParameterValue(commandInventario, "i_option", 'B');
                db.SetParameterValue(commandInventario, "i_inv_bodega", Bodega);
                db.SetParameterValue(commandInventario, "i_inv_referencia", Referencia);
                db.SetParameterValue(commandInventario, "i_inv_ccostos", CCostos);
                db.SetParameterValue(commandInventario, "i_inv_saldo", Cantidad);

                dr = db.ExecuteReader(commandInventario);

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
        /// Guarda el inventario de una bodega.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(InventarioInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventario, "i_operation", 'I');
                db.SetParameterValue(commandInventario, "i_option", 'A');

                db.SetParameterValue(commandInventario, "i_inv_bodega", item.Bodega);
                db.SetParameterValue(commandInventario, "i_inv_referencia", item.Referencia);
                db.SetParameterValue(commandInventario, "i_inv_ccostos", item.CCostos);
                db.SetParameterValue(commandInventario, "i_inv_saldo", item.Saldo);

                dr = db.ExecuteReader(commandInventario);

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
        /// Guarda el inventario de una bodega para el calculo de nivel de servicio.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertNivelServicio(InventarioInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventario, "i_operation", 'I');
                db.SetParameterValue(commandInventario, "i_option", 'B');

                db.SetParameterValue(commandInventario, "i_inv_bodega", item.Bodega);
                db.SetParameterValue(commandInventario, "i_inv_referencia", item.Referencia);
                db.SetParameterValue(commandInventario, "i_inv_ccostos", item.CCostos);
                db.SetParameterValue(commandInventario, "i_inv_saldo", item.Saldo);

                dr = db.ExecuteReader(commandInventario);

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
                db.SetParameterValue(commandInventario, "i_operation", 'D');
                db.SetParameterValue(commandInventario, "i_option", 'A');

                dr = db.ExecuteReader(commandInventario);

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
        /// Elimina todos los inventarios del calculo de nivel de servicio.
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllNivelServicio()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandInventario, "i_operation", 'D');
                db.SetParameterValue(commandInventario, "i_option", 'B');

                dr = db.ExecuteReader(commandInventario);

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

        #endregion


        /// METODOS NUEVOS JUTA
        /// /// <summary>
        /// Lista los saldos bodega del mes actual de un plu especifico. y con bodega variable
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        public InventarioInfo ListSaldosBodegaxPLUVariable(int intPLU,string bodega)
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'E');
            db.SetParameterValue(commandInventario, "i_plu", intPLU);
            db.SetParameterValue(commandInventario, "i_inv_bodega", bodega);

            IDataReader dr = null;

            InventarioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandInventario);

                while (dr.Read())
                {
                    m = Factory.GetInventario(dr);
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


        /// /// <summary>
        /// Busca la fecha que habra existencia de un producto agotado
        /// </summary>
        /// <param name="intPLU"></param>
        /// <returns></returns>
        public string BuscaFechaProducto(int intPLU, string campana)
        {
            db.SetParameterValue(commandInventario, "i_operation", 'S');
            db.SetParameterValue(commandInventario, "i_option", 'F');
            db.SetParameterValue(commandInventario, "i_plu", intPLU);
            db.SetParameterValue(commandInventario, "i_inv_bodega", campana);

            IDataReader dr = null;

            string j = "";

            try
            {
                dr = db.ExecuteReader(commandInventario);

                while (dr.Read())
                {
                    j = Tools.ToDateTime(dr, "fecha").ToShortDateString();
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

            return j;
        }


        public InventarioInfo ListSaldosBodegaxPLUxEmpresaria(string bodega, int intPLU)
        {
            this.db.SetParameterValue(this.commandInventario, "i_operation", 'S');
            this.db.SetParameterValue(this.commandInventario, "i_option", 'G');
            this.db.SetParameterValue(this.commandInventario, "i_plu", intPLU);
            this.db.SetParameterValue(this.commandInventario, "i_inv_bodega", bodega);
            IDataReader dr = null;
            InventarioInfo inventario = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandInventario);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    inventario = Factory.GetInventario(dr);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return inventario;
        }
    }
}