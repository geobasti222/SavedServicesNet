using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IEmailEnviados
    {
        #region "Metodos de email enviados"

        /// <summary>
        /// lista todos los email enviados
        /// </summary>
        /// <returns></returns>
        List<EmailEnviadosInfo> List();

        /// <summary>
        /// Trae email enviados por fecha y mensaje
        /// </summary>
        /// <returns></returns>
        List<EmailEnviadosInfo> ListXFechaMensaje(DateTime fecha, string mensajecod);

        /// <summary>
        /// Insertar un email enviado
        /// </summary>
        /// <returns></returns>
        bool Insert(EmailEnviadosInfo item);

        /// <summary>
        /// Actualizar un email enviado
        /// </summary>
        /// <returns></returns>
        bool Update(EmailEnviadosInfo item);

        #endregion
    }
}
