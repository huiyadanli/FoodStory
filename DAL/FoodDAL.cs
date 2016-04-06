using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class FoodDAL : DBHelper
    {
        //查询一条记录
        public Food QueryOneRecord(string id)
        {
            Food food;
            //设置sql语句
            string sqlStr = "SELECT * FROM Food WHERE ID=@ID";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@ID", id);
            //获取Sql DataReader对象
            SqlDataReader dataReader = GetDataReader(sqlStr, SqlParam);
            //如果 Sql DataReader对象可以读取到记录
            if (dataReader.Read())
            {
                //将DataReader对象转化成user(Model)对象
                food = new Food();
                food.ID = dataReader["ID"].ToString();
                food.UploaderID = dataReader["UploaderID"].ToString();
                food.Title = dataReader["Title"].ToString();
                food.Cover = dataReader["Cover"].ToString();
                food.Contents = dataReader["Contents"].ToString();
                food.Date = dataReader["Date"].ToString();
                //判断是否还可以读取到记录，如果可以，跑出异常
                if (dataReader.Read())
                {
                    throw new Exception("Food表有重复，请检查。");
                }
            }
            else
            {
                food = null;
            }
            dataReader.Close();//关闭SqlDataReader
            return food;
        }

        //上传者的所有记录
        public DataTable QueryAllRecordByUID(string uid)
        {
            string sqlStr = "SELECT * FROM Food WHERE UploaderID=@UploaderID";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@UploaderID", uid);
            return GetDataTable(sqlStr, SqlParam);
        }

        //搜索
        public DataTable Search(String[] keywords)
        {
            string sqlStr0 = "SELECT * FROM Food ";
            string sqlStr1 = "WHERE ";
            string sqlStr2 = "ORDER BY ";
            SqlParameter[] SqlParam = new SqlParameter[keywords.Length];
            for (int i = 0; i < keywords.Length; i++)
            {

                if (i == keywords.Length - 1)
                {
                    sqlStr1 += "Title LIKE @KeyWord" + i.ToString() + " ";
                    sqlStr2 += "(CASE WHEN Title LIKE @KeyWord" + i.ToString() + " THEN 1 ELSE 0 END) DESC";
                    SqlParam[i] = new SqlParameter("@KeyWord" + i.ToString(), "%" + keywords[i].ToString() + "%");
                }
                else
                {
                    sqlStr1 += "Title LIKE @KeyWord" + i.ToString() + " OR ";
                    sqlStr2 += "(CASE WHEN Title LIKE @KeyWord" + i.ToString() + " THEN 1 ELSE 0 END) + ";
                    SqlParam[i] = new SqlParameter("@KeyWord" + i.ToString(), "%" + keywords[i].ToString() + "%");
                }
            }
            string sqlStr = sqlStr0 + sqlStr1 + sqlStr2;
            return GetDataTable(sqlStr, SqlParam);
        }

        //插入一条记录
        public bool InsertOneRecord(Food food)
        {
            //设置Sql语句
            string sqlStr = "INSERT INTO [Food]([UploaderID],[Title],[Cover],[Contents])"
                + " VALUES(@UploaderID,@Title,@Cover,@Contents)";
            //设置Sql参数数组
            SqlParameter[] SqlParam = new SqlParameter[4];
            SqlParam[0] = new SqlParameter("@UploaderID", food.UploaderID);
            SqlParam[1] = new SqlParameter("@Title", food.Title);
            SqlParam[2] = new SqlParameter("@Cover", food.Cover);
            SqlParam[3] = new SqlParameter("@Contents", food.Contents);
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

        //逆序查询前num条记录
        public DataTable QueryMultRecord(int num)
        {
            string sqlStr = "SELECT TOP " + num + " * FROM Food ORDER BY ID DESC";
            return GetDataTable(sqlStr);
        }
    }
}
