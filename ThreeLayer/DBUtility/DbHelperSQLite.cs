using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtility
{
    public partial class DbHelperSQLite
    {
        private static readonly string sqliteConnString = ConfigurationManager.ConnectionStrings["sqliteConnString"].ConnectionString;
        //private static readonly string sqliteConnString = @"Data Source=C:\Users\16025\Documents\Visual Studio Project\Web\ThreeDemo\SchoolDb;Version=3;";

        /// <summary>
        /// 执行sql语句，返回查询表格
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(sqliteConnString))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
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
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(sqliteConnString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
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
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(sqliteConnString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
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
