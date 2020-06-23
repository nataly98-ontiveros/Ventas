using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class PreciosAutorizadosExisController : Controller
    {
        // GET: PreciosAutorizadosExis
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var productos = db.Productos.AsQueryable().Where(p => p.Status.Equals(4));
            return View(productos);
        }

        [Authorize(Roles = "Empleado")]
        public ActionResult EditS(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Productos prod = db.Productos.Find(id);
            prod.Status = 5;
            db.SaveChanges();


            return View(prod);
        }
    }
}