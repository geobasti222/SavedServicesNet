using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Enterprise.Services.Models;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.ActionFilters;
using System.Web.Http.Cors;

namespace Application.Enterprise.Services.Controllers
{
    
    public class ConfigurationParametersController : BaseController
    {
        static readonly IConfigurationParameters MyParameter = new Application.Enterprise.Services.Models.ConfigurationParameters();

        [HttpGet]
        [HttpPost]        
        public List<Application.Enterprise.CommonObjects.ConfigurationParameters> GetConfigurationParameters(AutenticationRequest objUser)
        {
            InfoUsuario MyUser = new InfoUsuario(objUser.strIdUser);
            Application.Enterprise.CommonObjects.ConfigurationParameters objConfig = new Application.Enterprise.CommonObjects.ConfigurationParameters();
         //   objConfig.Error = validateAuthenticatedUser(objUser.strIdUser);

            if (false)
            {
                List<Application.Enterprise.CommonObjects.ConfigurationParameters> lsConfigParams = new List<Application.Enterprise.CommonObjects.ConfigurationParameters>();
                lsConfigParams.Add(objConfig);
                return lsConfigParams;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        [HttpPost]        
        public List<Application.Enterprise.CommonObjects.ConfigurationParameters> GetInfoContacts(AutenticationRequest objUser)
        {
            /*InfoUsuario MyUser = new InfoUsuario(objUser.strIdUser);
            Application.Enterprise.CommonObjects.Contact objConfig = new Infrastructure.Models.Contact();
            objConfig.Error = validateAuthenticatedUser(objUser.strIdUser);

            if (objConfig.Error.existError)
            {
                List<Application.Enterprise.CommonObjects.Contact> lsConfigParams = new List<Infrastructure.Models.Contact>();
                lsConfigParams.Add(objConfig);
                return lsConfigParams;
            }
            else
            {
                return MyParameter.GetInfoContacts(MyUser);
            }*/

            return null;
        }

    }
}
