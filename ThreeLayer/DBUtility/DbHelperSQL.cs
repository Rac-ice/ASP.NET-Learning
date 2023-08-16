using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBUtility
{
    public partial class DbHelperSQL
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        //private static readonly string connString = @"server=LAPTOP-ENH36EGQ\MSSQLSERVER2012;uid=sa;pwd=271016;database=MyDb";

        /// <summary>
        /// 执行sql语句，返回查询表格
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">语句类型</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
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

        /// <summary>
        /// 执行sql语句，返回受影响行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">语句类型</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

        /// <summary>
        /// 执行sql语句，返回查询结果
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">语句类型</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int ExecuteTrans(string[] sqls, List<SqlParameter[]> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        int result = 0;
                        for (int i = 0; i < sqls.Length; i++)
                        {
                            cmd.CommandText += sqls[i];
                            cmd.Parameters.AddRange(parameters[i]);
                        }
                        cmd.Transaction = trans;
                        result = cmd.ExecuteNonQuery();
                        trans.Commit();
                        return result;
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
        }
    }
}
