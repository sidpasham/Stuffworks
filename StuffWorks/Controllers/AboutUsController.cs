using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuffWorks.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View("AboutUsIndex");
        }
    }
}