using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ZonaxCiudad
    /// </summary>
    public class ZonaxCiudad : IZonaxCiudad
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ZonaxCiudad module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ZonaxCiudad()
        {
            module = new Application.Enterprise.Data.ZonaxCiudad();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ZonaxCiudad(string databaseName)
        {
            module = new Application.Enterprise.Data.ZonaxCiudad(databaseName);
        }

        #region Miembros de IZonaxCiudad
        /// <summary>
        /// Lista todos las zonas y ciudades existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todas las ciudades de una zona especifica.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }

        
        /// <summary>
        /// Lista todas las ciudades de una zona especifica de las tablas de G&G.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZonaGYG(string Zona)
        {
            return module.ListxZonaGYG(Zona);
        }

        /// <summary>
        /// Lista todas las ciudades de un departamento especifico con tablas de G&G.
        /// </summary>
        /// <param name="IdDepto"></param>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZonaGYGxDepartamento(string IdDepto, string IdZona)
        {
            return module.ListxZonaGYGxDepartamento(IdDepto, IdZona);
        }

        public List<ZonaxCiudadInfo> ListxZonaGYGxDepartamentoTodos(string IdDepto)
        {
            return module.ListxZonaGYGxDepartamentoTodos(IdDepto);
        }
        /******************GAVL******************************/
        /// <summary>
        /// Lista todas las Zonas Con ciudades con tablas de G&G.
        /// </summary>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZonaGYG()
        {
            return module.ListZonaGYG();
        }

        public bool InsertZonaXCiudad( ZonaxCiudadInfo item)
        {
            return module.InsertZonaxCiudad (item);
        }


        #endregion
    }
}
