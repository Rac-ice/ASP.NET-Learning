using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Student
    {
        public string StuId { get; set; }
        public string StuName { get; set; }
        public int StuAge { get; set; }
        public string StuGender { get; set; }
        public string DepId { get; set; }
    }
}
