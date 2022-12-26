using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebAPI.Controllers;

namespace WebAPI.Database
{
    public class Database
    {
        public static DataTable ReadTable(string StoredProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // Result variable
                DataTable resultTable = new DataTable();

                // Create connection
                string SQLConnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // Create and Assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = StoredProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // Check parameters in Stored Procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // Execute sqlCommand and Assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(resultTable);

                connection.Close();

                return resultTable;
            }
            catch
            {
                return null;
            }
        }

        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                // Start a local transaction.

                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@CurrentID"].Value;
                    // Attempt to commit the transaction.

                }
                catch (Exception ex)
                {

                    result = null;
                }

            }
            return result;
        }
        public static DataTable GetAllItems()
        {
            return ReadTable("GetAllItems");
        }
        public static DataTable GetItemById(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("id", id);
            return ReadTable("GetItemById", param);
        }
        public static int AddCoffee(Coffee cf)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("name", cf.name);
            param.Add("price", cf.price);
            param.Add("detail", cf.detail);
            param.Add("image", cf.image);
            param.Add("type", cf.type);

            int kq = int.Parse(Exec_Command("Add_Coffee", param).ToString());
            return kq;
        }
        public static int EditCoffee(Coffee cf)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("id", cf.id);
            param.Add("name", cf.name);
            param.Add("price", cf.price);
            param.Add("detail", cf.detail);
            param.Add("image", cf.image);
            int kq = int.Parse(Exec_Command("Edit_Coffee", param).ToString());
            return kq;
        }
        public static int DeleteCoffee(Coffee cf)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("id",cf.id);

            int kq = int.Parse(Exec_Command("Delete_Coffee", param).ToString());
            return kq;
        }
        public static User AddUser(User nd)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("name", nd.name);
            param.Add("username", nd.username);
            param.Add("password", nd.password);
            param.Add("email", nd.email ?? "info@gmail.com");
            int kq = int.Parse(Exec_Command("Add_User", param).ToString());
            if (kq > -1)
                nd.id = kq;
            return nd;
        }
        public static User Login(string username, string pw)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("username", username);
            param.Add("password", pw);
            DataTable tb = ReadTable("Login", param);
            User kq = new User();
            if (tb.Rows.Count > 0)
            {
                kq.id = int.Parse(tb.Rows[0]["id"].ToString());
                kq.name = tb.Rows[0]["name"].ToString();
                kq.username = tb.Rows[0]["username"].ToString();
                kq.email = tb.Rows[0]["email"].ToString();
                kq.password = tb.Rows[0]["password"].ToString();
            }
            else
                kq.id = 0;
            return kq;


        }
        public static int AddCart(Cart gh)
        {
            //khai bao datatable chua ds hang
            DataTable tb = new DataTable();
            tb.Columns.Add("id_coffee", typeof(int));
            tb.Columns.Add("count", typeof(int));
            tb.Columns.Add("price", typeof(int));
            tb.Columns.Add("totalPrice", typeof(int));
            foreach (Coffee h in gh.coffees)
            {
                DataRow r = tb.NewRow();
                r["id_cofee"] = h.id;
                r["count"] = h.count;
                r["price"] = h.price;
                r["totalPrice"] = h.count * h.price;
                tb.Rows.Add(r);
            }
            tb.AcceptChanges();
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("id", gh.id);
            param.Add("t", tb);
            int kq = int.Parse(Exec_Command("Add_Order", param).ToString());

            return kq;
        }
    }
}