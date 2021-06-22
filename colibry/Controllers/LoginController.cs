using colibry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private ColibryDb db = new ColibryDb();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String user, String pass)
        {
            //var usuario = db.Usuarios.Where(s => (s.Username.Equals(user) && s.Password.Equals(pass)) ).FirstOrDefault();
            var usuario = db.Database.SqlQuery<User>(
                "SELECT  u.*, r.nombre rol,  u.id_rol idRol " +
                "FROM usuarios u  inner join roles r on r.id = u.id_rol " +
                "WHERE u.username = '"+ user + "' AND u.password = '"+ pass + "';").ToList();

            if (usuario != null && usuario.Count > 0)
            {
                Session["Id"] = usuario[0].Id;
                Session["Username"] = usuario[0].Username;
                Session["Id_rol"] = usuario[0].Id_rol;
                Session["NombreCompleto"] = (usuario[0].Nombre+" "+usuario[0].Apellido);
                Session["Nombre"] = usuario[0].Nombre;
                Session["Apellido"] = usuario[0].Apellido;
                Session["Rol"] = usuario[0].Rol;

                return RedirectToAction("Index","Admin","");
            }
            else {
                return RedirectToAction("index");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.AddHeader("Cache-control", "no-store, must-revalidate, private, no-cache");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Expires", "0");
            Response.AppendToLog("window.location.reload();");
            Session.Clear();
            Session.RemoveAll();

            return RedirectToAction("Index");
        }

        // GET: Registro de Usuario
        public ActionResult Registro()
        {
            return View();
        }

    }
}
