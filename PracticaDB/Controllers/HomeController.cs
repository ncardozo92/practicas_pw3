using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new equipodbEntities())
            {
                List<Equipos> listaEquipos = context.Equipos.OrderBy(e => e.FechaCreacion).ToList();

                return View(listaEquipos);
            }
            
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Add(Equipos Equipo)
        {
            if (ModelState.IsValid)
            {
                using (var context = new equipodbEntities())
                {

                    context.Equipos.Add(Equipo);
                    context.SaveChanges();
                }

                return RedirectToAction("index");
            }
            else return View("Add", Equipo);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {

            using(var context = new equipodbEntities())
            {
                Equipos Equipo = context.Equipos.Find(id);
                return View(Equipo);
            }
        }

        [HttpPost]
        public ActionResult Editar(Equipos EquipoEditado)
        {

            using (var context = new equipodbEntities())
            {

                Equipos EquipoAEditar = context.Equipos.Find(EquipoEditado.Id);

                EquipoAEditar.Nombre = EquipoEditado.Nombre;
                EquipoAEditar.CantidadIntegrantes = EquipoEditado.CantidadIntegrantes;
                EquipoAEditar.FechaCreacion = EquipoEditado.FechaCreacion;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar( int id)
        {

            using( var context = new equipodbEntities())
            {

                Equipos EquipoAEliminar = context.Equipos.Find(id);

                return View(EquipoAEliminar);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(Equipos Equipo)
        {

            using(var context = new equipodbEntities())
            {

                Equipos EquipoAEliminar = context.Equipos.Find(Equipo.Id);
                context.Equipos.Remove(EquipoAEliminar);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



            //consumo de un servicio

            public string ConsumoDeServicio()
        {

            using (var servicio = new ServiceReference1.UnServicioSoapClient())
            {

                return servicio.HelloWorld();
            }

        }

    }
}