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
        public AuthDetails GetUserAuthDetails(string email, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);
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
                        details.StoreUserID = GetFieldInt(reader, "StoreUserID");
                        details.FullName = GetField(reader, "FullName");
                        details.Email = GetField(reader, "Email");
                        details.Password = GetField(reader, "Password");
                        details.GroupId = GetFieldInt(reader, "GroupId");
                        details.Mobile = GetField(reader, "Mobile");
                        details.Status = GetFieldInt(reader, "Status");
                        details.ForceUpdatePassword = GetFieldBool(reader, "ForceUpdatePassword");
                        details.IsTempBlocked = GetFieldBool(reader, "IsTempBlocked");
                        details.Is2FAEnabled = GetFieldBool(reader, "Is2FAEnabled");
                        details.IsOTPEnabled = GetFieldBool(reader, "IsOTPEnabled");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, "AccountSQL.GetUserAuthDetails");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return details;
        }

        public Authentication GetUserFullDetails(string email, int userId, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);
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
                WriteExceptionLog(ex, "AccountSQL.GetUserFullDetails");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return details;
        }

        public bool AddStoreUserOTP(int StoreUserId, string OTP, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "AddStoreUserOTP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserId", StoreUserId);
                cmd.Parameters.AddWithValue("@OTP", OTP);

                returnBool = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, "AccountSQL.AddStoreUserOTP");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return returnBool;
        }

        public bool AddEmailHistoryWithOTP(EmailMsg email, int userId, string OTP, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "AddEmailHistoryWithOTP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserId", userId);
                cmd.Parameters.AddWithValue("@OTP", OTP);
                cmd.Parameters.AddWithValue("@To", email.To);
                cmd.Parameters.AddWithValue("@From", email.To);
                cmd.Parameters.AddWithValue("@Subject", email.Subject);
                cmd.Parameters.AddWithValue("@Body", email.Body);
                cmd.Parameters.AddWithValue("@Status", email.IsSent ? 1 : 0);

                returnBool = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                returnBool = false;
                WriteExceptionLog(ex, "AccountSQL.AddEmailHistoryWithOTP");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return returnBool;
        }
    }
}
