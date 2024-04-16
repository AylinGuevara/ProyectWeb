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
    public class FacturaController : Controller
    {
        private ProyectoContext dbContext  = new ProyectoContext();
        public ActionResult Index()
        {
            var factura = dbContext.Factura.Include(f => f.Cliente).Include(f => f.Pedido);
            return View(factura.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = dbContext.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(dbContext.Cliente, "ClienteId", "Codigo");
            ViewBag.PedidoId = new SelectList(dbContext.Pedido, "PedidoId", "PedidoId");
            return View(new Factura());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaId,ClienteId,PedidoId,FechaCreacion,FechaFactura,Estado,Total,SubTotal,Descuento")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                dbContext.Factura.Add(factura);
                dbContext.Factura.Add(factura);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(dbContext.Cliente, "ClienteId", "Codigo", factura.ClienteId);
            ViewBag.PedidoId = new SelectList(dbContext.Pedido, "PedidoId", "PedidoId", factura.PedidoId);
            return View(factura);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = dbContext.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(dbContext.Cliente, "ClienteId", "Codigo", factura.ClienteId);
            ViewBag.PedidoId = new SelectList(dbContext.Pedido, "PedidoId", "PedidoId", factura.PedidoId);
            return View(factura);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaId,ClienteId,PedidoId,FechaCreacion,FechaFactura,Estado,Total,SubTotal,Descuento")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(factura).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(dbContext.Cliente, "ClienteId", "Codigo", factura.ClienteId);
            ViewBag.PedidoId = new SelectList(dbContext.Pedido, "PedidoId", "PedidoId", factura.PedidoId);
            return View(factura);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = dbContext.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = dbContext.Factura.Find(id);
            dbContext.Factura.Remove(factura);
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
