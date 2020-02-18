using System;
namespace Application.Enterprise.Services.Models
{
    interface IConfigurationInstruments
    {
        bool AddConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView);

        bool AddDelConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView);

        bool DeleteConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView);

        System.Collections.Generic.List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> GetConfigurationInstrumentsView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView);

        System.Collections.Generic.List<Application.Enterprise.CommonObjects.ConfigurationInstrumentsView> GetConfigurationInstrumentsPortfolioView(Application.Enterprise.CommonObjects.ConfigurationInstrumentsView objView);

    }
}
