using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_app.Controllers
{
    public class VistasController : Controller
    {
        // GET: Vistas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult parcial()
        {

            return null;
        }
    }
}