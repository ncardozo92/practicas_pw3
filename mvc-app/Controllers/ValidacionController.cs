using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_app.Models;

namespace mvc_app.Controllers
{
    public class ValidacionController : Controller
    {
        // GET: Validacion
        public ActionResult Index()
        {
            return View(new Empleado());
        }

        [HttpPost]
        public string Validado(Empleado e)
        {
            if (ModelState.IsValid) //con esta instrucción determino que hacer de acuerdo al resultado de la validación
            {
                return "Todo está bien";
            }
            else
            {
                return "Todo está mal";
            }
        }
    }
}