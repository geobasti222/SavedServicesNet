using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class TopMenos20 : ITopMenos20
    {
          private Application.Enterprise.Data.TopMenos20 module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TopMenos20()
        {
            module = new Application.Enterprise.Data.TopMenos20();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TopMenos20(string databaseName)
        {
            module = new Application.Enterprise.Data.TopMenos20(databaseName);
        }

       

        public List<Topmenos20Info> lista()
        {
            return module.lista(); 
        }





        #region Miembros de ISustitutosEncabezados

        public List<Topmenos20Info> Lista()
        {
            return module.lista(); 
        }



        #endregion


    }
}
