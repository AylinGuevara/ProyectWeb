using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectWeb.DataBase;
using ProyectWeb.Models;

namespace ProyectWeb.Controllers
{
    public class GrupoDescuentoController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        public GrupoDescuentoController()
        {
            
        }
        public ActionResult Index()
        {
            return View(db.GrupoDescuento.ToList());
        }

       
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoDescuento grupoDescuento = db.GrupoDescuento.Find(id);
            if (grupoDescuento == null)
            {
                return HttpNotFound();
            }
            return View(grupoDescuento);
        }

       
        public ActionResult Crear()
        {
            return View();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "GrupoDescuentoId,Codigo,Descripcion,Estado,Porcentaje,FechaCreacion")] GrupoDescuento grupoDescuento)
        {
            if (ModelState.IsValid)
            {
                db.GrupoDescuento.Add(grupoDescuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoDescuento);
        }

        
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoDescuento grupoDescuento = db.GrupoDescuento.Find(id);
            if (grupoDescuento == null)
            {
                return HttpNotFound();
            }
            return View(grupoDescuento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "GrupoDescuentoId,Codigo,Descripcion,Estado,Porcentaje,FechaCreacion")] GrupoDescuento grupoDescuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoDescuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoDescuento);
        }

        
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoDescuento grupoDescuento = db.GrupoDescuento.Find(id);
            if (grupoDescuento == null)
            {
                return HttpNotFound();
            }
            return View(grupoDescuento);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            GrupoDescuento grupoDescuento = db.GrupoDescuento.Find(id);
            db.GrupoDescuento.Remove(grupoDescuento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
