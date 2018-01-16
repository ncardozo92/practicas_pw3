using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_app.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Inicio()
        {
            return View();//si no se especifica el nombre de una vista, .NET busca la vista con el mismo nombre que el action
        }
    }
}