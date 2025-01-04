using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseSQL
    {
        internal readonly string connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

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
            return Convert.ToInt32(reader.GetValue(ordinal));
        }

        public long GetFieldLong(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
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
            return Convert.ToDecimal(reader.GetValue(ordinal));
        }

        public bool GetFieldBool(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return Convert.ToBoolean(reader.GetValue(ordinal));
        }

        public DateTime GetFieldDate(SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return Convert.ToDateTime(reader.GetValue(ordinal));
        }
        
    }
}
