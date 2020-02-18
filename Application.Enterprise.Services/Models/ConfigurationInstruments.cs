using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;


namespace Application.Enterprise.Services.Models
{
    public class ConfigurationInstruments : IConfigurationInstruments
    {

        /// <summary>
        /// Guarda un instrumento x usuario.
        /// </summary>
        /// <param name="objView"></param>
        /// <returns></returns>
        public bool AddConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView)
        {
            bool okTrans = false;
            try
            {
                okTrans = Business.ConfiguracionInstrumentos.AdicionarConfiguracionInstrumento(objView.NameNemotec, objView.NameUser);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                okTrans = false;

                //Business.Error.Adicionar(DateTime.Now, objView.NameUser, "WebAPI", "AddConfigurationInstrumentsView: " + ex.Message);
            }

            return okTrans;

        }

        /// <summary>
        /// Guarda un instrumento x usuario.
        /// </summary>
        /// <param name="objView"></param>
        /// <returns></returns>
        public bool AddDelConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView)
        {
            bool okTrans = false;
            try
            {
                //okTrans = Business.ConfiguracionInstrumentos.AdicionarBorrarConfiguracionInstrumento(objView);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                okTrans = false;

                //Business.Error.Adicionar(DateTime.Now, objView.NameUser, "WebAPI", "AddDelConfigurationInstrumentsView: " + ex.Message);
            }

            return okTrans;

        }

        /// <summary>
        /// Elimina todos los instrumentos de un usuario especifico.
        /// </summary>
        /// <param name="objView"></param>
        /// <returns></returns>
        public bool DeleteConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView)
        {
            bool okTrans = false;
            try
            {
                okTrans = Business.ConfiguracionInstrumentos.EliminarConfiguracionIntrumentos(objView.NameUser);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                okTrans = false;

                //Business.Error.Adicionar(DateTime.Now, objView.NameUser, "WebAPI", "DeleteConfigurationInstrumentsView: " + ex.Message);
            }

            return okTrans;

        }

        /// <summary>
        /// Obtiene la lista de los instrumentos de configuracion de un usuario.
        /// </summary>
        /// <param name="objView"></param>
        /// <returns></returns>
        public List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> GetConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView)
        {
            List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> ListConfiguration = new List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView>();
            try
            {
                DataTable dt = Business.ConfiguracionInstrumentos.ConsultarConfiguracionInstrumentosxUsuario(objView.NameUser);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Application.Enterprise.CommonObjects.ConfigurationInstrumentsView confi = new Application.Enterprise.CommonObjects.ConfigurationInstrumentsView();

                        confi.NameUser = dt.Rows[i]["nombreusuario"].ToString();
                        confi.NameNemotec = dt.Rows[i]["nemotecnico"].ToString();
                        /* confi.Error = new Infrastructure.Models.Error();
                         confi.Error.existError = false;
                         confi.Error.Code = 0;*/

                        ListConfiguration.Add(confi);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                Application.Enterprise.CommonObjects.ConfigurationInstrumentsView confi = new Application.Enterprise.CommonObjects.ConfigurationInstrumentsView();
                /*confi.Error = new Infrastructure.Models.Error();
                confi.Error.existError = true;
                confi.Error.Code = 1;
                confi.Error.Description = ex.Message;*/

                //ListConfiguration.Add(confi);

                //Business.Error.Adicionar(DateTime.Now, objView.NameUser, "WebAPI", "GetConfigurationInstrumentsView: " + ex.Message);
            }

            return ListConfiguration;
        }


        /// <summary>
        /// Lista todos los instrumentos del colcap + los instrumento del portafolio de cada usuario.
        /// </summary>
        /// <param name="objView"></param>
        /// <returns></returns>
        public List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> GetConfigurationInstrumentsPortfolioView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView)
        {
            List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> ListConfiguration = new List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView>();
            try
            {
                DataTable dt = Business.ConfiguracionInstrumentos.ConsultarConfiguracionInstrumentosxUsuarioPortafolio(objView.NameUser);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Application.Enterprise.CommonObjects.ConfigurationInstrumentsView confi = new Application.Enterprise.CommonObjects.ConfigurationInstrumentsView();

                        /*confi.NameUser = dt.Rows[i]["nombreusuario"].ToString();
                        confi.NameNemotec = dt.Rows[i]["nemotecnico"].ToString();
                        confi.Error = new Infrastructure.Models.Error();
                        confi.Error.existError = false;
                        confi.Error.Code = 0;
                        */
                        ListConfiguration.Add(confi);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                Application.Enterprise.CommonObjects.ConfigurationInstrumentsView confi = new Application.Enterprise.CommonObjects.ConfigurationInstrumentsView();
                /*confi.Error = new Infrastructure.Models.Error();
                 confi.Error.existError = true;
                 confi.Error.Code = 1
                 confi.Error.Description = ex.Message; */

                //ListConfiguration.Add(confi);

                //Business.Error.Adicionar(DateTime.Now, objView.NameUser, "WebAPI", "GetConfigurationInstrumentsPortfolioView: " + ex.Message);


            }

            return ListConfiguration;
        }
    }
}
