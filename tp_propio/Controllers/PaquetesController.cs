using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp_propio.Models;
using tp_propio.Services;

namespace tp_propio.Controllers
{
    public class PaquetesController : Controller
    {
        private string UrlLogin = "/Home/Login";

        private PaqueteService PaqueteService = new PaqueteService();
        private ReservaService ReservaService = new ReservaService();

        private bool AutorizarUsuario()
        {
            if (Session["Id"] != null)
            {
                if (Session["IsAdmin"] != null)
                    return !(bool)Session["IsAdmin"]; //se niega porque necesito que NO SEA ADMIN
                else
                    return false;
            }
            else return false;

        }

        public ActionResult Index()
        {
            return View("Paquetes");
        }

        [HttpGet]
        public ActionResult Detalles()
        {
            int id;
            int.TryParse(Request.QueryString["idPaquete"], out id);

            return View(PaqueteService.GetPaquete(id));
        }

        public ActionResult Historial()
        {
            if (AutorizarUsuario())
            {
                int IdUsuario = (int)(Session["Id"]);

                List<Reserva> Reservas = ReservaService.GetReservas(IdUsuario);
                return View(Reservas);
            }
            else return Redirect(UrlLogin);
        }

        [HttpGet]
        public ActionResult Reservar(int id)
        {
            

            Paquete PaqueteReservado = PaqueteService.GetPaquete(id);
            Reserva Reserva = new Reserva();

            ViewBag.NombrePaquete = PaqueteReservado.Nombre;
            Reserva.IdPaquete = PaqueteReservado.Id;
            
            /*
            ReservaViewModel ViewModel = new ReservaViewModel
            {
                Paquete = PaqueteService.GetPaquete(id)
            };
            */
            return View(Reserva);
        }
        
        [HttpPost]
        public ActionResult Reservar(Reserva Reserva)
        {
            //Usuario Usuario = (Usuario)Session["Usuario"];
            if (AutorizarUsuario())
            {
                Reserva.FechaCreacion = DateTime.Now;
                Reserva.IdUsuario = (int)Session["Id"];

                if (ReservaService.AddReserva(Reserva))
                {
                    return RedirectToAction("Historial");
                }
                else
                {
                    return View(Reserva);
                }
            }
            else return Redirect(UrlLogin);
        }

        [HttpPost]
        public JsonResult CancelarReserva(int Id)
        {
            if (AutorizarUsuario())
                return Json(new { eliminado = ReservaService.Cancelar(Id) });
            else return null;
        }
        
       
    }
}