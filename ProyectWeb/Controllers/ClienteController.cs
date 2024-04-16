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
    public class ClienteController : Controller
    {
        private ProyectoContext context = new ProyectoContext();

        public ActionResult Index()
        {
            var cliente = context.Cliente.Include(c => c.CondicionPago).Include(c => c.GrupoDescuento);
            return View(cliente.ToList());
        }

        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Create()
        {
            ViewBag.CondicionPagoId = new SelectList(context.CondicionPago, "CondicionPagoId", "Codigo");
            ViewBag.GrupoDescuentoId = new SelectList(context.GrupoDescuento, "GrupoDescuentoId", "Codigo");
            return View(new Cliente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Codigo,Nombres,Apellidos,GrupoDescuentoId,CondicionPagoId,Estado,FechaCreacion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondicionPagoId = new SelectList(context.CondicionPago, "CondicionPagoId", "Codigo", cliente.CondicionPagoId);
            ViewBag.GrupoDescuentoId = new SelectList(context.GrupoDescuento, "GrupoDescuentoId", "Codigo", cliente.GrupoDescuentoId);
            return View(cliente);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondicionPagoId = new SelectList(context.CondicionPago, "CondicionPagoId", "Codigo", cliente.CondicionPagoId);
            ViewBag.GrupoDescuentoId = new SelectList(context.GrupoDescuento, "GrupoDescuentoId", "Codigo", cliente.GrupoDescuentoId);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ClienteId,Codigo,Nombres,Apellidos,GrupoDescuentoId,CondicionPagoId,Estado,FechaCreacion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicionPagoId = new SelectList(context.CondicionPago, "CondicionPagoId", "Codigo", cliente.CondicionPagoId);
            ViewBag.GrupoDescuentoId = new SelectList(context.GrupoDescuento, "GrupoDescuentoId", "Codigo", cliente.GrupoDescuentoId);
            return View(cliente);
        }

        public ActionResult Elimar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Cliente cliente = context.Cliente.Find(id);
            context.Cliente.Remove(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
