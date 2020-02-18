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
    public class Descuento
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandDescuento;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Descuento(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Descuento()
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
            commandDescuento = db.GetStoredProcCommand("PRC_SVDN_DESCUENTO");

            db.AddInParameter(commandDescuento, "i_operation", DbType.String);
            db.AddInParameter(commandDescuento, "i_option", DbType.String);
            db.AddParameter(commandDescuento, "i_dsc_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);
            //db.AddInParameter(commandDescuento, "i_dsc_id", DbType.Int32);
            db.AddInParameter(commandDescuento, "i_dsc_descripcion", DbType.String);
            db.AddInParameter(commandDescuento, "i_dsc_desde", DbType.Decimal);
            db.AddInParameter(commandDescuento, "i_dsc_hasta", DbType.Decimal);
            db.AddInParameter(commandDescuento, "i_dsc_porcentaje", DbType.Decimal);
            db.AddInParameter(commandDescuento, "i_dsc_porcentajehogar", DbType.Decimal);
            db.AddInParameter(commandDescuento, "i_dsc_estado", DbType.Boolean);
            db.AddInParameter(commandDescuento, "i_dsc_sysdate", DbType.DateTime);
            db.AddInParameter(commandDescuento, "i_valorpedido", DbType.Decimal);
            db.AddInParameter(commandDescuento, "i_dsc_unineg", DbType.String);
            db.AddInParameter(commandDescuento, "i_dsc_grupoproducto", DbType.String);
            db.AddInParameter(commandDescuento, "i_dsc_campana", DbType.String);
            db.AddInParameter(commandDescuento, "i_dsc_prodestrella", DbType.Boolean);

            db.AddOutParameter(commandDescuento, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandDescuento, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Descuento

        /// <summary>
        /// Lista todos los descuentos.
        /// </summary>
        /// <returns></returns>
        public List<DescuentoInfo> List()
        {
            db.SetParameterValue(commandDescuento, "i_operation", 'S');
            db.SetParameterValue(commandDescuento, "i_option", 'A');

            List<DescuentoInfo> col = new List<DescuentoInfo>();

            IDataReader dr = null;

            DescuentoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDescuento);

                while (dr.Read())
                {
                    m = Factory.GetDescuento(dr);

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
        /// Lista un descuento x id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DescuentoInfo ListxId(int Id)
        {
            db.SetParameterValue(commandDescuento, "i_operation", 'S');
            db.SetParameterValue(commandDescuento, "i_option", 'B');
            db.SetParameterValue(commandDescuento, "i_dsc_id", Id);

            IDataReader dr = null;

            DescuentoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDescuento);

                while (dr.Read())
                {
                    m = Factory.GetDescuento(dr);
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
        /// Lista un descuento x rango de valor del pedido y unidad de negocio de un articulo.
        /// </summary>
        /// <param name="ValorPedido"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="GrupoProducto"></param>
        /// <returns></returns>
        public DescuentoInfo ListxValorPedido(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana)
        {
            db.SetParameterValue(commandDescuento, "i_operation", 'S');
            db.SetParameterValue(commandDescuento, "i_option", 'C');
            db.SetParameterValue(commandDescuento, "i_valorpedido", ValorPedido);
            db.SetParameterValue(commandDescuento, "i_dsc_unineg", UnidadNegocio);
            db.SetParameterValue(commandDescuento, "i_dsc_grupoproducto", GrupoProducto);
            db.SetParameterValue(commandDescuento, "i_dsc_campana", Campana);

            IDataReader dr = null;

            DescuentoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDescuento);

                while (dr.Read())
                {
                    m = Factory.GetDescuento(dr);
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
        /// Lista un descuento x rango de valor del pedido y unidad de negocio de un articulo con privilegio con producto estrella.
        /// </summary>
        /// <param name="ValorPedido"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="GrupoProducto"></param>
        /// <param name="Campana"></param>
        /// <param name="ProdEstrella"></param>
        /// <returns></returns>
        public DescuentoInfo ListxValorPedidoProdEstrella(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella)
        {
            db.SetParameterValue(commandDescuento, "i_operation", 'S');
            db.SetParameterValue(commandDescuento, "i_option", 'D');
            db.SetParameterValue(commandDescuento, "i_valorpedido", ValorPedido);
            db.SetParameterValue(commandDescuento, "i_dsc_unineg", UnidadNegocio);
            db.SetParameterValue(commandDescuento, "i_dsc_grupoproducto", GrupoProducto);
            db.SetParameterValue(commandDescuento, "i_dsc_campana", Campana);
            db.SetParameterValue(commandDescuento, "i_dsc_prodestrella", ProdEstrella);

            IDataReader dr = null;

            DescuentoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDescuento);

                while (dr.Read())
                {
                    m = Factory.GetDescuento(dr);
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
        /// Guarda un descuento nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(DescuentoInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandDescuento, "i_operation", 'I');
                db.SetParameterValue(commandDescuento, "i_option", 'A');

                db.SetParameterValue(commandDescuento, "i_dsc_descripcion", item.Descripcion);
                db.SetParameterValue(commandDescuento, "i_dsc_desde", item.Desde);
                db.SetParameterValue(commandDescuento, "i_dsc_hasta", item.Hasta);
                db.SetParameterValue(commandDescuento, "i_dsc_porcentaje", item.Porcentaje);
                db.SetParameterValue(commandDescuento, "i_dsc_porcentajehogar", item.PorcentajeHogar);
                db.SetParameterValue(commandDescuento, "i_dsc_estado", item.Estado);
                db.SetParameterValue(commandDescuento, "i_dsc_unineg", item.UnidadNegocio);
                db.SetParameterValue(commandDescuento, "i_dsc_campana", item.Campana);
                db.SetParameterValue(commandDescuento, "i_dsc_prodestrella", item.ProdEstrella);

                dr = db.ExecuteReader(commandDescuento);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandDescuento, "i_dsc_id"));


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de descuento.  Nombre:" + item.Descripcion + ",   Desde: " + item.Desde + ", Hasta: " + item.Hasta + ", Porcentaje:" + item.Porcentaje + ", Estado:" + item.Estado + ", ProdEstrella:" + item.ProdEstrella + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                id = 0;

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
            return id;
        }

        /// <summary>
        /// Realiza la actualizacion de un descuento existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(DescuentoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandDescuento, "i_operation", 'U');
                db.SetParameterValue(commandDescuento, "i_option", 'A');

                db.SetParameterValue(commandDescuento, "i_dsc_id", item.Id);
                db.SetParameterValue(commandDescuento, "i_dsc_descripcion", item.Descripcion);
                db.SetParameterValue(commandDescuento, "i_dsc_desde", item.Desde);
                db.SetParameterValue(commandDescuento, "i_dsc_hasta", item.Hasta);
                db.SetParameterValue(commandDescuento, "i_dsc_porcentaje", item.Porcentaje);
                db.SetParameterValue(commandDescuento, "i_dsc_porcentajehogar", item.PorcentajeHogar);
                db.SetParameterValue(commandDescuento, "i_dsc_estado", item.Estado);
                db.SetParameterValue(commandDescuento, "i_dsc_unineg", item.UnidadNegocio);
                db.SetParameterValue(commandDescuento, "i_dsc_campana", item.Campana);

                dr = db.ExecuteReader(commandDescuento);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de descuento. Nuevos Valores para Id:" + item.Id + ", Nombre:" + item.Descripcion + ",   Desde: " + item.Desde + ", Hasta: " + item.Hasta + ", Porcentaje:" + item.Porcentaje + ", Estado:" + item.Estado + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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
        /// Elimina un Descuento.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Delete(int Id, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandDescuento, "i_operation", 'D');
                db.SetParameterValue(commandDescuento, "i_option", 'A');

                db.SetParameterValue(commandDescuento, "i_dsc_id", Id);

                dr = db.ExecuteReader(commandDescuento);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la eliminación de descuento. Descuento Id:" + Id + ". Acción Realizada por el Usuario: " + Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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
    }
}