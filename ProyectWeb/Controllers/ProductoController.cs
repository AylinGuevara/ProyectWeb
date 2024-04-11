using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        //DEtalles
        public ActionResult Details(int id)
        {
            return View();
        }

        // Crear
        public ActionResult Create()
        {
            return View();
        }

        // crear
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Editar
        public ActionResult Edit(int id)
        {
            return View();
        }

        //Editar
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
             

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // eliminar
        public ActionResult Delete(int id)
        {
            return View();
        }

        // eliminar
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
