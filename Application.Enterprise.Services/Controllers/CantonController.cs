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
    
    public class CantonController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public List<CiudadInfo> ListarCanton(EstadoInfo ObjProvincia)
        {
            List<CiudadInfo> lista = new List<CiudadInfo>();
            Ciudad module = new Ciudad("conexion");

            lista = module.ListByEstado(ObjProvincia.CodEstado);

            return lista;
        }
    
    }
}
