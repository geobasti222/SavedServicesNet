using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Net.Mime;
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class Mail : IMail
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Mail module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Mail()
        {
            module = new Application.Enterprise.Data.Mail();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Mail(string databaseName)
        {
            module = new Application.Enterprise.Data.Mail(databaseName);
        }

        #region Miembros de IMail

        /// <summary>
        /// Lista la configuracion para enviar correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SmtpMailInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }

        /// <summary>
        /// Lista la configuracion de un mail por tipo
        /// </summary>
        /// <param name="IdTipoMensaje"></param>
        /// <returns></returns>
        public SmtpMailInfo ListxTipoMensaje(int IdTipoMensaje)
        {
            return module.ListxTipoMensaje(IdTipoMensaje);
        }

        #endregion

        /// <summary>
        /// Configura los parametros de envio de correo.
        /// </summary>
        /// <param name="EmailPara">E-Mail de Destinatario</param>
        /// <returns></returns>
        public SmtpMailInfo ConfigurarParametros(int IdTipoMensaje, string EmailPara, string strUsuario, string strPassword, string NombreEmpresaria, string IdPedido, string ValorPedido)
        {
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            SmtpMailInfo ObjMailInfo = ListxTipoMensaje(IdTipoMensaje);

            //objSmtpMailInfo.EmailPara = ObjMailInfo.EmailPara; 
            objSmtpMailInfo.EmailPara = EmailPara;
            objSmtpMailInfo.EmailParaNivi = ObjMailInfo.EmailParaNivi; //cambiar el email para servicio al cliente cuando se ponga en produccion en la bd.
            objSmtpMailInfo.EmailDesde = ObjMailInfo.EmailDesde;

            if (IdTipoMensaje == (int)TipoMailEnum.Registro)
            {
                objSmtpMailInfo.Asunto = ObjMailInfo.Asunto;
            }
            else if (IdTipoMensaje == (int)TipoMailEnum.Pedido)
            {
                //objSmtpMailInfo.Asunto = ObjMailInfo.Asunto + " No: " + IdPedido;

                PedidosCliente objPedidosCliente = new PedidosCliente("conexion");
                PedidosClienteInfo objPedidosClienteInfo = new PedidosClienteInfo();

                objPedidosClienteInfo = objPedidosCliente.ListPedidoxId(IdPedido);

                //MRG: Corregir por que cuando el pedido se anula se revienta en esta linea por que la consulta no trae los pedidos anulados.
                //objSmtpMailInfo.Asunto = " Campana: " + objPedidosClienteInfo.Campana + " Pedido: " + IdPedido + " Cedula: " + objPedidosClienteInfo.Nit + " Zona: " + objPedidosClienteInfo.Zona + " Gerente: " + objPedidosClienteInfo.Vendedor;

            }
            else if (IdTipoMensaje == (int)TipoMailEnum.RegistroEmpresaria)
            {
                //no hacer nada.
                Cliente objCliente = new Cliente("conexion");
                ClienteInfo objClienteInfo = new ClienteInfo();

                objClienteInfo = objCliente.ListClienteNivixNit(strUsuario);// strUsuario = NIT

                objSmtpMailInfo.Asunto = " Nit: " + objClienteInfo.Nit + " Nombre: " + objClienteInfo.RazonSocial;
            }
            else if (IdTipoMensaje == (int)TipoMailEnum.RecuperacionClave)
            {
                objSmtpMailInfo.EmailPara = EmailPara;
                objSmtpMailInfo.Asunto = "Niviglobal S.A.S - Recuperación de Clave";
            }
            else if (IdTipoMensaje == (int)TipoMailEnum.ErrorNegativos)
            {
                objSmtpMailInfo.EmailPara = EmailPara;
                objSmtpMailInfo.Asunto = "Advertencia: Negativos en Referencias";
            }

            //MRG: Corregir por que cuando el pedido se anula se revienta en esta linea por que la consulta no trae los pedidos anulados.
            //objSmtpMailInfo.CuerpoMsj = CuerpoMensaje(IdTipoMensaje, strUsuario, strPassword, NombreEmpresaria, IdPedido, ValorPedido); //Usuario y password de empresaria a la que se envia el correo.           
            objSmtpMailInfo.ServidorCorreo = ObjMailInfo.ServidorCorreo;
            objSmtpMailInfo.Puerto = ObjMailInfo.Puerto;//*587-465
            objSmtpMailInfo.AutenticacionSSL = ObjMailInfo.AutenticacionSSL;
            objSmtpMailInfo.Usuario = ObjMailInfo.Usuario;
            objSmtpMailInfo.Password = ObjMailInfo.Password;

            return objSmtpMailInfo;
        }

        /// <summary>
        /// Configura los parametros de envio de correo.
        /// </summary>
        /// <param name="EmailPara">E-Mail de Destinatario</param>
        /// <returns></returns>
        public SmtpMailInfo ConfigurarParametrosAuditoriaReserva(AuditoriaReservaInfo objAuditoriaReservaInfo)
        {
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            SmtpMailInfo ObjMailInfo = ListxTipoMensaje((int)TipoMailEnum.ErrorReservaEnLinea);

            objSmtpMailInfo.EmailPara = ObjMailInfo.EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            //objSmtpMailInfo.EmailPara = EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            objSmtpMailInfo.EmailParaNivi = ObjMailInfo.EmailParaNivi; //cambiar el email para servicio al cliente cuando se ponga en produccion en la bd.
            objSmtpMailInfo.EmailDesde = ObjMailInfo.EmailDesde;

            //objSmtpMailInfo.EmailPara = EmailPara;
            objSmtpMailInfo.Asunto = "Advertencia - Error de Pedido Numero: " + objAuditoriaReservaInfo.NumeroPedido;

            objSmtpMailInfo.CuerpoMsj = CargarPlantillaCuerpoErrorPedidoReservaLinea(objAuditoriaReservaInfo);
            objSmtpMailInfo.ServidorCorreo = ObjMailInfo.ServidorCorreo;
            objSmtpMailInfo.Puerto = ObjMailInfo.Puerto;//*587-465
            objSmtpMailInfo.AutenticacionSSL = ObjMailInfo.AutenticacionSSL;
            objSmtpMailInfo.Usuario = ObjMailInfo.Usuario;
            objSmtpMailInfo.Password = ObjMailInfo.Password;

            return objSmtpMailInfo;
        }


        /// <summary>
        /// GAVL  Configuracion de Parametros de mensajes de registros
        /// </summary>
        /// <param name="EmailPara"></param>
        /// <param name="strUsuario"></param>
        /// <returns></returns>
        public SmtpMailInfo ConfigurarParametrosSuprimirRegistros(string EmailPara, string strUsuario, string nit, int opcion)
        {
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            SmtpMailInfo ObjMailInfo = ListxTipoMensaje((int)TipoMailEnum.SuprimirRegistro);

            if (opcion == 1)
            {
                objSmtpMailInfo.EmailPara = "";
                objSmtpMailInfo.EmailParaNivi = EmailPara;
            }
            else
            {
                objSmtpMailInfo.EmailPara = ObjMailInfo.EmailParaNivi;
                objSmtpMailInfo.EmailParaNivi = ObjMailInfo.EmailPara;
            }

            objSmtpMailInfo.EmailDesde = ObjMailInfo.EmailDesde;


            objSmtpMailInfo.Asunto = ObjMailInfo.Asunto;

            objSmtpMailInfo.CuerpoMsj = CargarPlantillaCuerpoSuprimirRegistro(nit, strUsuario);
            objSmtpMailInfo.ServidorCorreo = ObjMailInfo.ServidorCorreo;
            objSmtpMailInfo.Puerto = ObjMailInfo.Puerto;//*587-465
            objSmtpMailInfo.AutenticacionSSL = ObjMailInfo.AutenticacionSSL;
            objSmtpMailInfo.Usuario = ObjMailInfo.Usuario;
            objSmtpMailInfo.Password = ObjMailInfo.Password;

            return objSmtpMailInfo;
        }


        /// <summary>
        /// Configura los parametros de envio de correo.
        /// </summary>
        /// <param name="EmailPara">E-Mail de Destinatario</param>
        /// <returns></returns>
        public SmtpMailInfo ConfigurarParametrosAuditoriaNegativos(AuditoriaNegativosInfo objAuditoriaNegativosInfo)
        {
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            SmtpMailInfo ObjMailInfo = ListxTipoMensaje((int)TipoMailEnum.ErrorNegativos);

            objSmtpMailInfo.EmailPara = ObjMailInfo.EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            //objSmtpMailInfo.EmailPara = EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            objSmtpMailInfo.EmailParaNivi = ObjMailInfo.EmailParaNivi; //cambiar el email para servicio al cliente cuando se ponga en produccion en la bd.
            objSmtpMailInfo.EmailDesde = ObjMailInfo.EmailDesde;

            //objSmtpMailInfo.EmailPara = EmailPara;
            objSmtpMailInfo.Asunto = "Advertencia - Negativos en Referencia: " + objAuditoriaNegativosInfo.Referencia;

            objSmtpMailInfo.CuerpoMsj = CargarPlantillaCuerpoAuditoriaNegativos(objAuditoriaNegativosInfo);
            objSmtpMailInfo.ServidorCorreo = ObjMailInfo.ServidorCorreo;
            objSmtpMailInfo.Puerto = ObjMailInfo.Puerto;//*587-465
            objSmtpMailInfo.AutenticacionSSL = ObjMailInfo.AutenticacionSSL;
            objSmtpMailInfo.Usuario = ObjMailInfo.Usuario;
            objSmtpMailInfo.Password = ObjMailInfo.Password;

            return objSmtpMailInfo;
        }

        /// <summary>
        /// Configura los parametros de envio de correo.
        /// </summary>
        /// <param name="EmailPara">E-Mail de Destinatario</param>
        /// <returns></returns>
        public SmtpMailInfo ConfigurarParametrosAuditoriaPedidos(AuditoriaPedidosInfo objAuditoriaPedidosInfo)
        {
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            SmtpMailInfo ObjMailInfo = ListxTipoMensaje((int)TipoMailEnum.ErrorPedidos);

            objSmtpMailInfo.EmailPara = ObjMailInfo.EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            //objSmtpMailInfo.EmailPara = EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            objSmtpMailInfo.EmailParaNivi = ObjMailInfo.EmailParaNivi; //cambiar el email para servicio al cliente cuando se ponga en produccion en la bd.
            objSmtpMailInfo.EmailDesde = ObjMailInfo.EmailDesde;

            //objSmtpMailInfo.EmailPara = EmailPara;
            objSmtpMailInfo.Asunto = "Advertencia: " + objAuditoriaPedidosInfo.Observacion;

            objSmtpMailInfo.CuerpoMsj = CargarPlantillaCuerpoAuditoriaPedidos(objAuditoriaPedidosInfo);
            objSmtpMailInfo.ServidorCorreo = ObjMailInfo.ServidorCorreo;
            objSmtpMailInfo.Puerto = ObjMailInfo.Puerto;//*587-465
            objSmtpMailInfo.AutenticacionSSL = ObjMailInfo.AutenticacionSSL;
            objSmtpMailInfo.Usuario = ObjMailInfo.Usuario;
            objSmtpMailInfo.Password = ObjMailInfo.Password;

            return objSmtpMailInfo;
        }

        /// <summary>
        /// Configura los parametros de envio de correo.
        /// </summary>
        /// <param name="EmailPara">E-Mail de Destinatario</param>
        /// <returns></returns>
        public SmtpMailInfo ConfigurarParametrosAuditoriaSaldosBodega(List<AuditoriaSaldosBodegaInfo> objAuditoriaSaldosBodegaInfo)
        {
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            SmtpMailInfo ObjMailInfo = ListxTipoMensaje((int)TipoMailEnum.ErrorSaldosBodega);

            objSmtpMailInfo.EmailPara = ObjMailInfo.EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            //objSmtpMailInfo.EmailPara = EmailPara; //cambiar a EmailPara cuando se ponga en produccion.
            objSmtpMailInfo.EmailParaNivi = ObjMailInfo.EmailParaNivi; //cambiar el email para servicio al cliente cuando se ponga en produccion en la bd.
            objSmtpMailInfo.EmailDesde = ObjMailInfo.EmailDesde;

            //objSmtpMailInfo.EmailPara = EmailPara;
            objSmtpMailInfo.Asunto = "Advertencia - Problemas Saldos Bodega ";

            objSmtpMailInfo.CuerpoMsj = CargarPlantillaCuerpoAuditoriaSaldosBodega(objAuditoriaSaldosBodegaInfo);
            objSmtpMailInfo.ServidorCorreo = ObjMailInfo.ServidorCorreo;
            objSmtpMailInfo.Puerto = ObjMailInfo.Puerto;//*587-465
            objSmtpMailInfo.AutenticacionSSL = ObjMailInfo.AutenticacionSSL;
            objSmtpMailInfo.Usuario = ObjMailInfo.Usuario;
            objSmtpMailInfo.Password = ObjMailInfo.Password;

            return objSmtpMailInfo;
        }

        /// <summary>
        /// Selecciona el cuerpo del msj correspondiente al tipo.
        /// </summary>
        /// <param name="IdTipoMensaje"></param>
        /// <returns></returns>
        public string CuerpoMensaje(int IdTipoMensaje, string strUsuario, string strPassword, string NombreEmpresaria, string IdPedido, string ValorPedido)
        {
            string Mensaje = "";

            switch (IdTipoMensaje)
            {
                case (int)TipoMailEnum.Registro:
                    Mensaje = CargarPlantillaCuerpoRegistro(strUsuario, strPassword, NombreEmpresaria); //Usuario y password de empresaria a la que se envia el correo.                      
                    break;
                case (int)TipoMailEnum.Pedido:
                    //Mensaje = CargarPlantillaCuerpoPedido(NombreEmpresaria, IdPedido, ValorPedido); //Usuario y password de empresaria a la que se envia el correo.  
                    Mensaje = CargarPlantillaCuerpoPedidoDetalle(NombreEmpresaria, IdPedido, ValorPedido); //Usuario y password de empresaria a la que se envia el correo.  
                    break;
                case (int)TipoMailEnum.RegistroEmpresaria:
                    Mensaje = CargarPlantillaCuerpoRegistroEmpresariaWeb(strUsuario, strPassword, NombreEmpresaria); //Usuario y password de empresaria a la que se envia el correo.                      
                    break;
                case (int)TipoMailEnum.RecuperacionClave:
                    Mensaje = CargarPlantillaCuerpoRecuperacionClaveEmpresaria(strUsuario, strPassword, NombreEmpresaria); //Usuario y password de empresaria a la que se envia el correo.                      
                    break;
                default: //case DayOfWeek.Sunday:
                    break;
            }
            return Mensaje;
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoRegistro(string strUsuario, string strPassword, string NombreEmpresaria)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");

            sb.Append(" </head> ");
            sb.Append(" <body  >");
            sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("    <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("  Asunto del Correo: <b>Nuevo Registro de Empresaria Catálogo NIVI</b>");
            sb.Append("  <br /> ");
            sb.Append("   <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>" + NombreEmpresaria + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  Bienvenid@ a esta GRAN OPORTUNIDAD de tener tu propio negocio.");
            sb.Append("  <br /> ");
            sb.Append("  Gracias por registrarte en Catálogo NIVI, has dado el primer paso para convertirte en un@ exitos@ empresari@ NIVI, una asesora se contactara contigo para explicarte nuestro  ");
            sb.Append("  modelo de negocio y todos nuestros maravillosos beneficios. </p> ");
            sb.Append("      <br> ");
            sb.Append("    <p>Para ingresar al sistema dirijase al siguiente link: http://apps.nivienlinea.co/Empresarias/ <br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("      <br> ");
            sb.Append("    <p>El usuario y clave del Sistema Web para acceder a todas sus funcionalidades. <br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("   <table width=\"432\" border=\"0\" align=\"center\"> ");
            sb.Append("    <tr> ");
            sb.Append("     <td width=\"237\" ><b>Nombre de Usuario:  ");
            sb.Append("   </b></td>");
            sb.Append("     <td width=\"235\">&nbsp; ");
            sb.Append(strUsuario);
            sb.Append("</td> ");
            sb.Append("   </tr> ");
            sb.Append("    <tr> ");
            sb.Append("     <td><b>Contraseña:  ");
            sb.Append("   </b></td> ");
            sb.Append("     <td> &nbsp; ");
            sb.Append(strPassword);
            sb.Append("  </td> ");
            sb.Append("    </tr> ");
            sb.Append("    <tr> ");
            sb.Append("      <td>&nbsp;</td> ");
            sb.Append("      <td>&nbsp;</td> ");
            sb.Append("    </tr> ");
            sb.Append("    </table> ");           
            sb.Append("    <p>No olvides que debes cambiar tu contraseña por medio del menú de opciones lateral izquierdo --> 'Cambiar Contraseña'  <br> ");         
            sb.Append("    </p> ");
            sb.Append("    <p>Tenemos a tu disposición las siguientes líneas telefónicas para resolver todas tus inquietudes  <br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <p>Teléfonos: (6) 3387838 - 3387828 en la ciudad de Pereira, o puedes enviar un correo electrónico a la siguiente dirección centrodecontacto.co@niviglobal.com <br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <table width=\"432\" border=\"0\" align=\"center\"> ");
            sb.Append("      <tr> ");
            sb.Append("        <td style=\"font-family:Verdana, Arial, Helvetica, sans-serif; font-size:9px;  font-weight: bold;\" align=\"center\">Niviglobal S.A.S Calle 100 B #17A-29 Bodega 3 Belmonte");
            sb.Append(" Pereira, Colombia</td> ");
            sb.Append("     </tr> ");
            sb.Append("  </table> ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoPedido(string NombreEmpresaria, string IdPedido, string ValorPedido)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            sb.Append(" ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> ");


            sb.Append("<style>");
            sb.Append("body {");
            sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");


            sb.Append(" </head> ");
            //sb.Append(" <body >");           
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");

            sb.Append(" <body  >");
            sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("    <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");

            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>" + NombreEmpresaria + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Su pedido Numero:  <font color=red><b>" + IdPedido + "</b></font> ha sido almacenado correctamente y se encuentra en proceso de aprobacion. ");
            sb.Append(" <br /> <br />Por favor no olvide realizar el pago del pedido por medio de alguna de las siguientes entidades financieras: ");
            sb.Append(" <BR /><br />FAVOR CONSIGNAR UNICAMENTE EN RECAUDO EMPRESARIAL: ");
            sb.Append("   <table width=\"600\" border=\"0\" align=\"center\"> ");
            sb.Append("    <tr> ");
            sb.Append("     <td width=\"450\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><b>BANCOLOMBIA CUENTA CORRIENTE No: ");
            sb.Append("   </b></td>");
            sb.Append("     <td width=\"235\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\">&nbsp; ");
            sb.Append(" 07360543221 "); // CUENTA BANCOLOMBIA
            sb.Append("</td> ");
            sb.Append("   </tr> ");
            sb.Append("    <tr> ");
            sb.Append("     <td width=\"450\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\"><b>SERVIENTREGA (EFECTY CONVENIO): ");
            sb.Append("   </b></td> ");
            sb.Append("     <td style=\"font-family:Verdana, Arial, Helvetica, sans-serif\"> &nbsp; ");
            sb.Append("110016"); //CUENTA EFECTY
            sb.Append("  </td> ");
            sb.Append("    </tr> ");
            sb.Append("    <tr> ");
            sb.Append("     <td width=\"450\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\"><b>BANAGRARIO CUENTA CORRIENTE No: ");
            sb.Append("   </b></td>");
            sb.Append("     <td width=\"235\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\">&nbsp; ");
            sb.Append(" 357030003739 "); // CUENTA BANAGRARIO
            sb.Append("</td> ");
            sb.Append("   </tr> ");
            sb.Append("    <tr> ");
            sb.Append("      <td>&nbsp;</td> ");
            sb.Append("      <td>&nbsp;</td> ");
            sb.Append("    </tr> ");
            sb.Append("    </table> ");
            sb.Append("    <p><b>CONDICIONES DE PAGO:</b><br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <p>Los pagos deben hacerse mediante consignacion o transferencia bancaria a nombre de Niviglobal S.A.S<br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <p>La mora en los pagos sera al interes estipulado por la ley. Cualquier observacion sobre faltantes se debera deajar constancia en la guia de transportes.<br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <p>La mercancia se encuentra en consignacion hasta que su pago sea realizado totalmente y este asi lo acepte. Devoluciones y reclamos deben hacerse antes de 15 dias calendario.<br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <p>Gracias por comprar en Niviglobal S.A.S<br> ");
            sb.Append("      <br> ");
            sb.Append("    </p> ");
            sb.Append("    <table width=\"432\" border=\"0\" align=\"center\"> ");
            sb.Append("      <tr> ");
            sb.Append("        <td style=\"font-family:Verdana, Arial, Helvetica, sans-serif; font-size:9px;  font-weight: bold;\" align=\"center\">Niviglobal S.A.S Av 30 de Agosto # 104-107 ");
            sb.Append(" Pereira, Colombia</td> ");
            sb.Append("     </tr> ");
            sb.Append("  </table> ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }


        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoPedidoDetalle(string NombreEmpresaria, string IdPedido, string ValorPedido2)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            #region codigo viejo            
            /*sb.Append(" <html> ");
            sb.Append(" <head> ");
            sb.Append(" ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> ");


            sb.Append("<style>");
            sb.Append("body {");
            sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");


            sb.Append(" </head> ");
            //sb.Append(" <body >");           
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");

            sb.Append(" <body  >");
            sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("    <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");

            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>" + NombreEmpresaria + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");

            PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
            List<PedidosDetalleClienteInfo> objPedidosDetalleClienteInfo = new List<PedidosDetalleClienteInfo>();

            objPedidosDetalleClienteInfo = objPedidosDetalleCliente.ListDetallePedidoxNumeroMailAuditoria(IdPedido);


            sb.Append("   <table width=\"1100px\" border=\"0\" align=\"center\"> ");
            sb.Append("    <tr> ");
            sb.Append("      <td>Id</td> ");
            sb.Append("      <td>Referencia</td> ");
            sb.Append("      <td>Descripcion</td> ");
            sb.Append("      <td>Valor</td> ");
            sb.Append("      <td>IVA</td> ");
            sb.Append("      <td>CCostos</td> ");
            sb.Append("      <td>CantidadPedida</td> ");
            sb.Append("      <td>Fecha Creacion</td> ");
            sb.Append("    </tr> ");

            foreach (PedidosDetalleClienteInfo item in objPedidosDetalleClienteInfo)
            {
                sb.Append("    <tr> ");
                sb.Append("      <td>" + item.Id + "</td> ");
                sb.Append("      <td width=\"150px\">" + item.Referencia + "</td> ");
                sb.Append("      <td width=\"500px\">" + item.Descripcion + "</td> ");
                sb.Append("      <td>" + item.Valor + "</td> ");
                sb.Append("      <td>" + item.TarifaIVA + "</td> ");
                sb.Append("      <td width=\"100px\">" + item.Lote + "</td> ");
                sb.Append("      <td>" + item.Cantidad + "</td> ");
                sb.Append("      <td width=\"150px\">" + item.IdDocumentoFuente + "</td> ");

                sb.Append("    </tr> ");

            }

            sb.Append("    </table> ");


            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");*/
            #endregion           

            sb.Append(" <html xmlns=\"http://www.w3.org/1999/xhtml\"> ");
            sb.Append(" <head> ");
            sb.Append(" ");
            sb.Append("<meta content=\"text/html; charset=utf-8\" http-equiv=\"content-type\"> ");
            sb.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0;\"> ");
            sb.Append("<meta name=\"format-detection\" content=\"telephone=no\"> ");
            sb.Append("<style> ");
            sb.Append("body { margin: 0; padding: 0; min-width: 100%; width: 100% !important; height: 100% !important;} ");
            sb.Append("body, table, td, div, p, a { -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%; } ");
            sb.Append("table, td { mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-spacing: 0; } ");
            sb.Append("img { border: 0; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; } ");
            sb.Append("#outlook a { padding: 0; } ");
            sb.Append(".ReadMsgBody { width: 100%; } ");
            sb.Append(".ExternalClass { width: 100%; } .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div { line-height: 100%; } ");
            sb.Append("@media all and (min-width: 560px) { .container { border-radius: 8px; -webkit-border-radius: 8px; -moz-border-radius: 8px; -khtml-border-radius: 8px;} } ");
            sb.Append("a, a:hover {color: #127DB3;} ");
            sb.Append(".footer a, .footer a:hover { color: #999999; } ");
 	        sb.Append("</style> ");
            sb.Append("<title>TU PEDIDO NIVI</title> ");
            sb.Append("</head> ");
            sb.Append("<body topmargin=\"0\" rightmargin=\"0\" bottommargin=\"0\" leftmargin=\"0\" width=\"50%\" ");
            sb.Append("style=\"color: black; background-color: #f0f0f0; border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 50%; height: 50%; -webkit-font-smoothing: antialiased; text-size-adjust: 50%; -ms-text-size-adjust: 50%; -webkit-text-size-adjust: 50%; line-height: 50%; background-color: #F0F0F0;	color: #000000;\" marginheight=\"0\" marginwidth=\"0\"> ");
            sb.Append("<table style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 37%;\" class=\"background\" align=\"center\"  border=\"0\"  cellpadding=\"0\"  cellspacing=\"0\"  width=\"100%\"> ");
            sb.Append("<tbody> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;\" align=\"center\" bgcolor=\"#F0F0F0\" valign=\"top\"> ");
            sb.Append("<table style=\"border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit; max-width: 560px;\" class=\"wrapper\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"560\"> ");
            sb.Append("<tbody> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 20px;			padding-bottom: 20px;\" align=\"center\" valign=\"top\"> ");
            sb.Append("<div style=\"display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0; color: #F0F0F0;\" class=\"preheader\"></div> ");
            sb.Append("<a target=\"_blank\" style=\"text-decoration: none;\" href=\"http://niviglobal.com/co\"><img src=\"http://niviglobal.com/nivinews/invoice_co/images/logo-black.png\" alt=\"Logo\"  title=\"Logo\"  style=\"color: black; font-size: 10px; margin: 0px; padding: 0px; outline: medium none; text-decoration: none; border: medium none; display: block; width: 200px; height: 156px;\"  border=\"0\"  hspace=\"0\"  vspace=\"0\"></a> ");

            sb.Append("</td> ");
            sb.Append("</tr> ");               
            sb.Append("</tbody> ");
            sb.Append("</table> ");
            sb.Append("<table style=\"border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit; max-width: 560px;\" class=\"container\" align=\"center\" bgcolor=\"#FFFFFF\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"560\"> "); 

            sb.Append("<tbody> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%; padding-top: 25px; color: #f14d80;	font-family: sans-serif;\" class=\"header\"  align=\"center\" valign=\"top\"> ");
            sb.Append(" Gracias por pasar tu pedido Nivi ❤ </td> ");
            sb.Append("</tr> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-bottom: 3px; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 18px; font-weight: 300; line-height: 150%; padding-top: 5px;	color: #000000;	font-family: sans-serif;\" class=\"subheader\" align=\"center\" valign=\"top\"> ");
            sb.Append("A continuación el detalle de tu compra: </td> ");
            sb.Append("</tr> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-top: 20px;\" class=\"hero\" align=\"center\" valign=\"top\"><a target=\"_blank\" style=\"text-decoration: none;\"  href=\"http://niviglobal.com/co\"><img src=\"http://niviglobal.com/nivinews/invoice_co/images/1120x630.jpg\" alt=\"Please enable images to view this content\" title=\"Hero Image\"  style=\" width: 100%; max-width: 560px;	color: #000000; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;\" border=\"0\" hspace=\"0\" vspace=\"0\" width=\"560\"></a></td> ");
            sb.Append("</tr> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%; padding-top: 25px; color: #000000;	font-family: sans-serif;\" class=\"paragraph\" align=\"center\" valign=\"top\">  ");
            sb.Append("<br> ");          
            sb.Append("</td> ");
            sb.Append("</tr> ");
            // AQUI IRIA EL CODIGO DE DETALLE DEL PEDIDO BEGIN
                sb.Append("<tr> ");
                sb.Append("<td> ");
                sb.Append(" <table width=\"978\" border=\"0\" > ");
                sb.Append(" <tr> ");
                sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");              
                sb.Append("  <b>" + NombreEmpresaria + "</b>,");
                sb.Append("  <br /> ");               
                PedidosDetalleCliente objPedidosDetalleCliente1 = new PedidosDetalleCliente("conexion");
                PedidosCliente objPedidosCliente = new PedidosCliente("conexion");   
                List<PedidosDetalleClienteInfo> objPedidosDetalleClienteInfo1 = new List<PedidosDetalleClienteInfo>();
                PedidosClienteInfo objPedidosDetalleClienteInfo2 = new PedidosClienteInfo();
                objPedidosDetalleClienteInfo1 = objPedidosDetalleCliente1.ListPedidoDetallexIdxReserva(IdPedido);
                objPedidosDetalleClienteInfo2 = objPedidosCliente.ListPedidoxId(IdPedido);
                sb.Append("  <b>" + objPedidosDetalleClienteInfo2.Fecha + "</b>,");
                sb.Append("  <br /> ");
                sb.Append("  <br /> ");
                sb.Append("   <table width= \"950px\" border=\"0\" align=\"center\"> ");
                sb.Append("    <tr> ");
                sb.Append("      <td><b>Id Corto</b></td> ");
                sb.Append("      <td><b>Descripcion</b></td> ");
                sb.Append("      <td align=\"right\"><b>Valor</b></td> ");
                sb.Append("      <td align=\"right\"><b>IVA</b></td> ");
                //sb.Append("      <td><b>CCostos</b></td> ");
                sb.Append("      <td align=\"right\"><b>Cant. Reservada</b></td> ");
                sb.Append("      <td align=\"right\"><b>Cant. Pedida</b></td> ");
                sb.Append("    </tr> ");

                decimal suma = 0;
                decimal valor = 0;
                foreach (PedidosDetalleClienteInfo item in objPedidosDetalleClienteInfo1)
                {
                    sb.Append("    <tr> ");                  
                    sb.Append("      <td width=\"120px\">" + item.IdCodigoCorto + "</td> ");
                    sb.Append("      <td width=\"320px\">" + item.Descripcion + "</td> ");
                    if (Convert.ToInt32(item.TarifaIVA) == 0)
                    {
                        sb.Append("      <td align=\"right\">" + Convert.ToInt32(item.Valor).ToString("C") + "</td> ");
                        suma += Convert.ToInt32(item.Valor) * Convert.ToInt32(item.CantidadPedida);
                    }
                    else {
                        decimal iva = (Convert.ToDecimal(item.TarifaIVA) / 100);
                        suma += ((Convert.ToDecimal(item.Valor) * (iva)) + (Convert.ToDecimal(item.Valor))) * Convert.ToDecimal(item.CantidadPedida);
                        valor = ((Convert.ToDecimal(item.Valor) * (iva)) + (Convert.ToDecimal(item.Valor)));
                        sb.Append("      <td align=\"right\">" + Convert.ToInt32(valor).ToString("C") + "</td> ");
                    }
                    sb.Append("      <td align=\"right\">" + Convert.ToInt32(item.TarifaIVA) + "</td> ");
                    sb.Append("      <td align=\"right\">" + Convert.ToInt32(item.CantidadPedida) + "</td> ");
                    sb.Append("      <td align=\"right\">" + Convert.ToInt32(item.Cantidad) + "</td> ");     
                    sb.Append("    </tr> ");
                }
                sb.Append("    <tr> ");
                sb.Append("<td>&nbsp; </td>");              
                sb.Append("    </tr> ");
                sb.Append("    <tr> ");               
                sb.Append("<td> <b>Total:</b></td>");
                sb.Append("<td>" +Convert.ToInt32(suma).ToString("C") + "</td> ");                 
                sb.Append("    </tr> ");
                sb.Append("    </table> ");
                sb.Append("  <p><br /> ");
                sb.Append("  </p> ");
                sb.Append("  <p>&nbsp; ");
                sb.Append("     </p></td> ");
                sb.Append(" </tr> ");
                sb.Append(" </table> ");
                sb.Append("</td> ");         
                sb.Append("</tr> ");
            // AQUI IRIA EL CODIGO DE DETALLE DEL PEDIDO END
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 25px;	padding-bottom: 5px;\" class=\"button\" align=\"center\" valign=\"top\"><a  href=\"http://niviglobal.com/compras\" target=\"_blank\" style=\"text-decoration: underline;\"> ");
            sb.Append("<table style=\"max-width: 240px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> ");
            sb.Append("<tbody> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"padding: 12px 24px; margin: 0; text-decoration: underline; border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;\" align=\"center\" bgcolor=\"#f14d80\"  valign=\"middle\"> ");
            sb.Append("<a target=\"_blank\" style=\"text-decoration: underline; color: #FFFFFF; font-family: sans-serif; font-size: 17px; font-weight: 400; line-height: 120%;\" href=\"http://niviglobal.com/compras\"> ");
            sb.Append("IR AL PORTAL EMPRESARIAL </a> </td> ");
            sb.Append("</tr> ");
            sb.Append("</tbody> ");
            sb.Append("</table> ");
            sb.Append("</a> </td> ");
            sb.Append("</tr> ");

            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 25px;\" class=\"line\" align=\"center\" valign=\"top\"> ");
            sb.Append("<hr style=\"margin: 0; padding: 0;\" align=\"center\" color=\"#E0E0E0\"  noshade=\"noshade\" size=\"1\" width=\"100%\"> ");
            sb.Append("</td> ");
            sb.Append("</tr> ");

            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%; padding-top: 20px; padding-bottom: 25px; color: #000000;	font-family: sans-serif;\" class=\"paragraph\" align=\"center\" valign=\"top\"> ");
            sb.Append("<strong>CENTRO DE CONTACTO NIVIGLOBAL<br></strong>Tienes preguntas?  ");
            sb.Append("<a href=\"mailto:centrodecontacto.co@niviglobal.com\" target=\"_blank\" style=\"color: #127DB3; font-family: sans-serif; font-size: 17px; font-weight: 400; line-height: 160%;\">centrodecontacto.co@niviglobal.com</a><br> ");
            sb.Append("A nivel nacional marca: (096)3387838 - (096)3387828<br> ");
            sb.Append("Desde un Celular marca: (036)3387838 - (036)3387828</td> ");
            sb.Append("</tr> ");
           
            sb.Append("</tbody> ");
            sb.Append("</table> ");

            sb.Append("<table style=\"border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit; max-width: 560px;\" class=\"wrapper\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"560\"> ");
            sb.Append("<tbody> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 25px;\" class=\"social-icons\" align=\"center\" valign=\"top\"> ");
            sb.Append("<table style=\"border-collapse: collapse; border-spacing: 0px; padding: 0px; width: 170px; height: 44px;\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> ");
            sb.Append("<tbody> ");
            sb.Append("<tr> ");
            sb.Append("<td style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\" align=\"center\"  valign=\"middle\"><br></td> ");

            sb.Append("<td style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\" align=\"center\" valign=\"middle\"><a target=\"_blank\" href=\"http://facebook.com/CatalogoNivi\" style=\"text-decoration: none;\"><img style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: inline-block; color: #000000;\" alt=\"F\" title=\"Facebook\" src=\"http://niviglobal.com/nivinews/invoice_co/images/social-icons/facebook.png\" border=\"0\" height=\"44\" hspace=\"0\" vspace=\"0\" width=\"44\"></a> </td> ");

            sb.Append("<td style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\" align=\"center\" valign=\"middle\"><a target=\"_blank\" href=\"http://instagram.com/CatalogoNivi\" style=\"text-decoration: none;\"><img style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: inline-block;	color: #000000;\" alt=\"I\" title=\"Instagram\" src=\"http://niviglobal.com/nivinews/invoice_co/images/social-icons/instagram.png\" border=\"0\" height=\"44\" hspace=\"0\" vspace=\"0\" width=\"44\"></a> </td> ");

            sb.Append("<td style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\" align=\"center\" valign=\"middle\"><br> </td> ");
            sb.Append("</tr> ");
            sb.Append("</tbody> ");
            sb.Append("</table> ");
            sb.Append("</td> ");
            sb.Append("</tr>  ");

            sb.Append("<tr>  ");
            sb.Append("<td style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%; padding-top: 20px; padding-bottom: 20px; color: #999999; font-family: sans-serif;\" class=\"footer\" align=\"center\" valign=\"top\"> Este email es enviado automáticamente desde el Portal Empresarial Niviglobal. </td> ");
            sb.Append("</tr>  ");               
            sb.Append("</tbody>  ");
            sb.Append("</table>  ");
            sb.Append("</td>  ");
            sb.Append("</tr>  ");
            sb.Append("</tbody>  ");
            sb.Append("</table>  ");
            sb.Append("</body>  ");
            sb.Append("</html>  ");

           
            return sb.ToString();
        }


        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoRegistroEmpresariaWeb(string strUsuario, string strPassword, string NombreEmpresaria)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");

            sb.Append(" </head> ");
            sb.Append(" <body  >");
            sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("    <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("   <br /> ");
            sb.Append("  <br /> ");
            sb.Append("   <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>" + NombreEmpresaria + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Registro de empresaria WEB, asignado a la zona 9106 con estado PROSPECTO. ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoRecuperacionClaveEmpresaria(string strUsuario, string strPassword, string NombreEmpresaria)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");
            sb.Append(" </head> ");
            sb.Append(" <body  >");
            sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>" + NombreEmpresaria + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Usted ha solicitado recuperar su clave a la plataforma virtual de Empresarias. ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Por favor dirijase al siguiente enlace: http://www.niviglobal.com ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  A continuación escriba la siguiente información de acceso. ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Usuario: " + strUsuario);
            sb.Append("  <br /> ");
            sb.Append("  Clave: " + strPassword);
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Si se presenta alguna inconsistencia con el acceso a la plataforma, por favor comuniquese con nuestro Centro de Contacto Nivi. ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Gracias por utilizar nuestros servicios. ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoErrorPedidoReservaLinea(AuditoriaReservaInfo objAuditoriaReservaInfo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");
            sb.Append(" </head> ");
            sb.Append(" <body  >");
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>Numero Pedido: " + objAuditoriaReservaInfo.NumeroPedido + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Se ha presentado una inconsistencia en la digitacion del pedido. ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  A continuación se describe la información de la incidencia del Pedido: ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Numero: " + objAuditoriaReservaInfo.NumeroPedido);
            sb.Append("  <br /> ");
            sb.Append("  Id Auditoria: " + objAuditoriaReservaInfo.Id);
            sb.Append("  <br /> ");
            sb.Append("  Numero Error: " + objAuditoriaReservaInfo.NumeroError);
            sb.Append("  <br /> ");
            sb.Append("  Mensaje Error: " + objAuditoriaReservaInfo.MensajeError);
            sb.Append("  <br /> ");
            sb.Append("  Fecha: " + objAuditoriaReservaInfo.Sysdate);
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  SVDN Motor Auditoria Automatico. ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoAuditoriaNegativos(AuditoriaNegativosInfo objAuditoriaNegativosInfo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");
            sb.Append(" </head> ");
            sb.Append(" <body  >");
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Se han presentado negativos en la siguiente referencia: ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>Referencia: " + objAuditoriaNegativosInfo.Referencia + "</b>,");
            sb.Append("  <br /> ");
            sb.Append("  id: " + objAuditoriaNegativosInfo.Id);
            sb.Append("  <br /> ");
            sb.Append("  bodega: " + objAuditoriaNegativosInfo.Bodega);
            sb.Append("  <br /> ");
            sb.Append("  codigototal: " + objAuditoriaNegativosInfo.CodigoTotal);
            sb.Append("  <br /> ");
            sb.Append("  referencia: " + objAuditoriaNegativosInfo.Referencia);
            sb.Append("  <br /> ");
            sb.Append("  nombre_producto: " + objAuditoriaNegativosInfo.NombreProducto);
            sb.Append("  <br /> ");
            sb.Append("  codigocolor: " + objAuditoriaNegativosInfo.CodigoColor);
            sb.Append("  <br /> ");
            sb.Append("  descripcion: " + objAuditoriaNegativosInfo.Descripcion);
            sb.Append("  <br /> ");
            sb.Append("  codigotalla: " + objAuditoriaNegativosInfo.CodigoTalla);
            sb.Append("  <br /> ");
            sb.Append("  ccostos: " + objAuditoriaNegativosInfo.CCostos);
            sb.Append("  <br /> ");
            sb.Append("  saldo: " + objAuditoriaNegativosInfo.Saldo);
            sb.Append("  <br /> ");
            sb.Append("  costo_ponderado_final: " + objAuditoriaNegativosInfo.CostoPonderadoFinal);
            sb.Append("  <br /> ");
            sb.Append("  Fecha: " + objAuditoriaNegativosInfo.Sysdate);

            if (objAuditoriaNegativosInfo.CantidadNegativos > 3)
            {
                sb.Append("  <br /> ");
                sb.Append("  <br /> ");
                sb.Append("  <font color=red><b> EXISTEN " + (objAuditoriaNegativosInfo.CantidadNegativos - 1) + " NEGATIVOS ADICIONALES AL REPORTADO, POR FAVOR VERIFICAR DE MANERA URGENTE!! </b></font>");
            }

            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  SVDN Motor Auditoria Automatico. ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoAuditoriaPedidos(AuditoriaPedidosInfo objAuditoriaPedidosInfo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");
            sb.Append(" </head> ");
            sb.Append(" <body  >");
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Se han presentado inconsistencias en el siguiente Pedido: ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>Id Auditoria: </b>" + objAuditoriaPedidosInfo.Id + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Numero Pedido: </b>" + objAuditoriaPedidosInfo.Numero + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Nit: </b>" + objAuditoriaPedidosInfo.Nit + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Zona: </b>" + objAuditoriaPedidosInfo.Zona + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Campaña: </b>" + objAuditoriaPedidosInfo.Campana + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Vendedor: </b>" + objAuditoriaPedidosInfo.Vendedor + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Portal: </b>" + objAuditoriaPedidosInfo.Portal + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>factusemanal: </b>" + objAuditoriaPedidosInfo.FactuSemanal + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>CantidadSVDN: </b>" + objAuditoriaPedidosInfo.CantidadSVDN + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>CantidadGYG: </b>" + objAuditoriaPedidosInfo.CantidadGYG + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Observacion: </b>" + objAuditoriaPedidosInfo.Observacion + ",");
            sb.Append("  <br /> ");
            sb.Append("  <b>Fecha: </b>" + objAuditoriaPedidosInfo.Sysdate + "");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  SVDN Motor Auditoria Automatico. ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }

        /// <summary>
        /// Crea la plantilla en html
        /// </summary>
        /// <param name="strUsuario"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoAuditoriaSaldosBodega(List<AuditoriaSaldosBodegaInfo> objAuditoriaSaldosBodegaInfo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");
            sb.Append(" </head> ");
            sb.Append(" <body  >");
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Se han presentado inconsistencias en saldos de bodega: ");


            foreach (AuditoriaSaldosBodegaInfo item in objAuditoriaSaldosBodegaInfo)
            {
                sb.Append("  <br /> ");
                sb.Append("  <br /> ");
                sb.Append("  Id: " + item.Id);
                sb.Append("  <br /> ");
                sb.Append("  Mes: " + item.Mes);
                sb.Append("  <br /> ");
                sb.Append("  Ccostos: " + item.CCostos);
                sb.Append("  <br /> ");
                sb.Append("  Referencia: " + item.Referencia);
                sb.Append("  <br /> ");
                sb.Append("  Cantidad: " + item.Cantidad);
                sb.Append("  <br /> ");
                sb.Append("  Costo Mercancia: " + item.CostoMercancia);
                sb.Append("  <br /> ");
                sb.Append("  Descripcion: " + item.Opcion);
                sb.Append("  <br /> ");
                sb.Append("  Numero Pedido: " + item.NumeroPedido);
                sb.Append("  <br /> ");
                sb.Append("  Fecha: " + item.Sysdate);
                sb.Append("  <br /> ");
                sb.Append("  <br /> ");
                sb.Append("  <br /> ");
                sb.Append("  /*-------------------------------------------------------------------------------------------*/ ");
                sb.Append("  /*-------------------------------------------------------------------------------------------*/ ");

            }

            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  SVDN Motor Auditoria Automatico. ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }


        /// <summary>
        /// GAVL CARGA CUERPO DEL MENSAJE CUANDO SE SUPRIME EL REGISTRO
        /// </summary>
        /// <param name="objAuditoriaReservaInfo"></param>
        /// <returns></returns>
        public string CargarPlantillaCuerpoSuprimirRegistro(string nit, string Usuario)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();


            /*
             Buen Dia, 

            La empresaria cc+nombreapellido, ha decidido dar de baja su registro en las plataformas SVDN/Portal
            Empresarias de Niviglobal S.A.S.  Por tal motivo es indispensable retirar la informacion de la empresaria 
            del canal de comunicaciones, envio de correos electronicos y solcitud de llamadas.

            Fecha Cancelacion Registro: Getdate()

            Cordialmente,

            TIC, SVDN.
             
             
             <td width="60" rowspan="3" scope="col">
                    <img id="Img6" src="images/facturas.png"
                        width="60" height="60" /></a>
            </td>
             
             */



            sb.Append(" <html> ");
            sb.Append(" <head> ");
            //sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"> ");

            sb.Append("<style>");
            sb.Append("body {");
            //sb.Append(" background-image:url('http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png');");
            // sb.Append(" background-repeat:repeat-y no-repeat;");
            sb.Append(" background-color:#ffffff;");
            sb.Append(" margin:0;");
            sb.Append(" padding:0;");
            sb.Append(" }");
            sb.Append("</style>");
            sb.Append(" </head> ");
            sb.Append(" <body  >");
            //sb.Append(" <table width=\"978\" height=\"999\" border=\"0\" style='background-image:url(http://www.niviglobal.com/colombia/escribenos/exportar/imagenes/backgroundmail.png)' > ");
            sb.Append(" <tr> ");

            sb.Append(" <td> ");
            sb.Append(" <img src='cid:imagen'  width=\"200\" height=\"120\" />");
            sb.Append(" </td> ");
            sb.Append(" </tr> ");




            sb.Append(" <tr> ");
            sb.Append("<td width=\"968\" valign=\"top\" style=\"font-family:Verdana, Arial, Helvetica, sans-serif\" ><p><br /> ");
            sb.Append("  <br /> ");
            sb.Append("  <b>Buen Dia</b>,");
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  La empresaria <b> " + Usuario + " </b> con numero de cedula <b> " + nit + " </b> , ha decidido dar de baja su registro en las plataformas SVDN/Portal  ");
            sb.Append("  Empresarias de Niviglobal S.A.S.  Por tal motivo es indispensable retirar la informacion de la empresaria ");
            sb.Append("  del canal de comunicaciones, envio de correos electronicos y solcitud de llamadas. ");

            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Fecha Cancelación Registro: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            sb.Append("  <br /> ");
            sb.Append("  <br /> ");
            sb.Append("  Cordialmente,");
            sb.Append("  <br /> ");
            sb.Append("  TIC, SVDN.");
            sb.Append("  <br /> ");
            sb.Append("  ");
            sb.Append("  <p><br /> ");
            sb.Append("  </p> ");
            sb.Append("  <p>&nbsp; ");
            sb.Append("     </p></td> ");
            sb.Append(" </tr> ");
            sb.Append(" </table> ");
            sb.Append(" <p>&nbsp;</p> ");
            sb.Append(" </body> ");
            sb.Append(" </html> ");

            return sb.ToString();
        }


        /// <summary>
        /// Envia un E-Mail
        /// </summary>
        /// <param name="objSmtpMail"></param>
        /// <returns></returns>
        public bool SendMail(SmtpMailInfo objSmtpMail)
        {
            bool transOk = false;

            // To
            MailMessage mailMsg = new MailMessage();
            //mailMsg.To.Add(objSmtpMail.EmailPara);
            if (objSmtpMail.EmailPara != "")
            {
                mailMsg.CC.Add(objSmtpMail.EmailPara);
            }
            if (objSmtpMail.EmailParaNivi != "")
            {
                mailMsg.Bcc.Add(objSmtpMail.EmailParaNivi);            
            }

            // From
            MailAddress mailAddress = new MailAddress(objSmtpMail.EmailDesde, "CATALOGONIVI");
            mailMsg.From = mailAddress;

            // Subject and Body
            mailMsg.Subject = objSmtpMail.Asunto;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = objSmtpMail.CuerpoMsj;

            //------------------------------------

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, new System.Net.Mime.ContentType("text/html"));
            //*LinkedResource resource = new LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + "/Images/logo1.png");
            //*resource.ContentId = "dealer_logo";
            //*htmlView.LinkedResources.Add(resource); 

            mailMsg.AlternateViews.Add(htmlView);


            //--------------------------------------

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient(objSmtpMail.ServidorCorreo, objSmtpMail.Puerto);

            if (objSmtpMail.AutenticacionSSL)
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(objSmtpMail.Usuario, objSmtpMail.Password);
                //*smtpClient.EnableSsl = true;
                smtpClient.EnableSsl = true;// Dejar en True para envio de correo desde gmail.

            }

            //decirle al servidor de gmail de nivi que no necesita certificados.
            ServicePointManager.ServerCertificateValidationCallback =

               delegate(object s

                   , X509Certificate certificate

                   , X509Chain chain

                   , SslPolicyErrors sslPolicyErrors)

               { return true; };

            try
            {
                smtpClient.Send(mailMsg);
                transOk = true;
            }
            catch (Exception)
            {
                /*Errores SMTP:
                * 1)
                * Error: Comando no implementado. La respuesta del servidor fue: unimplemented (#5.5.1). 
                * Solucion:  objSmtpMailInfo.AutenticacionSSL = true; pasara a false
                */

                //Error, could not send the message                 
                transOk = false;
            }

            return transOk;
        }


        /// <summary>
        /// Envia un E-Mail  con Image
        /// </summary>
        /// <param name="objSmtpMail"></param>
        /// <returns></returns>
        public bool SendMailConImage(SmtpMailInfo objSmtpMail)
        {
            bool transOk = false;

            // To
            MailMessage mailMsg = new MailMessage();

          

            
            //mailMsg.To.Add(objSmtpMail.EmailPara);
            if (objSmtpMail.EmailPara != "")
            {
                mailMsg.CC.Add(objSmtpMail.EmailPara);
                
            }
            if (objSmtpMail.EmailParaNivi != "")
            {
                
                string[] split = objSmtpMail.EmailParaNivi.Split(',');

                if (split.Length > 0)
                {
                    foreach (string s in split)
                    {
                        if (s.Trim() != "")
                        {
                            mailMsg.To.Add(s);
                        }
                    }
                }
                else
                {
                    mailMsg.To.Add(objSmtpMail.EmailParaNivi);
                }

            }

            // From
            MailAddress mailAddress = new MailAddress(objSmtpMail.EmailDesde);
            mailMsg.From = mailAddress;

            // Subject and Body
            mailMsg.Subject = objSmtpMail.Asunto;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = objSmtpMail.CuerpoMsj;

            //------------------------------------

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, new System.Net.Mime.ContentType("text/html"));
            LinkedResource resource = new LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + "/Images/nivi_logo.png");
            resource.ContentId = "imagen";
            htmlView.LinkedResources.Add(resource); 


            mailMsg.AlternateViews.Add(htmlView);


            //--------------------------------------

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient(objSmtpMail.ServidorCorreo, objSmtpMail.Puerto);

            if (objSmtpMail.AutenticacionSSL)
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(objSmtpMail.Usuario, objSmtpMail.Password);
                //*smtpClient.EnableSsl = true;
                smtpClient.EnableSsl = true;// Dejar en True para envio de correo desde gmail.
            }

            //decirle al servidor de gmail de nivi que no necesita certificados.
            ServicePointManager.ServerCertificateValidationCallback =

               delegate(object s

                   , X509Certificate certificate

                   , X509Chain chain

                   , SslPolicyErrors sslPolicyErrors)

               { return true; };

            try
            {
                smtpClient.Send(mailMsg);
                transOk = true;
            }
            catch (Exception)
            {
                /*Errores SMTP:
                * 1)
                * Error: Comando no implementado. La respuesta del servidor fue: unimplemented (#5.5.1). 
                * Solucion:  objSmtpMailInfo.AutenticacionSSL = true; pasara a false
                */

                //Error, could not send the message                 
                transOk = false;
            }

            return transOk;
        }



        /// <summary>
        /// Envia un E-Mail
        /// </summary>
        /// <param name="objSmtpMail"></param>
        /// <returns></returns>
        public bool SendMailRecuperarClave(SmtpMailInfo objSmtpMail)
        {
            bool transOk = false;

            // To
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(objSmtpMail.EmailPara);
            mailMsg.To.Add(objSmtpMail.EmailParaNivi);

            // From
            MailAddress mailAddress = new MailAddress(objSmtpMail.EmailDesde);
            mailMsg.From = mailAddress;

            // Subject and Body
            mailMsg.Subject = objSmtpMail.Asunto;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = objSmtpMail.CuerpoMsj;

            //------------------------------------

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, new System.Net.Mime.ContentType("text/html"));
            //*LinkedResource resource = new LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + "/Images/logo1.png");
            //*resource.ContentId = "dealer_logo";
            //*htmlView.LinkedResources.Add(resource); 

            mailMsg.AlternateViews.Add(htmlView);


            //--------------------------------------

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient(objSmtpMail.ServidorCorreo, objSmtpMail.Puerto);

            if (objSmtpMail.AutenticacionSSL)
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(objSmtpMail.Usuario, objSmtpMail.Password);
                //*smtpClient.EnableSsl = true;
                smtpClient.EnableSsl = true; // Dejar en True para envio de correo desde gmail.
            }

            //decirle al servidor de gmail de nivi que no necesita certificados.
            ServicePointManager.ServerCertificateValidationCallback =

               delegate(object s

                   , X509Certificate certificate

                   , X509Chain chain

                   , SslPolicyErrors sslPolicyErrors)

               { return true; };

            try
            {
                smtpClient.Send(mailMsg);
                transOk = true;
            }
            catch (Exception ex)
            {
                /*Errores SMTP:
                * 1)
                * Error: Comando no implementado. La respuesta del servidor fue: unimplemented (#5.5.1). 
                * Solucion:  objSmtpMailInfo.AutenticacionSSL = true; pasara a false
                */

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Error, could not send the message                 
                transOk = false;
            }

            return transOk;
        }


        /// <summary>
        /// Envia un E-Mail
        /// </summary>
        /// <param name="objSmtpMail"></param>
        /// <returns></returns>
        public bool SendMailErrorReserva(SmtpMailInfo objSmtpMail)
        {
            bool transOk = false;

            // To
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(objSmtpMail.EmailPara);
            mailMsg.To.Add(objSmtpMail.EmailParaNivi);

            // From
            MailAddress mailAddress = new MailAddress(objSmtpMail.EmailDesde);
            mailMsg.From = mailAddress;

            // Subject and Body
            mailMsg.Subject = objSmtpMail.Asunto;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = objSmtpMail.CuerpoMsj;

            //------------------------------------

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, new System.Net.Mime.ContentType("text/html"));
            //*LinkedResource resource = new LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + "/Images/logo1.png");
            //*resource.ContentId = "dealer_logo";
            //*htmlView.LinkedResources.Add(resource); 

            mailMsg.AlternateViews.Add(htmlView);


            //--------------------------------------

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient(objSmtpMail.ServidorCorreo, objSmtpMail.Puerto);

            if (objSmtpMail.AutenticacionSSL)
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(objSmtpMail.Usuario, objSmtpMail.Password);
                //*smtpClient.EnableSsl = true;
                smtpClient.EnableSsl = true;// Dejar en True para envio de correo desde gmail.
            }

            //decirle al servidor de gmail de nivi que no necesita certificados.
            ServicePointManager.ServerCertificateValidationCallback =

               delegate(object s

                   , X509Certificate certificate

                   , X509Chain chain

                   , SslPolicyErrors sslPolicyErrors)

               { return true; };

            try
            {
                smtpClient.Send(mailMsg);
                transOk = true;
            }
            catch (Exception ex)
            {
                /*Errores SMTP:
                * 1)
                * Error: Comando no implementado. La respuesta del servidor fue: unimplemented (#5.5.1). 
                * Solucion:  objSmtpMailInfo.AutenticacionSSL = true; pasara a false
                */

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Error, could not send the message                 
                transOk = false;
            }

            return transOk;
        }
    }
}
