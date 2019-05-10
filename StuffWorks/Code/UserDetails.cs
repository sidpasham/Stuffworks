using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StuffWorks_BAL;
using System.Data;

namespace StuffWorks.Code
{
    public class UserDetails
    {
        public int usertype;
        public string useremail;
        public string userfullname;
        public int userId;
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public string pincode;
        public string country;
        
        //load particular user data using user email ID
        public static UserDetails LoadUserData(string Email)
        {
            UserDetails us = new UserDetails();
            DataTable dt = null;
            using (stuffWorks_BAL swbal = new stuffWorks_BAL())
            {
                dt = swbal.GetUserDetails(Email);
            }
            if (dt!=null)
            {
                us.useremail = dt.Rows[0]["User_Email"].ToString();
                us.userfullname = dt.Rows[0]["User_Name"].ToString();
                us.Address1 = dt.Rows[0]["Address1"].ToString();
                us.Address2 = dt.Rows[0]["Address2"].ToString();
                us.City = dt.Rows[0]["City"].ToString();
                us.State = dt.Rows[0]["State"].ToString();
                us.pincode = dt.Rows[0]["Zip"].ToString();
                us.userId = Convert.ToInt32(dt.Rows[0]["User_ID"]);
                us.usertype = Convert.ToInt32(dt.Rows[0]["Is_User_Type"]);
            }
            return us;
        }
            }
}