using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class UnidadMedidaController : Controller
    {
        public UnidadMedidaController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Detalles(int id)
        {
            return View();
        }

       
        public ActionResult Crear()
        {
            return View();
        }

        // Crear
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

        //Editar
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

        
        public ActionResult eliminar(int id)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult eliminar(int id, FormCollection collection)
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
