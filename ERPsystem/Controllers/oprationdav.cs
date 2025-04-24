using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ERPsystem.Controllers
{
    public class oprationdav
    {
        ERPSYSTEMEntities ee= new ERPSYSTEMEntities();  


       public List<budget> showbudget()
        {
           var f= ee.budgets.ToList();
            return f;
        }

        public int budgetadd(budget b)
        {
            try
            {
                ee.budgets.Add(b);
                ee.SaveChanges();
                return 1;
            }
            catch (Exception ex) {


                return 0;

            }
        }

        public budget editbudget(int id)
        {
            return ee.budgets.FirstOrDefault(x => x.budget_id == id);
        }

        public List<account> getAccounts()
        {
            return ee.accounts.ToList();
        }


        public int budgetupdate(budget b)
        {

          var f=   ee.budgets.FirstOrDefault(x => x.budget_id == b.budget_id);
            f.spent = b.spent;
            f.allocated = b.allocated;
            f.account_id = b.account_id;
            f.remaining = b.remaining;
            f.fiscal_year = b.fiscal_year;
            try
            {
                ee.budgets.AddOrUpdate(f);
                ee.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int deletebudget(int id)
        {
           var f=  ee.budgets.FirstOrDefault(x => x.budget_id == id);
            if(f != null)
            {
                ee.budgets.Remove(f);
                ee.SaveChanges();
                return 1;
            }
            return 0;
        }


    }
}