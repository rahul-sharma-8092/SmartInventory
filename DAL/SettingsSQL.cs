using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class SettingsSQL : BaseSQL
    {
        int resultInt = 0;

        public int AddUpdateCategory(Entity.Categories category, string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "AddUpdateCategory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Description", category.Description);
                cmd.Parameters.AddWithValue("@ParentCategoryID", string.IsNullOrEmpty(category.ParentCategoryID) ? 0 : Convert.ToInt32(category.ParentCategoryID));
                cmd.Parameters.AddWithValue("@IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("@StoreUserId", category.StoreUserId);
                cmd.Parameters.AddWithValue("@UserName", category.UserName);

                resultInt = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                resultInt = -1;
                WriteExceptionLog(ex, "SettingsSQL.AddUpdateCategory");
                if (!ex.Message.Contains("Violation of UNIQUE KEY"))
                {
                    throw;
                }
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return resultInt;
        }

        public DataTable GetCategories(string StoreUserName)
        {
            connString = CreateConnString(StoreUserName);
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "GetCategories";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dataTable);
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, "SettingsSQL.GetCategories");
                throw;
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return dataTable;
        }

        public string DeleteCategory(int id, string StoreUserName)
        {
            string returnMessage = "";
            connString = CreateConnString(StoreUserName);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "DeleteCategory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                returnMessage = Convert.ToString(cmd.ExecuteScalar()) ?? "";
            }
            catch (Exception ex)
            {
                returnMessage = "";
                WriteExceptionLog(ex, "SettingsSQL.DeleteCategory");
            }
            finally
            {
                CloseConnection(conn, cmd);
            }
            return returnMessage;
        }
    }
}
