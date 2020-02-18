using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;

namespace Application.Enterprise.Business
{
    public class PremiosSVDN : IPremiosSVDN
    {
         /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosSVDN module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosSVDN()
        {
            module = new Application.Enterprise.Data.PremiosSVDN();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosSVDN(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosSVDN(databaseName);
        }

       /// <summary>
        /// Calcula el premio
       /// </summary>
       /// <param name="pedido"></param>
       /// <returns></returns>
        public bool ganarPremio(string pedido)
        {
            return module.ganarPremio(pedido);
        }

      /// <summary>
        ///  Inserta el premio en el pedido
      /// </summary>
      /// <param name="pedido"></param>
      /// <returns></returns>
        public bool insertarPremio(string pedido)
        {
            return module.insertarPremio(pedido);
        }
    }
}
