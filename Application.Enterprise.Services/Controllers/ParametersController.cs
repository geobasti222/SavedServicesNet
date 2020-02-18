using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace Application.Enterprise.Services.Controllers
{
    
    public class ParametersController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        static readonly IConfigurationParameters DbParameters = new Models.ConfigurationParameters();
        //private static ITokenServices _TokenServices = new TokenServices();

        public static IAutentication Instance => _Instance.Value;



        [HttpGet]
        [HttpPost]        
        public List<Application.Enterprise.CommonObjects.RegionalesInfo> GetContactSign(AutenticationRequest objUser)
        {
            /*List<RegionalesInfo> lista = new List<RegionalesInfo>(); ;
            Application.Enterprise.Business.Regionales module = new Application.Enterprise.Business.Regionales("conexion");

            lista = module.List();

            if (lista != null && lista.Count > 0)
            {
                rcb_regional.DataTextField = "Nombre";
                rcb_regional.DataValueField = "CodigoRegional";
                rcb_regional.DataSource = lista;
                rcb_regional.DataBind();
            }
            else
            {
                rcb_regional.Text = "";
                rcb_regional.SelectedValue = "";
                rcb_regional.ClearSelection();
                rcb_regional.Items.Clear();
            }

            rcb_regional.Items.Insert(0, new RadComboBoxItem(" "));

            if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona) || Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {

                //-----------------------------------------------------------------------------------------------------------
                //Establece la region del usuario logueado.
                Application.Enterprise.Business.RegionxZona moduleRegionxZona = new Application.Enterprise.Business.RegionxZona("conexion");
                NIVI.Application.Enterprise.CommonObjects.RegionxZonaInfo objRegionxZonaInfo = new NIVI.Application.Enterprise.CommonObjects.RegionxZonaInfo();

                objRegionxZonaInfo = moduleRegionxZona.ListRegionalxZona(Session["IdZona"].ToString());

                if (objRegionxZonaInfo != null)
                {
                    rcb_regional.SelectedValue = objRegionxZonaInfo.CodigoRegion.ToString();

                    rcb_regional.Enabled = false;

                    if (rcb_regional.SelectedValue != "")
                    {
                        LoadZonasxRegion(Convert.ToInt32(rcb_regional.SelectedValue));
                    }
                    //-----------------------------------------------------------------------------------------------------------

                    //Para que mantenga el estado del combo seleccionado por el usuario.
                    //if (vsconcepto != "" && vsconcepto != null)
                    //{
                    //    rcb_concepto.SelectedValue = vsconcepto;
                    //}
                }
                else
                {
                    EnableDisableControls(false);

                    //---------------------------------------------------------------------------------------------------------------
                    //Mensaje de advertencia
                    LiteralControl ltr = new LiteralControl();
                    ltr.Text = "<style type=\"text/css\" rel=\"stylesheet\">" + @".radalert { background-image: url(../images/warning.gif) !important; } </style> ";
                    this.Page.Header.Controls.Add(ltr);

                    string radalertscript = "<script language='javascript'>function f(){callAlertGenerico('La region actual se encuentra deshabilitada para el ingreso de empresarias. Por favor comuniquese con servicio al cliente.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
                }
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {


                Application.Enterprise.Business.Regionales objRegionales = new Application.Enterprise.Business.Regionales("conexion");
                NIVI.Application.Enterprise.CommonObjects.RegionalesInfo objRegionalesInfo = new NIVI.Application.Enterprise.CommonObjects.RegionalesInfo();

                objRegionalesInfo = objRegionales.ListxCedulaRegional(Session["CedulaRegional"].ToString().Trim());

                if (objRegionalesInfo != null)
                {
                    rcb_regional.SelectedValue = objRegionalesInfo.CodigoRegional.ToString();

                    rcb_regional.Enabled = false;

                    if (rcb_regional.SelectedValue != "")
                    {
                        LoadZonasxRegion(Convert.ToInt32(rcb_regional.SelectedValue));
                    }
                    //-----------------------------------------------------------------------------------------------------------

                }
            }

    */

            return null;
        }
    }
}
