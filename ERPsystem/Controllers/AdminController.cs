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
        ERPSYSTEMEntities ee = new ERPSYSTEMEntities();
        oprationdav oo= new oprationdav();  
        public ActionResult Index()
        {


           
            return View();
        }

        public ActionResult Budgetshow()
        {
            var f = oo.showbudget();
            
            return View(f);  
        }


        public ActionResult Budgetadd() {
        
            budget b= new budget();
        
          return View(b);    
        }

        [HttpPost]
        public ActionResult Budgetadd(budget b) {

            int a = oo.budgetadd(b);
            if (a == 0)
            {


                return RedirectToAction("Index");

            }

            return RedirectToAction("Budgetshow");
            

        }

        public ActionResult editbudget(int id) { 
        var  b = oo.editbudget(id);
            ViewBag.Accounts = new SelectList(oo.getAccounts(), "account_id", "name", b.account_id);

            return View(b);
        }

        [HttpPost]
        public ActionResult editbudget(budget b)
        {
           
                var result = oo.budgetupdate(b);
                if (result == 1)
                    return RedirectToAction("Budgetshow");
          

            ViewBag.Accounts = new SelectList(oo.getAccounts(), "account_id", "name", b.account_id);
            return View(b);
        }


        public ActionResult deletebudget(int id)
        {

            int a= oo.deletebudget(id);
            if (a == 1)
                return RedirectToAction("Budgetshow");

            return RedirectToAction("Budgetshow");
        }

    }
}