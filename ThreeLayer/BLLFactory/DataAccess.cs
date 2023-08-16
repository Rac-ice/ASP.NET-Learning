using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLLFactory
{
    public class DataAccess
    {
        static readonly string AssemblyName = ConfigurationManager.AppSettings["BLLAssemblyName"];

        public static IBLL.IDepartment CreateDepartment()
        {
            string ClassNamespace = AssemblyName + ".Department";
            object objType = Assembly.Load(AssemblyName).CreateInstance(ClassNamespace);
            return objType as IBLL.IDepartment;
        }
    }
}
