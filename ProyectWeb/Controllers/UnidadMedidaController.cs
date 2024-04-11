using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class UnidadMedidaController : Controller
    {
        // GET: UnidadMedida
        public ActionResult Index()
        {
            return View();
        }

        // Detalles
        public ActionResult Details(int id)
        {
            return View();
        }

        // Crear
        public ActionResult Create()
        {
            return View();
        }

        // Crear
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
                // TODO: Add update logic here

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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
