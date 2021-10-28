using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_DepartmentFormat
    {
        /// <summary>
        /// 获取部门表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">部门表实体</param>
        /// <returns>部门表SQL字符串</returns>
        public static string sql_t_Department(t_Department t_Department)
        {
            string sql_t_Department = new SqlHelper().GetSqlForKingdeeSql("t_Department.sql");
            return string.Format(
                sql_t_Department,
                t_Department.FName,             //领料部门
                t_Department.FItemID            //必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
