using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_app.Controllers
{
    public class FechaController : Controller
    {
        // GET: Fecha
        public ActionResult MiFecha(int dia, int mes, int anio)
        {
            ViewBag.dia = dia;
            ViewBag.mes = mes;
            ViewBag.anio = anio;

            return View();
        }
    }
}