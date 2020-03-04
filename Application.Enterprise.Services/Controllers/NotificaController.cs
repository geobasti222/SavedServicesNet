using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Services.Controllers
{

    public class NotificaController : BaseController

    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        //private static ITokenServices _TokenServices = new TokenServices();

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public List<NotificaInfo> ListadoEnvioEmail()
        {

            List<NotificaInfo> ObjNotificaInfoResponse = new List<NotificaInfo>();

            Notifica objNotifica = new Notifica("conexion");

            ObjNotificaInfoResponse = objNotifica.List();

           

            return ObjNotificaInfoResponse;


        }

        [HttpGet]
        [HttpPost]
        public NotificaInfo ActualizarNotificaMail(NotificaInfo objNotificaInfo)

        {
            NotificaInfo ObjNotificaInfoResponse = new NotificaInfo();

            Notifica ObjNotifica = new Notifica("conexion");

            bool OkTrans = false;

            OkTrans = ObjNotifica.UpdateNotifica(objNotificaInfo.Nit, objNotificaInfo.Mt_Id, objNotificaInfo.Documento);


            if (OkTrans)
            {
              
                ObjNotificaInfoResponse.Nit = objNotificaInfo.Nit;
                ObjNotificaInfoResponse.Estado = true;
            }
            else
            {
                ObjNotificaInfoResponse.Error = new Error();
                ObjNotificaInfoResponse.Error.Id = -1;
                ObjNotificaInfoResponse.Error.Descripcion = "No se puede crear actualizar la informacion, verifique el Documento de la empresaria.:" + objNotificaInfo.Nit + ", Fallo Envio.";
                ObjNotificaInfoResponse.Nit = objNotificaInfo.Nit;
            }



            return ObjNotificaInfoResponse;

        }



    }
}
