using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;

namespace Application.Enterprise.Business
{
    public class Mezcla : IMezcla
    {
         /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Mezclas module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Mezcla()
        {
            module = new Application.Enterprise.Data.Mezclas();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Mezcla(string databaseName)
        {
            module = new Application.Enterprise.Data.Mezclas(databaseName);
        }


        /// <summary>
        /// Traer las traerClaseVenta completas
        /// </summary>
        /// <returns></returns>
        public DataTable traerClaseVenta()
        {
            return module.traerClaseVenta();
        }
    }
}
