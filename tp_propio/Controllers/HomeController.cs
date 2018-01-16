using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using tp_propio.Models;
using tp_propio.Services;

namespace tp_propio.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioService UsuarioService = new UsuarioService();
        private PaqueteService PaqueteService = new PaqueteService();

        public ActionResult Index()
        {
            List<Paquete> PaquetesDestacados = PaqueteService.GetDestacados();
            return View(PaquetesDestacados);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Login(Usuario UsuarioRecibido)
        {

            if (!ModelState.IsValid)
            {
                return View("Login", UsuarioRecibido);
                
            }
            else
            {
                Usuario UsuarioAutenticado = UsuarioService.GetUsuario(UsuarioRecibido);
                    if (UsuarioAutenticado != null)
                    {
                        //datos de usuario cargados en sesion
                        Session["Id"] = UsuarioAutenticado.Id;
                        Session["IsAdmin"] = UsuarioAutenticado.Admin;
                        Session["Nombre"] = UsuarioAutenticado.Nombre;
                        Session["Apellido"] = UsuarioAutenticado.Apellido;
                        Session["Email"] = UsuarioAutenticado.Email;
                        Session["Contrasenia"] = UsuarioAutenticado.Contrasenia;

                    if (UsuarioAutenticado.Admin)
                        {
                        return Redirect("/admin/paquetes/index");
                        }
                        else
                        {
                        return Redirect("/Paquetes/Historial");
                        }
                        
                    }
                    else //en caso de que la autenticacion falle
                    {
                        ViewBag.NotFound = 1;
                        return View("Login", UsuarioRecibido);
                    }
                
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Index");
        }
    }
}