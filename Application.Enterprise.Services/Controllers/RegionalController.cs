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
    
    public class RegionalController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public List<RegionalesInfo> ListarRegional(SessionUserInfo ObjSessionUserInfo)
        {
            List<RegionalesInfo> lista = new List<RegionalesInfo>();
            Application.Enterprise.Business.Regionales module = new Application.Enterprise.Business.Regionales("conexion");

            lista = module.List();                      

            if (ObjSessionUserInfo.IdGrupo.ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona) || ObjSessionUserInfo.IdGrupo == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                //-----------------------------------------------------------------------------------------------------------
                //Establece la region del usuario logueado.
                Application.Enterprise.Business.RegionxZona moduleRegionxZona = new Application.Enterprise.Business.RegionxZona("conexion");
                RegionxZonaInfo objRegionxZonaInfo = new RegionxZonaInfo();

                objRegionxZonaInfo = moduleRegionxZona.ListRegionalxZona(ObjSessionUserInfo.IdZona.ToString());

                if (objRegionxZonaInfo != null)
                {                  
                    foreach (var item in lista)
                    {
                        if (item.CodigoRegional== (int)objRegionxZonaInfo.CodigoRegion)
                        {
                            RegionalesInfo objRegionalesInfo = new RegionalesInfo();
                            objRegionalesInfo.Codgereg = objRegionxZonaInfo.IdRegional;
                            objRegionalesInfo.CodigoRegional = objRegionxZonaInfo.CodigoRegion;
                            objRegionalesInfo.IdRegional= objRegionxZonaInfo.CodigoRegion.ToString();
                            objRegionalesInfo.Nombre = objRegionxZonaInfo.Descripcion;
                            objRegionalesInfo.NombreGerente = objRegionxZonaInfo.Descripcion;
                            objRegionalesInfo.Usuario = ObjSessionUserInfo.Cedula;

                            lista = new List<RegionalesInfo>();
                            lista.Add(objRegionalesInfo);
                            break;
                        }
                    }
                  
                }
                else
                {
                    lista = new List<RegionalesInfo>(); 
                }
            }
            else if (ObjSessionUserInfo.IdGrupo == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                Application.Enterprise.Business.Regionales objRegionales = new Application.Enterprise.Business.Regionales("conexion");
                RegionalesInfo objRegionalesInfo = new RegionalesInfo();

                objRegionalesInfo = objRegionales.ListxCedulaRegional(ObjSessionUserInfo.CedulaRegional.Trim());

                if (objRegionalesInfo != null)
                {
                    foreach (var item in lista)
                    {
                        if (item.CodigoRegional == (int)objRegionalesInfo.CodigoRegional)
                        {
                            lista = new List<RegionalesInfo>();
                            lista.Add(item);
                            break;
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------

                }
            }

            return lista;
        }

        [HttpGet]
        [HttpPost]
        public RegionalesInfo RegionalxId(int id)
        {
            RegionalesInfo reg = null;
            Application.Enterprise.Business.Regionales module = new Application.Enterprise.Business.Regionales("conexion");

            reg = module.ListxId(id);           

            return reg;
        }

        [HttpGet]
        [HttpPost]
        public RegionalesInfo RegionalxZona(string Zona)
        {
            RegionalesInfo reg = null;
            Application.Enterprise.Business.Regionales module = new Application.Enterprise.Business.Regionales("conexion");

            reg = module.ListxZona(Zona);

            return reg;
        }

    }
}