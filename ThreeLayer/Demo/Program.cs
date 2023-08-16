using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Model.Department department = new Model.Department();
            IBLL.IDepartment depBll = BLLFactory.DataAccess.CreateDepartment();


            #region 系部添加
            //department.DepId = "test";
            //department.DepName = "test";
            //if (depBll.Insert(department))
            //{
            //    Console.WriteLine("ok");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}
            #endregion

            #region 系部展示
            //List<Model.Department> list = depBll.GetList();
            //foreach (Model.Department dept in list)
            //{
            //    Console.WriteLine("编号：{0}   名称：{1}", dept.DepId, dept.DepName);
            //}
            #endregion

            #region 系部修改
            //department.DepId = "006";
            //department.DepName = "艺术系";
            //string oldId = "006";
            //if (depBll.Update(department, oldId))
            //{
            //    Console.WriteLine("ok");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}
            #endregion

            #region 系部删除
            //string depId = "test";
            //if (depBll.Delete(depId))
            //{
            //    Console.WriteLine("ok");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}
            #endregion

            #region 执行存储过程
            //Console.WriteLine(depBll.Exec_DepCount());
            #endregion

            #region 执行用存储过程封装的事务
            //string Id1 = "002";
            //string Id2 = "006";
            //Console.WriteLine(depBll.Exec_ChangeName(Id1, Id2));
            #endregion

            #region 执行事务
            //Console.WriteLine(depBll.Transaction("002", "物理系", "006", "艺术系"));
            #endregion

            Console.ReadKey();
        }
    }
}
