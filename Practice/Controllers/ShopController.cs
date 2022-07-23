using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Practice.Models;

namespace Practice.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        PracticeLabEntities1 dbHelper = new PracticeLabEntities1();
        // GET: Shop
        public ActionResult Index()
        {
            return View("Allcustomer", dbHelper.RDBS.ToList());
        }

        public ActionResult AddCustomer()
        {
            return View("Addcustomer");
        }

        public ActionResult Afteradd(RDB customer)
        {
            dbHelper.RDBS.Add(customer);
            int rowsAffected = dbHelper.SaveChanges();
            if (rowsAffected > 0)
            {
                return Redirect("/Shop/Index");
            }
            else
            {
                return View("Addcustomer");
            }

        }


        public ActionResult Approve(int id)
        {
            RDB customerToApproved = dbHelper.RDBS.Find(id);
            customerToApproved.Status = "Approved";
            int rowaffected = dbHelper.SaveChanges();
            if (rowaffected > 0)
            {
                return Redirect("/Shop/Index");
            }
            else
            {
                return View();
            }
        }
    }
}