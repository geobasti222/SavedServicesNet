using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Regionales
    /// </summary>
    public interface IRegionales
    {
        #region "Metodos de Regionales"

        /// <summary>
        /// Lista todos las regiones existentes.
        /// </summary>
        /// <returns></returns>
        List<RegionalesInfo> List();

        /// <summary>
        /// Consulta una regional por id
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        RegionalesInfo ListxId(int CodigoRegional);

           /// <summary>
        /// Lista una regional por zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        RegionalesInfo ListxZona(string Zona);
        
         /// <summary>
        /// -Lista una regional por cedula de regional
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <returns></returns>
        RegionalesInfo ListxCedulaRegional(string CedulaRegional);
        
        /// <summary>
        /// Lista las regiones que comprenden al pais
        /// </summary>
        /// <returns></returns>
        List<RegionalesInfo> ListRegionesPais();

        /// <summary>
        /// Se obtiene la regiones por codigo
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        RegionalesInfo ListxCedulaRegional(int CodigoRegional);


        /// <summary>
        /// Lista una regional Y nombre de gerente
        /// </summary>
        /// <returns></returns>
        List<RegionalesInfo> ListXGerente();

        /// <summary>
        /// Realiza el registro de una regional
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool InsertRegionales( RegionalesInfo  item, string Usuario);


        /// <summary>
        /// Realiza el eliminacion  de una regional
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool DeleteRegionales(string CodigoRegional, string Usuario);

        /// <summary>
        /// lista los gerentes
        /// </summary>
        /// <returns></returns>
        List<RegionalesInfo> ListGerentes();


         /// <summary>
        /// Lista un los gerentesregionales
        /// </summary>
        /// <returns></returns>
        List<RegionalesInfo> ListGerentesRegionales();


        /// <summary>
        /// ACtualizar un divisional
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(RegionalesInfo item);



        #endregion
    }
}

