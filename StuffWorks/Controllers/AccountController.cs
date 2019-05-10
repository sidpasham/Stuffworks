using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StuffWorks.Models;
using StuffWorks_BAL;
using System.Web.Security;
using StuffWorks.Code;
using System.Data;

namespace StuffWorks.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View("AccountIndex");
        }

        [HttpGet]
        //GET: StufferRegistration
        public ActionResult RegisterStuffer()
        {
            RegisterStuffer stuffer = new RegisterStuffer();
            
            stuffer.Services = GetServices();
            return View(stuffer);
        }

        private static List<SelectListItem> GetServices()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            DataTable dt = null;
            using (stuffWorks_BAL sw_bal = new stuffWorks_BAL())
            {
                dt = sw_bal.GetAvailableServices();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new SelectListItem
                    {
                        Text = row["Service_Name"].ToString(),
                        Value = row["Service_ID"].ToString()
                    });
                }
            }
            return items;
        }

        [HttpPost]
        public void Register(Register model)
        {
            if (ModelState.IsValid)
            {
                using (stuffWorks_BAL sw_bal= new stuffWorks_BAL())
                {
                    sw_bal.register(model.FullName, model.EmailID, model.Password,Convert.ToInt32(UserType.client_User),model.Phone);
                }
            }
        }

        [HttpPost]
        public void RegisterStuffer(RegisterStuffer model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            List<SelectListItem> items = new List<SelectListItem>();
            items = GetServices();
            if (ModelState.IsValid)
            {
                using (stuffWorks_BAL sw_bal = new stuffWorks_BAL())
                {
                    sw_bal.registerStuffer(model.FullName, model.EmailID, model.Password, Convert.ToInt32(UserType.service_User), model.Phone,model.Address1,model.Address2,model.City,model.State,model.ZipCode,Convert.ToInt32(items.Find(x=>x.Value==model.Service.ToString()).Value));
                }
            }

        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                if(!model.rememberme)
                {
                    using (stuffWorks_BAL sw_bal = new stuffWorks_BAL())
                    {
                        //if(sw_bal.isloginsuccess(model.EmailID, model.Password))
                        //{
                        //    return RedirectToAction("Index","AboutUs");
                        //}
                        if(Membership.ValidateUser(model.EmailID,model.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.EmailID, false);
                            Session["UserData"] = UserDetails.LoadUserData(model.EmailID);
                            
                            return RedirectToAction("Index", "ManageUser");
                        }
                        else
                        {
                            ModelState.AddModelError("password", "The username or password is incorrect");
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else if(model.rememberme)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // 1- login module
        // 2 - register module


        [AllowAnonymous]
        [HttpPost]
        public JsonResult IsEmailIDExists(string EmailID)
        {
            if (ModelState.IsValid)
            {
                if (EmailID != null)
                {
                    using (stuffWorks_BAL sw_bal = new stuffWorks_BAL())
                    {
                        if(sw_bal.IsEmailIDExists(EmailID, 1))
                        {
                            return Json(true);
                        }
                        else
                        {
                            return Json(false);
                        }
                     }
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult IsEmailIDExistsRegister(string EmailID)
        {
            if (ModelState.IsValid)
            {
                if (EmailID != null)
                {
                    using (stuffWorks_BAL sw_bal = new stuffWorks_BAL())
                    {
                        return Json(sw_bal.IsEmailIDExists(EmailID, 2));
                    }
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}