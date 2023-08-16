using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CMS.DAL
{
    public class NewsDal
    {
        public List<News> GetPageList(int start, int end)
        {
            string sql = "select * from (select row_number() over(order by id) as num,* from T_News) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] parameters = {
                                            new SqlParameter("@start",SqlDbType.Int),
                                            new SqlParameter("@end",SqlDbType.Int)
                                        };
            parameters[0].Value = start;
            parameters[1].Value = end;
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
            List<News> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<News>();
                News news = null;
                foreach (DataRow row in dt.Rows)
                {
                    news = new News();
                    Entity(news, row);
                    list.Add(news);
                }
            }
            return list;
        }

        private void Entity(News news, DataRow row)
        {
            news.Id = Convert.ToInt32(row["Id"]);
            news.Title = row["Title"] != DBNull.Value ? row["Title"].ToString() : string.Empty;
            news.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
            news.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            news.Author = row["Author"] != DBNull.Value ? row["Author"].ToString() : string.Empty;
            news.ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : string.Empty;
        }
        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from T_News";
            return Convert.ToInt32( SqlHelper.ExecuteScalar(sql,CommandType.Text));
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News GetModel(int id)
        {
            string sql = "select * from T_News where Id=@id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, parameter);
            News news = null;
            if (dt.Rows.Count > 0)
            {
                news = new News();
                Entity(news, dt.Rows[0]);
            }
            return news;
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteInfo(int id)
        {
            string sql = "delete from T_News where Id=@id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameter);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int AddNew(News news)
        {
            string sql = "insert into T_News values(@Author,@Title,@Msg,@ImagePath,@SubDateTime)";
            SqlParameter[] parameters = {
                                            new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                            new SqlParameter("@Title",SqlDbType.NVarChar,128),
                                            new SqlParameter("@Msg",SqlDbType.NVarChar),
                                            new SqlParameter("@ImagePath",SqlDbType.NVarChar,128),
                                            new SqlParameter("@SubDateTime",SqlDbType.DateTime)
                                        };
            parameters[0].Value = news.Author;
            parameters[1].Value = news.Title;
            parameters[2].Value = news.Msg;
            parameters[3].Value = "";
            parameters[4].Value = news.SubDateTime;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }
    }
}
