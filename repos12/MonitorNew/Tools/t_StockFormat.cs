using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_StockFormat
    {
        /// <summary>
        /// 获取仓库表SQL字符串
        /// </summary>
        /// <param name="t_Stock">仓库表实体</param>
        /// <returns>仓库表SQL字符串</returns>
        public static string sql_t_Stock(t_Stock t_Stock)
        {
            string sql_t_Stock = new SqlHelper().GetSqlForKingdeeSql("t_Stock.sql");
            return string.Format(
                sql_t_Stock,
                t_Stock.FName,              //收料仓库
                t_Stock.FItemID             //必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
