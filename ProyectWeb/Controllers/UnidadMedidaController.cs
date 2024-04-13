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
    public class UnidadMedidaController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        public ActionResult Index()
        {
            return View(db.UnidadMedida.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedida unidadMedida = db.UnidadMedida.Find(id);
            if (unidadMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedida);
        }

     
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnidadMedidaId,Codigo,Descripcion,Estado,FechaCreacion")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadMedida.Add(unidadMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadMedida);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedida unidadMedida = db.UnidadMedida.Find(id);
            if (unidadMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedida);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnidadMedidaId,Codigo,Descripcion,Estado,FechaCreacion")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadMedida);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedida unidadMedida = db.UnidadMedida.Find(id);
            if (unidadMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedida);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadMedida unidadMedida = db.UnidadMedida.Find(id);
            db.UnidadMedida.Remove(unidadMedida);
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
