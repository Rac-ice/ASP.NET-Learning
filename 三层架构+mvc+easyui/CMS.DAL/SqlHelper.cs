using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public class SqlHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public static DataTable ExecuteDataTable(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql,conn))
                {
                    adapter.SelectCommand.CommandType = type;
                    if (parameters != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    }
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.CommandType = type;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql,CommandType type,params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.CommandType = type;
                    if (parameters!=null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
