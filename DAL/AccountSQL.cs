using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountSQL : BaseSQL
    {
        public AuthDetails GetUserAuthDetails(string email)
        {
            AuthDetails details = new AuthDetails();

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "GetUserAuthDetailsByEmail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        details.UserID = GetFieldInt(reader, "UserID");
                        details.Email = GetField(reader, "Email");
                        details.Password = GetField(reader, "Password");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.FileLogger.WriteLog("AccountSQL", "Error in AccountSQL.GetUserAuthDetails: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return details;
        }

        public Authentication GetUserFullDetails(string email, int userId)
        {
            Authentication details = new Authentication();

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "GetUserFullDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        details.UserID = GetFieldInt(reader, "UserID");
                        details.FirstName = GetField(reader, "FirstName");
                        details.LastName = GetField(reader, "LastName");
                        details.Email = GetField(reader, "Email");
                        details.Role = GetField(reader, "Role");
                        details.RoleId = GetFieldInt(reader, "RoleId");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.FileLogger.WriteLog("AccountSQL", "Error in AccountSQL.GetUserAuthDetails: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return details;
        }
    }
}
