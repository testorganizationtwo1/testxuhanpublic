using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class ICSubContractFormat
    {
        /// <summary>
        /// 获取委外订单SQL字符串
        /// </summary>
        /// <param name="ICSubContract">委外订单实体</param>
        /// <returns>委外订单SQL字符串</returns>
        public static string sql_ICSubContract(ICSubContract ICSubContract)
        {
            string sql_ICSubContract = new SqlHelper().GetSqlForKingdeeSql("ICSubContract.sql");
            return string.Format(
                sql_ICSubContract,
                ICSubContract.FInterID,                             //内码
                ICSubContract.FSupplyID,                            //供应商内码
                ICSubContract.FBillNo                               //编号
                );
        }
    }
}
