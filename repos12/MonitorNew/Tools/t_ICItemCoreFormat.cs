using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_ICItemCoreFormat
    {
        /// <summary>
        /// 获取物料表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">物料表实体</param>
        /// <returns>物料表SQL字符串</returns>
        public static string sql_t_ICItemCore(t_ICItemCore t_ICItemCore)
        {
            string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
            return string.Format(
                sql_t_ICItemCore,
                t_ICItemCore.FNumber,           //物料代码
                t_ICItemCore.FName,             //物料名称
                t_ICItemCore.FModel,            //规格型号
                t_ICItemCore.FItemID            //必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
