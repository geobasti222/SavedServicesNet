using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IMatrizComercialJA
    /// </summary>
    public interface IMatrizComercialJA
    {

        /// <summary>
        /// Traer las campanas completas
        /// </summary>
        /// <returns></returns>
        DataTable traerCampanas();

        /// <summary>
        /// Traer las campanas mayores a la seleccionada
        /// </summary>
        /// <returns></returns>
        DataTable traerCampanasMayores(DateTime campanaini);

        /// <summary>
        /// Traer divisionales completas
        /// </summary>
        /// <returns></returns>
        DataTable traerDivisionales();

        /// <summary>
        /// Traer divisionales por zona seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerZonasXDivisionales(String division);

        /// <summary>
        /// Traer Zona por zona seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        ZonaInfo traerZonasXZona(String zona);

       
                

        #region listar

        ////divisionales-----------------------------------------------------
        /// <summary>
        /// TRAE LOS DATOS POR DIVISION Y CAMPANA
        /// </summary>
        /// <param name="division"></param>
        /// <param name="campana"></param>
        /// <returns></returns>
        DataTable traerxDivisionalYCampana(String division, String campana);

        /// <summary>
        /// Traer todos las divisionales de una campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerDivisionales(String campana);

        ////zonas-----------------------------------------------------------
        /// <summary>
        /// Lista todas los datos de las zonas x campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        DataTable traerDatosZonasxCampana(String campana);

        /// <summary>
        /// Lista todas los datos de las zonas por zona y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <returns></returns>
        DataTable traerDatosZonasxZonaYCampana(String zona, String campana);

        /// <summary>
        /// Lista todas los datos de las zonas por divional y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        DataTable traerDatosxDivisionalYCampana(String divisional, String campana, String campanafin);

        /// <summary>
        /// Lista todas los datos de las zonas por divional, campana y zona
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        DataTable traerDatosZonasxDivisionalCampanaYZona(String campana, String divisional, String zona);

        //////campanas-----------------------------------------------------------------------------
        /// <summary>
        /// Lista todas los datos de las campanas por  rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        DataTable traerDatoscampanaxRangoCampana(DateTime campana, DateTime campanafin);

        /// <summary>
        /// Lista todas los datos de las campanas por zona, rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        DataTable traerDatoscampanaxZonaYRangoCampana(DateTime campana, String zona, DateTime campanafin);


        /// <summary>
        /// Lista todas los datos de las campanas por divisional, rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        DataTable traerDatoscampanaxDivisionalYRangoCampana(DateTime campana, String divisional, DateTime campanafin);


        /// <summary>
        /// Lista todos los datos de campana x zona rango de campana y divisional
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <param name="campanafin"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        DataTable traerDatoscampanaxZonaYRangoCampanaYDivisional(DateTime campana, String zona, DateTime campanafin, String divisional);
        

        #endregion

       /// <summary>
        /// Lista todos los datos de Empresarias por estado X
      /// </summary>
      /// <param name="Estado"></param>
      /// <param name="campana"></param>
      /// <param name="Zona"></param>
      /// <returns></returns>
        DataTable traerDatosEmpresariasEstado(String Estado, String campana, String Zona);
        
        /// <summary>
        /// Lista todos los datos de Empresarias por estado (1,2,6,7)
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        DataTable traerDatosEmpresariasActivas(String campana, String Zona);

        /// <summary>
        /// Lista todos los datos de Empresarias con pedidos en la campaña y zona 
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        DataTable traerDatosEmpresariasPedidos(String campana, String Zona);
        
        /// <summary>
        /// Traer todos los datos de las divisionales de una campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerPais(String campana, string campanafin);

        /// <summary>
        /// Lista todas los datos de las zonas por divional y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        DataTable traerDatosZonasxDivisionalYCampana(String divisional, String campana);

       
        

        #region lista nuevas de la matriz vieja fea
         /// <summary>
        /// Lista las nuevas que fueron prospecto
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<ClienteInfo> NuevasProspecto(string campana);

        /// <summary>
        /// Lista las nuevas que fueron referido
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<ClienteInfo> NuevasReferido(string campana);

         /// <summary>
        /// Lista las nuevas que fueron 18 campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<ClienteInfo> Nuevas18Campana(string campana);
        

        /// <summary>
        /// Lista las nuevas 
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<ClienteInfo> Nuevas(string campana);
        
        
        
        #endregion


    }
}
