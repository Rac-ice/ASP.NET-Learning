using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IDepartment
    {
        int Insert(Model.Department department);
        int Update(Model.Department department, string oldId);
        int Delete(string depId);

        object Exec_DepCount();
        int Exec_ChangeName(string Id1, string Id2);

        int Transaction(string Id1, string Name1, string Id2, string Name2);

        List<Model.Department> GetList();
        List<Model.Department> GetList(Dictionary<string,string> dic);
    }
}
