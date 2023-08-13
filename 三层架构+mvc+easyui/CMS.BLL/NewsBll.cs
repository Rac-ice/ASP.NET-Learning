using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class NewsBll
    {
        CMS.DAL.NewsDal newsDal = new DAL.NewsDal();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public List<News> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return newsDal.GetPageList(start, end);
        }
        /// <summary>
        /// 获取总的页数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = newsDal.GetRecordCount();
            int pageCount = Convert.ToInt32( Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        public News GetModel(int id)
        {
            return newsDal.GetModel(id);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteInfo(int id)
        {
            return newsDal.DeleteInfo(id) > 0;
        }

        public bool AddNew(News news)
        {
            return newsDal.AddNew(news) > 0;
        }
    }
}
