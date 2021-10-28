using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_AccountFormat
    {
        /// <summary>
        /// 获取科目表SQL字符串
        /// </summary>
        /// <param name="t_Account">科目表实体</param>
        /// <returns>科目表SQL字符串</returns>
        public static string sql_t_Account(t_Account t_Account)
        {
            string sql_t_Account = new SqlHelper().GetSqlForKingdeeSql("t_Account.sql");
            return string.Format(
                sql_t_Account,
                t_Account.FAccountID,                     //科目内码
                t_Account.FNumber,                        //科目代码
                t_Account.FName,                          //科目名称
                t_Account.FLevel,                         //科目级次
                t_Account.FDetail,                        //核算项目内码
                t_Account.FGroupID,                       //科目类别内码
                t_Account.FDC                             //借贷方向
                );
        }
    }
}
