using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_UnitGroupFormat
    {
        /// <summary>
        /// 获取单位类别表SQL字符串
        /// </summary>
        /// <param name="t_UnitGroup">单位类别表实体</param>
        /// <returns>单位类别表SQL字符串</returns>
        public static string sql_t_UnitGroup(t_UnitGroup t_UnitGroup)
        {
            string sql_t_UnitGroup = new SqlHelper().GetSqlForKingdeeSql("t_UnitGroup.sql");
            return string.Format(
                sql_t_UnitGroup,
                t_UnitGroup.FUnitGroupID,                   //组别内码
                t_UnitGroup.FName,                          //组别名称
                t_UnitGroup.FDefaultUnitID                  //默认单位
                );
        }
    }
}
