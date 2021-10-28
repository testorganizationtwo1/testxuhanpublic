using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_OrganizationFormat
    {
        /// <summary>
        /// 获取客户表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">客户表实体</param>
        /// <returns>客户表SQL字符串</returns>
        public static string sql_t_Organization(t_Organization t_Organization)
        {
            string sql_t_Organization = new SqlHelper().GetSqlForKingdeeSql("t_Organization.sql");
            return string.Format(
                sql_t_Organization,
                t_Organization.FName,               //名称
                t_Organization.FItemID              //必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
