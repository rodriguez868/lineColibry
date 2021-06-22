using colibry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace colibry.Controllers
{
    public class UsuariosController : Controller
    {
        private ColibryDb db = new ColibryDb();

        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuario> usuariosResult = db.Usuarios.Where(s => s.Estado != -1).ToList();
            return View(usuariosResult);

        }
        public ActionResult Usuario(int? Id)
        {
            var usuario = db.Usuarios.Where(s => s.Id == Id).FirstOrDefault();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Usuario(Usuario usuario)
        {
            try
            {
                var id = usuario.Id;
                if (id == 0)
                {
                    db.Usuarios.Add(usuario);
                }
                else
                {
                    var usuarioData = db.Usuarios.Find(usuario.Id);
                    TryUpdateModel(usuarioData, "", new string[] { "Nombre", "Lastname", "Email", "Username", "Password", "Id_rol", "Estado" });
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();

        }

        [HttpPost]
        public ActionResult BorrarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioData = db.Usuarios.Find(usuario.Id);
                TryUpdateModel(usuarioData, "", new string[] { "Estado" });
                db.SaveChanges();
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Index");

        }
    }

}