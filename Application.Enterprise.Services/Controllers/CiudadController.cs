using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Web.Http;

namespace Application.Enterprise.Services.Controllers
{

    public class CiudadController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public CiudadInfo ListarCiudad(CiudadInfo ObjCiudadInfoReq)
        {
            CiudadInfo ObjCiudadResponse = new CiudadInfo();

            CiudadInfo ObjCiudadInfo = new CiudadInfo();
            Ciudad ObjCiudad = new Ciudad("conexion");

            decimal PorcentajeIvaFlete = 0;

            decimal ValorFleteSinIva = 0;
            decimal ValorFlete = 0;

            ObjCiudadInfo.CodigoCiudadDespacho = ObjCiudadInfoReq.CodCiudad.Trim();

            try
            {
                //se obtiene la info de la ciudad del cliente.
                ObjCiudadInfo = ObjCiudad.ListCiudadxId(ObjCiudadInfoReq.CodCiudad.Trim());

                PorcentajeIvaFlete = ObjCiudadInfo.IVA;
                ValorFleteSinIva = ObjCiudadInfo.ValorFlete;
                ValorFlete = (ValorFleteSinIva + (PorcentajeIvaFlete * (ValorFleteSinIva / 100)));

                ObjCiudadResponse.CodigoCiudadDespacho = ObjCiudadInfoReq.CodCiudad.Trim();
                ObjCiudadResponse.ValorFlete = ValorFlete;
            }
            catch
            {
                ObjCiudadResponse.CodigoCiudadDespacho = ObjCiudadInfoReq.CodCiudad.Trim();
                ObjCiudadResponse.ValorFlete = -1;
            }           

            return ObjCiudadResponse;
        }

    }
}
