using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_AuxItemFormat
    {
        /// <summary>
        /// 获取辅助资料信息表SQL字符串
        /// </summary>
        /// <param name="t_AuxItem">辅助资料信息表实体</param>
        /// <returns>辅助资料信息表SQL字符串</returns>
        public static string sql_t_AuxItem(t_AuxItem t_AuxItem)
        {
            string sql_t_AuxItem = new SqlHelper().GetSqlForKingdeeSql("t_AuxItem.sql");
            return string.Format(
                sql_t_AuxItem,
                t_AuxItem.FItemID,                  //内码
                t_AuxItem.FItemClassID,             //辅助属性类别内码
                t_AuxItem.FNumber,                  //编码
                t_AuxItem.FName,                    //名称
                t_AuxItem.FParentID,                //上级内码
                t_AuxItem.FUnUsed,                  //是否使用
                t_AuxItem.FFullNumber,              //长编码（与编码相同）
                t_AuxItem.FDeleted,                 //是否已删除
                t_AuxItem.FShortNumber,             //短编码（与编码相同）
                t_AuxItem.FFullName                 //全名（与名称相同）
                );
        }
    }
}
