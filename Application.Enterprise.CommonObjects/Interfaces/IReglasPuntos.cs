using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IReglasPuntos
    {
        /// <summary>
        /// Lista todos las reglas existentes
        /// </summary>
        /// <returns></returns>
        List<ReglaPuntoInfo> List();

        /// <summary>
        /// Inserta los datos del reglas puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool Insert(ReglaPuntoInfo item, string Usuario);

        /// <summary>
        /// lista todos las reglas puntos existentes
        /// </summary>
        /// <returns></returns>
        List<ReglaPuntoInfo> ListxCampana(string campana);

        /// <summary>
        /// lista uno las reglas puntos existentes por campana order by idxcampana desc
        /// </summary>
        /// <returns></returns>
        ReglaPuntoInfo ListUnoxCampana(string campana);

        /// <summary>
        /// Prcesa los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool PorcesoPuntos(string campana, string numero);
        
       
        /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerMisPuntos(String nit);
        
        // <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerMisPuntosTotal(String nit);

        /// <summary>
        /// Anula los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool AnularPuntos( string numero);
        
        
        /// <summary>
        /// Motor de los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        void MotorPuntos(string campana);

        /// <summary>
        /// lista por una campaña especifica.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>

        CampanaInfo ListxCampana();


        /// <summary>
        /// borra una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
         bool DeleteReglas(int id, string Usuario);


        /// <summary>
        ///  acutaliza una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
         bool UpdateEstadoReglas(int id, string Usuario, bool estado);

        /// <summary>
        /// lista uno las reglas puntos existentes por campana order by idxcampana desc
        /// </summary>
        /// <returns></returns>
         ReglaPuntoInfo ListUnoxidCampana(string campana, string id);
        
         /// <summary>
        /// Prcesa los puntos para el 90% nivel servicio
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
         bool PorcesoPuntos90(string numero);
        
        /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
         PuntosTotalEmpreInfo traerMisPuntosTotalEmp(String nit);
         
             
         /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
         DataTable traerMisPuntosCampana(String nit, string campana, string campanafin);
        
           /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
         DataTable traerPuntosEmpresariasGerente(String zona);

        /// <summary>
        /// Guarda estados de la regla puntos
        /// </summary>
        /// <param name="item"></param>
         int Insertestados(EstadosPremiosInfo item, string usuario);

        /// <summary>
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
         ReglaPuntoInfo Reglaconse();
        
        
        
    }
}
