using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    //数据库操作类
    public class DBHelper
    {
        //类字段
        private string _ConnectionString;

        //类属性
        public string ConnectionString
        {
            get { return this._ConnectionString;  }
            set { this._ConnectionString = value; }
        }

        //构造函数
        public DBHelper()
        {
            //获取数据库连接字符串(ConfigurationManager类需要引入System.Configuration的命名空间)
            ConnectionString = ConfigurationManager.ConnectionStrings["FoodStory"].ConnectionString;
        }

        //打开数据库连接
        public SqlConnection OpenConnection()
        {
            //创建并打开数据库连接
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }
        
        //执行不带参数的查询语句，返回一个整数(查询结果的第1行第1列)
        public int ExecuteScalarToInt(string safeSql)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        //执行带参数的查询语句，返回一个整数(查询结果的第1行第1列)
        public int ExecuteScalarToInt(string sql, params SqlParameter[] values)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                string resultStr = cmd.ExecuteScalar().ToString();
                if (resultStr != "")
                    result = Convert.ToInt32(resultStr);
                else
                    result = 0;
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        //执行不带参数的查询语句，返回一个字符串(查询结果的第1行第1列)
        public string ExecuteScalarToStr(string safeSql)
        {
            string result = "";
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                result = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        //执行带参数的查询语句，返回一个字符串(查询结果的第1行第1列)
        public string ExecuteScalarToStr(string sql, params SqlParameter[] values)
        {
            string result = "";
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                result = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        //执行不带参数的非查询语句(增、删、改)，返回受影响的记录行数
        public int ExecuteNonQuery(string safeSql)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        //执行带参数的非查询语句(增、删、改)，返回受影响的记录行数
        public int ExecuteNonQuery(string sql, params SqlParameter[] values)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        //执行不带参数的查询语句，获得一个SqlDataReader对象
        public SqlDataReader GetDataReader(string safeSql)
        {
            SqlDataReader reader;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //connection.Close();   //此处不能关闭connection，会导致后面SqlDataReader读取数据失败
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return reader;
        }

        //执行带参数的查询语句，获得一个SqlDataReader对象
        public SqlDataReader GetDataReader(string sql, params SqlParameter[] values)
        {
            SqlDataReader reader;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //connection.Close();  //此处不能关闭connection，会导致后面SqlDataReader读取数据失败
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }
            return reader;
        }

        //执行不带参数的查询语句，返回一个DataTable对象
        public DataTable GetDataTable(string safeSql)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                connection.Close();  
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return ds.Tables[0];
        }

        //执行带参数的查询语句，返一个DataTable对象
        public DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return ds.Tables[0];
        }
    }
}

