using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class CondicionPagoController : Controller
    {
        // GET: CondicionPago
        public ActionResult Index()
        {
            return View();
        }

        // GET: CondicionPago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CondicionPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicionPago/Create
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

        // GET: CondicionPago/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CondicionPago/Edit/5
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

        // GET: CondicionPago/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CondicionPago/Delete/5
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
