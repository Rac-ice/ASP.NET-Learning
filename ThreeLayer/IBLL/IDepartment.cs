using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IDepartment
    {
        bool Insert(Model.Department department);

        bool Update(Model.Department department, string oldId);
        bool Delete(string depId);

        object Exec_DepCount();
        bool Exec_ChangeName(string Id1, string Id2);

        bool Transaction(string Id1, string Name1, string Id2, string Name2);

        List<Model.Department> GetList();
        List<Model.Department> GetList(Dictionary<string, string> dic);
    }
}
