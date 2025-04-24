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


       public object list()
        {
           var f=  ee.transactions.ToList();
            return f;
        }


       
    }
}