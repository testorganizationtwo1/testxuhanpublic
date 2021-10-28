using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_Base_EmpFormat
    {
        /// <summary>
        /// 获取职员表SQL字符串
        /// </summary>
        /// <param name="t_Base_Emp">职员表实体</param>
        /// <returns>职员表SQL字符串</returns>
        public static string sql_t_Base_Emp(t_Base_Emp t_Base_Emp)
        {
            string sql_t_Base_Emp = new SqlHelper().GetSqlForKingdeeSql("t_Base_Emp.sql");
            return string.Format(
                sql_t_Base_Emp,
                t_Base_Emp.FName,                   //职员名称
                t_Base_Emp.FItemID                  //必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
