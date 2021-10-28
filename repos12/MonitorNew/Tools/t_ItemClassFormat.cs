using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
    internal class t_ItemClassFormat
    {
        /// <summary>
        /// 获取基础资料类别表SQL字符串
        /// </summary>
        /// <param name="t_ItemClass">基础资料类别表实体</param>
        /// <returns>基础资料类别表SQL字符串</returns>
        public static string sql_t_ItemClass(t_ItemClass t_ItemClass)
        {
            string sql_t_ItemClass = new SqlHelper().GetSqlForKingdeeSql("t_ItemClass.sql");
            return string.Format(
                sql_t_ItemClass,
                t_ItemClass.FItemClassID,         //类别内码
                t_ItemClass.FNumber,              //类别代码
                t_ItemClass.FName,                //名称
                t_ItemClass.FName_en,             //未知字段
                t_ItemClass.FVersion,             //版本号
                t_ItemClass.FImport,              //外部引入
                t_ItemClass.FBrNo,                //公司代码
                t_ItemClass.FUserDefilast,        //操作员
                t_ItemClass.FType,                //类型
                t_ItemClass.FGRType,              //集团控制类别
                t_ItemClass.FRemark,              //备注
                t_ItemClass.FGrControl            //未知字段
                );

        }
    }
}
