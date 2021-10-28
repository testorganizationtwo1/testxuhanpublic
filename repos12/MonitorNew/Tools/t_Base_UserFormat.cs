using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;

namespace MonitorNew.Tools
{
    public class t_Base_UserFormat
    {
        /// <summary>
        /// 获取系统用户信息表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">系统用户信息表实体</param>
        /// <returns>系统用户信息表SQL字符串</returns>
        public static string sql_t_Base_User(t_Base_User t_Base_User)
        {
            string sql_t_Base_User = new SqlHelper().GetSqlForKingdeeSql("t_Base_User.sql");
            return string.Format(
                sql_t_Base_User,
                t_Base_User.FName,                     // 制单--审核人
                t_Base_User.FPrimaryGroup,             // 必填项，非文档要求
                t_Base_User.FUserID                    // 必填项，非文档要求，主键，要求手动插入最大ID
                );
        }
    }
}
