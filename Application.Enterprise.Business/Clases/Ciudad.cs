using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ciudad
    /// </summary>
    public class Ciudad : ICiudad
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Ciudad module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Ciudad()
        {
            module = new Application.Enterprise.Data.Ciudad();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Ciudad(string databaseName)
        {
            module = new Application.Enterprise.Data.Ciudad(databaseName);
        }
        
        #region Miembros de ICiudad
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CiudadInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista todas las ciudades existentes por codigo de departamento.
        /// </summary>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        public List<CiudadInfo> ListByEstado(string CodEstado)
        {
            return module.ListByEstado(CodEstado);
        }

        /// <summary>
        /// lista todas las ciudades existentes por codigo de departamento.
        /// </summary>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        public List<CiudadInfo> ListByCanton(string CodCanton, string codprovincia)
        {
            return module.ListByCanton(CodCanton, codprovincia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public ZonadeCiudadInfo ZonadeCiudad(string Ciudad)
        {
            return module.ZonadeCiudad(Ciudad);
        }

        /// <summary>
        /// lista una ciudad por codigo.
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public CiudadInfo ListxCodCiudad(string CodCiudad)
        {
            return module.ListxCodCiudad(CodCiudad);
        }

        /// <summary>
        /// Lista todas las ciudades que tengan relacionadas un estado
        /// </summary>
        /// <returns></returns>
        public List<CiudadInfo> ListCiudadesConEstado(string CodEstado)
        {
            return module.ListCiudadesConEstado(CodEstado);
        }

        /// <summary>
        /// Lista una ciudad especifica x codigo.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public CiudadInfo ListCiudadxId(string CodCiudad)
        {
            return module.ListCiudadxId(CodCiudad);
        }


        /// <summary>
        /// Lista una ciudad especifica x codigo. para sacar el pedidomin
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public CiudadInfo ListCiudadxIdPedMin(string CodCiudad)
        {
            return module.ListCiudadxIdPedMin(CodCiudad);
        }

        #endregion
    }
}
