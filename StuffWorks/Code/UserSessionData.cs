using StuffWorks_BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StuffWorks.Code
{
    public class UserSessionData
    {
        public UserDetails userDetails { get; private set; }
        
        public static UserSessionData loadUserSessionData(Models.Login modellogin)
        {
            UserSessionData userSessionData = new UserSessionData();
            UserDetails user = new UserDetails();
            //user.LoadUserData(modellogin);
            userSessionData.userDetails = user;

            return userSessionData;
        }
    }
}