using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class UserInfoBll
    {
        DAL.UserInfoDal userInfoDal = new DAL.UserInfoDal();

        public UserInfo GetUserInfo(string txtName, string txtPwd)
        {
            return userInfoDal.GetUserInfo(txtName, txtPwd);
        }

    }
}
