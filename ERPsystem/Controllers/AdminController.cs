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
        oprationdav oo= new oprationdav();  
        public ActionResult Index()
        {


           object  a=  oo.list();
            return View(a);
        }


       


    }
}