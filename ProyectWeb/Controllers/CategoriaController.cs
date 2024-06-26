﻿using System;
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
    public class CategoriaController : Controller
    {
      ProyectoContext context;

        public CategoriaController()
        {
            context = new ProyectoContext();
        }

        public ActionResult Index()
        {
            return View(context.Categoria.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

       
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,Codigo,Descripcion,Estado,FechaCreacion")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Codigo,Descripcion,Estado,FechaCreacion")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = context.Categoria.Find(id);
            context.Categoria.Remove(categoria);
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
