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
    /// JA
    /// </summary>
    public class MatrizComercialMeta
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMatrizComercialMeta;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MatrizComercialMeta(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MatrizComercialMeta()
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
            commandMatrizComercialMeta = db.GetStoredProcCommand("PRC_SVDN_MATRIZ_COMERCIAL_METAS");

            db.AddInParameter(commandMatrizComercialMeta, "i_operation", DbType.String);
            db.AddInParameter(commandMatrizComercialMeta, "i_option", DbType.String);

            db.AddInParameter(commandMatrizComercialMeta, "i_campana", DbType.String);
            db.AddInParameter(commandMatrizComercialMeta, "i_zona", DbType.String);          
            db.AddInParameter(commandMatrizComercialMeta, "i_Npedidos", DbType.Int32);           
            db.AddInParameter(commandMatrizComercialMeta, "i_Consecutivas", DbType.Decimal);
            db.AddInParameter(commandMatrizComercialMeta, "i_Retenidas", DbType.Decimal);
            db.AddInParameter(commandMatrizComercialMeta, "i_Nuevas", DbType.Decimal);
            db.AddInParameter(commandMatrizComercialMeta, "i_Activas", DbType.Decimal);
            db.AddInParameter(commandMatrizComercialMeta, "i_Facturacion", DbType.Decimal);

            db.AddOutParameter(commandMatrizComercialMeta, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMatrizComercialMeta, "o_err_msg", DbType.String, 1000);
        }
        #endregion

         /// <summary>
        /// lista el presupuesto matriz usando distinct en campana
        /// </summary>
        /// <returns></returns>
        public List<MatrizComercialMetaInfo> ListCampana()
        {
            db.SetParameterValue(commandMatrizComercialMeta, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialMeta, "i_option", 'A');

            List<MatrizComercialMetaInfo> col = new List<MatrizComercialMetaInfo>();

            IDataReader dr = null;

            MatrizComercialMetaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialMeta);

                while (dr.Read())
                {
                    m = Factory.GetMeta(dr);

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
        /// Lista presupuesto por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialMetaInfo> ListxCampana(String campana)
        {
            db.SetParameterValue(commandMatrizComercialMeta, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialMeta, "i_option", 'B');
            db.SetParameterValue(commandMatrizComercialMeta, "i_campana", campana);

            List<MatrizComercialMetaInfo> col = new List<MatrizComercialMetaInfo>();

            IDataReader dr = null;

            MatrizComercialMetaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialMeta);

                while (dr.Read())
                {
                    m = Factory.GetMeta(dr);

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
        /// Elimina Registro de la Tabla Meta
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="zona"></param>
        /// <param name="opt">Opcion  del Store</param>
        /// <returns></returns>
        public bool DeleteMeta(string Campana, string zona, string usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMatrizComercialMeta, "i_operation", 'D');
                db.SetParameterValue(commandMatrizComercialMeta, "i_option", 'A');
                db.SetParameterValue(commandMatrizComercialMeta, "i_campana", Campana);
                db.SetParameterValue(commandMatrizComercialMeta, "i_zona", zona);




                dr = db.ExecuteReader(commandMatrizComercialMeta);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se Eliminó un registro  de la tabla  SVDN_METAS. Campaña " + Campana + ", Zona: " + zona + ". Acción Realizada por el Usuario: " + usuario;


                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------


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
        /// Inserta registros en tabla matriz presupuesto
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertRegistroMeta(MatrizComercialMetaInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMatrizComercialMeta, "i_operation", 'I');
                db.SetParameterValue(commandMatrizComercialMeta, "i_option", 'A');

                db.SetParameterValue(commandMatrizComercialMeta, "i_campana", item.Campana);
                db.SetParameterValue(commandMatrizComercialMeta, "i_zona", item.Zona);
                db.SetParameterValue(commandMatrizComercialMeta, "i_Npedidos", item.Npedidos);
                db.SetParameterValue(commandMatrizComercialMeta, "i_Consecutivas", item.Consecutivas);
                db.SetParameterValue(commandMatrizComercialMeta, "i_Retenidas", item.Retenidas);
                db.SetParameterValue(commandMatrizComercialMeta, "i_Nuevas", item.Nuevas);
                db.SetParameterValue(commandMatrizComercialMeta, "i_Activas", item.Activas);
                db.SetParameterValue(commandMatrizComercialMeta, "i_Facturacion", item.Facturacion);

                dr = db.ExecuteReader(commandMatrizComercialMeta);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro en la tabla metas: Campaña " + item.Campana + ",Zona " + item.Zona + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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
        /// obtiene una Zona existente mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public MatrizComercialMetaInfo ListxZona(String zona, String campana)
        {
            db.SetParameterValue(commandMatrizComercialMeta, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialMeta, "i_option", 'F');
            db.SetParameterValue(commandMatrizComercialMeta, "i_zona", zona);
            db.SetParameterValue(commandMatrizComercialMeta, "i_campana", campana);

            IDataReader dr = null;

            MatrizComercialMetaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialMeta);

                while (dr.Read())
                {
                    m = Factory.GetMeta(dr);

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

    }
}
