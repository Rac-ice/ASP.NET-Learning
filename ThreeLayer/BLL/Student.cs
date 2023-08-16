using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Student
    {
        IDAL.IStudent StuDal = DALFactory.DataAccess.CreateStudent();

        public bool Insert(Model.Student student)
        {
            return StuDal.Insert(student) > 0;
        }

        public bool Update(Model.Student student, string oldId)
        {
            return StuDal.Update(student, oldId) > 0;
        }

        public bool Delete(string stuId)
        {
            return StuDal.Delete(stuId) > 0;
        }

        public List<Model.Student> GetList()
        {
            return StuDal.GetList();
        }
        public List<Model.Student> GetList(Dictionary<string, string> dic)
        {
            return StuDal.GetList(dic);
        }
    }
}
