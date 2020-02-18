using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Agotados
    ///  CODIGO BY JUTA.
    /// </summary>
    public interface IAmarres
	{



        bool insertarAmarreEnca(AmarresInfo amarre);
        bool insertarAmarreDeta(AmarresInfo amarre);
        bool validarReferencia(string referencia); 
        bool validarSku(string idcorto); 

        bool verxistenciaEncabezado(int pinta, int amarre, decimal valorpinta, string descripcion);
        List<AmarresInfo> verTodosAmarres();
        List<AmarresInfo> verPintasyAmarresVigentes();
        List<AmarresInfo> verPintasVigentes();
        List<AmarresInfo> verAmarresVigentes();
        List<AmarresInfo> ListAmarresxCodigo(string id_producto);
        List<AmarresInfo> ListAmarresxregla(string id_regla, string codproducto);
        string getReferencia(string id_corto);

       List<AmarresInfo> ListtodosamarresCodigo(string id_producto); 


         List<AmarresInfo> ListItemsPorpinta(string id_regla, string codproducto);
         AmarresInfo getAmarreIteminfo(string codproducto);

        
        /*

        void insertaramarrexReferenciaxCampana(AmarresInfo amarre);
        void insertaramarrexReferenciaxFecha(AmarresInfo amarre);
        void insertaramarrexIdCortoxCampana(AmarresInfo amarre);
        void insertaramarrexIdCortoxFecha(AmarresInfo amarre);
        void insertarpintaxReferenciaxCampana(AmarresInfo amarre);
        void insertarpintaxReferenciaxFecha(AmarresInfo amarre);
        void insertarpintaxIdCortoxCampana(AmarresInfo amarre);
        void insertarpintaxIdCortoxFecha(AmarresInfo amarre);
           */

       // void insertaramarre(AmarresInfo amarre); 
        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        ///List<AmarreReglaInfo> ListReglas(string campana);

        /// <summary>
        /// lista todos los amarres de una regla
        /// </summary>
        /// <returns></returns>
       /// List<AmarresInfo> ListAmarres(int regla);

        /// <summary>
        /// lista todos los premios de una regla
        /// </summary>
        /// <returns></returns>
       /// List<AmarrePremioInfo> ListAmarresPremios(int regla);

        /// <summary>
        /// lista un producto 
        /// </summary>
        /// <returns></returns>
        //PLUInfo producto(string plu, string referencia);
      

        
        /// <summary>
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
       /// AmarreReglaInfo Reglaconse();

        /// <summary>
        /// Guarda una regla amarre nueva
        /// </summary>
        /// <param name="item"></param>
       /// int InsertRegla(AmarreReglaInfo item, string usuario);

        /// <summary>
        /// Guarda un amarre nuevo
        /// </summary>
        /// <param name="item"></param>
        ///int InsertAmarre(AmarresInfo item, string usuario);
        
         /// <summary>
        /// Guarda un amarre premio
        /// </summary>
        /// <param name="item"></param>
       /// int InsertPremio(AmarrePremioInfo item, string usuario);

         /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
       /// bool DeleteReglas(int id, string Usuario);

        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        ///bool UpdateActivoRegla(int id, string Usuario, int activo);
        
        
        
        /// <summary>
        /// lista una regla
        /// </summary>
        /// <returns></returns>
        ///AmarreReglaInfo Reglas(string id);
        
         /// <summary>
        /// "borra" el detalle de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
      ///  bool DeleteAmarrePremios(int id, string Usuario);

        /// <summary>
        /// actualiza una regla amarre 
        /// </summary>
        /// <param name="item"></param>
       ///  int UpdateRegla(AmarreReglaInfo item, string usuario);

        /// <summary>
        /// Guarda una regla amarre nueva
        /// </summary>
        /// <param name="item"></param>
        /// int InsertPedidoTEMP(string usuario, string plu, int cantidad, string catalogo, string catalogoreal);
        
         /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
      //   bool DeletePedidosTemporales(string usuario);

        /// <summary>
        /// procesa los amarres precio diferenciado
       /// </summary>
       /// <param name="numero"></param>
       /// <param name="campana"></param>
       /// <returns></returns>
        /// DataTable procesar(string numero, string campana);
        
        
        /// <summary>
        /// lista un producto premio
        /// </summary>
        /// <returns></returns>
       ///  PLUInfo productoPremio(string plu, string referencia);


       /// <summary>
       /// Obtener cantidad de premio no descuento
       /// </summary>
       /// <param name="plu"></param>
       /// <returns></returns>
         ///DataTable obtenerCantidad(string plu);
        
	}
}
