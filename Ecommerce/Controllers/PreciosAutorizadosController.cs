using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class PreciosAutorizadosController : Controller
    {
        // GET: PreciosAutorizados
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var productos = db.Productos.AsQueryable().Where(p => p.Status.Equals(2));
            return View(productos);
        }

        // POST: AUCTUALIZAR STATUS DE PRODUCTOS A 3

        [Authorize(Roles = "Empleado")]
        public ActionResult EditS(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Productos prod = db.Productos.Find(id);
            prod.Status = 3;
            db.SaveChanges();


            return View(prod);
        }
    }
}