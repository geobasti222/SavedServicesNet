using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class DevolucionesInfo
    {
        private string nit;

        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }
        private string campana;

        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }
        private string ped_numero;

        public string PedNumero
        {
            get { return ped_numero; }
            set { ped_numero = value; }
        }
        private string fac_numero;

        public string FacNumero
        {
            get { return fac_numero; }
            set { fac_numero = value; }
        }
        private string dev_numero;

        public string DevNumero
        {
            get { return dev_numero; }
            set { dev_numero = value; }
        }
        private DateTime dev_fecha;

        public DateTime DevFecha
        {
            get { return dev_fecha; }
            set { dev_fecha = value; }
        }
        private int dev_anulado;

        public int DevAnulado
        {
            get { return dev_anulado; }
            set { dev_anulado = value; }
        }
    }
}
