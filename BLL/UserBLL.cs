using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Web.Security;
using System.Data;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();
        private FarvoriteDAL farvoriteDAL = new FarvoriteDAL();

        //查询用户信息，返回User对象或者null
        public User QueryInfo(string username)
        {
            return userDAL.QueryOneRecord(username);
        }

        //查询用户信息，返回User对象或者null
        public User QueryInfoByID(string id)
        {
            return userDAL.QueryOneRecordByID(id);
        }

        //验证用户密码是否正确
        public bool VerifyPwd(string username, string pwd)
        {
            //查询用户信息，成功返回true，失败返回false
            User user = QueryInfo(username);
            //判断是否查询到学生信息
            if (user == null)
            {
                return false;
            }
            else
            {
                //如果代码正确或为空，或数据库中密码为空
                if (user.Pwd == FormsAuthentication
                    .HashPasswordForStoringInConfigFile(pwd, "MD5"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //查询用户名是否存在
        public bool IsExist(string username)
        {
            return userDAL.IsExist(username);
        }

        //注册用户
        public bool Register(User user)
        {
            return userDAL.InsertOneRecord(user);
        }

        //修改用户信息
        public bool ModifyInfo(User user)
        {
            return userDAL.UpdateOneRecord(user);
        }

        //修改用户密码
        public bool ModifyPwd(string email, string oldPwd, string newPwd)
        {
            //判断老密码是否准确
            if (VerifyPwd(email, oldPwd) == true)
            {
                //更新新密码并返回结果
                return userDAL.UpdateOneRecordPwd(email, newPwd);
            }
            else
            {
                return false;
            }
        }

        //修改用户头像
        public bool ModifyFace(string email, string path)
        {
            return userDAL.UpdateOneRecordAny(email, "FacePath", path);
        }

        //返回用户喜欢的
        public DataTable FarvoriteTable(string id)
        {
            return farvoriteDAL.QueryAllRecord(id);
        }
    }
}
