using DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Model;

namespace DAL
{
    public class DepartmentSQLite : IDAL.IDepartment
    {
        public int Delete(string depId)
        {
            string sql = "delete from department where depid=@depid";
            SQLiteParameter parameter = new SQLiteParameter("@depid", depId);
            return DbHelperSQLite.ExecuteNonQuery(sql, parameter);
        }

        public int Exec_ChangeName(string Id1, string Id2)
        {
            throw new NotImplementedException();
        }

        public object Exec_DepCount()
        {
            throw new NotImplementedException();
        }

        public List<Model.Department> GetList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from department");
            DataTable dt = DbHelperSQLite.GetDataTable(sb.ToString());
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

        public List<Model.Department> GetList(Dictionary<string, string> dic)
        {
            throw new NotImplementedException();
        }

        public int Insert(Model.Department department)
        {
            string sql = "insert into Department(depid,depname) values(@depid,@depname)";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@depid",department.DepId),
                new SQLiteParameter("@depname",department.DepName)
            };
            return DbHelperSQLite.ExecuteNonQuery(sql, parameters);
        }

        public int Transaction(string Id1, string Name1, string Id2, string Name2)
        {
            throw new NotImplementedException();
        }

        public int Update(Model.Department department, string oldId)
        {
            string sql = "update department set depid=@depid,depname=@depname where depid=@oldid";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@depid",department.DepId),
                new SQLiteParameter("@depname",department.DepName),
                new SQLiteParameter("@oldid",oldId)
            };
            return DbHelperSQLite.ExecuteNonQuery(sql, parameters);
        }

        private void LoadEntity(Model.Department department, DataRow row)
        {
            department.DepId = row["DepId"] != DBNull.Value ? row["DepId"].ToString() : string.Empty;
            department.DepName = row["DepName"] != DBNull.Value ? row["DepName"].ToString() : string.Empty;
        }
    }
}
