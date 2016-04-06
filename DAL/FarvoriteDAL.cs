using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class FarvoriteDAL : DBHelper
    {
        public DataTable QueryAllRecord(string uid)
        {
            string sqlStr = "SELECT * FROM [Favorite] WHERE UserID=@UserID";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@UserID", uid);
            return GetDataTable(sqlStr, SqlParam);
        }

        public Farvorite QueryOneRecord(string uid, string foodID)
        {
            Farvorite farvorite;
            string sqlStr = "SELECT * FROM [Favorite] WHERE UserID=@UserID AND FoodID=@FoodID";
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@UserID", uid);
            SqlParam[1] = new SqlParameter("@FoodID", foodID);
            SqlDataReader dataReader = GetDataReader(sqlStr, SqlParam);
            if (dataReader.Read())
            {
                farvorite = new Farvorite();
                farvorite.ID = dataReader["ID"].ToString();
                farvorite.UserID = dataReader["UserID"].ToString();
                farvorite.FoodID = dataReader["FoodID"].ToString();
                farvorite.Date = dataReader["Date"].ToString();
                if (dataReader.Read())
                {
                    throw new Exception("表有重复，请检查。");
                }
            }
            else
            {
                farvorite = null;
            }
            dataReader.Close();
            return farvorite;
        }

        public bool InsertOneRecord(string uid, string foodID)
        {
            //设置Sql语句
            string sqlStr = "INSERT INTO [Favorite]([UserID],[FoodID])"
                + " VALUES(@UserID,@FoodID)";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@UserID", uid);
            SqlParam[1] = new SqlParameter("@FoodID", foodID);
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

        public bool DeleteOneRecord(string uid, string foodID)
        {
            //设置Sql语句
            string sqlStr = "DELETE FROM [Favorite] WHERE UserID=@UserID AND FoodID=@FoodID";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@UserID", uid);
            SqlParam[1] = new SqlParameter("@FoodID", foodID);
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
    }
}
