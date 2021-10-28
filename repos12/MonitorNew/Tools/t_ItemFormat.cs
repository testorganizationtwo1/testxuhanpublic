using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_ItemFormat
    {
        /// <summary>
        /// 获取基础资料主表SQL字符串
        /// </summary>
        /// <param name="t_Item">基础资料主表实体</param>
        /// <returns>基础资料主表SQL字符串</returns>
        public static string sql_t_Item(t_Item t_Item)
        {
            string sql_t_Item = new SqlHelper().GetSqlForKingdeeSql("t_Item.sql");
            return string.Format(
                sql_t_Item,
                t_Item.FItemID,                               //ID号  必填项，非文档要求，主键，要求手动插入最大ID                      
                t_Item.FItemClassID,                          //类型ID号
                t_Item.FNumber,                               //编码
                t_Item.FParentID,                             //父ID
                t_Item.FName,                                 //名称
                t_Item.FDetail                                //是否明细
                );
        }
    }
}
