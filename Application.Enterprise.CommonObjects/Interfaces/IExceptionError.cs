using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ExceptionError
    /// </summary>
    public interface IExceptionError
    {
        #region "Metodos de ExceptionError"
       
        bool RegistrarException(ExceptionErrorInfo item);       

        #endregion
    }
}

