using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Application.Enterprise.CommonObjects.Enumerations;
using System.Web.Http.Cors;

namespace Application.Enterprise.Services.Controllers
{
    
    public class VendedorController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public List<VendedorInfo> LoadZonasxRegion(SessionUserInfo ObjSessionUserInfo)
        {
            List<VendedorInfo> lista = new List<VendedorInfo>();
            Vendedor objVendedor = new Vendedor("conexion");

            if (ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona) || ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                lista.Add(objVendedor.ListxCodVendedor(ObjSessionUserInfo.IdVendedor.ToString()));
            }
            else if (ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                Regionales objRegionales = new Regionales("conexion");
                RegionalesInfo objRegionalesInfo = new RegionalesInfo();

                objRegionalesInfo = objRegionales.ListxId(Convert.ToInt32(ObjSessionUserInfo.IdRegional));

                if (objRegionalesInfo != null)
                {
                    lista = objVendedor.ListxGerentesZonales(objRegionalesInfo.IdRegional);
                }
            }

            //-----------------------------------------------------------------------------------------------------------
            //Establece la zona del usuario logueado.

            if (ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                foreach (var item in lista)
                {
                    if (item.IdVendedor.Trim() == ObjSessionUserInfo.IdVendedor)
                    {                       
                        lista = new List<VendedorInfo>();
                        lista.Add(item);
                        break;
                    }
                }
            }
            else if (ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                lista = new List<VendedorInfo>();
            }
            if (ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                 lista = new List<VendedorInfo>();
            }
            //-----------------------------------------------------------------------------------------------------------
            
            return lista;
        }

        [HttpGet]
        [HttpPost]
        public VendedorInfo VendedorxId(string id)
        {
            VendedorInfo reg = null;
            Application.Enterprise.Business.Vendedor module = new Application.Enterprise.Business.Vendedor("conexion");

            reg = module.ListxIdVendedor(id);

            return reg;
        }

    }
}
