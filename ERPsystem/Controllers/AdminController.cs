using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPsystem.Controllers
{



    public class AdminController : Controller
    {
        // GET: Admin
        ERPSYSTEMEntities eee = new ERPSYSTEMEntities();
        public ActionResult Index()
        {

            var f = eee.transactions.ToList();
           
            return View();
        }


        public ActionResult Addtransations()
        {
            
            return View();
        }
    }
}