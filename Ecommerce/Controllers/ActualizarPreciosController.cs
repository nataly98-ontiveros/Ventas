using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ActualizarPreciosController : Controller
    {
        // GET: ActualizarPrecios
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var productos = db.Productos.AsQueryable().Where(p => p.Status.Equals(3));            

            return View(productos);
        }

        public ActionResult EditDesc()
        {
            return View();
        }

        // GET: Productos/Details
        [Authorize(Roles = "Empleado")]
        public ActionResult Details(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Productos produc = db.Productos.Find(id);

            return View(produc);

        }

        // POST: AUCTUALIZAR PRODUCTOS
        [Authorize(Roles = "Empleado")]
        public ActionResult EditS(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Productos prod = db.Productos.Find(id);
            prod.Status = 4;
            db.SaveChanges();
            return View(prod);
        }


        
        // POST: AUCTUALIZAR PRODUCTOS
        [HttpGet]
        [Authorize(Roles = "Empleado")]
        public ActionResult EditPrecio(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Productos prod = db.Productos.Find(id);
            prod.Precio_Antiguo = prod.Precio_final;
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View("EditPrecio", prod);

        }
        [HttpPost]
        [Authorize(Roles = "Empleado")]
        public ActionResult EditPrecio(Productos prod)
        {

            if (ModelState.IsValid)
            {
                
                ApplicationDbContext db = new ApplicationDbContext();
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "ActualizarPrecios");
            }

            return View(prod);

        }
    }
}