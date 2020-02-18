using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Enterprise.Services.Models;
using Application.Enterprise.CommonObjects;
using System.Data;
using System.Reflection;
using System.Diagnostics;


namespace Application.Enterprise.Services.Models
{
    public class ConfigurationParameters : Application.Enterprise.Services.Models.IConfigurationParameters
    {
        public List<Application.Enterprise.CommonObjects.ConfigurationParameters> GetConfigurationParameters(InfoUsuario objUser)
        {
            List<Application.Enterprise.CommonObjects.ConfigurationParameters> MyParameters = new List<Application.Enterprise.CommonObjects.ConfigurationParameters>();
            try
            {
                DataTable dtParametros = Business.ParametroConfiguracion.Obtener(objUser);

                if (dtParametros.Rows.Count > 0)
                {




                    for (int i = 0; i < dtParametros.Rows.Count; i++)
                    {
                        Application.Enterprise.CommonObjects.ConfigurationParameters CfgItem = new Application.Enterprise.CommonObjects.ConfigurationParameters();

                        CfgItem.Name = dtParametros.Rows[i]["Nombre"].ToString();
                        CfgItem.Value = dtParametros.Rows[i]["Valor"].ToString();
                        /*CfgItem.Error = new Error();
                        CfgItem.Error.existError = false;*/

                        MyParameters.Add(CfgItem);
                    }
                }
                else
                {
                    /*Application.Enterprise.CommonObjects.ConfigurationParameters MyCfg = new Application.Enterprise.CommonObjects.ConfigurationParameters();
                    MyCfg.Error = new Error();
                    MyCfg.Error.existError = false;
                    MyParameters.Add(MyCfg); */
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                Application.Enterprise.CommonObjects.ConfigurationParameters MyCfg = new Application.Enterprise.CommonObjects.ConfigurationParameters();
                /*MyCfg.Error = new Error();
                MyCfg.Error.existError = true;
                MyCfg.Error.Description = ex.Message;
                MyCfg.Error.Code = 3;
                MyParameters.Add(MyCfg);

                Business.Error.Adicionar(DateTime.Now, objUser.Id, "WebAPI", "GetConfigurationParameters: " + ex.Message);
                */
            }

            return MyParameters;
        }


        public List<Application.Enterprise.CommonObjects.ConfigurationParameters> GetInfoContacts(InfoUsuario objUser)
        {

            //List<Application.Enterprise.CommonObjects.Contact> MyContacts = new List<Application.Enterprise.CommonObjects.Contact>();
            try
            {
                DataTable dtParametros = Business.ParametroConfiguracion.ObtenerContactosFirma(objUser);

                if (dtParametros.Rows.Count > 0)
                {

                    for (int i = 0; i < dtParametros.Rows.Count; i++)
                    {
                        /*Application.Enterprise.CommonObjects.Contact ContactsItem = new Application.Enterprise.CommonObjects.Contact();

                         ContactsItem.Name = dtParametros.Rows[i]["Nombre"].ToString();
                         ContactsItem.Mail = dtParametros.Rows[i]["Correo"].ToString();
                         ContactsItem.PhoneNumber = dtParametros.Rows[i]["Extension"].ToString();

                         ContactsItem.Error = new Error();
                         ContactsItem.Error.existError = false; 

                          MyContacts.Add(ContactsItem);*/
                    }
                }
                else
                {
                    /* Application.Enterprise.CommonObjects.Contact MyContact = new Application.Enterprise.CommonObjects.Contact();
                     MyContact.Error = new Error();
                     MyContact.Error.existError = false;
                    MyContacts.Add(MyContact);*/
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                /*Application.Enterprise.CommonObjects.Contact MyContact = new Application.Enterprise.CommonObjects.Contact();
                MyContact.Error = new Error();
                MyContact.Error.existError = true;
                MyContact.Error.Description = ex.Message;
                MyContact.Error.Code = 3;
                MyContacts.Add(MyContact);*/

                //Business.Error.Adicionar(DateTime.Now, objUser.Id, "WebAPI", "GetInfoContacts: " + ex.Message);
            }

            return null;
        }
    }
}
