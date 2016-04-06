using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Web.Security;

namespace DAL
{
    public class UserDAL : DBHelper
    {
        //查询一条记录
        public User QueryOneRecord(string username)
        {
            User user;
            //设置sql语句
            string sqlStr = "SELECT * FROM [User] WHERE Email=@Username";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@Username", username);
            //获取Sql DataReader对象
            SqlDataReader dataReader = GetDataReader(sqlStr, SqlParam);
            //如果 Sql DataReader对象可以读取到记录
            if (dataReader.Read())
            {
                //将DataReader对象转化成user(Model)对象
                user = new User();
                user.ID = dataReader["ID"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Pwd = dataReader["Pwd"].ToString();
                user.NickName = dataReader["NickName"].ToString();
                user.Sex = dataReader["Sex"].ToString();
                user.FacePath = dataReader["FacePath"].ToString();
                user.Phone = dataReader["Phone"].ToString();
                user.QQ = dataReader["QQ"].ToString();
                user.RegTime = dataReader["RegTime"].ToString();
                //判断是否还可以读取到记录，如果可以，跑出异常
                if (dataReader.Read())
                {
                    throw new Exception("User表有重复，请检查。");
                }

            }
            else
            {
                user = null;
            }
            dataReader.Close();//关闭SqlDataReader
            //返回user类对象
            return user;
        }

        //查询一条记录
        public User QueryOneRecordByID(string id)
        {
            User user;
            //设置sql语句
            string sqlStr = "SELECT * FROM [User] WHERE ID=@ID";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@ID", id);
            //获取Sql DataReader对象
            SqlDataReader dataReader = GetDataReader(sqlStr, SqlParam);
            //如果 Sql DataReader对象可以读取到记录
            if (dataReader.Read())
            {
                //将DataReader对象转化成user(Model)对象
                user = new User();
                user.ID = dataReader["ID"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Pwd = dataReader["Pwd"].ToString();
                user.NickName = dataReader["NickName"].ToString();
                user.Sex = dataReader["Sex"].ToString();
                user.FacePath = dataReader["FacePath"].ToString();
                user.Phone = dataReader["Phone"].ToString();
                user.QQ = dataReader["QQ"].ToString();
                user.RegTime = dataReader["RegTime"].ToString();
                //判断是否还可以读取到记录，如果可以，跑出异常
                if (dataReader.Read())
                {
                    throw new Exception("User表有重复，请检查。");
                }

            }
            else
            {
                user = null;
            }
            dataReader.Close();//关闭SqlDataReader
            //返回user类对象
            return user;
        }

        //查询用户是否存在
        public bool IsExist(string username)
        {
            //设置sql语句
            string sqlStr = "SELECT COUNT(*) FROM [User] WHERE Email=@Username";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@Username", username);
            //执行Sql语句，查询结果的第一行第一列，并转化为整数
            int result = ExecuteScalarToInt(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的学生学号有重复，请检查。");
            }
        }

        //插入一条记录
        public bool InsertOneRecord(User user)
        {
            //查询邮箱号是否存在
            if (IsExist(user.Email) == false)
            {
                //设置Sql语句
                string sqlStr = "INSERT INTO [User]([Email],[Pwd],[NickName],[Sex],[FacePath],[Phone],[QQ],[EmailVerification])"
                    + " VALUES(@Email,@Pwd,@NickName,@Sex,@FacePath,@Phone,@QQ,@EmailVerification)";
                //设置Sql参数数组
                SqlParameter[] SqlParam = new SqlParameter[8];
                SqlParam[0] = new SqlParameter("@Email", user.Email);
                SqlParam[1] = new SqlParameter("@Pwd", user.Pwd);
                SqlParam[2] = new SqlParameter("@NickName", user.NickName);
                SqlParam[3] = new SqlParameter("@Sex", user.Sex);
                SqlParam[4] = new SqlParameter("@FacePath", user.FacePath);
                SqlParam[5] = new SqlParameter("@Phone", user.Phone);
                SqlParam[6] = new SqlParameter("@QQ", user.QQ);
                SqlParam[7] = new SqlParameter("@EmailVerification", user.EmailVerification);
                //执行SQL语句，并返回受影响的记录
                int result = ExecuteNonQuery(sqlStr, SqlParam);
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //更新一条记录
        public bool UpdateOneRecord(User user)
        {
            //设置Sql语句
            string sqlStr = "UPDATE [User] SET [NickName] = @NickName,[Sex] = @Sex,[FacePath] = @FacePath,[Phone] = @Phone,[QQ] = @QQ,[EmailVerification] = @EmailVerification WHERE [Email] = @Email";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[7];
            SqlParam[0] = new SqlParameter("@NickName", user.NickName);
            SqlParam[1] = new SqlParameter("@Sex", user.Sex);
            SqlParam[2] = new SqlParameter("@FacePath", user.FacePath);
            SqlParam[3] = new SqlParameter("@Phone", user.Phone);
            SqlParam[4] = new SqlParameter("@QQ", user.QQ);
            SqlParam[5] = new SqlParameter("@EmailVerification", user.EmailVerification);
            SqlParam[6] = new SqlParameter("@Email", user.Email);
            //执行SQL语句，并返回受影响的记录
            int result = ExecuteNonQuery(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的用户名有重复，请检查。");
            }
        }

        //更新一条记录的密码字段
        public bool UpdateOneRecordPwd(string email, string newPwd)
        {

            //设置sql语句
            string sqlStr = "UPDATE [User] SET Pwd=@Pwd WHERE [Email] = @Email";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@Pwd", FormsAuthentication.HashPasswordForStoringInConfigFile(newPwd, "MD5"));
            SqlParam[1] = new SqlParameter("@Email", email);
            //执行SQL语句，并返回受影响的记录
            int result = ExecuteNonQuery(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的用户名有重复，请检查。");
            }
        }

        //更新一条任意字段
        public bool UpdateOneRecordAny(string email, string field, string value)
        {

            //设置sql语句
            string sqlStr = "UPDATE [User] SET " + field + "=@Value WHERE [Email] = @Email";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@Value", value);
            SqlParam[1] = new SqlParameter("@Email", email);
            //执行SQL语句，并返回受影响的记录
            int result = ExecuteNonQuery(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的用户名有重复，请检查。");
            }
        }
    }
}
