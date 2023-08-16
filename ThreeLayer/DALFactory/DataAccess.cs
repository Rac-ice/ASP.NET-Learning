using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class DataAccess
    {
        static readonly string AssemblyName = ConfigurationManager.AppSettings["DALAssemblyName"];

        public static IDAL.IDepartment CreateDepartment()
        {
            string ClassNamespace = AssemblyName + ".DepartmentSQLite";
            object objType = Assembly.Load(AssemblyName).CreateInstance(ClassNamespace);
            return objType as IDAL.IDepartment;
        }

        public static IDAL.IStudent CreateStudent()
        {
            string ClassNamespace = AssemblyName + ".Student";
            object objType = Assembly.Load(AssemblyName).CreateInstance(ClassNamespace);
            return objType as IDAL.IStudent;
        }
    }
}
