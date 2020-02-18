using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Data
{
    public class PremiosPuntosWinforms
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosPuntosWinforms;

        #region Constructor
        public PremiosPuntosWinforms(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        public PremiosPuntosWinforms()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        private void Config()
        {
            commandPremiosPuntosWinforms = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_PUNTOS_WINFORMS");

            db.AddInParameter(commandPremiosPuntosWinforms, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_option", DbType.String);

            db.AddParameter(commandPremiosPuntosWinforms, "i_prepw_numero", DbType.Int32, 22, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_referencia", DbType.String);            
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_puntos", DbType.Int32);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_campana", DbType.String);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_refcontenedora", DbType.String);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_nivel", DbType.Int32);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_sumarpuntos", DbType.String);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_campanaentrega", DbType.String);
            db.AddParameter(commandPremiosPuntosWinforms, "i_prepw_nombre_producto", DbType.String, 22, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandPremiosPuntosWinforms, "i_prepw_filtro", DbType.String);            

            db.AddOutParameter(commandPremiosPuntosWinforms, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosPuntosWinforms, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de PremiosWinform

        /// <summary>
        /// Lista todos los premios
        /// </summary>
        /// <returns></returns>
        public List<PremiosPuntosWinformsInfo> List()
        {
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_option", 'A');

            List<PremiosPuntosWinformsInfo> col = new List<PremiosPuntosWinformsInfo>();

            IDataReader dr = null;

            PremiosPuntosWinformsInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosWinforms);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosWinforms(dr);

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
        /// Lista los premios respecto a una campaña
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<PremiosPuntosWinformsInfo> ListXCampana(string campana)
        {
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_option", 'B');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_campana", campana);

            List<PremiosPuntosWinformsInfo> col = new List<PremiosPuntosWinformsInfo>();

            IDataReader dr = null;

            PremiosPuntosWinformsInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosWinforms);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosWinforms(dr);

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
        /// 
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<PremiosPuntosWinformsInfo> ListReferenciasYCampanas(string campana, string referencia)
        {
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_option", 'C');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_campana", campana);
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_referencia", referencia);

            List<PremiosPuntosWinformsInfo> col = new List<PremiosPuntosWinformsInfo>();

            IDataReader dr = null;

            PremiosPuntosWinformsInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosWinforms);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosWinforms(dr);

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
        /// Realiza consulta de los premios que tengan un nivel inferior a la referencia contenedora y no esten asociados a esa referencia
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public List<PremiosPuntosWinformsInfo> ListSinRefcontenedora(int nivel, string refcontenedora, string filtro)
        {
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_option", 'D');
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_nivel", nivel);
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_refcontenedora", refcontenedora);
            db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_filtro", filtro);            

            List<PremiosPuntosWinformsInfo> col = new List<PremiosPuntosWinformsInfo>();

            IDataReader dr = null;

            PremiosPuntosWinformsInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosWinforms);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosWinforms(dr);

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
        /// Inserta Nuevo Registro de Punto por Premio
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertPremiosPuntos(PremiosPuntosWinformsInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_operation", 'I');
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_option", 'A');
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_referencia", item.Referencia);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_puntos", item.Puntos);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_campana", item.Campana);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_nivel", item.Nivel);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_campanaentrega", item.Campana_Entrega);

                dr = db.ExecuteReader(commandPremiosPuntosWinforms);

                strid = System.Convert.ToString(db.GetParameterValue(commandPremiosPuntosWinforms, "i_prepw_numero")).Trim();
                //Obtiene el identificador (consecutivo) del insert                


                if (item.GuardarAuditoria)
                {
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Guardar auditoria 
                    try
                    {
                        Auditoria objAuditoria = new Auditoria("conexion");
                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                        item.Usuario = "User_Premios_Winforms";
                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                        objAuditoriaInfo.Usuario = item.Usuario;
                        objAuditoriaInfo.Proceso = "Se realizó la insercion en la tabla Premios_Puntos_Winforms #: " + strid + " Referencia: " + item.Referencia + " Puntos: " + item.Puntos + " Campana: " + item.Campana + " . Acción Realizada por el Usuario: " + item.Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------                
                }
                //****************************************************************************************************************************************

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

            return strid;
        }

        /// <summary>
        /// Actualiza Registro de Punto por Premio
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdatePremiosPuntos(PremiosPuntosWinformsInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_operation", 'U');
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_option", 'A');

                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_puntos", item.Puntos);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_campana", item.Campana);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_referencia", item.Referencia);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_refcontenedora", item.RefContenedora);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_sumarpuntos", item.SumarPuntos);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_nivel", item.Nivel);
                db.SetParameterValue(commandPremiosPuntosWinforms, "i_prepw_campanaentrega", item.Campana_Entrega);

                dr = db.ExecuteReader(commandPremiosPuntosWinforms);

                transOk = true;

                //****************************************************************************************************************************************
                //Si el perfil es de un usuario interno de nivi se debe guardar la auditoria.
                if (item.GuardarAuditoria)
                {
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Guardar auditoria 
                    try
                    {
                        Auditoria objAuditoria = new Auditoria("conexion");
                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                        objAuditoriaInfo.Usuario = item.Usuario;

                        string numero = "0";
                        //System.Convert.ToString(db.GetParameterValue(commandPremiosPuntosWinforms, "i_prepw_numero")).Trim();

                        objAuditoriaInfo.Proceso = "Se realizó la actualización del Pedido Número: " + numero + " . Acción Realizada por el Usuario: " + item.Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------                
                }
                //****************************************************************************************************************************************

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
