using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.DatabaseHelper
{
    public class SqlHelper
    {
        static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["sqlConnectStr"].ToString();

        public string GetSqlForKingdeeSql(string fileName)
        {
            string directoryStr = string.Format("{0}\\DatabaseHelper\\KingdeeSql\\{1}", Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(directoryStr))
            {
                return null;
            }
            using (StreamReader rs = new StreamReader(directoryStr, System.Text.Encoding.UTF8))//注意编码
            {
                string resultStr = rs.ReadToEnd();
                rs.Close();
                return resultStr;
            }
        }
        public bool ConnectSql()
        {   // 连接数据库
            try
            {
                //if(conn.State==ConnectionState.Closed)
                //    conn.Open();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool SqlPour(string sql, Dictionary<string, string> dic)
        {   //可完成增删改
            try
            {
                ConnectSql();   //打开连接
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    if (dic != null)
                    {
                        foreach (var item in dic)
                        {
                            com.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    com.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public ArrayList SelectInfo(string sql, Dictionary<string, string> dic)
        {   //可完成查找操作，以Object存取放入ArrayList返回
            try
            {
                ConnectSql();   //打开连接
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    ArrayList al = new ArrayList();
                    if (dic != null)
                    {
                        foreach (var item in dic)
                        {   //遍历参数并进行赋值，防止sql注入
                            com.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    SqlDataReader rd = com.ExecuteReader();
                    int clumn = 0;  //得到数据的列数
                    if (rd.Read())
                    {
                        clumn = rd.FieldCount;
                    }
                    else
                    {
                        rd.Close();
                        return new ArrayList();
                    }
                    do
                    {   //读取每行每列的数据并放入Object数组中
                        Object[] obj = new object[clumn];
                        for (int i = 0; i < clumn; i++)
                        {
                            obj[i] = rd[i];
                        }
                        al.Add(obj);    //将一行数据放入数组中
                    } while (rd.Read());
                    rd.Close();
                    conn.Close();
                    return al;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 获取主键中最大的值加1
        /// 为了插入新数据使用
        /// </summary>
        /// <param name="colName">需要查询的列名</param>
        /// <param name="tableName">需要查询的表名</param>
        /// <returns></returns>
        public int GetMaxId(string colName,string tableName)
        {
            try
            {
                string sql = "select max("+ colName + ") from "+ tableName;
                ConnectSql();   //打开连接
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    SqlDataReader rd = com.ExecuteReader();
                    if (rd.Read())
                    {
                        int result = Convert.ToInt32(rd.GetValue(0)) + 1;
                        rd.Close();
                        conn.Close();
                        return result;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void closeConn()
        {   //关闭数据库连接
            try
            {
                //if (conn != null) { conn.Close(); }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
