using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp_propio.Models;
using tp_propio.Services;

namespace tp_propio.Controllers
{
    
    public class AdminController : Controller
    {
        private string UrlLogin = "/Home/Login";
        private PaqueteService PaqueteService = new PaqueteService();
        private ReservaService ReservaService = new ReservaService();

        public bool AutorizarAdmin()
        {
            if (Session["IsAdmin"] == null)
            {
                return false;
            }
            else 
            {
                return (bool)Session["IsAdmin"];
            }
        }
        
        public ActionResult Index(int Page = 1, int PageItems = 5)
        {
            if (!AutorizarAdmin())
                return Redirect(UrlLogin);

                int PaginasTotales;
                int PaquetesTotales = PaqueteService.ContarPaquetes();

                if (PaquetesTotales % PageItems == 0)
                {
                    PaginasTotales = PaquetesTotales / PageItems;
                }
                else
                {
                    PaginasTotales = (PaquetesTotales / PageItems) + 1;
                }

                if (Request.QueryString["PaqueteEliminado"] != null)
                    ViewData["eliminado"] = Request.QueryString["PaqueteEliminado"];

                if (Request.QueryString["paqueteActualizado"] != null)
                    ViewData["actualizado"] = Request.QueryString["paqueteActualizado"];

                if (Request.QueryString["paqueteCreado"] != null)
                    ViewData["creado"] = Request.QueryString["paqueteCreado"];



                return View(
                    new GrillaAdminViewModel
                    {
                        Paquetes = PaqueteService.getPaquetes(Page, PageItems),
                        Paginas = PaginasTotales,
                        PaginaActual = Page
                    }
                    );
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            if (AutorizarAdmin())
                return View();
            else
                return Redirect(UrlLogin);
        }
        
        [HttpPost]
        public ActionResult Nuevo(Paquete p, HttpPostedFileBase File)
        {
            if (AutorizarAdmin())
            {
                //verifico si la foto fue cargada
                if (File != null)
                {
                    string path = Server.MapPath("~/imagenes/");
                    string fileName = Path.GetFileName(File.FileName);

                    File.SaveAs(path + fileName);

                    p.Foto = fileName; //asegurarse de que esta linea de codigo anda
                }
                else
                {
                    ViewBag.FileUploadError = "El paquete debe tener una foto descriptiva";

                    return View(p);
                }

                if (!ModelState.IsValid)
                {
                    return View(p);
                }
                else
                {


                    if (PaqueteService.Add(p))
                    {

                        return Redirect(string.Concat("/Admin/Paquetes/index?paqueteCreado=", p.Nombre));
                    }
                    else
                    {
                        return View(p);
                    }

                }
            }
            else
                return Redirect(UrlLogin);
        }

        [HttpGet]
        public ActionResult Editar(long id)
        {
            if (AutorizarAdmin())
            {
                ViewBag.Accion = "Editar";

                return View(PaqueteService.GetPaquete(id));
            }
            else return Redirect(UrlLogin);
        }

        [HttpPost]
        public ActionResult Editar(Paquete p,/*int id, */HttpPostedFileBase File)//en desarrollo
        {
            if (AutorizarAdmin())
            {
                if (!ModelState.IsValid)
                {
                    return View(p);
                }
                else
                {
                    if (File != null)
                    {
                        //primero elimino la foto que esta almacenada
                        string path = Server.MapPath("~/imagenes/");
                        string PreviousFileName = PaqueteService.GetPaquete(p.Id).Foto;


                        System.IO.File.Delete(path + PreviousFileName);

                        //ahora cargo el nuevo archivo
                        string fileName = Path.GetFileName(File.FileName);

                        File.SaveAs(path + fileName);

                        p.Foto = fileName;
                    }


                    if (PaqueteService.Actualizar(p))
                    {
                        return Redirect(string.Concat("/Admin/Paquetes/index?paqueteActualizado=", p.Nombre));
                    }
                    else
                    {
                        return View(p);
                    }
                }
            }
                else return Redirect(UrlLogin);

        }
        
        //REfactorizar para mejorar
        [HttpGet]
        public ActionResult Eliminar(long id)
        {
            if (AutorizarAdmin())
                return View(PaqueteService.GetPaquete(id));
            else
                return Redirect(UrlLogin);
        }

        [HttpPost]
        public ActionResult Eliminar(Paquete p)
        {
            if (AutorizarAdmin())
            {
                Paquete Paquete = PaqueteService.GetPaquete(p.Id);

                try
                {
                    string path = Server.MapPath("~/imagenes/");
                    string FileName = Paquete.Foto;


                    System.IO.File.Delete(path + FileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                ReservaService.EliminarReservas(p.Id);

                PaqueteService.Eliminar(Paquete);
                return Redirect(string.Concat("/admin/paquetes/index?PaqueteEliminado=", Paquete.Nombre));
            }
            else
                return Redirect(UrlLogin);
        }
        
        
    }
}