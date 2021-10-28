using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class SEOrderFormat
    {
        /// <summary>
        /// 获取外销订单表SQL字符串
        /// </summary>
        /// <param name="SEOrder">外销订单表实体</param>
        /// <returns>外销订单表SQL字符串</returns>
        public static string sql_SEOrder(SEOrder SEOrder)
        {
            string sql_SEOrder = new SqlHelper().GetSqlForKingdeeSql("SEOrder.sql");
            return string.Format(
                sql_SEOrder,
                SEOrder.FBrNo,                               //分支机构代码              
                SEOrder.FInterID,                            //内码
                SEOrder.FBillNo,                             //单据编号
                SEOrder.FCurrencyID,                         //币别
                SEOrder.FCustID,                             //订单客户
                SEOrder.FDate,                               //订单日期
                SEOrder.FTranType                            //业务代码
                );
        }
    }
}
