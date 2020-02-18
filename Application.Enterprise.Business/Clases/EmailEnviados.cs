using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class EmailEnviados:IEmailEnviados
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.EmailEnviados module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>

        public EmailEnviados()
        {
            module = new Application.Enterprise.Data.EmailEnviados();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public EmailEnviados(string databaseName)
        {
            module = new Application.Enterprise.Data.EmailEnviados(databaseName);
        }

        public List<EmailEnviadosInfo> List()
        {
            return module.List();
        }

        public List<EmailEnviadosInfo> ListXFechaMensaje(DateTime fecha, string mensajecod)
        {
            return module.ListXFechaMensaje(fecha, mensajecod);
        }

        /// <summary>
        /// Insertar un cliente smtp
        /// </summary>
        /// <returns></returns>
        public bool Insert(EmailEnviadosInfo item)
        {
            return module.Insert(item);
        }

        /// <summary>
        /// Actualizar un cliente smtp
        /// </summary>
        /// <returns></returns>
        public bool Update(EmailEnviadosInfo item)
        {
            return module.Update(item);
        }
    }
}
