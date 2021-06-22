using colibry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace colibry.Controllers
{
    public class OrdenesController : Controller
    {
        private ColibryDb db = new ColibryDb();
        // GET: Ordenes
        public ActionResult Index()
        {
            List<Orden> listaOrdenes = db.Ordenes.Where(s => s.Estado != -1).ToList();
            return View(listaOrdenes);
        }

        public ActionResult Orden(int ?id)
        {
            var orden = db.Ordenes.Where(s => s.Id == id).FirstOrDefault();
            return View(orden);
        }

        [HttpPost]
        public ActionResult Orden(Orden orden)
        {
            try
            {
                var id = orden.Id;
                if (id == 0)
                {
                    db.Ordenes.Add(orden);
                }
                else
                {
                    var ordenData = db.Ordenes.Find(orden.Id);
                    TryUpdateModel(ordenData, "", new string[] { 
                        "Sitio", "Fecha", "Direccion", 
                        "Tipo", "Latitud", "Longitud", 
                        "Altura", "Nivel_mar", "Tipo_ingreso", 
                        "Actividad", "Id_usuario"
                    });
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
        public ActionResult EliminarOrden(Orden orden)
        {
            try
            {
                var ordenData = db.Ordenes.Find(orden.Id);
                TryUpdateModel(ordenData, "", new string[] { "Estado" });
                db.SaveChanges();
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Gestion(int? id)
        {
            var orden = db.Ordenes.Where(o => o.Id == id).FirstOrDefault();
            return View(orden);
        }

    }
}