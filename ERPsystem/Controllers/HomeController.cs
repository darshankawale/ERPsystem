using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace ERPsystem.Controllers
{
    public class HomeController : Controller
    {
        ERPSYSTEMEntities E1 = new ERPSYSTEMEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact() 
        {

            return View();
        
        }

        public ActionResult Login()
        {

            return View();

        }
        public ActionResult TransactionListView()
        {

            var transactions = E1.transactions.ToList();
            return View(transactions);

        }
       

        [HttpPost]
        public ActionResult SaveTransaction(transaction ss)
        {
            E1.transactions.Add(ss);
            E1.SaveChanges();

            
            return RedirectToAction("TransactionListView");
           

        }
       
        [HttpPost]
        public ActionResult UpdateTransaction(transaction model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ERPSYSTEMEntities())
                {
                    var existing = db.transactions.FirstOrDefault(t => t.transaction_id == model.transaction_id);
                    if (existing != null)
                    {
                        existing.account_id = model.account_id;
                        existing.date = model.date;
                        existing.description = model.description;
                        existing.amount = model.amount;
                        existing.type = model.type;
                        existing.related_id = model.related_id;

                        db.SaveChanges();
                    }
                }

                return RedirectToAction("TransactionListView"); 
            }

            return View(model);
        }

        public ActionResult DeleteTransaction(int id)
        {
            var transaction = E1.transactions.FirstOrDefault(t => t.transaction_id == id);
            if (transaction != null)
            {
                E1.transactions.Remove(transaction);
                E1.SaveChanges();
            }

            return RedirectToAction("TransactionListView"); 
        }
        
        
    }
}