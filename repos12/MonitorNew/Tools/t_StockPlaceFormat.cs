using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_StockPlaceFormat
    {
        /// <summary>
        /// 获取仓位表SQL字符串
        /// </summary>
        /// <param name="t_StockPlace">仓位表实体</param>
        /// <returns>仓位表SQL字符串</returns>
        public static string sql_t_StockPlace(t_StockPlace t_StockPlace)
        {
            string sql_t_StockPlace = new SqlHelper().GetSqlForKingdeeSql("t_StockPlace.sql");
            return string.Format(
                sql_t_StockPlace,
                t_StockPlace.FName,             // 仓位
                t_StockPlace.FNumber,           // 必填项，非文档要求
                t_StockPlace.FDetail,           // 必填项，非文档要求
                t_StockPlace.FParentID,         // 必填项，非文档要求
                t_StockPlace.FFullNumber,       // 必填项，非文档要求
                t_StockPlace.FSPID              // 必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
