using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// BO matriz comercial JA
    /// </summary>
    public class MatrizComercialJA:IMatrizComercialJA
    {
         /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MatrizComercialJA module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MatrizComercialJA()
        {
            module = new Application.Enterprise.Data.MatrizComercialJA();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MatrizComercialJA(string databaseName)
        {
            module = new Application.Enterprise.Data.MatrizComercialJA(databaseName);
        }

        /// <summary>
        /// Traer Zona por zona seleccionada
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public ZonaInfo traerZonasXZona(String zona)
        {
            return module.traerZonasXZona(zona);
        }


        public DataTable traerCampanas()
        {
            return module.traerCampanas();
        }

        public DataTable traerCampanasMayores(DateTime campanaini)
        {
            return module.traerCampanasMayores(campanaini);
        }

        public DataTable traerDivisionales()
        {
            return module.traerDivisionales();
        }

        public DataTable traerZonasXDivisionales(String division)
        {
            return module.traerZonasXDivisionales(division);
        }

        #region listar

        /// <summary>
        /// Traer todos los datos de una divisional por campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerxDivisionalYCampana(String division, String campana)
        {
            return module.traerxDivisionalYCampana(division, campana);
        }

        /// <summary>
        /// Traer todos las divisionales de una campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerDivisionales(String campana)
        {
            return module.traerDivisionales(campana);
        }

        //end divisionales

        /// <summary>
        /// Lista todas los datos de las zonas x campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxCampana(String campana)
        {
            return module.traerDatosZonasxCampana(campana);
        }

        /// <summary>
        /// Lista todas los datos de las zonas por zona y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxZonaYCampana(String zona, String campana)
        {
            return module.traerDatosZonasxZonaYCampana(zona, campana);
        }

        /// <summary>
        /// Lista todas los datos de las zonas por divional y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatosxDivisionalYCampana(String divisional, String campana, String campanafin)
        {
            return module.traerDatosxDivisionalYCampana(divisional, campana, campanafin);
        }

        /// <summary>
        /// Lista todas los datos de las zonas por divional, campana y zona
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxDivisionalCampanaYZona(String campana, String divisional, String zona)
        {
            return module.traerDatosZonasxDivisionalCampanaYZona(campana, divisional, zona);
        }


        //end zonas

        /// <summary>
        /// Lista todas los datos de las campanas por  rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        public DataTable traerDatoscampanaxRangoCampana(DateTime campana, DateTime campanafin)
        {
            return module.traerDatoscampanaxRangoCampana(campana, campanafin);
        }


        /// <summary>
        /// Lista todas los datos de las campanas por divisional, rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        public DataTable traerDatoscampanaxDivisionalYRangoCampana(DateTime campana, String divisional, DateTime campanafin)
        {
            return module.traerDatoscampanaxDivisionalYRangoCampana(campana, divisional, campanafin);
        }

        /// <summary>
        /// Lista todas los datos de las campanas por zona, rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        public DataTable traerDatoscampanaxZonaYRangoCampana(DateTime campana, String zona, DateTime campanafin)
        {
            return module.traerDatoscampanaxZonaYRangoCampana(campana, zona, campanafin);
        }


        /// <summary>
        /// Lista todos los datos de campana x zona rango de campana y divisional
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <param name="campanafin"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatoscampanaxZonaYRangoCampanaYDivisional(DateTime campana, String zona, DateTime campanafin, String divisional)
        {
            return module.traerDatoscampanaxZonaYRangoCampanaYDivisional(campana, zona, campanafin, divisional);
        }

        #endregion

       
        /// <summary>
        /// Lista todos los datos de Empresarias por estado (1,2,6,7)
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public DataTable traerDatosEmpresariasActivas(String campana, String Zona)
        {
            return module.traerDatosEmpresariasActivas(campana,Zona);
        }

        /// <summary>
        /// Lista todos los datos de Empresarias por estado X
      /// </summary>
      /// <param name="Estado"></param>
      /// <param name="campana"></param>
      /// <param name="Zona"></param>
      /// <returns></returns>
        public DataTable traerDatosEmpresariasEstado(String Estado, String campana, String Zona)
        {
            return module.traerDatosEmpresariasEstado(Estado, campana, Zona);
        }

        /// <summary>
        /// Lista todos los datos de Empresarias con pedidos en la campaña y zona 
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public DataTable traerDatosEmpresariasPedidos(String campana, String Zona)
        {
            return module.traerDatosEmpresariasPedidos(campana, Zona);
        }

        /// <summary>
        /// Traer todos los datos de las divisionales de una campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerPais(String campana, string campanafin)
        {
            return module.traerPais(campana, campanafin);
                                
        }

        /// <summary>
        /// Lista el reporte de estados de las empresarias x campaña.
        /// </summary>
        /// <param name="IdEstado"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEstadosEmpresariasxCampana(int IdEstado, string Campana)
        {
            return module.ListEstadosEmpresariasxCampana(IdEstado, Campana);
        }


         /// <summary>
        /// Lista todas los datos de las zonas por divional y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxDivisionalYCampana(String divisional, String campana)
        {
            return module.traerDatosZonasxDivisionalYCampana(divisional, campana);
        }

        

         #region COSAS DE LA MATRIZ VIEJA FEA
        /// <summary>
        /// Lista las nuevas que fueron prospecto
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> NuevasProspecto(string campana)
        {
            return module.NuevasProspecto(campana);
        }

        /// <summary>
        /// Lista las nuevas que fueron referido
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> NuevasReferido(string campana)
        {

            return module.NuevasReferido(campana);

        }


         /// <summary>
        /// Lista las nuevas que fueron 18 campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> Nuevas18Campana(string campana)
        {

            return module.Nuevas18Campana(campana);

        }
        
        /// <summary>
        /// Lista las nuevas 
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> Nuevas(string campana)
        {
            return module.Nuevas(campana);
        }
        

        #endregion

    }
}
