using colibry.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [SessionCheck]
    public class AdminController : Controller
    {
        private ColibryDb db = new ColibryDb();
       
        public ActionResult Index()
        {
            string filtro_usuario = "";
            string filtro_total = "";

            filtro_usuario = Session["Id_rol"].Equals("2") ? " and id_usuario = " + Session["Id"] : filtro_usuario;
            filtro_usuario = Session["Id_rol"].Equals("3") ? " and id_coordinador = " + Session["Id"] : filtro_usuario;
            filtro_usuario = Session["Id_rol"].Equals("4") || Session["Id_rol"].Equals("1") ? " " : filtro_usuario;
            filtro_usuario = Session["Id_rol"].Equals("5") ? " and id_tecnico = " + Session["Id"] : filtro_usuario;

            filtro_total = Session["Id_rol"].Equals("2") ? " where id_usuario = " + Session["Id"] : filtro_total;
            filtro_total = Session["Id_rol"].Equals("3") ? " where id_coordinador = " + Session["Id"] : filtro_total;
            filtro_total = Session["Id_rol"].Equals("4") || Session["Id_rol"].Equals("1") ? " " : filtro_total;
            filtro_total = Session["Id_rol"].Equals("5") ? " where id_tecnico = " + Session["Id"] : filtro_total;

            var dashboard = db.Database.SqlQuery<Dashboard>("Select  " +
            "(Select count(id) from ordenes where estado = 2 " + filtro_usuario + ") num_asignado, " +
            "(Select count(id) from ordenes where estado = 5 " + filtro_usuario + ") num_rechazado, " +
            "(Select count(id) from ordenes where estado = 3 " + filtro_usuario + ") num_proceso, " +
            "(Select count(id) from ordenes where estado = 4 " + filtro_usuario + ") num_finalizado, " +
            "(Select count(id) from ordenes where estado = 1 ) num_nuevas, " +
            "(Select count(id) from ordenes " + filtro_total + ") num_total" ).ToList();
            ViewBag.Asignados = dashboard[0].num_asignado;
            ViewBag.Finalizados = dashboard[0].num_finalizado;
            ViewBag.Rechazado = dashboard[0].num_rechazado;
            ViewBag.Enproceso = dashboard[0].num_proceso;
            ViewBag.Nuevas = dashboard[0].num_nuevas;
            ViewBag.Total = dashboard[0].num_total;
            ViewBag.Abiertos = (dashboard[0].num_nuevas + dashboard[0].num_proceso + dashboard[0].num_asignado) > 0 && dashboard[0].num_total > 0 ? ((dashboard[0].num_nuevas + dashboard[0].num_proceso + dashboard[0].num_asignado)*100)/ dashboard[0].num_total:0;
            ViewBag.Cerrados = dashboard[0].num_finalizado > 0 ? (dashboard[0].num_finalizado * 100) / dashboard[0].num_total:0;
            ViewBag.Rechazados = dashboard[0].num_rechazado > 0 ? (dashboard[0].num_rechazado * 100) / dashboard[0].num_total:0;


            return View(dashboard);
        }

        public ActionResult Calendario()
        {
            string filtro_usuario = "";
            filtro_usuario = Session["Id_rol"].Equals("2") ? " where id_usuario = " + Session["Id"] : filtro_usuario;

            var listaOrdenes = db.Database.SqlQuery<Ordenes>("SELECT  id, sitio, fecha," +
                "case when estado = 1 or  estado = 2 then 'bg-primary' when estado = 3 then 'bg-warning'  when estado = 5 then 'bg-danger' when estado = 4 then 'bg-success' end className " +
                "FROM ordenes  " +
                filtro_usuario).ToList();

            var jsonOrdenes = Newtonsoft.Json.JsonConvert.SerializeObject(listaOrdenes);
            ViewBag.objOrdenes = jsonOrdenes;

            return View();
        }

        public ActionResult Ordenes()
        {
            string filtro_usuario = "";
            filtro_usuario = Session["Id_rol"].Equals("2") ? " where id_usuario = " + Session["Id"] : filtro_usuario;

            var listaOrdenes = db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico, " +
                "e.nombre nm_estado  " +
                "FROM ordenes o " +
                "left join estados e ON e.id = o.estado " +
                filtro_usuario).ToList();
            return View(listaOrdenes);
        }

        public ActionResult Orden(int? id)
        {
            var orden = db.Ordenes.Where(s => s.Id == id).FirstOrDefault();
            return View(orden);
        }

        [HttpPost]
        public ActionResult Orden(Orden orden)
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
            return RedirectToAction("Ordenes");
        }
        
        public ActionResult Gestionar(int id)
        {
            var ordenModel = db.Ordenes.Where(s => s.Id == id).FirstOrDefault();
            var orden = db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico, " +
                "e.nombre nm_estado,  " +
                "ti.nombre nm_tipo_ingreso,  " +
                "tt.nombre nm_tipo_torre  " +
                "FROM ordenes o " +
                "left join estados e ON e.id = o.estado " +
                "left join tipo_torre tt ON tt.id = o.tipo " +
                "left join tipo_ingreso ti ON ti.id = o.tipo_ingreso " +
                "where o.id =" + id).ToList();

            var coordinador = db.Usuarios.Select(u => new { u.Id, Nombre = u.Nombre + " " + u.Apellido, u.Id_rol }).Where(u => u.Id_rol.Equals("3"));
            var tecnico = db.Usuarios.Select(u => new { u.Id, Nombre = u.Nombre + " " + u.Apellido, u.Id_rol }).Where(u => u.Id_rol.Equals("5"));
            var lineabase1 = db.Lineabase.Where(l => l.Id_orden == id && l.Id_tipo_datos == 1).OrderBy(l=>l.Id_sector);
            var lineabase2 = db.Lineabase.Where(l => l.Id_orden == id && l.Id_tipo_datos == 2);
            var evidencias = db.Evidencias.Where(e => e.Tipo == 1 &&  e.Id_orden == id);
            var HSQ = db.Evidencias.Where(h => h.Tipo == 2 && h.Id_orden == id);

            var querySectores = db.Lineabase.Select(s => new {s.Id, s.Id_sector,s.Id_orden }).Where(s => s.Id_orden == id).OrderBy(s => s.Id_sector).GroupBy(s=>s.Id_sector);

            ViewBag.Coordinador = new SelectList(coordinador.AsEnumerable(), "Id", "Nombre");
            ViewBag.Tecnico = new SelectList(tecnico.AsEnumerable(), "Id", "Nombre");
            ViewBag.Orden = orden[0];
            ViewBag.id_orden = id;
            ViewBag.Lineabase1 = lineabase1;
            ViewBag.Lineabase2 = lineabase2;
            ViewBag.Sectores = querySectores;
            ViewBag.Evidencias = evidencias;
            ViewBag.HSQs = HSQ;

            return View(ordenModel);
        }

        [HttpPost]
        public ActionResult Gestionar(Orden orden)
        {
            try
            {
                var ordenData = db.Ordenes.Find(orden.Id);
                TryUpdateModel(ordenData, "", new string[] {
                    "Id_coordinador", "Id_tecnico", "Estado"
                });

                db.SaveChanges();
                return RedirectToAction("Ordenes");
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();

        }

        public ActionResult Aprobar(int id)
        {
            try
            {
                var ordenData = db.Ordenes.Find(id);
                ordenData.Estado = 4;
                TryUpdateModel(ordenData, "", new string[] { "Estado"});

                db.SaveChanges();
                return RedirectToAction("Gestionar", new { id = id });
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();

        }

        public ActionResult Rechazar(int id)
        {
            try
            {
                var ordenData = db.Ordenes.Find(id);
                ordenData.Estado = 5;
                TryUpdateModel(ordenData, "", new string[] { "Estado" });

                db.SaveChanges();
                return RedirectToAction("Gestionar", new { id = id });
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Evidencia(int Id, int Tipo, EvidenciaUpload evidenciaUpload)
        {
            
            var file = evidenciaUpload.Files[0];
           
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 10; //10 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                    string fileExt = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower();
                    if (!AllowedFileExtensions.Contains(fileExt))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        try {
                            //TO:DO
                            string typeAdd = Tipo == 1 ? "_Evidencia_" : "_HSQ_";
                            string nameAdd = "orden_" + Id + typeAdd + file.FileName;

                            var fileName = Path.GetFileName(nameAdd);
                            var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                            file.SaveAs(path);
                            ModelState.Clear();
                            ViewBag.Message = "Evidencia cargada satisfactoriamente";

                            Evidencia evidencia = new colibry.Models.Evidencia
                            {
                                Id_orden = Id,
                                Ruta = "~/Content/Upload/" + fileName,
                                Tamano = file.ContentLength ,
                                Tipo = Tipo,
                                Content = file.ContentType,
                                Nombre = fileName
                            };

                            db.Evidencias.Add(evidencia);

                            var ordenData = db.Ordenes.Find(Id);
                            ordenData.Estado = 3;
                            TryUpdateModel(ordenData, "", new string[] { "Estado" });
                            db.SaveChanges();

                        } catch (Exception e) {
                            ViewBag.Message = "Fallo carga de la evidencia";
                        }
                       

                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Gestionar", new { id = Id });
        }

        [HttpPost]
        public ActionResult Lineabase(Lineabase lineabase)
        {
            try
            {
                db.Lineabase.Add(lineabase);
                db.SaveChanges();

                var ordenData = db.Ordenes.Find(lineabase.Id_orden);
                ordenData.Estado = 3;
                TryUpdateModel(ordenData, "", new string[] { "Estado" });
                db.SaveChanges();

                return RedirectToAction("Gestionar", new { id = lineabase.Id_orden});

            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "No se pueden regisrrar los datos intenta nuevamente.");
            }
            return RedirectToAction("Gestionar", new { id = lineabase.Id_orden });
        }

        public ActionResult BorrarOrden(int id)
        {
            try
            {
                var orden = db.Ordenes.Find(id);
                db.Ordenes.Remove(orden);
                db.SaveChanges();
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Ordenes");
        }

        public ActionResult Usuarios()
        {
            string filtro_usuario = "";
            filtro_usuario = !Session["Id_rol"].Equals("1") ? " where u.id_rol != 1 "  : filtro_usuario;

            var listaUsuarios = db.Database.SqlQuery<User>(
                "SELECT  u.*, r.nombre rol,  u.id_rol idRol " +
                "FROM usuarios u  " +
                "inner join roles r on r.id = u.id_rol " +
                filtro_usuario +
                "order by u.id_rol asc ;").ToList();

            return View(listaUsuarios);
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
                    db.SaveChanges();
                }
                else
                {
                    var usuarioData = db.Usuarios.Find(usuario.Id);
                    TryUpdateModel(usuarioData, "", new string[] { "Nombre", "Apellido", "Email", "Username","Id_rol", "Estado" });
                    db.SaveChanges();
                    if (usuario.Password != null && usuario.Password !="") {
                        TryUpdateModel(usuarioData, "", new string[] { "Password" });
                        db.SaveChanges();
                    }
                }
               
                return RedirectToAction("Usuarios");
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }

        public ActionResult BorrarUsuario(int id)
        {
            try
            {
                Usuario usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Usuarios");
        }

        public ActionResult Intinerario()
        {
            string filtro_usuario = "";

            filtro_usuario = Session["Id_rol"].Equals("2") ? " and o.id_usuario = " + Session["Id"] : filtro_usuario;
            filtro_usuario = Session["Id_rol"].Equals("3") ? " and o.id_coordinador = " + Session["Id"] : filtro_usuario;
            filtro_usuario = Session["Id_rol"].Equals("4") || Session["Id_rol"].Equals("1") ? " ": filtro_usuario;
            filtro_usuario = Session["Id_rol"].Equals("5") ? " and o.id_tecnico = " + Session["Id"] : filtro_usuario;

            ViewBag.Creados = db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico," +
                " e.nombre nm_estado  " +
                "FROM ordenes o  " +
                "left join estados e ON e.id = o.estado " +
                "WHERE o.estado = 1 " + filtro_usuario + " order by o.fecha desc").ToList();


            ViewBag.Asignados =  db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico," +
                " e.nombre nm_estado  " +
                "FROM ordenes o  " +
                "left join estados e ON e.id = o.estado " +
                "WHERE o.estado = 2 "+filtro_usuario+" order by o.fecha desc").ToList();

            ViewBag.Gestionados = db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico, " +
                "e.nombre nm_estado  " +
                "FROM ordenes o  " +
                "left join estados e ON e.id = o.estado " +
                "WHERE o.estado = 3 " + filtro_usuario + " order by o.fecha desc").ToList();


            ViewBag.Rechazados = db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico, " +
                "e.nombre nm_estado  " +
                "FROM ordenes o  " +
                "left join estados e ON e.id = o.estado " +
                "WHERE o.estado = 5 " + filtro_usuario + " order by o.fecha desc").ToList();


            ViewBag.Finalizados = db.Database.SqlQuery<Ordenes>("SELECT  o.*, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_usuario) nm_usuario, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_coordinador) nm_coordinador, " +
                "(select CONCAT(nombre, ' ', apellido) from usuarios where id = o.id_tecnico) nm_tecnico, " +
                "e.nombre nm_estado  " +
                "FROM ordenes o  " +
                "left join estados e ON e.id = o.estado " +
                "WHERE o.estado = 4 " + filtro_usuario + " order by o.fecha desc").ToList();

            return View();
        }
    }
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["Id"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                                { "Controller", "Login" },
                                { "Action", "Index" }
                                });
            }
        }
    }
}
