using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_SubMessageFormat
    {
        /// <summary>
        /// 获取辅助资料表SQL字符串
        /// </summary>
        /// <param name="t_SubMessage">辅助资料表实体</param>
        /// <returns>辅助资料表SQL字符串</returns>
        public static string sql_t_SubMessage(t_SubMessage t_SubMessage)
        {
            string sql_t_SubMessage = new SqlHelper().GetSqlForKingdeeSql("t_SubMessage.sql");
            return string.Format(
                sql_t_SubMessage,
                t_SubMessage.FBrNo,             //公司代码
                t_SubMessage.FInterID,          //必填项，非文档要求，主键，要求手动插入最大ID
                t_SubMessage.FID,               //资料代码
                t_SubMessage.FParentID,         //上级内码
                t_SubMessage.FName,             //资料名称
                t_SubMessage.FTypeID,           //类型内码
                t_SubMessage.FDetail,           //是否明细
                t_SubMessage.FDeleted,          //是否禁用
                t_SubMessage.FSystemType,       //系统标示
                t_SubMessage.FSpec              
                );
        }
    }
}
