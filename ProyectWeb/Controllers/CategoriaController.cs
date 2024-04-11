using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class CategoriaController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Detalles(int id)
        {
            return View();
        }

        // Crear
        public ActionResult Crear()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Crear(FormCollection collection)
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

        
        public ActionResult Editar(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
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

        
        public ActionResult Eliminar(int id)
        {
            return View();
        }

        // Eliminar
        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
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
