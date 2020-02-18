using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para cliente
    /// </summary>
    public class Cliente : ICliente
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Cliente module;
        private Application.Enterprise.Data.ValidaClienteIquitos moduleperu; //GAVL VALIDACION DE INSERCION PARA PERU IQUITOS

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Cliente()
        {
            module = new Application.Enterprise.Data.Cliente();

        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Cliente(string databaseName)
        {
            module = new Application.Enterprise.Data.Cliente(databaseName);
        }

        #region Miembros de ICliente
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista un cliente especifico por nit.
        /// </summary>
        /// <returns></returns>
        public ClienteInfo ListxNIT(string nit)
        {
            return module.ListxNIT(nit);
        }

        /// <summary>
        /// lista un Cliente de SVDN especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteSVDNxNit(string Nit)
        {
            return module.ListClienteSVDNxNit(Nit);
        }

        public bool RegistrarEmpresaria(ClienteInfo item)
        {
            bool okTrans = false;

            try
            {
                ///SE COMENTO POR QUE ESTO HACE LA VALIDACION DE LOS SECTORES AUTOMATICO SI UN CLIENTE NO TIENE.
                ///COMO SE AGREGARON NUEVOS COMBOS DE FUNCIONALIDAD DE REGIONAL,ZONA , CIUDAD , BARRIO, SECTOR SE HACE EL INSERT DEIRECTO.
                ////Application.Enterprise.Business.Sector moduleSector = new Application.Enterprise.Business.Sector();
                ////List<SectorInfo> listaSector = moduleSector.ListxCiudad(item.CodCiudad);

                ////if (listaSector != null && listaSector.Count > 0)
                ////{
                ////    //Valida si el sector es unico se asigna automaticamente la zona.
                ////    if (listaSector.Count == 1)
                ////    {
                ////        Application.Enterprise.Business.SectorZona moduleSectorZona = new Application.Enterprise.Business.SectorZona();
                ////        List<SectorZonaInfo> listaSectorZona = moduleSectorZona.ListxSector(listaSector[0].CodSector);

                ////        item.Zona = listaSectorZona[0].Zona;
                ////        item.CodSector = listaSectorZona[0].CodSector;

                ////        Application.Enterprise.Business.Vendedor moduleVendedor = new Application.Enterprise.Business.Vendedor();
                ////        List<VendedorInfo> listaVendedor = moduleVendedor.ListxZona(item.Zona);

                ////        //Valida si existe un vendedor activo para asignar.
                ////        if (listaVendedor != null && listaVendedor.Count > 0)
                ////        {
                ////            item.Vendedor = listaVendedor[0].IdVendedor;
                ////        }
                ////        else
                ////        {
                ////            item.Vendedor = "9999";//TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////        }
                ////    }
                ////    else
                ////    {
                ////        if (item.Zona == null && item.Vendedor == null && item.CodSector == null)
                ////        {
                ////            item.Zona = "9999";//TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////            item.Vendedor = "9999";//TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////            item.CodSector = "9999999"; //TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////        }
                ////    }
                ////}
                ////else
                ////{
                ////    item.Zona = "9999";//TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////    item.Vendedor = "9999";//TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////    item.CodSector = "9999999"; //TODO: CAMBIAR ESTE VALOR QUEMADO EN EL CODIGO: 9999 SIN ASIGNAR
                ////}

                okTrans = module.RegistrarEmpresaria(item);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            return okTrans;

        }

        /// <summary>
        /// Realiza el registro de una empresaria de peru.
        /// </summary>
        /// <param name="item"></param>
        public bool RegistrarEmpresariaPeru(ClienteInfo item)
        {
            bool okTrans = false;
            bool resultado = false;


            moduleperu = new Application.Enterprise.Data.ValidaClienteIquitos(); //GAVL VALIDACION DE INSERCION PARA PERU IQUITOS
            try
            {
                okTrans = module.RegistrarEmpresariaPeru(item);

                //INICIO GAVL REGITRO DE EMPRESARIAS IQUITOS
                if (okTrans)
                {
                    resultado = moduleperu.ValidaClientesIquitos(item.Vendedor.ToString(), item.Zona.ToString(), item.CodCiudad.ToString(), item.Nit.ToString());

                    if (resultado)
                    {
                        okTrans = moduleperu.RegistrarEmpresariaPeru(item.Nit, item.Usuario);

                    }
                }
                //FIN GAVL 
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            return okTrans;
        }

        /// <summary>
        /// lista las empresarias con un estado de cliente.
        /// </summary>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListxEstadosCliente(int EstadoCliente)
        {
            return module.ListxEstadosCliente(EstadoCliente);
        }

        public List<ClienteInfo> getClienteactualinfo(string cedula)
        {
            //*return module.getClienteactualinfo(cedula);
            return null;
        }

        public bool actulizarDatosPersonales(string cedula, string celular, string direccion, string direccionenvio,  string email) {

            //*return module.actulizarDatosPersonales(cedula, celular, direccion, direccionenvio, email);
            return false;
        }
        

        /// <summary>
        ///  Realiza la aprobacion de una empresaria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresaria(ClienteInfo item)
        {
            try
            {
                return module.AprobarEmpresaria(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }

        }

        /// <summary>
        /// Eliminar una Empresaria del sistema.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public bool BorrarEmpresaria(string nit)
        {
            //TODO: Implelementar
            return false;
        }

        /// <summary>
        /// lista todas las empresarias.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListTodasEmpresarias()
        {
            return module.ListTodasEmpresarias();
        }

        /// <summary>
        /// lista un cliente especifico por nit para un encabezado de pedido.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxEncabezadoPedido(string nit)
        {
            return module.ListxNITxEncabezadoPedido(nit);
        }

        /// <summary>
        /// lista las empresarias de una gerente de zona.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerente(string IdVendedor)
        {
            return module.ListEmpresariasxGerente(IdVendedor);
        }

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLider(string IdLider)
        {
            return module.ListEmpresariasxLider(IdLider);
        }

        /// <summary>
        /// Lista la direccion y telefono principal de una empresaria.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListTelefonoDireccionxNIT(string nit)
        {
            return module.ListTelefonoDireccionxNIT(nit);
        }

        /// <summary>
        /// Realiza la actualizacion de direccion y telefono de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarDireccionTelefono(ClienteInfo item)
        {
            try
            {
                return module.ActualizarDireccionTelefono(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// GAVL SE AGREGA NUEVO PROCEDIMIENTO PARA ACTUALIZAR CLIENTE DE IQUITOS 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool ActualizarDireccionTelefonoPeru(ClienteInfo item)
        {
            bool okTrans = false;
            //bool resultado = false;
            moduleperu = new Application.Enterprise.Data.ValidaClienteIquitos(); //GAVL VALIDACION DE INSERCION PARA PERU IQUITOS
            try
            {
                okTrans = module.ActualizarDireccionTelefono(item);
                //if (okTrans)
                //{
                //    resultado = moduleperu.ActualizarDireccionTelefonoIquito(item);
                //    if (resultado)
                //    {
                //        okTrans = resultado;
                //    }   
                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
            return okTrans;
        }

        /// <summary>
        /// Realiza la actualizacion del estado de migracion del cliente a produccion en la BD de Nivi y MKT.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateClienteEnProduccion(string Nit, bool EnProduccion)
        {
            try
            {
                return module.UpdateClienteEnProduccion(Nit, EnProduccion);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de la zona de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool UpdateZona(string Nit, string Zona)
        {
            try
            {
                return module.UpdateZona(Nit, Zona);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }
        /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateCliente(ClienteInfo item)
        {
            try
            {
                return module.UpdateCliente(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de una empresaria en Peru.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateClientePeru(ClienteInfo item)
        {
            bool oktrans = false;
            // bool resultado = false;
            moduleperu = new Application.Enterprise.Data.ValidaClienteIquitos(); //GAVL VALIDACION DE INSERCION PARA PERU IQUITOS
            try
            {
                oktrans = module.UpdateClientePeru(item);
                //INICIO GAVL ACTUALIZACION DE EMPRESARIAS IQUITOS
                //if (oktrans)
                //{
                //    resultado = moduleperu.UpdateClientePeruIquitos(item);
                //    if (resultado)
                //    {
                //        oktrans = resultado;
                //    }
                //}
                //FIN GAVL
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
            return oktrans;
        }


        /// <summary>
        /// Este es igual al Update "A" pero se le agrega vendedor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AprobarEmpresariaConVendedor(ClienteInfo item)
        {
            try
            {
                return module.AprobarEmpresariaConVendedor(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        public bool UpdateEstadoCliente(string Nit, int EstadoCliente)
        {
            try
            {
                return module.UpdateEstadoCliente(Nit, EstadoCliente);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de la aceptacion de terminos y condiciones.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateAceptoTerminosyCondiciones(ClienteInfo objClienteInfo)
        {
            try
            {
                return module.UpdateAceptoTerminosyCondiciones(objClienteInfo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del email de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateEmailCliente(ClienteInfo objClienteInfo)
        {
            try
            {
                return module.UpdateEmailCliente(objClienteInfo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de la asignacion de premio de bienvenida.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateEstadoPremioCliente(string Nit)
        {
            try
            {
                return module.UpdateEstadoPremioCliente(Nit);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// GAVL Realiza la actualizacion del estado del cliente  
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateClienteEstado(string Nit, int EstadoCliente, string Usuario)
        {
            try
            {
                return module.UpdateClienteEstado(Nit, EstadoCliente, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        ///  Realiza la aprobacion de CCN de una empresaria en Peru.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresariaProspectoPeru(ClienteInfo item)
        {
            try
            {
                return module.AprobarEmpresariaProspectoPeru(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }

        }

        /// <summary>
        /// Realiza la actualizacion de ciudad de despacho una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarCiudadDespacho(ClienteInfo item)
        {
            try
            {
                return module.ActualizarCiudadDespacho(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// Realiza la actualizacion de la red de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdLider"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateModificarRed(string Nit, string IdLider, string Usuario)
        {
            try
            {
                return module.UpdateModificarRed(Nit, IdLider, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de una empresaria si es del plan privilegio o no.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoPrivilegio"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateEstadoPrivilegio(string Nit, bool EstadoPrivilegio, string Usuario)
        {
            try
            {
                return module.UpdateEstadoPrivilegio(Nit, EstadoPrivilegio, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de Nivi en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDNivi(ClienteInfo item)
        {
            try
            {
                return module.InsertClienteBDNivi(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de MKT en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDMkt(ClienteInfo item)
        {
            try
            {
                return module.InsertClienteBDMkt(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de SVDN para iniciar el procesamiento.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDSVDN(ClienteInfo item)
        {
            try
            {
                return module.InsertClienteBDSVDN(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// lista todos los Clientes de SVDN existentes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListClientesSVDN()
        {
            return module.ListClientesSVDN();
        }

        /// <summary>
        /// lista un Cliente de nivi especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteNivixNit(string Nit)
        {
            return module.ListClienteNivixNit(Nit);
        }

        /// <summary>
        /// lista un Cliente de MKT especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteMktxNit(string Nit)
        {
            return module.ListClienteMktxNit(Nit);
        }

        /// <summary>
        /// Lista los clientes de una zona especifica.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxZona(string IdZona)
        {
            return module.ListEmpresariasxZona(IdZona);
        }

        /// <summary>
        /// Lista los clientes de una zona especifica con privilegio.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxZonaPrivilegio(string IdZona)
        {
            return module.ListEmpresariasxZonaPrivilegio(IdZona);
        }

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimple(string nit)
        {
            return module.ListxNITSimple(nit);
        }

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimple(string IdVendedor)
        {
            return module.ListEmpresariasxGerenteSimple(IdVendedor);
        }

     

        /// <summary>
        /// Lista las empresarias de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteRegional(string CodigoRegional)
        {
            return module.ListEmpresariasxGerenteRegional(CodigoRegional);
        }


        /// <summary>
        /// listado de clientes de bienvenida.
        /// </summary>
        /// <param name="FechaIngreso"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListClienteBienvenida(DateTime FechaIngreso)
        {
            return module.ListClienteBienvenida(FechaIngreso);
        }

        /// <summary>
        /// Lista el listado de clientes por estado egreso.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoEgreso(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoEgreso(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Nuevas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoNuevas(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoNuevas(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresos(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoPosiblesEgresos(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista la consecutividad de campañas de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<string> ListConsecutividadCliente(string Nit)
        {
            return module.ListConsecutividadCliente(Nit);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Activas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoActivas(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoActivas(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista los clientes con estado prospecto
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListClientesProspecto()
        {
            return module.ListClientesProspecto();
        }


        /// <summary>
        /// Lista el listado de clientes por estado egreso para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoEgresoRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoEgresoRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado nuevas para regionales.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoNuevasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoNuevasRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresosRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoPosiblesEgresosRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Activas para regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoActivasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoActivasRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista todos los nit y estados de las empresarias que no hayan generado pedido en la campaña anterior a la actual
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariaSinPedido()
        {
            return module.ListEmpresariaSinPedido();
        }

        public List<ClienteInfo> ListInformacionEmpresarias(string cedula)
        {
            return module.ListInformacionEmpresarias(cedula);
        }

        public List<ClienteInfo> ListEmpresariasInactivasXCampana(string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasInactivasXCampana(Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// lista las empresarias prospecto de la zona 9106
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasProspectoVPN()
        {
            return module.ListEmpresariasProspectoVPN();
        }

        /// <summary>
        /// Lista las empresarias Inactivas de acuerdo a una campaña especifica - Para gerentes divisionales
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasInactivasXCampanaDivisional(string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasInactivasXCampanaDivisional(Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista si el cliente debe ver los terminos y condiciones de la plataforma.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo MostrarTerminosyCondiciones(string nit)
        {
            return module.MostrarTerminosyCondiciones(nit);
        }

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado para editar.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimpleEdit(string nit)
        {
            return module.ListxNITSimpleEdit(nit);
        }

        /// <summary>
        /// Lista si una empresaria corresponde a un lider.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="idlider"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxLider(string nit, string idlider)
        {
            return module.ListxNITxLider(nit, idlider);
        }

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado para editar.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimpleEditEc(string nit)
        {
            return module.ListxNITSimpleEditEc(nit);
        }

        /// <summary>
        /// Lista las empresarias de una gerente que pertenece a una zona maestra.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimpleZonaMaestra(string Zona)
        {
            return module.ListEmpresariasxGerenteSimpleZonaMaestra(Zona);
        }

        /// <summary>
        /// Lista todos los estados de los clientes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEstadosEmpresarias()
        {
            return module.ListEstadosEmpresarias();
        }

        /// <summary>
        /// Lista el reporte de estados de las empresarias x campaña.
        /// </summary>
        /// <param name="IdEstado"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEstadosEmpresariasxCampana(int IdEstado, string Campana)
        {
            return module.ListEstadosEmpresariasxCampana(IdEstado, Campana);
        }

        #endregion

        #region Metodos del Buscador

        /// <summary>
        ///  Mapeo de los criterios de busqueda seleccionados por el usuario con los campos originales de la base de datos
        /// </summary>
        /// <param name="language">Idioma</param>
        /// <returns>Lista de mapero para el buscador</returns>
        public TableMapping SearchMapping(string language)
        {
            return module.SearchMapping(language);

        }

        /// <summary>
        /// Consulta las empresarias existentes.
        /// </summary>
        /// <param name="lstItem">lista de condiciones a buscar.</param>
        /// <returns>resultado de las empresarias encontrados.</returns>
        public List<ClienteInfo> ListSearch(List<SearchCondition> lstItem)
        {
            string filter = SearchCondition.GetFilterQueryList(lstItem);
            return module.ListSearch(filter);
        }

        #endregion

        #region DESMANTELADORAS

        /// <summary>
        /// List cliente que sea demanteladora para cambiar estado del pedido
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool BuscaDemanteladora(string Nit, string Zona)
        {
            bool okTrans = false;

            try
            {
                okTrans = module.BuscaDemanteladora(Nit, Zona);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            return okTrans;
        }
        #endregion

        #region ASISTENTES
        /// <summary>
        /// GAVL Lista las empresarias de un asistente
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxAsistente(string CodigoRegional)
        {
            return module.ListEmpresariasxAsistente(CodigoRegional);
        }
        #endregion

        /// <summary>
        /// Realiza el pre-registro de una empresaria
        /// </summary>
        /// <param name="item"></param>
        public bool ReenvioSolicitud(string nit, string usu)
        {
            //*return module.ReenvioSolicitud(nit, usu);
            return false;
        }


         /// <summary>
        /// consulta informe cartera y estado comercial
        /// </summary>
        /// <param name="item"></param>
        public List<ClienteInfo> InformeCarteraComercial(string estado, string campana)
        {
            //*return module.InformeCarteraComercial(estado, campana);
            return null;
        }

        /// <summary>
        /// Mira el saldo de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ClienteSaldo(string Nit)
        {
            //*return module.ClienteSaldo(Nit);
            return null;
        }


        /// <summary>
        /// lista un Cliente de SVDN especifico por nit. de norte para la regla de 50000
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteNORTE(string Nit)
        {
            //*return module.ListClienteNORTE(Nit);
            return null;
        }

         /// <summary>
        /// lista cliente para mirar su tipo envio
        /// </summary>
        /// <returns></returns>
        public ClienteInfo ClienteTipoEnvio(string nit)
        {
            //*return module.ClienteTipoEnvio(nit);
            return null;
        }


        /// Mira el saldo de un cliente 50 mil anticipo
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ClienteSaldo50Mil(string Nit)
        {
            //*return module.ClienteSaldo50Mil(Nit);
            return null;
        }


        public ClienteInfo ListClienteSVDNxNitxVendedorxLider(string Nit, string IdVendedor, string IdLider)
        {
            return module.ListClienteSVDNxNitxVendedorxLider(Nit, IdVendedor, IdLider);
        }

    }
}
