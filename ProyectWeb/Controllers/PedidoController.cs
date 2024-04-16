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
    public class PedidoController : Controller
    {
        private ProyectoContext Context = new ProyectoContext();

        public ActionResult Index()
        {
            var pedido = Context.Pedido.Include(p => p.Cliente);
            return View(pedido.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = Context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(Context.Cliente, "ClienteId", "Codigo");
            return View(new Pedido());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,ClienteId,FechaCreacion,FechaPedido,Estado,Total,SubTotal,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                Context.Pedido.Add(pedido);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(Context.Cliente, "ClienteId", "Codigo", pedido.ClienteId);
            return View(pedido);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = Context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(Context.Cliente, "ClienteId", "Codigo", pedido.ClienteId);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,ClienteId,FechaCreacion,FechaPedido,Estado,Total,SubTotal,Descuento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(pedido).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(Context.Cliente, "ClienteId", "Codigo", pedido.ClienteId);
            return View(pedido);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = Context.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = Context.Pedido.Find(id);
            Context.Pedido.Remove(pedido);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
