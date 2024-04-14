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
    public class CondicionPagoController : Controller
    {
        private ProyectoContext dbContext = new ProyectoContext();

        public ActionResult Index()
        {
            return View(dbContext.CondicionPago.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionPago condicionPago = dbContext.CondicionPago.Find(id);
            if (condicionPago == null)
            {
                return HttpNotFound();
            }
            return View(condicionPago);
        }
        public ActionResult Create()
        {
            return View(new CondicionPago());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CondicionPagoId,Codigo,Descripcion,Estado,Dias,FechaCreacion")] CondicionPago condicionPago)
        {
            if (ModelState.IsValid)
            {
                dbContext.CondicionPago.Add(condicionPago);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicionPago);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionPago condicionPago = dbContext.CondicionPago.Find(id);
            if (condicionPago == null)
            {
                return HttpNotFound();
            }
            return View(condicionPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CondicionPagoId,Codigo,Descripcion,Estado,Dias,FechaCreacion")] CondicionPago condicionPago)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(condicionPago).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicionPago);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionPago condicionPago = dbContext.CondicionPago.Find(id);
            if (condicionPago == null)
            {
                return HttpNotFound();
            }
            return View(condicionPago);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondicionPago condicionPago = dbContext.CondicionPago.Find(id);
            dbContext.CondicionPago.Remove(condicionPago);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
