using System;
using System.Configuration;
using System.Data;
using System.Threading;
using MonitorNew.Tools;
using Npgsql;

namespace Monitor.DatabaseHelper
{
    public class PgsqlHelper
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["postgres"].ToString();
        public PgsqlHelper()
        {
            Thread.Sleep(GlobalConstant.Speed);
        }
        /// <summary>
        /// 测试Odoo数据库连通性
        /// </summary>
        /// <returns>是否可以连接成功</returns>
        public string TestConnectSql()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            return "Odoo数据库连接正常√";
                        }
                        else
                        {
                            return "Odoo数据库连接失败×";
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
        /// <summary>
        /// 指定列、值返回指定列的数据
        /// </summary>
        /// <param name="returnColumnName">需要返回的列值</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">where条件中指定的列名</param>
        /// <param name="valueStr">where条件中指定列对应的指定数据</param>
        /// <returns></returns>
        public object SearchByPgSql(string sqlStr)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    NpgsqlCommand com = new NpgsqlCommand(sqlStr, conn);
                    return com.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 增 删 改（无参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSQL(string sql)
        {
            int n = -1;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        n = cmd.ExecuteNonQuery();
                    }
                    catch (NpgsqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return n;

        }


        /// <summary>
        /// 增 删 改（有参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params NpgsqlParameter[] parameters)
        {
            int n = -1;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                using (NpgsqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    n = cmd.ExecuteNonQuery();
                }
            }
            return n;
        }


        /// <summary>
        /// 查询并返回结果集DataTable(带参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params NpgsqlParameter[] parameters)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (NpgsqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }

        }

        /// <summary>
        /// 查询并返回结果集DataTable（无参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string sql)
        {
            NpgsqlConnection sqlConn = new NpgsqlConnection(connStr);
            DataTable ds = new DataTable();
            try
            {
                using (NpgsqlDataAdapter sqldap = new NpgsqlDataAdapter(sql, sqlConn))
                {
                    sqldap.Fill(ds);
                }
                return ds;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
