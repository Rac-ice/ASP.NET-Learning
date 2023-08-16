using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Department : IDepartment
    {
        IDAL.IDepartment DepDal = DALFactory.DataAccess.CreateDepartment();

        public bool Insert(Model.Department department)
        {
            return DepDal.Insert(department) > 0;
        }

        public bool Update(Model.Department department, string oldId)
        {
            return DepDal.Update(department, oldId) > 0;
        }

        public bool Delete(string depId)
        {
            return DepDal.Delete(depId) > 0;
        }

        public object Exec_DepCount()
        {
            return DepDal.Exec_DepCount();
        }

        public bool Exec_ChangeName(string Id1, string Id2)
        {
            return DepDal.Exec_ChangeName(Id1, Id2) > 0;
        }

        public List<Model.Department> GetList()
        {
            return DepDal.GetList();
        }

        public List<Model.Department> GetList(Dictionary<string, string> dic)
        {
            return DepDal.GetList(dic);
        }

        public bool Transaction(string Id1, string Name1, string Id2, string Name2)
        {
            return DepDal.Transaction(Id1, Name1,Id2,Name2) > 0;
        }
    }
}
