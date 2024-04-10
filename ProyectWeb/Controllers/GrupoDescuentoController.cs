using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class GrupoDescuentoController : Controller
    {
        // GET: GrupoDescuento
        public ActionResult Index()
        {
            return View();
        }

        // GET: GrupoDescuento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GrupoDescuento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoDescuento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrupoDescuento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GrupoDescuento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrupoDescuento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GrupoDescuento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
