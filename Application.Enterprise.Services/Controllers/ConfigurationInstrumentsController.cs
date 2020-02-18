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
    
    public class ConfigurationInstrumentsController : BaseController
    {
        static readonly IConfigurationInstruments MyConfiguration = new Services.Models.ConfigurationInstruments();

        [HttpGet]
        [HttpPost]        
        public bool AddConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objConfiguration)
        {
            /*objConfiguration.Error = validateAuthenticatedUser(objConfiguration.NameUser);

            if (!objConfiguration.Error.existError)
                return MyConfiguration.AddConfigurationInstrumentsView(objConfiguration);
            else*/
                return false;
        }

        [HttpGet]
        [HttpPost]        
        public bool AddDelConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objConfiguration)
        {
            /*objConfiguration.Error = validateAuthenticatedUser(objConfiguration.NameUser);

            if (!objConfiguration.Error.existError)
                return MyConfiguration.AddDelConfigurationInstrumentsView(objConfiguration);
            else*/
                return false;
        }

        [HttpGet]
        [HttpPost]        
        public bool DeleteConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objConfiguration)
        {
            //objConfiguration.Error = validateAuthenticatedUser(objConfiguration.NameUser);

            /*if (!objConfiguration.Error.existError)
                return MyConfiguration.DeleteConfigurationInstrumentsView(objConfiguration);
            else
            {
                return false;
            }*/

            return false;
        }


        [HttpGet]
        [HttpPost]        
        public List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> GetConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objConfiguration)
        {
            List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> lsconfiguration = new List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView>();
            /*objConfiguration.Error = validateAuthenticatedUser(objConfiguration.NameUser);
            if (!objConfiguration.Error.existError)
            {
                lsconfiguration = MyConfiguration.GetConfigurationInstrumentsView(objConfiguration);
            }
            else
            {
                lsconfiguration = new List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView>();
                lsconfiguration.Add(objConfiguration);
             
            }*/
            return lsconfiguration;
        }

        [HttpGet]
        [HttpPost]        
        public List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> GetConfigurationInstrumentsPortfolioView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objConfiguration)
        {
            List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> lsconfiguration = new List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView>();
            /*objConfiguration.Error = validateAuthenticatedUser(objConfiguration.NameUser);
            if (!objConfiguration.Error.existError)
            {
                lsconfiguration = MyConfiguration.GetConfigurationInstrumentsPortfolioView(objConfiguration);
            }
            else
            {
                lsconfiguration = new List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView>();
                lsconfiguration.Add(objConfiguration);

            }*/
            return lsconfiguration;
        }
    }
}
