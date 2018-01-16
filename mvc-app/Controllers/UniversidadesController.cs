using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_app.Models;

namespace mvc_app.Controllers
{
    public class UniversidadesController : Controller
    {
        private UniversidadNegocio un = new UniversidadNegocio();
        // GET: Universidades
        public ActionResult Inicio()
        {

            return View();
        }

        public ActionResult Crear()
        {

            return View();
        }

        public ActionResult Nueva()//binding automatico, se instancia el objeto y el controlador matcheara los campos de la peticion con el objeto
        {
            Universidad u = new Universidad();

            u.Id = un.ContarTodas() + 1;
            u.Nombre = Request["nombre"];
            u.CantidadCarreras = int.Parse(Request["CatidadCarreras"]);
            u.Direccion = Request["direccion"];

            un.Add(u);

            return RedirectToAction("Inicio");
        }

        public ActionResult Actualizar(int id)
        {
            
            return View(un.BuscarUniversidad(id));
        }

        [HttpPost]
        public ActionResult Update()
        {
            Universidad u = new Universidad();
            
            u.Id = int.Parse(Request["id"]);
            u.CantidadCarreras = int.Parse(Request["CatidadCarreras"]);
            u.Direccion = Request["direccion"];
            u.Nombre = Request["npmbre"];

            un.Update(u);

            return RedirectToAction("Inicio");
        }

        public ActionResult Eliminar(int id)
        {
            
            un.Delete(id);

            return RedirectToAction("Inicio");
        }

        public ActionResult Lista()
        {
            UniversidadNegocio un = new UniversidadNegocio();

            return View(un.ListarTodas());
        }
    }
}