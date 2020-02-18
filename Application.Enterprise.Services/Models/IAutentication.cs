using System;
using System.Collections.Generic;
using System.Data;
namespace Application.Enterprise.Services.Models
{
    public interface IAutentication
    {
        /*Error logOutUser_(string strIdUser);

        Application.Enterprise.Infrastructure.Models.Originator AutenticationUser(string strIdUser, string strPassword, string IpAddress, bool ValidateIP, bool force = false , bool disclaimer = false, string strToken = "",bool validatepassword=true);
        Application.Enterprise.Infrastructure.Models.Error ChangePassword(string iduser, string newpassword, string currentpassword);
        Application.Enterprise.Infrastructure.Models.Error ChangePasswordAdmin(string iduser, string newpassword, string securitypassword);
        Application.Enterprise.Infrastructure.Models.Error LogOutUser(string strIdUser, string strPassword, bool sendDis,  string ipAddress = "", bool removecache = false);
        Application.Enterprise.Infrastructure.Models.Error LogOutUserAdmin(string strIdUser, bool sendDis);*/
        /*string Encrypt(string toEncrypt, bool useHashing);
        bool IsAuthenticated(string strIdUser);
        bool RegisterUserIpAddress(string strIdUser, string strIpAddress);
        bool IsValidIpAddress(string strIdUser, string strIpAddress);
        DataTable GetRegisteredIPAddressByUserExternal(string strIdUser);
        //List<IpAddress> GetRegisteredIPAddressByUser(string strIdUser);
        bool DeleteRegisteredIPAddressByUser(string strIdUser, string IpAddress);
        bool IsValisLocalIpAddress(string strUserId, string IpAddress);
        bool UpdateDisclaimerDate(string strIdUser);
        
        DataTable AuthenticatedUsers(string user);
        string NumAuthenticatedUsers(string user);
        
        //List<Infrastructure.Enumerations.WebComponents> EnableComponents(string user);
        //bool GetUserbyDataServer(string nomUsuario);
        bool UpdateShowTutorialDate(string strIdUser);
        int AdicionarUsuarioOnline(string NombreUsuario, string Nombres, string Apellidos);
        int BorrarUsuarioOnline(string NombreUsuario);*/

        string GetUserbyToken(string token);

    }
}
