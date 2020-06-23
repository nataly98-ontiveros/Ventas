using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class DevolucionController : Controller
    {
        // GET: Devolucion
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var cliente = db.Cliente.AsQueryable();
            return View(cliente);
        }

        // GET: Productos/Details
        [Authorize(Roles = "Empleado")]
        public ActionResult InfoSolicitud()
        {
            return View();

        }

        [Authorize(Roles = "Empleado")]
        public ActionResult InfoCompra()
        {
            return View();

        }

        [Authorize(Roles = "Empleado")]
        public ActionResult EditSolicitud(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Productos prod = db.Productos.Find(id);
            prod.Precio_Antiguo = prod.Precio_final;
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View("EditSolicitud", prod);

        }
        [HttpPost]
        [Authorize(Roles = "Empleado")]
        public ActionResult EditSolicitud(Productos prod)
        {

            if (ModelState.IsValid)
            {

                ApplicationDbContext db = new ApplicationDbContext();
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Devolucion");
            }

            return View(prod);

        }

    }
}