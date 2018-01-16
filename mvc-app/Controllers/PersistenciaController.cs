using mvc_app.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_app.Controllers
{
    public class PersistenciaController : Controller
    {
        // GET: Persistencia

        private Contexto ctx = new Contexto();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Persona p)
        {

            
            this.ctx.Persona.Add(p);
            this.ctx.SaveChanges();
            

            
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int id)
        {

            return View("Index",this.ctx.Persona.Find(id));
        }

        [HttpPost]
        public ActionResult Actualizar(Persona PersonaActualizada) {

            //Siempre para actualizar hay que primero traer el registro, luego cargar los datos nuevos en el, y terminar con context.SaveChanges();
            Persona Persona = this.ctx.Persona.Find(PersonaActualizada.id);

            Persona.nombre = PersonaActualizada.nombre;
            Persona.email = PersonaActualizada.email;

            this.ctx.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult eliminar(int id)
        {
            Persona personaAEliminar = this.ctx.Persona.Find(id);
            this.ctx.Persona.Remove(personaAEliminar);

            this.ctx.SaveChanges();


            return RedirectToAction("Index");
        }




        public ActionResult Listado()
        {
            

            return View(this.ctx.Persona.ToList());
        }
    }

    
}