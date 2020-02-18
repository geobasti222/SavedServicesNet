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
    public class TrasladoFletesCiudad
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCiudadfletes;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TrasladoFletesCiudad(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TrasladoFletesCiudad()
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
            commandCiudadfletes = db.GetStoredProcCommand("PRC_SVDN_DIMCIUDAD_TEMP");

            db.AddInParameter(commandCiudadfletes, "i_operation", DbType.String);
            db.AddInParameter(commandCiudadfletes, "i_option", DbType.String);

            db.AddInParameter(commandCiudadfletes, "i_codciudad", DbType.String);
            db.AddInParameter(commandCiudadfletes, "i_valor", DbType.Decimal);
            db.AddInParameter(commandCiudadfletes, "i_iva", DbType.Decimal);
            db.AddInParameter(commandCiudadfletes, "i_excluido", DbType.Byte );
            db.AddInParameter(commandCiudadfletes, "i_valorfull", DbType.Decimal);
            db.AddInParameter(commandCiudadfletes, "i_optcampo", DbType.String);

            db.AddOutParameter(commandCiudadfletes, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCiudadfletes, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de Ciudad

        /// <summary>
        /// lista toda la vista previa de los fletes insertado por ciudad.
        /// </summary>
        /// <returns></returns>
        public List<TrasladoFleteCiudadinfo> List()
        {
            db.SetParameterValue(commandCiudadfletes, "i_operation", 'S');
            db.SetParameterValue(commandCiudadfletes, "i_option", 'A');

            List<TrasladoFleteCiudadinfo> col = new List<TrasladoFleteCiudadinfo>();

            IDataReader dr = null;

            TrasladoFleteCiudadinfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudadfletes);

                while (dr.Read())
                {
                    m = Factory.GetTrasladosFletes(dr);

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
        /// Guarda Traslado de fletes para la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertaTablasTemporales(TrasladoFleteCiudadinfo item, string Tipocampo)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiudadfletes, "i_operation", 'I');
                db.SetParameterValue(commandCiudadfletes, "i_option", 'A');

                db.SetParameterValue(commandCiudadfletes, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCiudadfletes, "i_valor", item.Valor);
                db.SetParameterValue(commandCiudadfletes, "i_iva", item.Iva);
                db.SetParameterValue(commandCiudadfletes, "i_excluido", item.ExcluidoIVA);
                db.SetParameterValue(commandCiudadfletes, "i_valorfull", item.ValorFleteFull);
                db.SetParameterValue(commandCiudadfletes, "i_optcampo", Tipocampo);

                dr = db.ExecuteReader(commandCiudadfletes);

                


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro Tabla Temporal en las tablas Temporales dimciudad: Codciudad " + item.CodCiudad + ",Valorflete " + item.Valor + ",Iva " + item.Iva + ",excluidoIVA " + item.ExcluidoIVA + ",ValorFletefull " + item.ValorFleteFull + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// S
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertTablaTemporalPrincipal(string Usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiudadfletes, "i_operation", 'I');
                db.SetParameterValue(commandCiudadfletes, "i_option", 'B');

                dr = db.ExecuteReader(commandCiudadfletes);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro registros en la  Tabla Temporal dimciudad_TEMP de las tablas Temporales dimciudad. Acción Realizada por el Usuario: " + Usuario;

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
        /// Elimina todos los elemnetos de la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public bool DeleteTempTransferflete()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiudadfletes, "i_operation", 'D');
                db.SetParameterValue(commandCiudadfletes, "i_option", 'A');
                
               
                dr = db.ExecuteReader(commandCiudadfletes);


               


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
        /// Elimina todos los elemnetos de la tabla temporaral.
        /// </summary>
        /// <returns></returns>
        public bool DeleteTransferflete(string TipoCampo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiudadfletes, "i_operation", 'D');
                db.SetParameterValue(commandCiudadfletes, "i_option", 'B');
                db.SetParameterValue(commandCiudadfletes, "i_optcampo", TipoCampo);


                dr = db.ExecuteReader(commandCiudadfletes);

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
        /// Actualiza los valores de la tabla dimciuada con la temporal de transferencia
        /// </summary>
        /// <returns></returns>
        public bool ActualizaTransferflete(string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiudadfletes, "i_operation", 'U');
                db.SetParameterValue(commandCiudadfletes, "i_option", 'A');


                dr = db.ExecuteReader(commandCiudadfletes);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion de los fletes por ciudad de la tabla dimciudad. Acción Realizada por el Usuario: " + Usuario;

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

        #endregion
    }
}