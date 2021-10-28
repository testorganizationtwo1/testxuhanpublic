using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;

namespace MonitorNew.Tools
{
    public class ZPStockBillEntryFormat
    {
        /// <summary>
        /// 获取虚仓出入库单据分录表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">虚仓出入库单据分录表实体</param>
        /// <returns>虚仓出入库单据分录表SQL字符串</returns>
        public static string sql_ZPStockBillEntry(ZPStockBillEntry ZPStockBillEntry)
        {
            string sql_ZPStockBillEntry = new SqlHelper().GetSqlForKingdeeSql("ZPStockBillEntry.sql");
            return string.Format(
                sql_ZPStockBillEntry,
                ZPStockBillEntry.FInterID,                  // 单据号
                ZPStockBillEntry.FEntryID,                  // 行号
                ZPStockBillEntry.FItemID,                   // 物料代码  外键，要求手动插入供应商表（t_ICItem）最大ID
                ZPStockBillEntry.FQty,                      // 基本单位数量
                ZPStockBillEntry.FBatchNo,                  // 批号
                ZPStockBillEntry.FNote,                     // 备注
                ZPStockBillEntry.FUnitID,                   // 单位
                ZPStockBillEntry.FAuxQty,                   // 数量
                ZPStockBillEntry.FSourceEntryID,            // 源单分录
                ZPStockBillEntry.FMapNumber,                // 对应代码
                ZPStockBillEntry.FMapName,                  // 对应名称
                ZPStockBillEntry.FKFDate,                   // 生产/采购日期
                ZPStockBillEntry.FKFPeriod,                 // 保质期(天)
                ZPStockBillEntry.FDCSPID,                   // 仓位
                ZPStockBillEntry.FAuxPropID,                // 辅助属性
                ZPStockBillEntry.FSecCoefficient,           // 换算率
                ZPStockBillEntry.FSecQty,                   // 辅助数量
                ZPStockBillEntry.FSourceTranType,           // 源单类型
                ZPStockBillEntry.FSourceInterId,            // 源单内码
                ZPStockBillEntry.FSourceBillNo,             // 源单单号
                ZPStockBillEntry.FDCStockID                // 仓库  外键，要求手动插入供应商表（t_Stock）最大ID
                );
        }
    }
}
