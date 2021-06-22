using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }

        public ActionResult Funciones()
        {
            ViewBag.Message = "Funciones";
            return View();
        }

        public ActionResult Ventajas()
        {
            ViewBag.Message = "Ventajas";
            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contactos()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Ayuda()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Terminos()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Servicios()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}