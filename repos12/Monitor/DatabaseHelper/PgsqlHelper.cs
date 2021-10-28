using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace Monitor.DatabaseHelper
{
    public class PgsqlHelper
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["postgres"].ToString();

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
