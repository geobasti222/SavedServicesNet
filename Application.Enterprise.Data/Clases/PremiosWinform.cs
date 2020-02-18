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
    public class PremiosWinform
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosWinform;


        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase">Nombre que contiene la base de datos a utilizar</param>
        public PremiosWinform(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosWinform()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        /// <summary>
        /// Metodo para configurar el comando de la DatabaseFactory
        /// </summary>
        private void Config()
        {
            commandPremiosWinform = db.GetStoredProcCommand("PRC_SVDN_PREMIOSWINFORM");

            db.AddInParameter(commandPremiosWinform, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_option", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_optionfiltro", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_cantidadregistros", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_minimopuntos", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_referenciascorrea", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_refcontenedora", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_campanapremio", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_campanaentrega", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_pluexcluidas", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_pedidominimo", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_cedula", DbType.String);
            db.AddInParameter(commandPremiosWinform, "i_prew_nropedido", DbType.String);
            db.AddOutParameter(commandPremiosWinform, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosWinform, "o_err_msg", DbType.String, 1000);
        }

        #endregion

        #region Metodos de PremiosWinform

        /// <summary>
        /// Lista todos los premios
        /// </summary>
        /// <returns></returns>
        public List<PremiosWinformInfo> List(string Campana, string MinimoPuntos, string ReferenciasCorrea, string PluExcluidas, string CampanaEntrega)
        {
            db.SetParameterValue(commandPremiosWinform, "i_operation", 'S');
            db.SetParameterValue(commandPremiosWinform, "i_option", 'A');
            db.SetParameterValue(commandPremiosWinform, "i_prew_minimopuntos", MinimoPuntos);
            db.SetParameterValue(commandPremiosWinform, "i_prew_referenciascorrea", ReferenciasCorrea);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pluexcluidas", PluExcluidas);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanapremio", Campana);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanaentrega", CampanaEntrega);

            List<PremiosWinformInfo> col = new List<PremiosWinformInfo>();

            IDataReader dr = null;

            PremiosWinformInfo m = null;

            try
            {
                commandPremiosWinform.CommandTimeout = 360;
                dr = db.ExecuteReader(commandPremiosWinform);

                while (dr.Read())
                {
                    m = Factory.GetPremiosWinform(dr);

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
        /// Lista la cantidad solicitada de resultados
        /// </summary>
        /// <param name="Campana">Consecutivo de la Campaña</param>
        /// <param name="MinimoPuntos">NiviPuntos</param>
        /// <param name="CantResults">Numero de Registros a Mostrar</param>
        /// <param name="ReferenciasCorrea"></param>
        /// <param name="RefContenedora"></param>
        /// <param name="RefExcluidas"></param>
        /// <returns></returns>
        public List<PremiosWinformInfo> ListCantidadSolicitada(string Campana, string MinimoPuntos, string CantResults, string ReferenciasCorrea, string RefContenedora, string PluExcluidas, string CampanaEntrega)
        {
            db.SetParameterValue(commandPremiosWinform, "i_operation", 'S');
            db.SetParameterValue(commandPremiosWinform, "i_option", 'B');
            db.SetParameterValue(commandPremiosWinform, "i_prew_minimopuntos", MinimoPuntos);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanapremio", Campana);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanaentrega", CampanaEntrega);
            db.SetParameterValue(commandPremiosWinform, "i_prew_cantidadregistros", CantResults);
            db.SetParameterValue(commandPremiosWinform, "i_prew_referenciascorrea", ReferenciasCorrea);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pluexcluidas", PluExcluidas);
            db.SetParameterValue(commandPremiosWinform, "i_prew_refcontenedora", RefContenedora);

            List<PremiosWinformInfo> col = new List<PremiosWinformInfo>();

            IDataReader dr = null;

            PremiosWinformInfo m = null;

            try
            {
                commandPremiosWinform.CommandTimeout = 360;
                dr = db.ExecuteReader(commandPremiosWinform);

                while (dr.Read())
                {
                    m = Factory.GetPremiosWinform(dr);

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
        /// Lista los premios obteniendo puntos sobrantes de otras campañas 
        /// </summary>
        /// <param name="ReferenciasCorrea"></param>
        /// <param name="CampanaPremio"></param>
        /// <param name="MinimoPuntos"></param>
        /// <param name="ReferenciaContenedora"></param>
        /// <param name="RefExcluidas"></param>
        /// <param name="PedidoMinimo"></param>
        /// <returns></returns>
        public List<PremiosWinformInfo> ListSobrantes(string ReferenciasCorrea, string CampanaPremio, string MinimoPuntos, string ReferenciaContenedora, string PluExcluidas, string CampanaEntrega, string PedidoMinimo)
        {
            db.SetParameterValue(commandPremiosWinform, "i_operation", 'S');
            db.SetParameterValue(commandPremiosWinform, "i_option", 'C');
            db.SetParameterValue(commandPremiosWinform, "i_prew_referenciascorrea", ReferenciasCorrea);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanapremio", CampanaPremio);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanaentrega", CampanaEntrega);
            db.SetParameterValue(commandPremiosWinform, "i_prew_minimopuntos", MinimoPuntos);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pluexcluidas", PluExcluidas);
            db.SetParameterValue(commandPremiosWinform, "i_prew_refcontenedora", ReferenciaContenedora);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pedidominimo", PedidoMinimo);
            

            List<PremiosWinformInfo> col = new List<PremiosWinformInfo>();

            IDataReader dr = null;

            PremiosWinformInfo m = null;

            try
            {
                commandPremiosWinform.CommandTimeout = 360;
                dr = db.ExecuteReader(commandPremiosWinform);

                while (dr.Read())
                {
                    m = Factory.GetPremiosWinform(dr);

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
        /// Lista los premios obteniendo puntos acumulados de otras campañas 
        /// </summary>
        /// <param name="opcAcum"></param>
        /// <param name="MinimoPuntos"></param>
        /// <param name="ReferenciasCorrea"></param>
        /// <param name="CampanaPremio"></param>
        /// <param name="RefContenedora"></param>
        /// <param name="RefExcluidas"></param>
        /// <param name="PedidoMinimo"></param>
        /// <param name="FiltroPremiosPredecesores"></param>
        /// <returns></returns>
        public List<PremiosWinformInfo> ListAcumulados(char opcAcum, string MinimoPuntos, string ReferenciasCorrea, string CampanaPremio, string RefContenedora, string PluExcluidas, string CampanaEntrega, string PedidoMinimo, string FiltroPremiosPredecesores)
        {
            db.SetParameterValue(commandPremiosWinform, "i_operation", 'S');
            db.SetParameterValue(commandPremiosWinform, "i_option", 'D');
            db.SetParameterValue(commandPremiosWinform, "i_optionfiltro", opcAcum);
            db.SetParameterValue(commandPremiosWinform, "i_prew_minimopuntos", MinimoPuntos);
            db.SetParameterValue(commandPremiosWinform, "i_prew_referenciascorrea", ReferenciasCorrea);
            db.SetParameterValue(commandPremiosWinform, "i_prew_refcontenedora", RefContenedora);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanapremio", CampanaPremio);
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanaentrega", CampanaEntrega);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pedidominimo", PedidoMinimo);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pluexcluidas", PluExcluidas.Trim());
            


            List<PremiosWinformInfo> col = new List<PremiosWinformInfo>();

            IDataReader dr = null;

            PremiosWinformInfo m = null;

            try
            {
                commandPremiosWinform.CommandTimeout = 360;
                dr = db.ExecuteReader(commandPremiosWinform);

                while (dr.Read())
                {
                    m = Factory.GetPremiosWinform(dr);
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
        /// Lista los detalles de un pedido de acuerdo a una cedula y  campaña, se incluyen las referencias a excluir
        /// </summary>
        /// <param name="CampanaPremio"></param>
        /// <param name="RefExcluidas"></param>
        /// <param name="Cedula"></param>
        /// <param name="NroPedido"></param>
        /// <returns></returns>
        public List<PremiosWinformPedidoInfo> ListPedidoDetalle(string CampanaPremio, string PluExcluidas, string Cedula, string NroPedido)
        {
            db.SetParameterValue(commandPremiosWinform, "i_operation", 'S');
            db.SetParameterValue(commandPremiosWinform, "i_option", 'E');
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanapremio", CampanaPremio);            
            db.SetParameterValue(commandPremiosWinform, "i_prew_pluexcluidas", PluExcluidas);
            db.SetParameterValue(commandPremiosWinform, "i_prew_cedula", Cedula);
            db.SetParameterValue(commandPremiosWinform, "i_prew_nropedido", NroPedido);

            List<PremiosWinformPedidoInfo> col = new List<PremiosWinformPedidoInfo>();

            IDataReader dr = null;

            PremiosWinformPedidoInfo m = null;

            try
            {
                commandPremiosWinform.CommandTimeout = 360;
                dr = db.ExecuteReader(commandPremiosWinform);

                while (dr.Read())
                {
                    m = Factory.GetPedidoDevolucionDetalle(dr);
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
        /// Lista los detalles de una devolucion de acuerdo a una cedula y  campaña, se incluyen las referencias a excluir
        /// </summary>
        /// <param name="CampanaPremio"></param>
        /// <param name="RefExcluidas"></param>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public List<PremiosWinformPedidoInfo> ListDevolucionDetalle(string CampanaPremio, string PluExcluidas, string Cedula)
        {
            db.SetParameterValue(commandPremiosWinform, "i_operation", 'S');
            db.SetParameterValue(commandPremiosWinform, "i_option", 'F');
            db.SetParameterValue(commandPremiosWinform, "i_prew_campanapremio", CampanaPremio);
            db.SetParameterValue(commandPremiosWinform, "i_prew_pluexcluidas", PluExcluidas);
            db.SetParameterValue(commandPremiosWinform, "i_prew_cedula", Cedula);

            List<PremiosWinformPedidoInfo> col = new List<PremiosWinformPedidoInfo>();

            IDataReader dr = null;

            PremiosWinformPedidoInfo m = null;

            try
            {
                commandPremiosWinform.CommandTimeout = 360;
                dr = db.ExecuteReader(commandPremiosWinform);

                while (dr.Read())
                {
                    m = Factory.GetPedidoDevolucionDetalle(dr);
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

