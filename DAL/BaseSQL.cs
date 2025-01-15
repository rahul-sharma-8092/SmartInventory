using Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BaseSQL
    {
        internal readonly string connection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        internal string connString = string.Empty;
        internal bool returnBool = false;

        public StoreDetails GetStoreDetails(string StoreUserName)
        {
            StoreDetails details = new StoreDetails();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "GetStoreDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserName", StoreUserName);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        details.StoreId = GetFieldInt(reader, "StoreId");
                        details.StoreName = GetField(reader, "StoreName");
                        details.StoreUserName = GetField(reader, "StoreUserName");
                        details.SubscriberId = GetFieldInt(reader, "SubscriberId");
                        details.Subscriber = GetField(reader, "Subscriber");
                        details.DBId = GetFieldInt(reader, "DBId");
                        details.Server = GetField(reader, "Server");
                        details.DBName = GetField(reader, "DBName");
                        details.DBUserName = GetField(reader, "DBUserName");
                        details.DBPassword = GetField(reader, "DBPassword");
                        details.Status = GetFieldInt(reader, "Status");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.FileLogger.WriteLog("AccountSQL", "Error in BaseSQL.GetStoreDetails: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return details;
        }

        public string CreateConnString(string StoreUserName)
        {
            StoreDetails details = GetStoreDetails(StoreUserName);
            return $"Data Source={details.Server};Initial Catalog={details.DBName};User ID={details.DBUserName};Password={details.DBPassword};";
        }

        public void CloseConnection(SqlConnection conn, SqlCommand cmd)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
            cmd.Dispose();
        }

        public int GetFieldInt(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.GetValue(ordinal) == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt32(reader.GetValue(ordinal));
        }

        public long GetFieldLong(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.GetValue(ordinal) == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt64(reader.GetValue(ordinal));
        }

        public string GetField(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return Convert.ToString(reader.GetValue(ordinal));
        }

        public decimal GetFieldDecimal(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.GetValue(ordinal) == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(reader.GetValue(ordinal));
        }

        public bool GetFieldBool(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.GetValue(ordinal) == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(reader.GetValue(ordinal));
        }

        public DateTime GetFieldDate(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.GetValue(ordinal) == DBNull.Value)
            {
                return Convert.ToDateTime("1753-01-01");
            }
            return Convert.ToDateTime(reader.GetValue(ordinal));
        }

        internal void WriteExceptionLog(Exception ex, string method)
        {
            string message = "Error in " + method + ":: Message='" + (Convert.ToString(ex.Message) ?? "").Trim() + "' StackTrace='" + (Convert.ToString(ex.StackTrace) ?? "").Trim() + "' InnerException='" + (Convert.ToString(ex.InnerException) ?? "").Trim() + "'";

            Common.FileLogger.WriteLog("DAL Error", message);
        }

        public void LogErrorToDB(ExecptionErrror obj, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "AddErrorLog";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Message", obj.Message);
                cmd.Parameters.AddWithValue("@StackTrace", obj.StackTrace);
                cmd.Parameters.AddWithValue("@InnerException", obj.InnerException);
                cmd.Parameters.AddWithValue("@URL", obj.URL);  
                cmd.Parameters.AddWithValue("@IpAddress", obj.IpAddress);  
                cmd.Parameters.AddWithValue("@Browser", obj.Browser);  
                cmd.Parameters.AddWithValue("@LogLevel", obj.LogLevel);
                cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = $"Error in BaseSQL.LogErrorToDB:: Catch - {ex.Message} \n|| Message:: {obj.Message} || StackTrace:: {obj.StackTrace} || InnerException:: {obj.InnerException} || URL:: {obj.URL} || IpAddress:: {obj.IpAddress} || Browser:: {obj.Browser}";

                Common.FileLogger.WriteLog("BaseSQL", msg);
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
        }
    }
}
