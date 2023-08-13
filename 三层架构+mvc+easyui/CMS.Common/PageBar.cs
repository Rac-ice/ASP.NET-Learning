using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public class PageBar
    {
        /// <summary>
        /// 产生数字页码条
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="PageCount">总的页数</param>
        /// <returns></returns>
        public static string GetPageBar(int pageIndex,int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 5;//起始位置，要求页面上显示10个数字页码
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;//终止位置
            if (end > pageCount)
            {
                end = pageCount;
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex != 1)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}'>❮</a>", pageIndex - 1));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(string.Format("<a href='javascript:void(0)' class='active'>{0}</a>", i));
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>", i));
                }
            }
            if (pageIndex != pageCount)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}'>❯</a>", pageIndex + 1));
            }
            return sb.ToString();
        }
    }
}
