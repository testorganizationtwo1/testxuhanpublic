using MonitorNew.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace Monitor.DatabaseHelper
{
    public class SqlHelper
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["sqlConnectStr"].ToString();
        public SqlHelper()
        {
            Thread.Sleep(GlobalConstant.Speed);
        }
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
        /// <summary>
        /// 测试金蝶数据库连通性
        /// </summary>
        /// <returns>是否可以连接成功</returns>
        public string TestConnectSql()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            return "Kingdee数据库连接正常√";
                        }
                        else
                        {
                            return "Kingdee数据库连接失败×";
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SqlPour(string sql, Dictionary<string, string> dic)
        {   //可完成增删改
            try
            {
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
            catch (Exception e)
            {
                throw e;
            }
        }
        public ArrayList SelectInfo(string sql, Dictionary<string, string> dic)
        {   //可完成查找操作，以Object存取放入ArrayList返回
            try
            {
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
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 指定列、值返回指定列的数据
        /// </summary>
        /// <param name="returnColumnName">需要返回的列值</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">where条件中指定的列名</param>
        /// <param name="valueStr">where条件中指定列对应的指定数据</param>
        /// <returns></returns>
        public object SearchBySql(string sqlStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sqlStr, conn);
                    return com.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询任意表中的指定int列的数据
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="tableName">表名</param>
        /// <param name="whereStr">查询条件</param>
        /// <returns>指定int列的数据</returns>
        public int SelectId(string colName,string tableName,string whereStr)
        {   //可完成查找操作，以Object存取放入ArrayList返回
            try
            {
                string sql = "select " + colName + " from " + tableName + " where "+ whereStr;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    object id = com.ExecuteScalar();
                    return Convert.ToInt32(id);
                }
            }
            catch (Exception e)
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
        public int GetMaxId(string colName, string tableName)
        {
            try
            {
                string sql = "select max(" + colName + ") from " + tableName;
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
            catch (Exception ex)
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