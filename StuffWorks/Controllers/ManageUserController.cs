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
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        public ActionResult Index()
        {
            if (((UserDetails)Session["UserData"]).usertype == 1)
            {
                return View("UserDashboard");
            }
            //User
            else if (((UserDetails)Session["UserData"]).usertype == 2)
            {
                //UserDetails usd = (UserDetails)Session["UserData"];

                return View("UserDashboard");
            }
            //Admin
            else if (((UserDetails)Session["UserData"]).usertype == 99)
            {
                DataSet ds = null;
                Admin admin = new Admin();
                using (stuffWorks_BAL sw_bal = new stuffWorks_BAL())
                {
                    ds = sw_bal.GetAdminData();
                    admin.dtusers = ds.Tables[0];
                    admin.dtstuffers = ds.Tables[1];
                    admin.dtservices = ds.Tables[2];
                }
                   
                return View("AdminView",admin);
            }
            return View("UserDashboard");

        }
        [HttpPost]
        public ActionResult ManageUserAccount(ManageUserDetails model)
        {
            UserDetails usd = (UserDetails)Session["UserData"];

            if (model.useremail != usd.useremail || model.Address1 != usd.Address1 || model.Address2 != usd.Address2 || model.City != usd.City || model.State != usd.State || model.Pincode != usd.pincode)
            {
                using (stuffWorks_BAL swBAL = new stuffWorks_BAL())
                {
                    Dictionary<string, string> userdict = new Dictionary<string, string>();
                    userdict.Add("userid", usd.userId.ToString());
                    userdict.Add("useremail", model.useremail);
                    userdict.Add("address1", model.Address1);
                    userdict.Add("address2", model.Address2);
                    userdict.Add("City", model.City);
                    userdict.Add("State", model.State);
                    userdict.Add("Pincode", model.Pincode.ToString());

                    swBAL.UpdateUserDetail(userdict);
                }
                Session["UserData"] = UserDetails.LoadUserData(model.useremail);
            }
            return View("ManageAccount");
        }
        [HttpGet]
        public ActionResult ManageUserAccount()
        {
            UserDetails usd = (UserDetails)Session["UserData"];
            ManageUserDetails msd = new ManageUserDetails();
            if (usd.useremail != "")
            {
                msd.useremail = usd.useremail;
            }
            if(usd.Address1 != "")
            {
                msd.Address1 = usd.Address1;
            }
            if (usd.Address2 != "")
            {
                msd.Address2 = usd.Address2;
            }
            if (usd.City != "")
            {
                msd.City = usd.City;
            }
            if (usd.State != "")
            {
                msd.State = usd.State;
            }
            if (usd.pincode != "")
            {
                msd.Pincode = usd.pincode;
            }
           return View("ManageAccount",msd);
        }
    }
}