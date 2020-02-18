using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Permiso JA
    /// </summary>
    public class Permiso : IPermiso
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Permiso module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Permiso()
        {
            module = new Application.Enterprise.Data.Permiso();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Permiso(string databaseName)
        {
            module = new Application.Enterprise.Data.Permiso(databaseName);
        }


         /// <summary>
        /// lista todos las funciones de un usuario en un formulario
        /// </summary>
        /// <returns></returns>
        public List<PermisoInfo> FUncionesXusuarioXFormulario(string usuario, string formulario)
        {
            return module.FUncionesXusuarioXFormulario(usuario, formulario);
        }
    }
}
