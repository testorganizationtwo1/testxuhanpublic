using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    public class t_BaseBondedManageTypeFormat
    {
        /// <summary>
        /// 获取保税监管类型表SQL字符串
        /// </summary>
        /// <param name="t_BaseBondedManageType">保税监管类型表实体</param>
        /// <returns>保税监管类型表SQL字符串</returns>
        public static string sql_t_BaseBondedManageType(t_BaseBondedManageType t_BaseBondedManageType)
        {
            string sql_t_BaseBondedManageType = new SqlHelper().GetSqlForKingdeeSql("t_BaseBondedManageType.sql");
            return string.Format(
                sql_t_BaseBondedManageType,                             
                t_BaseBondedManageType.FID,                             //内码
                t_BaseBondedManageType.FName,                           //保税监管名称
                t_BaseBondedManageType.FNumber,                         //保税监管代码
                t_BaseBondedManageType.FParentID,                       //父级内码
                t_BaseBondedManageType.FLogic,                          //菜单控制
                t_BaseBondedManageType.FDetail,                         //是否明细
                t_BaseBondedManageType.FDiscontinued,                   //状态
                t_BaseBondedManageType.FLevels,                         //级次
                t_BaseBondedManageType.FFullNumber,                     //保税监管全名
                t_BaseBondedManageType.FClassTypeID                     //类别
                );
        }
    }
}
