using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StuffWorks_DAL;
using System.Configuration;
using System.Data;

namespace StuffWorks_BAL
{
    public partial class stuffWorks_BAL
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["StuffWorks"].ConnectionString;
        protected string providerName = "System.Data.SqlClient";
        public void register(string fullName, string emailID, string password, int userType, string phone)
        {
            using (DataAccess da = new DataAccess(connectionString,providerName))
            {
                da.register(fullName, emailID, password, userType, phone);
            }
        }
        public void registerStuffer(string fullName, string emailID, string password, int userType, string phone, string address1, string address2, string city, string state, string zip, int serviceId)
        {
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {
                da.registerStuffer(fullName, emailID, password, userType, phone, address1,address2,city,state,zip,serviceId);
            }
        }

        public bool isloginsuccess(string emailID, string password)
        {
            bool isloginok = false;
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {
                if(da.isloginsuccess(emailID, password) == 1)
                {
                    isloginok = true;
                }
                else
                {
                    isloginok = false;
                }
            }
            return isloginok;
        }


        public bool IsEmailIDExists(string emailID, int whichmodule)
        {
            bool resultvalue =false;
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {                
               if (da.IsEmailIDExists(emailID) == 1)
                {
                    if (whichmodule == 1)
                    {
                        resultvalue= true;
                    }
                    else if (whichmodule == 2)
                    {
                        resultvalue = false;
                    }
                    
                }
                else
                {
                    if (whichmodule == 1)
                    {
                        resultvalue= false;
                    }
                    else if (whichmodule == 2)
                    {
                        resultvalue= true;
                    }
                }
            }
            return resultvalue;
        }

        public DataTable GetUserDetails(string useremail)
        {
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {
                return da.GetUserData(useremail);
            }

        } 

        public DataTable GetAvailableServices()
        {
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {
                return da.GetAvailableServices();
            }
        }

        public void UpdateUserDetail(Dictionary<string,string> userdicdetails)
        {
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {
                da.UpdateUserData(userdicdetails);
            }
            
        }

        public DataSet GetAdminData()
        {
            using (DataAccess da = new DataAccess(connectionString, providerName))
            {
                return da.GetAdminData();
            }

        }
    }
}
