using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para zona JA
    /// </summary>
    public class Zona : IZona
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Zona module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Zona()
        {
            module = new Application.Enterprise.Data.Zona();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Zona(string databaseName)
        {
            module = new Application.Enterprise.Data.Zona(databaseName);
        }

        #region Miembros de IZona
        /// <summary>
        /// lista todas las Zonas existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista las zonas de un sector.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListxSector(string CodSector)
        {
            return module.ListxSector(CodSector);
        }

        /// <summary>
        /// Lista las zonas de un mailgroup.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListxMailGroup(string MailGroup)
        {
            return module.ListxMailGroup(MailGroup);
        }

        /// <summary>
        /// Lista una zona especifica por id de zona.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public ZonaInfo ListxIdZona(string IdZona)
        {
            return module.ListxIdZona(IdZona);
        }

        /// <summary>
        /// Lista una zona especifica por id de zona con Flete1
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public ZonaPeruInfo ListxIdZonaYFlete1(string IdZona)
        {
            return module.ListxIdZonaYFlete1(IdZona);
        }

        /// <summary>
        /// Lista las zonas de una gerente regional.
        /// </summary>
        /// <param name="Regional"></param>
        /// <returns></returns>
        public List<ZonaInfo> ListxRegional(string Regional)
        {
            return module.ListxRegional(Regional);
        }

        /// <summary>
        /// Lista la informacion completa de todas las zonas existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListxInformacionZonas()
        {
            return module.ListxInformacionZonas();
        }

        /// <summary>
        /// Lista una zona especifica incluyendo zona maestra.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public ZonaInfo ListxIdZonaxZonaMaestra(string IdZona)
        {
            return module.ListxIdZonaxZonaMaestra(IdZona);
        }

        /// <summary>
        /// Realiza la actualizacion del valor del flete de una zona .
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="ValorFlete"></param>
        /// <returns></returns>
        public bool UpdateValorFlete(string Zona, decimal ValorFlete, string Usuario)
        {
            try
            {
                return module.UpdateValorFlete(Zona, ValorFlete, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de los dias borrador, reserva y de gracia.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="DiasBorrador"></param>
        /// <param name="DiasReserva"></param>
        /// <param name="DiasdeGracia"></param>
        /// <returns></returns>
        public bool UpdateDiasBorradoReservaGracia(string Zona, int DiasBorrador, int DiasReserva, int DiasdeGracia, string Usuario)
        {
            try
            {
                return module.UpdateDiasBorradoReservaGracia(Zona, DiasBorrador, DiasReserva, DiasdeGracia, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }



        /// <summary>
        /// Guarda una zona nueva.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(ZonaInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de una zona existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ZonaInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// lista todas las Zonas existentes mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListAll()
        {
            return module.ListAll();
        }

        /// <summary>
        /// Obtiene una zona mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public ZonaInfo ListxZona(string zona)
        {
            return module.ListxZona(zona);
        }

        /// <summary>
        /// Obtiene una lista buscada por vendedor y muestra los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        public List<ZonaInfo> ListxVendedor(string vendedor)
        {
            return module.ListxVendedor(vendedor);
        }

        #endregion


        public ZonaInfo CargarVariablesZona(string IdZona)
        {
            
           ZonaInfo objZonaInfo = new ZonaInfo();

            if (IdZona != null)
            {

                objZonaInfo = module.ListxIdZona(IdZona);

                if (objZonaInfo == null)
                {
                    //este parametro guarda los dias que debe estar vivo el pedido como un borrador o reserva en linea para anularlo.
                    Parametros objParametros = new Parametros("conexion");
                    ParametrosInfo objParametrosInfo = new ParametrosInfo();

                    objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.DiasCierrePedidoBorrador);

                    if (objParametrosInfo != null)
                    {
                        //este parametro guarda los dias que debe estar vivo el pedido como un borrador para anularlo.
                        objZonaInfo.DiasBorrador = Convert.ToInt32(objParametrosInfo.Valor);
                    }

                    objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.DiasCierrePedidoReservado);

                    if (objParametrosInfo != null)
                    {
                        //este parametro guarda los dias que debe estar vivo el pedido como una reserva para hacerle devolucion.
                        objZonaInfo.DiasReserva = Convert.ToInt32(objParametrosInfo.Valor);
                    }

                    objZonaInfo.DiasDeGracia = 1;
                }
            }
            else
            {
               Parametros objParametros = new Parametros("conexion");
               ParametrosInfo objParametrosInfo = new ParametrosInfo();

                objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.DiasCierrePedidoBorrador);

                if (objParametrosInfo != null)
                {
                    //este parametro guarda los dias que debe estar vivo el pedido como un borrador para anularlo.
                    objZonaInfo.DiasBorrador = Convert.ToInt32(objParametrosInfo.Valor);
                }

                objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.DiasCierrePedidoReservado);

                if (objParametrosInfo != null)
                {
                    //este parametro guarda los dias que debe estar vivo el pedido como una reserva para hacerle devolucion.
                    objZonaInfo.DiasReserva = Convert.ToInt32(objParametrosInfo.Valor);
                }

                objZonaInfo.DiasDeGracia = 1;
            }


            return objZonaInfo;
        }
    }
}
