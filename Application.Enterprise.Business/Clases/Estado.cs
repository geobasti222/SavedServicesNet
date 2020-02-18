using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para estado
    /// </summary>
    public class Estado : IEstado
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Estado module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Estado()
        {
            module = new Application.Enterprise.Data.Estado();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Estado(string databaseName)
        {
            module = new Application.Enterprise.Data.Estado(databaseName);
        }

        #region Miembros de IEstado
        /// <summary>
        /// lista todos los Estados existentes.
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista todos los Estados existentes por codigo de pais.
        /// </summary>
        /// <param name="CodPais"></param>
        /// <returns></returns>
        public List<EstadoInfo> ListByPais(string CodPais)
        {
            return module.ListByPais(CodPais);
        }


        public List<EstadoInfo> ListF()
        {
            return module.ListF(); 
        }

        public List<EstadoInfo> ListOrdenada()
        {
            return module.ListOrdenada();
        }

            /// <summary>
        ///Lista todos los departamentos de una zona especifica.
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> ListDepartamentosxZona(string IdZona)
        {
            return module.ListDepartamentosxZona(IdZona);
        }


        /// <summary>
        /// GAVL Lista Estados por Estado
        /// </summary>
        /// <param name="codestado"></param>
        /// <returns></returns>
        public EstadoInfo ListXEstado(string codestado)
        {
            return module.ListXEstado(codestado);
        }

         /// <summary>
        /// Lista los departamentos x ciudad
        /// </summary>
        /// <param name="codestado"></param>
        /// <returns></returns>
        public EstadoInfo ListDeptoxCiudad(string codestado)
        {
            return module.ListDeptoxCiudad(codestado);
        }

        #endregion


    }
}
