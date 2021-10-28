using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_CurrencyFormat
    {
        /// <summary>
        /// 获取币别表SQL字符串
        /// </summary>
        /// <param name="t_Currency">币别表实体</param>
        /// <returns>币别表SQL字符串</returns>
        public static string sql_t_Currency(t_Currency t_Currency)
        {
            string sql_t_Currency = new SqlHelper().GetSqlForKingdeeSql("t_Currency.sql");
            return string.Format(
                sql_t_Currency,
                t_Currency.FCurrencyID,                             //币别内码
                t_Currency.FNumber,                                 //币别代码
                t_Currency.FName,                                   //币别名称
                t_Currency.FOperator,                               //运算符
                t_Currency.FExchangeRate,                           //汇率
                t_Currency.FScale,                                  //小数位数
                t_Currency.FFixRate,                                //换算率
                t_Currency.FBrNo,                                   //公司代码
                t_Currency.FControl,                                //未知字段
                t_Currency.FDeleted,                                //是否禁用
                t_Currency.FSystemType,                             //未知字段
                t_Currency.FClassTypeID                             //未知字段
                );
        }
    }
}
