﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;

namespace MvcRestaurant.Controllers
{
    public class vitrinController : Controller
    {
        // GET: vitrin
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYEMEK.ToList();
            return View(degerler);
        }
    }
}