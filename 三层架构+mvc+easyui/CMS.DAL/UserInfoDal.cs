using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CMS.DAL
{
    public class UserInfoDal
    {
        public UserInfo GetUserInfo(string txtName, string txtPwd)
        {
            string sql = "select * from T_UserInfo where UserName=@txtName and UserPwd=@txtPwd";
            SqlParameter[] parameters = {
                                            new SqlParameter("@txtName",SqlDbType.NVarChar,32),
                                            new SqlParameter("@txtPwd",SqlDbType.NVarChar,32)
                                        };
            parameters[0].Value = txtName;
            parameters[1].Value = txtPwd;
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
            UserInfo userInfo = null;
            if (dt.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(userInfo,dt.Rows[0]);
            }
            return userInfo;
        }

        private void LoadEntity(UserInfo userInfo, DataRow dataRow)
        {
            userInfo.Id = Convert.ToInt32(dataRow["Id"]);
            userInfo.UserName = dataRow["UserName"] != DBNull.Value ? dataRow["UserName"].ToString() : string.Empty;
            userInfo.UserPwd = dataRow["UserPwd"] != DBNull.Value ? dataRow["UserPwd"].ToString() : string.Empty;
            userInfo.UserMail = dataRow["UserMail"] != DBNull.Value ? dataRow["UserMail"].ToString() : string.Empty;
            userInfo.RegTime = Convert.ToDateTime(dataRow["RegTime"]);
        }
    }
}
