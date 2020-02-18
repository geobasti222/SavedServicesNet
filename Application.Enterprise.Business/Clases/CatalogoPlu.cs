using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class CatalogoPlu : ICatalogoPlu
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CatalogoPlu module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CatalogoPlu()
        {
            module = new Application.Enterprise.Data.CatalogoPlu();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CatalogoPlu(string databaseName)
        {
            module = new Application.Enterprise.Data.CatalogoPlu(databaseName);
        }

        #region Miembros de ICatalogoPlu
        /// <summary>
        /// Lista todos los catalogos x plus.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoPluInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los catalogos x plus x id Codigo Rapido x catalogo
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListxIdCodigoRapido(string IdCodigoRapido, string Catalogo)
        {
            return module.ListxIdCodigoRapido(IdCodigoRapido, Catalogo);
        }


        /// <summary>
        /// Lista un catalogo x plus x id Codigo Rapido x catalogo unico.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxIdCodigoRapidoUnico(string IdCodigoRapido, string Catalogo)
        {
            return module.ListxIdCodigoRapidoUnico(IdCodigoRapido, Catalogo);
        }

        /// <summary>
        /// Lista todos los catalogos x plus x catalogo
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListxIdCodigoRapidoxCatalogo(string Catalogo)
        {
            return module.ListxIdCodigoRapidoxCatalogo(Catalogo);
        }

        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogo(string IdCodigoRapido)
        {
            return module.ListxCodigoRapidoSinCatalogo(IdCodigoRapido);
        }

        /// <summary>
        /// Lista un articulo por codigo rapido digitado con dependencia de catalogo x zona.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogoxZona(string IdCodigoRapido, string Zona)
        {
            return module.ListxCodigoRapidoSinCatalogoxZona(IdCodigoRapido, Zona);
        }
        
        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo sin bloqueo de visible POS.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogoSinBloqueo(string IdCodigoRapido)
        {
            return module.ListxCodigoRapidoSinCatalogoSinBloqueo(IdCodigoRapido);
        }

        /// <summary>
        /// Lista todos los numeros de  catalogos 
        /// </summary>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListCatalogos()
        {
            return module.ListCatalogos ();
        }

        /// <summary>
        /// lista catalogos por numero de catalogo
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListXCatalogos(string catalogo)
        {
            return module.ListXCatalogos (catalogo);
        }

        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo inactivo x agotado anunciado.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogoAgotadoAnunciado(string IdCodigoRapido)
        {
            return module.ListxCodigoRapidoSinCatalogoAgotadoAnunciado(IdCodigoRapido);
        }


        /// <summary>
        /// Actualiza campo activo x plus Por catalog
        /// </summary>
        /// <param name="catalogo"></param>
        /// <param name="plu"></param>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaXPlu(string catalogo, int plu, int estado, string usuario)
        {
            return module.ActualizaXPlu (catalogo, plu, estado, usuario);
        }


        /// <summary>
        /// Actualiza campo activo de todos los catalogos
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaTodo(int estado, string usuario)
        {
            return module.ActualizaTodo (estado, usuario);
        }

        /// <summary>
        /// GAVL  Actualiza referencia de plu con Descuento
        /// </summary>
        /// <param name="catalogo"></param>
        /// <param name="unidad"></param>
        /// <param name="plu"></param>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaPluXUnidad(string catalogo, string unidad, int plu, int estado, string usuario)
        {
            bool Oktrans = false;
            //return module.ActualizaXPlu(catalogo, plu, estado, usuario);
            List<CatalogoPluInfo> lista = new List<CatalogoPluInfo>();
            string CatalogoReal="";
            string referencia="";
            bool KardexUnidad = false;


            try
            {      
                lista = module.ListCatalogosXplu(catalogo.Trim(), plu);
            

                foreach (CatalogoPluInfo item in lista)
                {
               
                        if (estado == 1)
                        {
                            if (Tools.Left(item.CatalogoReal.ToString().Trim(), 1) != "O")
                            {
                                CatalogoReal = "O" + item.CatalogoReal.ToString().Trim();
                            }
                            else
                            {
                                CatalogoReal = item.CatalogoReal.ToString().Trim();
                            }
                        }
                        else
                        {
                            if (Tools.Left(item.CatalogoReal.ToString().Trim(), 1) == "O")
                            {
                                CatalogoReal = Tools.Right(item.CatalogoReal.ToString().Trim(), item.CatalogoReal.Trim().Length - 1);
                            }
                            else
                            {
                                CatalogoReal = item.CatalogoReal.ToString().Trim();
                            }
                        }
                        referencia = item.Referencia.ToString().Trim();
                    
                }

                if (lista.Count != 0){
                    Oktrans = module.ActualizaCatalogoXPlu(CatalogoReal.Trim(), catalogo.Trim(), plu, usuario);
                }
                    


               

                if (Oktrans)
                {
                    Application.Enterprise.Business.Kardex Kardex = new Application.Enterprise.Business.Kardex("conexion");
                    KardexUnidad = Kardex.ActualizaUnidadXReferencia(referencia.Trim(), unidad, usuario);
                    Oktrans = KardexUnidad;
                }
                else
                {
                    return Oktrans;
                }

            }
            catch (Exception ex)
            {
                Oktrans= false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
               
            }
            return Oktrans;
        }

         /// <summary>
        /// Guarda cargue catalogo
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CatalogoPluInfo item, String usuario)
        {
            try
            {
                return module.Insert(item,usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }
        }

         /// <summary>
      /// obtener critero o unineg de siesa de un item.
      /// </summary>
      /// <param name="IdCodigoRapido"></param>
      /// <returns></returns>
        public CatalogoPluInfo itemcriterio(string IdCodigoRapido)
        {
            return module.itemcriterio(IdCodigoRapido);
        }

        /// <summary>
        /// obtiene un catalogoplu con los puntos
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo catalogoPlupuntos(string idcorto)
        {
            return module.catalogoPlupuntos(idcorto);
        }

        #endregion
    }
}
