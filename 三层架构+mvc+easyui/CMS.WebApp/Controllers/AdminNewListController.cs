using CMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.WebApp.Controllers
{
    public class AdminNewListController : Controller
    {
        //
        // GET: /AdminNewListController/
        BLL.NewsBll newsBll = new BLL.NewsBll();
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 3;
            int pageCount = newsBll.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<News> list = newsBll.GetPageList(pageIndex, pageSize);
            ViewData["list"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }

        public ActionResult GetNewInfoModel()
        {
            int id = int.Parse(Request["id"]);
            News news = newsBll.GetModel(id);//获取详细信息
            return Json(news, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            if (newsBll.DeleteInfo(id))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        public ActionResult ShowAddInfo()
        {
            return View();
        }

        public ActionResult FileUpload()
        {
            HttpPostedFileBase postFile = Request.Files["fileUp"];//接收文件数据
            if (postFile==null)
            {
                return Content("no:请选择上传文件");
            }
            else
            {
                string fileName = Path.GetFileName(postFile.FileName); //文件名
                string fileExt = Path.GetExtension(fileName);//文件的扩展名称
                if (fileExt == ".jpg" || fileExt == ".png")
                {
                    string dir = "/ImagePath/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                     Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));//创建文件夹
                     string newfileName = Guid.NewGuid().ToString();//新的文件名
                     string fullDir = dir + newfileName + fileExt;//完整的路径
                     postFile.SaveAs(Request.MapPath(fullDir));//保存文件
                     return Content("ok:" + fullDir);
                }
                else
                {
                    return Content("no:文件格式错误");
                }
            }
        }
        [ValidateInput(false)]
        public ActionResult AddNewInfo(News news)
        {
            news.SubDateTime = DateTime.Now;
            if (newsBll.AddNew(news))
            {
                return Content("ok");
            }else
            {
                return Content("no");
            }
        }
    }
}
