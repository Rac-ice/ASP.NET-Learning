using DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class Student : IDAL.IStudent
    {
        public int Insert(Model.Student student)
        {
            string sql = "insert into student(stuid,stuname,stuage,stugender,depid) values(@stuid,@stuname,@stuage,@stugender,@depid)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@stuid",SqlDbType.NVarChar,20),
                new SqlParameter("@stuname",SqlDbType.NVarChar,10),
                new SqlParameter("@stuage",SqlDbType.Int,4),
                new SqlParameter("@stugender",SqlDbType.NVarChar,2),
                new SqlParameter("@depid",SqlDbType.NVarChar,20)
            };
            parameters[0].Value = student.StuId;
            parameters[1].Value = student.StuName;
            parameters[2].Value = student.StuAge;
            parameters[3].Value = student.StuGender;
            parameters[4].Value = student.DepId;
            return DbHelperSQL.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public int Update(Model.Student student, string oldId)
        {
            string sql = "update student set stuid=@stuid,stuname=@stuname,stuage=@stuage,stugender=@stugender,depid=@depid where stuid=@oldid";
            SqlParameter[] parameters =
            {
                new SqlParameter("@stuid",SqlDbType.NVarChar,20),
                new SqlParameter("@stuname",SqlDbType.NVarChar,10),
                new SqlParameter("@stuage",SqlDbType.Int,4),
                new SqlParameter("@stugender",SqlDbType.NVarChar,2),
                new SqlParameter("@depid",SqlDbType.NVarChar,20),
                new SqlParameter("@oldid",SqlDbType.NVarChar,20)
            };
            parameters[0].Value = student.StuId;
            parameters[1].Value = student.StuName;
            parameters[2].Value = student.StuAge;
            parameters[3].Value = student.StuGender;
            parameters[4].Value = student.DepId;
            parameters[5].Value = oldId;
            return DbHelperSQL.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public int Delete(string stuId)
        {
            string sql = "delete from student where stuid=@stuid";
            SqlParameter parameter = new SqlParameter("@stuid", SqlDbType.NVarChar, 20);
            parameter.Value = stuId;
            return DbHelperSQL.ExecuteNonQuery(sql, CommandType.Text, parameter);
        }

        public List<Model.Student> GetList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from student");
            DataTable dt = DbHelperSQL.GetDataTable(sb.ToString(), CommandType.Text);
            List<Model.Student> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Model.Student>();
                Model.Student student = null;
                foreach (DataRow row in dt.Rows)
                {
                    student = new Model.Student();
                    LoadEntity(student, row);
                    list.Add(student);
                }
            }
            return list;
        }

        public List<Model.Student> GetList(Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from student");
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (dic != null)
            {
                sb.Append(" where ");
                int count = dic.Count;
                foreach (var pair in dic)
                {
                    sb.Append(pair.Key + "=" + pair.Value);
                    parameters.Add(new SqlParameter("@" + pair.Key, pair.Value));
                    count--;
                    if (count > 0)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            DataTable dt = DbHelperSQL.GetDataTable(sb.ToString(), CommandType.Text, parameters.ToArray());
            List<Model.Student> list = null;
            if (dt.Rows.Count > 0)
            {
                Model.Student student = null;
                foreach (DataRow row in dt.Rows)
                {
                    student = new Model.Student();
                    LoadEntity(student, row);
                    list.Add(student);
                }
            }
            return list;
        }

        private void LoadEntity(Model.Student student, DataRow row)
        {
            student.StuId = row["StuId"] != DBNull.Value ? row["StuId"].ToString() : string.Empty;
            student.StuName = row["StuName"] != DBNull.Value ? row["StuName"].ToString() : string.Empty;
            student.StuAge = Convert.ToInt32(row["StuAge"]);
            student.StuGender = row["StuGender"] != DBNull.Value ? row["StuGender"].ToString() : string.Empty;
            student.DepId = row["DepId"] != DBNull.Value ? row["DepId"].ToString() : string.Empty;
        }
    }
}
