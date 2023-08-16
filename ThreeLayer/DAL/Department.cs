using DBUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Department : IDAL.IDepartment
    {
        public int Insert(Model.Department department)
        {
            string sql = "insert into department(depid,depname) values(@depid,@depname)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@depid",SqlDbType.NVarChar,20),
                new SqlParameter("@depname",SqlDbType.NVarChar,20)
            };
            parameters[0].Value = department.DepId;
            parameters[1].Value = department.DepName;
            return DbHelperSQL.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public int Update(Model.Department department,string oldId)
        {
            string sql = "update department set depid=@depid,depname=@depname where depid=@oldid";
            SqlParameter[] parameters =
            {
                new SqlParameter("@depid",SqlDbType.NVarChar,20),
                new SqlParameter("@depname",SqlDbType.NVarChar,20),
                new SqlParameter("@oldid",SqlDbType.NVarChar,20)
            };
            parameters[0].Value = department.DepId;
            parameters[1].Value = department.DepName;
            parameters[2].Value = oldId;
            return DbHelperSQL.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public int Delete(string depId)
        {
            string sql = "delete from department where depid=@depid";
            SqlParameter parameter = new SqlParameter("@depid", SqlDbType.NVarChar, 20);
            parameter.Value = depId;
            return DbHelperSQL.ExecuteNonQuery(sql, CommandType.Text, parameter);
        }

        public object Exec_DepCount()
        {
            object obj = DbHelperSQL.ExecuteScalar("GetDepCount", CommandType.StoredProcedure);
            return obj;
        }

        public int Exec_ChangeName(string Id1,string Id2)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id1",SqlDbType.NVarChar,20),
                new SqlParameter("@Id2",SqlDbType.NVarChar,20)
            };
            parameters[0].Value = Id1;
            parameters[1].Value = Id2;
            return DbHelperSQL.ExecuteNonQuery("ChangeName", CommandType.StoredProcedure,parameters);
        }

        public List<Model.Department> GetList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from department");
            DataTable dt = DbHelperSQL.GetDataTable(sb.ToString(), CommandType.Text);
            List<Model.Department> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Model.Department>();
                Model.Department department = null;
                foreach (DataRow row in dt.Rows)
                {
                    department = new Model.Department();
                    LoadEntity(department, row);
                    list.Add(department);
                }
            }
            return list;
        }

        public List<Model.Department> GetList(Dictionary<string,string> dic)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from department");
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
            List<Model.Department> list = null;
            if (dt.Rows.Count > 0)
            {
                Model.Department department = null;
                foreach (DataRow row in dt.Rows)
                {
                    department = new Model.Department();
                    LoadEntity(department, row);
                    list.Add(department);
                }
            }
            return list;
        }

        private void LoadEntity(Model.Department department, DataRow row)
        {
            department.DepId = row["DepId"] != DBNull.Value ? row["DepId"].ToString() : string.Empty;
            department.DepName = row["DepName"] != DBNull.Value ? row["DepName"].ToString() : string.Empty;
        }

        public int Transaction(string Id1,string Name1, string Id2,string Name2)
        {
            string[] sqls =
            {
                "update Department set DepName=@Name1 where DepId=@Id1;","update Department set DepName=@Name2 where DepId=@Id2;",
            };
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            list.Add(new SqlParameter[]
            {
                new SqlParameter("@Name1",SqlDbType.NVarChar,20){ Value = Name1},
                new SqlParameter("@Id1",SqlDbType.NVarChar,20){Value = Id1}
            });
            list.Add(new SqlParameter[]
            {
                new SqlParameter("@Name2",SqlDbType.NVarChar,20){ Value = Name2},
                new SqlParameter("@Id2",SqlDbType.NVarChar,20){Value = Id2}
            });
            return DbHelperSQL.ExecuteTrans(sqls, list);
        }

    }
}
