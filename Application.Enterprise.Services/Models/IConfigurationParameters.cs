using System;
namespace Application.Enterprise.Services.Models
{
    interface IConfigurationParameters
    {
        System.Collections.Generic.List<Application.Enterprise.CommonObjects.ConfigurationParameters> GetConfigurationParameters(Application.Enterprise.CommonObjects.InfoUsuario objUser);

        System.Collections.Generic.List<Application.Enterprise.CommonObjects.ConfigurationParameters> GetInfoContacts(Application.Enterprise.CommonObjects.InfoUsuario objUser);

    }
}
