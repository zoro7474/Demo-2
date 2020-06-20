using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;
using System.Security;

namespace MvcRestaurant.Controllers
{
    public class indexmesajlarController : Controller
    {
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLİLETİSİM.ToList();
            return View(degerler);
        }
        public ActionResult mesajSil(int id)
        {
            var person = db.TBLİLETİSİM.Find(id);
            db.TBLİLETİSİM.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");

        } 
    }
}