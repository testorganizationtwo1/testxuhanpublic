using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_MeasureUnitFormat
    {
        /// <summary>
        /// 获取计量单位表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">计量单位表实体</param>
        /// <returns>计量单位表SQL字符串</returns>
        public static string sql_t_MeasureUnit(t_MeasureUnit t_MeasureUnit)
        {
            string sql_t_MeasureUnit = new SqlHelper().GetSqlForKingdeeSql("t_MeasureUnit.sql");
            return string.Format(
                sql_t_MeasureUnit,
                t_MeasureUnit.FName,            //单位--常用单位
                t_MeasureUnit.FNumber           //必填项，非文档要求
                );
        }
    }
}
