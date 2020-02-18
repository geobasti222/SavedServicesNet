using System;
using System.Data;
using System.Web.Security;

using Application.Enterprise.Data;
using Application.Enterprise.CommonObjects;

using Microsoft.VisualBasic;

//using companyname.Security;

namespace Application.Enterprise.Business
{
    [Serializable]
    public class ConfiguracionInstrumentos
    {
        #region Constructor y Destructor

        public ConfiguracionInstrumentos()
        {
        }

        static ConfiguracionInstrumentos()
        {
        }

        #endregion

        #region Metodos

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
                okTrans = Data.ConfiguracionInstrumentos.AdicionarConfiguracionInstrumento(Nemotecnico, NombreUsuario);

            }
            catch (Exception ex)
            {
                /*Data.Error.Adicionar(DateTime.Now, NombreUsuario, ex.GetHashCode().ToString(), ex.Message); */
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
                okTrans = Data.ConfiguracionInstrumentos.EliminarConfiguracionIntrumentos(NombreUsuario);

            }
            catch (Exception ex)
            {
                /*Data.Error.Adicionar(DateTime.Now, NombreUsuario, ex.GetHashCode().ToString(), ex.Message); */
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
            DataTable configuracion = new DataTable();

            try
            {
                configuracion = Data.ConfiguracionInstrumentos.ConsultarConfiguracionInstrumentosxUsuario(NombreUsuario);
                return configuracion;
            }
            catch (Exception ex)
            {
                /*Data.Error.Adicionar(DateTime.Now,
                    NombreUsuario, ex.GetHashCode().ToString(),
                    ex.Message); */
                return configuracion;
            }
        }

        /// <summary>
        /// Lista todos los instrumentos del colcap + los instrumento del portafolio de cada usuario.
        /// </summary>
        /// <param name="NombreUsuario"></param>
        /// <returns></returns>
        public static DataTable ConsultarConfiguracionInstrumentosxUsuarioPortafolio(string NombreUsuario)
        {
            DataTable configuracion = new DataTable();

            try
            {
                configuracion = Data.ConfiguracionInstrumentos.ConsultarConfiguracionInstrumentosxUsuarioPortafolio(NombreUsuario);
                return configuracion;
            }
            catch (Exception ex)
            {
                /*Data.Error.Adicionar(DateTime.Now,
                    NombreUsuario, ex.GetHashCode().ToString(),
                    ex.Message); */
                return configuracion;
            }
        }


        public static DataTable EliminarConfiguracionIntrumentos1(string NombreUsuario)
        {
            bool okTrans = false;
            try
            {
                okTrans = Data.ConfiguracionInstrumentos.EliminarConfiguracionIntrumentos(NombreUsuario);

            }
            catch (Exception ex)
            {
                /*Data.Error.Adicionar(DateTime.Now, NombreUsuario, ex.GetHashCode().ToString(), ex.Message); */
            }

            return null;
        }



        #endregion
    }
}
