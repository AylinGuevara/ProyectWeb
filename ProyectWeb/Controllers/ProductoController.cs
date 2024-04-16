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
    public class ProductoController : Controller
    {
        private ProyectoContext Context = new ProyectoContext();

        public ActionResult Index()
        {
            var producto = Context.Producto.Include(p => p.Categoria).Include(p => p.UnidadMedida);
            return View(producto.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = Context.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(Context.Categoria, "CategoriaId", "Codigo");
            ViewBag.UnidadMedidaId = new SelectList(Context.UnidadMedida, "UnidadMedidaId", "Codigo");
            return View(new Producto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,CategoriaId,UnidadMedidaId,FechaCreacion,Estado,PrecioCompra")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                Context.Producto.Add(producto);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(Context.Categoria, "CategoriaId", "Codigo", producto.CategoriaId);
            ViewBag.UnidadMedidaId = new SelectList(Context.UnidadMedida, "UnidadMedidaId", "Codigo", producto.UnidadMedidaId);
            return View(producto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = Context.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(Context.Categoria, "CategoriaId", "Codigo", producto.CategoriaId);
            ViewBag.UnidadMedidaId = new SelectList(Context.UnidadMedida, "UnidadMedidaId", "Codigo", producto.UnidadMedidaId);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,CategoriaId,UnidadMedidaId,FechaCreacion,Estado,PrecioCompra")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(producto).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(Context.Categoria, "CategoriaId", "Codigo", producto.CategoriaId);
            ViewBag.UnidadMedidaId = new SelectList(Context.UnidadMedida, "UnidadMedidaId", "Codigo", producto.UnidadMedidaId);
            return View(producto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = Context.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = Context.Producto.Find(id);
            Context.Producto.Remove(producto);
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
