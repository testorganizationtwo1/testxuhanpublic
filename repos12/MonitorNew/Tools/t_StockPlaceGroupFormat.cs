using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_StockPlaceGroupFormat
    {
        /// <summary>
        /// 获取仓位分组表SQL字符串
        /// </summary>
        /// <param name="t_StockPlaceGroupGroup">仓位分组表实体</param>
        /// <returns>仓位分组表SQL字符串</returns>
        public static string sql_t_StockPlaceGroup(t_StockPlaceGroup t_StockPlaceGroup)
        {
            string sql_t_StockPlaceGroup = new SqlHelper().GetSqlForKingdeeSql("t_StockPlaceGroup.sql");
            return string.Format(
                sql_t_StockPlaceGroup,
                t_StockPlaceGroup.FSPGroupID,           // 仓位组ID
                t_StockPlaceGroup.FNumber,              // 仓位代码
                t_StockPlaceGroup.FName,                // 仓位名
                t_StockPlaceGroup.FDefaultSPID,         // 必填项
                t_StockPlaceGroup.FDeleted              // 是否禁用
                );
        }
    }
}
