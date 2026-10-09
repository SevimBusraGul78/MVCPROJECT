using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatiş()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniSatis(TblStok p1)
        {
            db.TblStok.Add(p1);
            db.SaveChanges();   
            return View("Index");  
       

        }
    }
}