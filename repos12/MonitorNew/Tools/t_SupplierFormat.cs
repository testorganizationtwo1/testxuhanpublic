using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_SupplierFormat
    {
        /// <summary>
        /// 获取供应商SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">供应商实体</param>
        /// <returns>供应商SQL字符串</returns>
        public static string sql_t_Supplier(t_Supplier t_Supplier)
        {
            string sql_t_Supplier = new SqlHelper().GetSqlForKingdeeSql("t_Supplier.sql");
            return string.Format(
                sql_t_Supplier,
                t_Supplier.FName,           //供应商
                t_Supplier.FItemID          //必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
