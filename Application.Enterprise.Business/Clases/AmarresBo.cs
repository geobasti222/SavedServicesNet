using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Agotados 
    ///  CODIGO BY JUTA.
    /// </summary>
    public class AmarresBo :IAmarres
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.AmarresDao module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AmarresBo()
        {
            module = new Application.Enterprise.Data.AmarresDao();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public AmarresBo(string databaseName)
        {
            module = new Application.Enterprise.Data.AmarresDao(databaseName);
        }
        public bool insertarAmarreEnca(AmarresInfo amarre) {
            return module.insertaramarreEnca(amarre); 
        }


        public bool insertarAmarreDeta(AmarresInfo amarre)
        {
            return module.insertaramarreDeta(amarre);
        }
        public bool verxistenciaEncabezado(int pinta, int amarre, decimal valorpinta, string descripcion)
        {
            return module.verxistenciaEncabezado(pinta, amarre, valorpinta, descripcion); 
        }
        
        public List<AmarresInfo> verTodosAmarres()
        {
            return module.verTodosAmarres(); 
        }
        public List<AmarresInfo> verPintasyAmarresVigentes()
        {
           return module.verPintasyAmarresVigentes(); 
        }
        public List<AmarresInfo> verPintasVigentes()
        {
           return module.verPintasVigentes(); 
        }
        public List<AmarresInfo> verAmarresVigentes()
        {
            return module.verAmarresVigentes(); 
        }
        public List<AmarresInfo> ListAmarresxCodigo(string id_producto){
            return module.ListAmarresxCodigo(id_producto); 
        }
        public bool validarReferencia(string referencia) {
            return module.validarReferencia(referencia); 
        }
        public bool validarSku(string idcorto) {
            return module.validarSku(idcorto); 
        }
        public List<AmarresInfo> ListAmarresxregla(string id_regla, string codproducto) {
            return module.ListAmarresxregla(id_regla,  codproducto); 
        }
        public string getReferencia(string id_corto) {
            return module.getReferencia(id_corto); 
        }
        public List<AmarresInfo> ListtodosamarresCodigo(string id_producto) { 
        return module.ListtodosamarresCodigo( id_producto); 
        }

      
        public List<AmarresInfo> ListItemsPorpinta(string id_regla, string codproducto) {
            return module.ListItemsPorpinta(id_regla, codproducto); 
        }


        public AmarresInfo getAmarreIteminfo(string codproducto) {
            return module.getAmarreIteminfo(codproducto);
        }
       /*
        public void insertaramarrexReferenciaxCampana(AmarresInfo amarre)
        {
            module.insertaramarrexReferenciaxCampana(amarre); 
        }
        public void insertaramarrexReferenciaxFecha(AmarresInfo amarre)
        {
            module.insertaramarrexReferenciaxFecha(amarre); 
        }
        public void insertaramarrexIdCortoxCampana(AmarresInfo amarre)
        {
            module.insertaramarrexIdCortoxCampana(amarre); 
        }
        public void insertaramarrexIdCortoxFecha(AmarresInfo amarre)
        {
            module.insertaramarrexIdCortoxFecha(amarre); 
        }
        public void insertarpintaxReferenciaxCampana(AmarresInfo amarre)
        {
            module.insertarpintaxReferenciaxCampana(amarre); 
        }
        public void insertarpintaxReferenciaxFecha(AmarresInfo amarre)
        {
            module.insertarpintaxReferenciaxFecha(amarre); 
        }
        public void insertarpintaxIdCortoxCampana(AmarresInfo amarre)
        {
            module.insertarpintaxIdCortoxCampana(amarre); 
        }
        public void insertarpintaxIdCortoxFecha(AmarresInfo amarre)
        {
            module.insertarpintaxIdCortoxFecha(amarre); 
        }
           
        */
       /* public void insertaramarre(AmarresInfo amarre) {
            module.insertarAmarre(amarre); 
        
        }*/

        /*
        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public List<AmarreReglaInfo> ListReglas(string campana)
        {
           // return module.ListReglas(campana);
        }

        /// <summary>
        /// lista todos los amarres de una regla
        /// </summary>
        /// <returns></returns>
        public List<AmarresInfo> ListAmarres(int regla)
        {
            return module.ListAmarres(regla);
        }


        /// <summary>
        /// lista todos los premios de una regla
        /// </summary>
        /// <returns></returns>
        public List<AmarrePremioInfo> ListAmarresPremios(int regla)
        {
            return module.ListAmarresPremios(regla);
        }

        /// <summary>
        /// lista un producto 
        /// </summary>
        /// <returns></returns>
        public PLUInfo producto(string plu, string referencia)
        {
            return module.producto(plu, referencia);
        }

        /// <summary>
        /// lista un producto premio
        /// </summary>
        /// <returns></returns>
        public PLUInfo productoPremio(string plu, string referencia)
        {
            return module.productoPremio(plu, referencia);
        }
        /// <summary>
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
        public AmarreReglaInfo Reglaconse()
        {
            return module.Reglaconse();
        }

        /// <summary>
        /// Guarda una regla amarre nueva
        /// </summary>
        /// <param name="item"></param>
        public int InsertRegla(AmarreReglaInfo item, string usuario)
        {
            return module.InsertRegla(item, usuario);
        }

        /// <summary>
        /// Guarda un amarre nuevo
        /// </summary>
        /// <param name="item"></param>
        public int InsertAmarre(AmarresInfo item, string usuario)
        {
            return module.InsertAmarre(item, usuario);
        }


         /// <summary>
        /// Guarda un amarre premio
        /// </summary>
        /// <param name="item"></param>
        public int InsertPremio(AmarrePremioInfo item, string usuario)
        {
            return module.InsertPremio(item, usuario);
        }


         /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteReglas(int id, string Usuario)
        {
            return module.DeleteReglas(id, Usuario);
        }


        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public bool UpdateActivoRegla(int id, string Usuario, int activo)
        {
            return module.UpdateActivoRegla(id, Usuario, activo);
        }


        /// <summary>
        /// lista una regla
        /// </summary>
        /// <returns></returns>
        public AmarreReglaInfo Reglas(string id)
        {
            return module.Reglas(id);
        }

         /// <summary>
        /// "borra" el detalle de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteAmarrePremios(int id, string Usuario)
        {
            return module.DeleteAmarrePremios(id, Usuario);
        }

        /// <summary>
        /// actualiza una regla amarre 
        /// </summary>
        /// <param name="item"></param>
        public int UpdateRegla(AmarreReglaInfo item, string usuario)
        {
            return module.UpdateRegla(item, usuario);
        }

        /// <summary>
        /// Guarda una regla amarre nueva
        /// </summary>
        /// <param name="item"></param>
        public int InsertPedidoTEMP(string usuario, string plu, int cantidad, string catalogo, string catalogoreal)
        {
            return module.InsertPedidoTEMP(usuario, plu, cantidad, catalogo, catalogoreal);
        }

         /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeletePedidosTemporales(string usuario)
        {
            return module.DeletePedidosTemporales(usuario);
        }

        /// <summary>
        /// procesa los amarres precio diferenciado
       /// </summary>
       /// <param name="numero"></param>
       /// <param name="campana"></param>
       /// <returns></returns>
        public DataTable procesar(string numero, string campana)
        {
            return module.procesar(numero, campana);
        }


       /// <summary>
       /// Obtener cantidad de premio no descuento
       /// </summary>
       /// <param name="plu"></param>
       /// <returns></returns>
        public DataTable obtenerCantidad(string plu)
        {
            return module.obtenerCantidad(plu);
        }*/
    }
}
