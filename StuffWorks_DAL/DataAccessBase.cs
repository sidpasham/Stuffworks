using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace StuffWorks_DAL
{
    public class DataAccessBase : Database,IDisposable
    {
        public DataAccessBase(string connectionString, string providerName) : base(connectionString, DbProviderFactories.GetFactory(providerName))
        {
        }

        protected override void DeriveParameters(DbCommand discoveryCommand)
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)discoveryCommand);
        }

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
