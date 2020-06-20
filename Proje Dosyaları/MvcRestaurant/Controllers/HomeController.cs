using System.Linq;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;
using MvcRestaurant.Models.Siniflarim;

namespace MvcRestaurant.Controllers
{
    public class HomeController : Controller
    {
        // GET: vitrin
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLYEMEK.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLİLETİSİM t)
        {
            db.TBLİLETİSİM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}