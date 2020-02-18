using System;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Application.Enterprise.Data
{
    public class ConfiguracionInstrumentos
    {
        static ConfiguracionInstrumentos()
        {
        }

         /// <summary>
        /// Guarda un instrumento x usuario.
        /// </summary>
        /// <param name="Nemotecnico"></param>
        /// <param name="NombreUsuario"></param>
        /// <returns></returns>
        public static bool AdicionarConfiguracionInstrumento(string Nemotecnico, string NombreUsuario)
        {
            bool okTrans = false;

            try
            {
                // Recuperar objeto de conexión
                Database dbTrader = DatabaseFactory.CreateDatabase("CONNTRADER_ADMIN");

                // Crear objeto SP
                DbCommand spObjetc = dbTrader.GetStoredProcCommand("PRC_INSTRUMENTOSXUSUARIO");

                dbTrader.AddInParameter(spObjetc, "@i_operation", DbType.String, 'I');
                dbTrader.AddInParameter(spObjetc, "@i_option", DbType.String, 'A');
                dbTrader.AddInParameter(spObjetc, "@i_nemotecnico", DbType.String, Nemotecnico);
                dbTrader.AddInParameter(spObjetc, "@i_nombreusuario", DbType.String, NombreUsuario);
                dbTrader.AddInParameter(spObjetc, "@i_sysdate", DbType.DateTime, DateTime.Now);
                dbTrader.ExecuteNonQuery(spObjetc);

                okTrans = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion en la funcion eTrader.Data.ConfiguracionInstrumentos.AdicionarConfiguracionInstrumento \n" + ex.Message);
            }

            return okTrans;
        }


        /// <summary>
        /// Elimina todos los instrumentos de un usuario especifico.
        /// </summary>
        /// <param name="NombreUsuario"></param>
        /// <returns></returns>
        public static bool EliminarConfiguracionIntrumentos(string NombreUsuario)
        {
            bool okTrans = false;

            try
            {
                // Recuperar objeto de conexión
                Database dbTrader = DatabaseFactory.CreateDatabase("CONNTRADER_ADMIN");

                // Crear objeto SP
                DbCommand spObjetc = dbTrader.GetStoredProcCommand("PRC_INSTRUMENTOSXUSUARIO");

                dbTrader.AddInParameter(spObjetc, "@i_operation", DbType.String, 'D');
                dbTrader.AddInParameter(spObjetc, "@i_option", DbType.String, 'A');
                dbTrader.AddInParameter(spObjetc, "@i_nemotecnico", DbType.String, "");
                dbTrader.AddInParameter(spObjetc, "@i_nombreusuario", DbType.String, NombreUsuario);
                dbTrader.AddInParameter(spObjetc, "@i_sysdate", DbType.DateTime, DateTime.Now);
                dbTrader.ExecuteNonQuery(spObjetc);

                okTrans = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion en la funcion eTrader.Data.ConfiguracionInstrumentos.EliminarConfiguracion \n" + ex.Message);
            }

            return okTrans;
        }

        /// <summary>
        /// Obtiene la lista de los instrumentos de configuracion de un usuario.
        /// </summary>
        /// <param name="NombreUsuario"></param>
        /// <returns></returns>
        public static DataTable ConsultarConfiguracionInstrumentosxUsuario(string NombreUsuario)
        {
            DataSet datos;
            DataTable configuracion = new DataTable();

            try
            {
                // Recuperar objeto de conexión
                Database dbTrader = DatabaseFactory.CreateDatabase("CONNTRADER_ADMIN");

                // Crear objeto SP
                DbCommand spObjetc = dbTrader.GetStoredProcCommand("PRC_INSTRUMENTOSXUSUARIO");
                dbTrader.AddInParameter(spObjetc, "@i_operation", DbType.String, 'S');
                dbTrader.AddInParameter(spObjetc, "@i_option", DbType.String, 'A');
                dbTrader.AddInParameter(spObjetc, "@i_nombreusuario", DbType.String, NombreUsuario);
                datos = dbTrader.ExecuteDataSet(spObjetc);
                configuracion = datos.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion en la funcion eTrader.Data.ConfiguracionInstrumentos.ConsultarConfiguracionInstrumentosxUsuario \n" + ex.Message);
            }

            return configuracion;
        }

        /// <summary>
        /// Lista todos los instrumentos del colcap + los instrumento del portafolio de cada usuario.
        /// </summary>
        /// <param name="NombreUsuario"></param>
        /// <returns></returns>
        public static DataTable ConsultarConfiguracionInstrumentosxUsuarioPortafolio(string NombreUsuario)
        {
            DataSet datos;
            DataTable configuracion = new DataTable();

            try
            {
                // Recuperar objeto de conexión
                Database dbTrader = DatabaseFactory.CreateDatabase("CONNTRADER_ADMIN");

                // Crear objeto SP
                DbCommand spObjetc = dbTrader.GetStoredProcCommand("PRC_INSTRUMENTOSXUSUARIO");
                dbTrader.AddInParameter(spObjetc, "@i_operation", DbType.String, 'S');
                dbTrader.AddInParameter(spObjetc, "@i_option", DbType.String, 'B');
                dbTrader.AddInParameter(spObjetc, "@i_nombreusuario", DbType.String, NombreUsuario);
                datos = dbTrader.ExecuteDataSet(spObjetc);
                configuracion = datos.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion en la funcion eTrader.Data.ConfiguracionInstrumentos.ConsultarConfiguracionInstrumentosxUsuarioPortafolio \n" + ex.Message);
            }

            return configuracion;
        }
    }
}