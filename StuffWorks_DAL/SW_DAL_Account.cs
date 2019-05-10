using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StuffWorks_DAL
{
    public partial class DataAccess : DataAccessBase
    {
        //Register Method
        public void register(string fullName, string emailID, string password, int userType, string phone)
        {
            int userId;
            Hashtable parameterCollection = new Hashtable();
            parameterCollection.Add("@user_email", emailID);
            parameterCollection.Add("@full_Name", fullName);
            parameterCollection.Add("@user_Password", password);
            parameterCollection.Add("@user_Type", userType);
            parameterCollection.Add("@phone", phone);
            userId =Util.GetProcedureValue(ConnectionString, "SW_Register", parameterCollection);
        }

        public void registerStuffer(string fullName, string emailID, string password, int userType, string phone, string address1, string address2, string city, string state, string zip, int serviceId)
        {
            int userId;
            Hashtable parameterCollection = new Hashtable();
            parameterCollection.Add("@user_email", emailID);
            parameterCollection.Add("@full_Name", fullName);
            parameterCollection.Add("@user_Password", password);
            parameterCollection.Add("@user_Type", userType);
            parameterCollection.Add("@phone", phone);
            parameterCollection.Add("@address1", phone);
            parameterCollection.Add("@address2", phone);
            parameterCollection.Add("@city", phone);
            parameterCollection.Add("@state", phone);
            parameterCollection.Add("@zip", phone);
            parameterCollection.Add("@serviceId", phone);
            userId = Util.GetProcedureValue(ConnectionString, "SW_Register", parameterCollection);
        }

        //Login method
        public int isloginsuccess(string emailID, string password)
        {
            Hashtable parameterCollection = new Hashtable();
            parameterCollection.Add("@user_email", emailID);
            parameterCollection.Add("@user_Password", password);
            return Util.GetProcedureValue(ConnectionString, "SW_Login", parameterCollection);
        }

        //Check if User Exists in Database
        public int IsEmailIDExists(string emailID)
        {
           
            Hashtable parameterCollection = new Hashtable();
            parameterCollection.Add("@user_email", emailID);
            return Util.GetProcedureValue(ConnectionString, "SW_IsEmailExists", parameterCollection);
        }

        //Get User Data in Database
        public DataTable GetUserData(string emailID)
        {

            Hashtable parameterCollection = new Hashtable();
            parameterCollection.Add("@user_email", emailID);
            return Util.GetDataTable(ConnectionString, "SW_GetUserData", parameterCollection);
        }

        public DataTable GetAvailableServices()
        {
            Hashtable parameterCollection = new Hashtable();
            return Util.GetDataTable(ConnectionString, "SW_GetAvailableServices", parameterCollection);
        }
        //update User Data in Database
        public void UpdateUserData(Dictionary<string,string> userdetails)
        {

            Hashtable parameterCollection = new Hashtable();
            parameterCollection.Add("@userid", userdetails["userid"]);
            parameterCollection.Add("@user_email", userdetails["useremail"]);
            parameterCollection.Add("@address1", userdetails["address1"]);
            parameterCollection.Add("@address2", userdetails["address2"]);
            parameterCollection.Add("@City", userdetails["City"]);
            parameterCollection.Add("@State", userdetails["State"]);
            parameterCollection.Add("@Pincode", userdetails["Pincode"]);
            Util.GetProcedureValue(ConnectionString, "SW_UpdateUserData", parameterCollection);
        }

        //get all User Data in Database
        public DataSet GetAdminData()
        {
            Hashtable parameterCollection = new Hashtable();
            return Util.GetDataSet(ConnectionString, "SW_GetAdminData", parameterCollection);
        }
    }
}
