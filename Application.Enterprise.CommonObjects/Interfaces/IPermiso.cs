using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{



    public interface IPermiso
    {
        #region "Metodos de IPermiso"

         /// <summary>
        /// lista todos las funciones de un usuario en un formulario
        /// </summary>
        /// <returns></returns>
        List<PermisoInfo> FUncionesXusuarioXFormulario(string usuario, string formulario);
        


        #endregion
    }
}
