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
    public class PedidoDetalleController : Controller
    {
        private ProyectoContext db = new ProyectoContext();
        public ActionResult Index()
        {
            var pedidoDetalle = db.PedidoDetalle.Include(p => p.Pedido).Include(p => p.Producto);
            return View(pedidoDetalle.ToList());
        }
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            return View(pedidoDetalle);
        }
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedido, "PedidoId", "PedidoId");
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId");
            return View(new PedidoDetalle());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoDetalleId,PedidoId,FechaCreacion,ProductoId,Precio,Total,SubTotal,Descuento")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                db.PedidoDetalle.Add(pedidoDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedido, "PedidoId", "PedidoId", pedidoDetalle.PedidoId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId", pedidoDetalle.ProductoId);
            return View(pedidoDetalle);
        }
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedido, "PedidoId", "PedidoId", pedidoDetalle.PedidoId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId", pedidoDetalle.ProductoId);
            return View(pedidoDetalle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "PedidoDetalleId,PedidoId,FechaCreacion,ProductoId,Precio,Total,SubTotal,Descuento")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedido, "PedidoId", "PedidoId", pedidoDetalle.PedidoId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "ProductoId", pedidoDetalle.ProductoId);
            return View(pedidoDetalle);
        }
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            return View(pedidoDetalle);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            PedidoDetalle pedidoDetalle = db.PedidoDetalle.Find(id);
            db.PedidoDetalle.Remove(pedidoDetalle);
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
