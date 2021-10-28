using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class ICBillTypeFormat
    {
        /// <summary>
        /// 获取单据类型表 SQL字符串
        /// </summary>
        /// <param name="ICBillTypeFormat">单据类型表 实体</param>
        /// <returns>单据类型表 SQL字符串</returns>
        public static string sql_ICBillType(ICBillType ICBillType)
        {
            string sql_ICBillType = new SqlHelper().GetSqlForKingdeeSql("ICBillType.sql");
            return string.Format(
                sql_ICBillType,
                ICBillType.FID,                  //内码
                ICBillType.FNumber,              //代码
                ICBillType.FName,                //名称
                ICBillType.FAcctID,              //会计科目
                ICBillType.FNote,                //备注
                ICBillType.FSystemic             //是否系统预设
                );
        }
    }
}
