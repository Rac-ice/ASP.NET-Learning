using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class NewsComments
    {
        public int Id { get; set; }
        public int NewId { get; set; }
        public string Msg { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
