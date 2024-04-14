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
        public ActionResult Index()
        {
            return View(db.GrupoDescuento.ToList());
        }
        public ActionResult Details(int? id)
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
        public ActionResult Create()
        {
            return View(new GrupoDescuento());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoDescuentoId,Codigo,Descripcion,Estado,Porcentaje,FechaCreacion")] GrupoDescuento grupoDescuento)
        {
            if (ModelState.IsValid)
            {
                db.GrupoDescuento.Add(grupoDescuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoDescuento);
        }
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "GrupoDescuentoId,Codigo,Descripcion,Estado,Porcentaje,FechaCreacion")] GrupoDescuento grupoDescuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoDescuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoDescuento);
        }
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
