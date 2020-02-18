using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PuntosSavedInfo
    {
        public virtual string NumeroPedido
        {
            get;
            set;
        }

        public virtual string Nit
        {
            get;
            set;
        }

        public virtual string Campana
        {
            get;
            set;
        }

        public virtual string Tipo
        {
            get;
            set;
        }

        public virtual int Cantidad
        {
            get;
            set;
        }

        public virtual string Movimiento
        {
            get;
            set;
        }

        public virtual int Procesado
        {
            get;
            set;
        }


        public virtual string Usuario
        {
            get;
            set;
        }



    }
}
