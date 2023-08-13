using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //约定大于配置
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            string vCode = Session["vCode"] == null ? string.Empty : Session["vCode"].ToString();
            if (string.IsNullOrEmpty(vCode))
            {
                return Content("null:验证码为空");
            }
            if (vCode.Equals(Request["txtCode"],StringComparison.InvariantCultureIgnoreCase))
            {
                string txtName = Request["txtName"];
                string txtPwd = Request["txtPwd"];
                BLL.UserInfoBll userInfoBll = new BLL.UserInfoBll();
                UserInfo userInfo = userInfoBll.GetUserInfo(txtName, txtPwd);
                if (userInfo != null)
                {
                    Session["UserInfo"] = userInfo;
                    Session["vCode"] = null;
                    return Content("ok:登录成功");
                }
                else
                {
                    return Content("no:登录失败");
                }
            }
            else
            {
                return Content("null:验证码错误");
            }
        }

        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.GetRandomString(5);//获取验证码
            Session["vCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }

        public ActionResult CheckCode()
        {
            if (!string.IsNullOrEmpty(Request["txtCode"]))
            {
                if (Session["vCode"].ToString().Equals(Request["txtCode"],StringComparison.InvariantCultureIgnoreCase))
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
            else
            {
                return Content("null");
            }
        }
    }
}
