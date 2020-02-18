using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para SustitutosDetalle
    /// </summary>
    public class Sustitutos : ISustitutos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Sustitutos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Sustitutos()
        {
            module = new Application.Enterprise.Data.Sustitutos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Sustitutos(string databaseName)
        {
            module = new Application.Enterprise.Data.Sustitutos(databaseName);
        }

        /*

        public List<Topmenos20Info> ListaTopMenos20()
        {
            return module.ListaTopMenos20(); 
        }*/





        #region Miembros de ISustitutosEncabezados

        public List<SustitutosInfo> Lista(string Referencia, string Catalogo)
        {
            return module.Lista(Referencia, Catalogo);
        }



        #endregion
    }
}
