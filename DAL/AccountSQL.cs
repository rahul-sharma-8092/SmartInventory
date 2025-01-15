using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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

        public int VerifyOTP(int StoreUserId, string Email, string Otp, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);

            int returnVal = 0;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "VerifyOTP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserId", StoreUserId);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Otp", Otp);
                SqlParameter returnParm = new SqlParameter("@ReturnVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(returnParm);

                cmd.ExecuteNonQuery();
                returnVal = (int)cmd.Parameters["@ReturnVal"].Value;
            }
            catch (Exception ex)
            {
                returnVal = 0;
                WriteExceptionLog(ex, "AccountSQL.VerifyOTP");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return returnVal;
        }

        public ForgotPassword GetPassResetLink(string Email, string IpAddress, string StoreUserName)
        {
            ForgotPassword obj = new ForgotPassword();
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "GetPassResetLink";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@IpAddress", IpAddress);
                cmd.Parameters.AddWithValue("@Guid", Guid.NewGuid().ToString());
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        obj.ReturnCode = GetFieldInt(reader, "ReturnCode");
                        obj.FullName = GetField(reader, "FullName");
                        obj.Email = GetField(reader, "Email");
                        obj.Guid = GetField(reader, "Guid");
                        obj.GuidTimeStamp = GetFieldDate(reader, "GuidTimeStamp");
                        obj.IsGuidExpired = GetFieldBool(reader, "IsGuidExpired");
                    }
                }
            }
            catch (Exception ex)
            {
                obj.ReturnCode = 0;
                WriteExceptionLog(ex, "AccountSQL.GetPassResetLink");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return obj;
        }

        public SetPassword ValidateResetPassToken(string token, string StoreUserName)
        {
            SetPassword obj = new SetPassword();
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "ValidateResetPassToken";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Token", token);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.Guid = token;
                    obj.IsGuidExpired = true;

                    if (reader.HasRows)
                    {
                        obj.ReturnCode = GetFieldInt(reader, "ReturnCode");
                        obj.StoreUserId = GetFieldInt(reader, "StoreUserId");
                        obj.FullName = GetField(reader, "FullName");
                        obj.Email = GetField(reader, "Email");
                        obj.IsGuidExpired = GetFieldBool(reader, "IsGuidExpired");
                    }
                }
            }
            catch (Exception ex)
            {
                obj.ReturnCode = 0;
                WriteExceptionLog(ex, "AccountSQL.ValidateResetPassToken");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return obj;
        }

        public bool SetPassword(SetPassword setPassword, string StoreUserName)
        {
            bool returnBool = false;
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "SetPassword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserId", setPassword.StoreUserId);
                cmd.Parameters.AddWithValue("@Email", setPassword.Email);
                cmd.Parameters.AddWithValue("@Password", setPassword.Password);

                returnBool = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                returnBool = false;
                WriteExceptionLog(ex, "AccountSQL.SetPassword");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return returnBool;
        }

        public int AddStoreUserTOTP(TotpUserData objData, string StoreUserName)
        {
            int returnVal = 0;
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "AddStoreUserTOTP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserId", objData.StoreUserId);
                cmd.Parameters.AddWithValue("@Email", objData.Email);
                cmd.Parameters.AddWithValue("@SecretKey", objData.SecretKey);

                returnVal = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                returnVal = 0;
                WriteExceptionLog(ex, "AccountSQL.AddStoreUserTOTP");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return returnVal;
        }

        public string GetUserTotpSecretKey(int StoreUserId, string StoreUserName)
        {
            string secretKey = "";
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "GetUserTotpSecretKey";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreUserId", StoreUserId);

                secretKey = cmd.ExecuteScalar().ToString() ?? "";
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, "AccountSQL.GetUserTotpSecretKey");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return secretKey;
        }

        public void TrackLoginHistory(string StoreUserName, int storeUserId, string email, string ipAddress, bool isFailed)
        {
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "TrackLoginHistory";
                cmd.CommandType = CommandType.StoredProcedure;

                string message = isFailed ? Common.Message.LoginFailed : Common.Message.LoginSuccess;

                cmd.Parameters.AddWithValue("@StoreUserId", storeUserId);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@IpAddress", ipAddress);
                cmd.Parameters.AddWithValue("@Message", message);
                cmd.Parameters.AddWithValue("@IsFailed", isFailed);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, "AccountSQL.TrackLoginHistory");
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
        }
    }
}
