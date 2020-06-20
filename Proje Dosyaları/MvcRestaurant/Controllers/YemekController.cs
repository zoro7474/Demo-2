using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;


namespace MvcRestaurant.Controllers
{
    public class YemekController : Controller
    {
        // GET: Yemek
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index(string p)
        {
            var yemekler = from k in db.TBLYEMEK select k;
            if (!string.IsNullOrEmpty(p))
            {
                yemekler = yemekler.Where(m => m.AD.Contains(p));
            }
          //  var yemekler = db.TBLYEMEK.ToList();
            return View(yemekler.ToList());
        }
        [HttpGet]
        public ActionResult YemekEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATAGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLSEF.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD +' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult YemekEkle(TBLYEMEK p)
        {
            var ktg = db.TBLKATAGORI.Where(k => k.ID == p.TBLKATAGORI.ID).FirstOrDefault();
            var sef = db.TBLSEF.Where(y => y.ID == p.TBLSEF.ID).FirstOrDefault();
            p.TBLKATAGORI = ktg;
            p.TBLSEF = sef;
            db.TBLYEMEK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YemekSil(int id)
        {
            var yemek = db.TBLYEMEK.Find(id);
            db.TBLYEMEK.Remove(yemek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YemekGetir(int id)
        {
            var ktp = db.TBLYEMEK.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATAGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLSEF.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("YemekGetir", ktp);
        }
        public ActionResult YemekGuncelle(TBLYEMEK p)
        {
            var yemek = db.TBLYEMEK.Find(p.ID);
            yemek.AD = p.AD;
            yemek.UCRET = p.UCRET;
            yemek.Resim = p.Resim;
            var ktg = db.TBLKATAGORI.Where(k => k.ID == p.TBLKATAGORI.ID).FirstOrDefault();
            var sef = db.TBLSEF.Where(y => y.ID == p.TBLSEF.ID).FirstOrDefault();
            yemek.KATEGORI = ktg.ID;
            yemek.SEF = sef.ID;
            yemek.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}