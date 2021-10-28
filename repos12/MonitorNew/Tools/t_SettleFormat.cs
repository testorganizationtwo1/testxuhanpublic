using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_SettleFormat
    {
        /// <summary>
        /// 获取结算方式表SQL字符串
        /// </summary>
        /// <param name="t_Settle">结算方式表实体</param>
        /// <returns>结算方式表SQL字符串</returns>
        public static string sql_t_Settle(t_Settle t_Settle)
        {
            string sql_t_Settle = new SqlHelper().GetSqlForKingdeeSql("t_Settle.sql");
            return string.Format(
                sql_t_Settle,
                t_Settle.FBrNo,                         //公司代码
                t_Settle.FItemID,                       //结算方式内码
                t_Settle.FName,                         //结算方式名称
                t_Settle.FNumber                        //结算方式代码
                );
        }
    }
}
