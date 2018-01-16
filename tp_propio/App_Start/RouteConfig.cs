using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace tp_propio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //rutas de administrador
            routes.MapRoute(

                name: "GrillaAdmin",
                url: "admin/paquetes/index/{page}",
                defaults: new {controller = "Admin", action = "Index", page = UrlParameter.Optional}
            );

            routes.MapRoute(

                name: "AltaPaquete",
                url: "admin/paquetes/nuevo",
                defaults: new { controller = "Admin", action = "Nuevo"}
            );

            routes.MapRoute(

                name: "EditarPaquete",
                url: "admin/paquetes/editar/{id}",
                defaults: new { controller = "Admin", action = "Editar" }
            );

            routes.MapRoute(

                name: "EliminarProducto",
                url: "admin/paquetes/eliminar/{id}",
                defaults: new { controller = "Admin", action = "Eliminar", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
