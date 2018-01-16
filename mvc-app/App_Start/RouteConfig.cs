using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc_app
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Fecha",
                url : "Fecha/{dia}/{mes}/{anio}",
                defaults: new { controller = "fecha", action = "MiFecha"}
                );
            
            routes.MapRoute(

                name: "Calculadora",
                url: "Calculadora",
                defaults: new { controller = "Calculadora", action = "Valores" }
                );

            routes.MapRoute(

                name: "Validacion",
                url: "Validacion",
                defaults: new { controller = "Validacion", action = "Index" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ventas", action = "Inicio", id = UrlParameter.Optional }
            );
        }
    }
}
