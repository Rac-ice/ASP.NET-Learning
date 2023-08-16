using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IStudent
    {
        int Insert(Model.Student student);
        int Update(Model.Student student, string oldId);
        int Delete(string stuId);
        List<Model.Student> GetList();
        List<Model.Student> GetList(Dictionary<string, string> dic);
    }
}
