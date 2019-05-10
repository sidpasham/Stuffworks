using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace StuffWorks_DAL
{
    public static class Util
    {
        public static void ExecuteProcedure(string connectionString, string StoredProcedre, Hashtable parameterList)
        {
            using (DataAccessBase dbHelper = new DataAccessBase(connectionString, "System.Data.SqlClient"))
            {
                DbCommand dbCommand = dbHelper.GetStoredProcCommand(StoredProcedre);
                //dbCommand.CommandTimeout = COMMAND_TIMEOUT;
                dbHelper.DiscoverParameters(dbCommand);

                if (parameterList != null)
                {
                    foreach (SqlParameter parameter in dbCommand.Parameters)
                    {
                        if (parameterList.ContainsKey(parameter.ParameterName))
                        {
                            dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, GetParameterData(parameter.SqlDbType, parameterList[parameter.ParameterName].ToString()));
                        }
                    }
                }
                using (DbConnection conn = dbHelper.CreateConnection())
                {
                    conn.Open();
                    DbTransaction transaction = conn.BeginTransaction(IsolationLevel.Snapshot);

                    try
                    {
                        dbHelper.ExecuteNonQuery(dbCommand, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static int GetProcedureValue(string connectionString, string StoredProcedre, Hashtable parameterList)
          {
            int queryresult = 0;
            string outputparameter = "";
            try
            {
                using (DataAccessBase dbHelper = new DataAccessBase(connectionString, "System.Data.SqlClient"))
                {
                    DbCommand dbCommand = dbHelper.GetStoredProcCommand(StoredProcedre);
                    dbHelper.DiscoverParameters(dbCommand);

                    if (parameterList != null)
                    {
                        foreach (SqlParameter parameter in dbCommand.Parameters)
                        {
                            if (parameterList.ContainsKey(parameter.ParameterName))
                            {
                                dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, GetParameterData(parameter.SqlDbType, parameterList[parameter.ParameterName].ToString()));
                        }
                            else
                            {
                                outputparameter = parameter.ToString();
                            }
                         }
                    }
                   using (DbConnection conn = dbHelper.CreateConnection())
                    {
                        conn.Open();
                        DbTransaction transaction = conn.BeginTransaction(IsolationLevel.Snapshot);

                        try
                        {
                            dbHelper.ExecuteNonQuery(dbCommand, transaction);
                            queryresult = Convert.ToInt32(dbCommand.Parameters[outputparameter].Value);
                            transaction.Commit();
                           
                        }
                        catch(Exception ex)
                        {
                            transaction.Rollback();
                            
                        }
                        return queryresult;
                    }
                }
            }
            catch(Exception ex)
            {
                return queryresult;
            }
        }

        public static int GetOutputParameter(string connectionString, string StoredProcedre, Hashtable parameterList)
        {
            int param = 0;
            using (DataAccessBase dbHelper = new DataAccessBase(connectionString, "System.Data.SqlClient"))
            {
                DbCommand dbCommand = dbHelper.GetStoredProcCommand(StoredProcedre);
                string outputParameter = "";
                //dbCommand.CommandTimeout = COMMAND_TIMEOUT;
                dbHelper.DiscoverParameters(dbCommand);

                if (parameterList != null)
                {
                    foreach (SqlParameter parameter in dbCommand.Parameters)
                    {
                        if (parameterList.ContainsKey(parameter.ParameterName))
                        {
                            if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                            {
                                outputParameter = parameter.ToString();
                                dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, 0);
                            }
                            else
                            {
                                dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, GetParameterData(parameter.SqlDbType, parameterList[parameter.ParameterName].ToString()));
                            }
                        }
                        else if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            outputParameter = parameter.ToString();
                        }
                    }
                }
                using (DbConnection conn = dbHelper.CreateConnection())
                {
                    conn.Open();
                    DbTransaction transaction = conn.BeginTransaction(IsolationLevel.Snapshot);

                    try
                    {
                        dbHelper.ExecuteNonQuery(dbCommand, transaction);
                        if (!string.IsNullOrEmpty(dbCommand.Parameters[outputParameter].Value.ToString()))
                            param = (int)dbCommand.Parameters[outputParameter].Value;
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return param;
            }
        }

        public static DataTable GetDataTable(string connectionString, string StoredProcedre, Hashtable parameterList)
        {
            DataSet ds = null;
            using (DataAccessBase dbHelper = new DataAccessBase(connectionString, "System.Data.SqlClient"))
            {
                DbCommand dbCommand = dbHelper.GetStoredProcCommand(StoredProcedre);
                dbHelper.DiscoverParameters(dbCommand);

                if (parameterList != null)
                {
                    foreach (SqlParameter parameter in dbCommand.Parameters)
                    {
                        if (parameterList.ContainsKey(parameter.ParameterName))
                        {
                            dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, GetParameterData(parameter.SqlDbType, parameterList[parameter.ParameterName].ToString()));
                        }
                    }
                }
                using (DbConnection conn = dbHelper.CreateConnection())
                {
                    conn.Open();
                    DbTransaction transaction = conn.BeginTransaction(IsolationLevel.Snapshot);

                    try
                    {
                        ds = dbHelper.ExecuteDataSet(dbCommand, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    return ds.Tables[0];
                     
                }
            }
        }

        public static DataSet GetDataSet(string connectionString, string StoredProcedre, Hashtable parameterList)
        {
            DataSet ds = null;
            using (DataAccessBase dbHelper = new DataAccessBase(connectionString, "System.Data.SqlClient"))
            {
                DbCommand dbCommand = dbHelper.GetStoredProcCommand(StoredProcedre);
                dbHelper.DiscoverParameters(dbCommand);

                if (parameterList != null)
                {
                    foreach (SqlParameter parameter in dbCommand.Parameters)
                    {
                        if (parameterList.ContainsKey(parameter.ParameterName))
                        {
                            dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, GetParameterData(parameter.SqlDbType, parameterList[parameter.ParameterName].ToString()));
                        }
                    }
                }
                using (DbConnection conn = dbHelper.CreateConnection())
                {
                    conn.Open();
                    DbTransaction transaction = conn.BeginTransaction(IsolationLevel.Snapshot);

                    try
                    {
                        ds = dbHelper.ExecuteDataSet(dbCommand, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    return ds;
                }
            }
        }
        //public static void UpdateUserDetailstoDB(string connectionString, string StoredProcedre, Hashtable parameterList)
        //{

        //    using (DataAccessBase dbHelper = new DataAccessBase(connectionString, "System.Data.SqlClient"))
        //    {
        //        DbCommand dbCommand = dbHelper.GetStoredProcCommand(StoredProcedre);
        //        dbHelper.DiscoverParameters(dbCommand);

        //        if (parameterList != null)
        //        {
        //            foreach (SqlParameter parameter in dbCommand.Parameters)
        //            {
        //                if (parameterList.ContainsKey(parameter.ParameterName))
        //                {
        //                    dbHelper.SetParameterValue(dbCommand, parameter.ParameterName, GetParameterData(parameter.SqlDbType, parameterList[parameter.ParameterName].ToString()));
        //                }
        //            }
        //        }
        //        using (DbConnection conn = dbHelper.CreateConnection())
        //        {
        //            conn.Open();
        //            DbTransaction transaction = conn.BeginTransaction(IsolationLevel.Snapshot);

        //            try
        //            {
        //                dbHelper.ExecuteDataSet(dbCommand, transaction);
        //                transaction.Commit();
        //            }
        //            catch
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }                 

        private static object GetParameterData(SqlDbType sqlDbType, string parameter)
        {
            switch (sqlDbType)
            {
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Char:
                case SqlDbType.Xml:
                    return parameter;
                case SqlDbType.Decimal:
                    return Convert.ToDecimal(parameter);
                case SqlDbType.Int:
                    return Convert.ToInt32(parameter);
                case SqlDbType.TinyInt:
                    return Convert.ToInt16(parameter);
                case SqlDbType.Bit:
                    return Convert.ToBoolean(parameter);
                case SqlDbType.DateTime:
                case SqlDbType.Date:
                case SqlDbType.DateTime2:
                    return Convert.ToDateTime(parameter);
                default:
                    return null;
            }
        }

    }
}
