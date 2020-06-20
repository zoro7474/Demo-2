using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;
using System.Web.Security;

namespace MvcRestaurant.Controllers
{
    public class adminhakkımızdaController : Controller
    {
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMIZDA.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult acıklamaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult acıklamaEkle(TBLHAKKIMIZDA p)
        {
            db.TBLHAKKIMIZDA.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult acıklamaSil(int id)
        {
            var person = db.TBLHAKKIMIZDA.Find(id);
            db.TBLHAKKIMIZDA.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult acıklamaGetir(int id)
        {
            var prs = db.TBLHAKKIMIZDA.Find(id);
            return View("acıklamaGetir", prs);
        }
        public ActionResult acıklamaGuncelle(TBLHAKKIMIZDA p)
        {
            var prs = db.TBLHAKKIMIZDA.Find(p.ID);
            prs.ACIKLAMA = p.ACIKLAMA;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}