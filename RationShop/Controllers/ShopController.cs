
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RationShop.Models;

namespace RationShop.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        LabPracticeEntities1 dbHelper = new LabPracticeEntities1();
        // GET: Shop
        public ActionResult Index()
        {
            return View("Allcustomer", dbHelper.RSDBs.ToList());
        }

        public ActionResult AddCustomer()
        {
            return View("Addcustomer");
        }

        public ActionResult Afteradd(RSDB customer)
        {
            dbHelper.RSDBs.Add(customer);
            int rowsAffected = dbHelper.SaveChanges();
            if (rowsAffected > 0)
            {
                return Redirect("/Shop/AllCustomer");
            }
            else
            {
                return View("Addcustomer");
            }

        }


        public ActionResult Approve(int id)
        {
            RSDB customerToApproved = dbHelper.RSDBs.Find(id);
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