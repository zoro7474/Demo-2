using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;

namespace MvcRestaurant.Controllers
{
    public class panelmenüController : Controller
    {
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        // GET: panelmenü
        public ActionResult Index(string p)
        {
            var yemekler = from k in db.TBLYEMEK select k;
            if (!string.IsNullOrEmpty(p))
            {
                yemekler = yemekler.Where(m => m.AD.Contains(p));
            }
            return View(yemekler.ToList());
        }
    }
}