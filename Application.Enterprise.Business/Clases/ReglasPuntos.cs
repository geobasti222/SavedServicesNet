using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;

namespace Application.Enterprise.Business
{
    public class ReglasPuntos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglaPuntos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasPuntos()
        {
            module = new Application.Enterprise.Data.ReglaPuntos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasPuntos(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglaPuntos(databaseName);
        }

        /// <summary>
        /// Inserta los datos del amarrado
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<ReglaPuntoInfo> List(string campana)
        {
            return module.List(campana);
        }

        /// <summary>
        /// Inserta los datos del reglas puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Insert(ReglaPuntoInfo item, string Usuario)
        {
            return module.Insert(item, Usuario);
        }

        /// <summary>
        /// lista todos las reglas puntos existentes
        /// </summary>
        /// <returns></returns>
        public List<ReglaPuntoInfo> ListxCampana(string campana)
        {
            return module.ListxCampana(campana);
        }

        /// <summary>
        /// lista uno las reglas puntos existentes por campana order by idxcampana desc
        /// </summary>
        /// <returns></returns>
        public ReglaPuntoInfo ListUnoxCampana(string campana)
        {
            return module.ListUnoxCampana(campana);
        }

        /// <summary>
        /// Prcesa los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool PorcesoPuntos(string campana, string numero)
        {
            return module.PorcesoPuntos(campana, numero);
        }

        // <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerMisPuntos(String nit) {
            return module.traerMisPuntos(nit);
        }

        // <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerMisPuntosTotal(String nit)
        {
            return module.traerMisPuntosTotal(nit);
        }

        /// <summary>
        /// Anula los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool AnularPuntos( string numero)
        {
            return module.AnularPuntos( numero);
        }

        /// <summary>
        /// Motor de los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public void MotorPuntos(string campana)
        {
            module.MotorPuntos(campana);
        }

        /// <summary>
        /// lista por una campaña especifica.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public CampanaInfo ListxCampana()
        {
            return module.ListxCampana();
        }

        /// <summary>
        /// borra una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteReglas(int id, string Usuario) {
            return module.DeleteReglas(id, Usuario);
        }


        /// <summary>
        ///  acutaliza una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateEstadoReglas(int id, string Usuario, int estado) {
            return module.UpdateEstadoReglas(id, Usuario, estado);
        }


        /// <summary>
        /// lista uno las reglas puntos existentes por campana order by idxcampana desc
        /// </summary>
        /// <returns></returns>
        public ReglaPuntoInfo ListUnoxidCampana(string campana, string id)
        {
            return module.ListUnoxidCampana(campana, id);
        }


         /// <summary>
        /// Prcesa los puntos para el 90% nivel servicio
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool PorcesoPuntos90(string numero)
        {
            return module.PorcesoPuntos90(numero);
        }


        /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public PuntosTotalEmpreInfo traerMisPuntosTotalEmp(String nit)
        {
            return module.traerMisPuntosTotalEmp(nit);
        }


        /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerMisPuntosCampana(String nit, string campana, string campanafin)
        {
            return module.traerMisPuntosCampana(nit, campana, campanafin);
        }

        /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerPuntosEmpresariasGerente(String zona)
        {
            return module.traerPuntosEmpresariasGerente(zona);
        }


        /// <summary>
        /// Guarda estados de la regla puntos
        /// </summary>
        /// <param name="item"></param>
        public int Insertestados(EstadosPremiosInfo item, string usuario)
        {
            return module.Insertestados(item, usuario);
        }


        /// <summary>
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
        public ReglaPuntoInfo Reglaconse()
        {
            return module.Reglaconse();
        }
    }
}
