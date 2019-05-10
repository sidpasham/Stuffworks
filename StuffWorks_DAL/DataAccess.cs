using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffWorks_DAL
{
    public partial class DataAccess : DataAccessBase
    {
        public DataAccess(string connectionString, string providerName) : base(connectionString, providerName)
        {
        }
        public string connectionString = ConfigurationManager.ConnectionStrings["StuffWorks"].ConnectionString;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
