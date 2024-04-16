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
    public class FacturaDetalleController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

      
        public ActionResult Index()
        {
            var facturaDetalle = db.FacturaDetalle.Include(f => f.Factura).Include(f => f.Producto);
            return View(facturaDetalle.ToList());
        }

        
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalle.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

       
        public ActionResult Create()
        {
            ViewBag.FacturaId = new SelectList(db.Factura, "FacturaId", "FacturaId");
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId");
            return View(new FacturaDetalle());
        }

           [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaDetalleId,FacturaId,FechaCreacion,ProductoId,Precio,Total,SubTotal,Descuento")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.FacturaDetalle.Add(facturaDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacturaId = new SelectList(db.Factura, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId", facturaDetalle.ProductoId);
            return View(facturaDetalle);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalle.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacturaId = new SelectList(db.Factura, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId", facturaDetalle.ProductoId);
            return View(facturaDetalle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "FacturaDetalleId,FacturaId,FechaCreacion,ProductoId,Precio,Total,SubTotal,Descuento")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacturaId = new SelectList(db.Factura, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId", facturaDetalle.ProductoId);
            return View(facturaDetalle);
        }

        
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalle.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            FacturaDetalle facturaDetalle = db.FacturaDetalle.Find(id);
            db.FacturaDetalle.Remove(facturaDetalle);
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
