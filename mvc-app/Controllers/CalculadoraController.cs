using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_app.Controllers
{
    public class CalculadoraController : Controller
    {

        
        public ActionResult Valores()
        {
            
            return View();
        }
        
        [HttpPost]
        public ActionResult Suma()
        {
            if (Request["val1"] != null && Request["val2"] != null)
                ViewBag.resultado = Int32.Parse(Request["val1"]) + Int32.Parse(Request["val2"]);

            return View();
        }

    }
}