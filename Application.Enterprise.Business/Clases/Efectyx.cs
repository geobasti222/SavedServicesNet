using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;

namespace Application.Enterprise.Business
{
    public class Efectyx : IEfectyx
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Efectyx module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Efectyx()
        {
            module = new Application.Enterprise.Data.Efectyx();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Efectyx(string databaseName)
        {
            module = new Application.Enterprise.Data.Efectyx(databaseName);
        }

        /// <summary>
        /// Inserta los datos del amarrado
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public DataTable traerCarteraSaldos()
        {
            return module.traerCarteraSaldos();
        }


         /// <summary>
        /// Traer llos totales linea 03
        /// </summary>
        /// <returns></returns>
        public DataTable traerTotales()
        {
            return module.traerTotales();
        }
    }
}
