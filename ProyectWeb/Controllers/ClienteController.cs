using ProyectWeb.DataBase;
using ProyectWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectWeb.Controllers
{
    public class ClienteController : Controller

    {
        private ProyectoContext contex;
        public ClienteController()
        {
            contex = new ProyectoContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            contex.Dispose();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var Clientes = contex.Cliente.ToList();
            return View(Clientes);
        }
        public ActionResult Nuevo()
        {
            var cliente = new Cliente(); // Crear un nuevo objeto Cliente
            return View("ClienteForm", cliente); // Pasar el objeto Cliente a la vista
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                // Guardar el cliente en la base de datos
                contex.Cliente.Add(cliente);
                contex.SaveChanges();

                // Redirigir a la acción Index
                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, regresar a la vista con los errores
            return View("ClienteForm", cliente);
        }
        public ActionResult Editar(int id)
        {
            var cliente = contex.Cliente.FirstOrDefault(c => c.ClienteId == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View("ClienteForm", cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                // Actualizar el cliente en la base de datos
                contex.Entry(cliente).State = EntityState.Modified;
                contex.SaveChanges();

                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, regresar a la vista con los errores
            return View("ClienteForm", cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {


            var cliente = contex.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }


        public ActionResult Detalles(int id)
        {
            var cliente = contex.Cliente.FirstOrDefault(c => c.ClienteId== id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            var cliente = contex.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            contex.Cliente.Remove(cliente);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
