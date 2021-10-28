using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;

namespace MonitorNew.Tools
{
    public class POOrderEntryFormat
    {
        /// <summary>
        /// 获取采购订单分录表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">采购订单分录表实体</param>
        /// <returns>采购订单分录表SQL字符串</returns>
        public static string sql_POOrderEntry(POOrderEntry POOrderEntry)
        {
            string sql_POOrderEntry = new SqlHelper().GetSqlForKingdeeSql("POOrderEntry.sql");
            return string.Format(
                sql_POOrderEntry,
                POOrderEntry.FInterID,              // 单据号
                POOrderEntry.FEntryID,              // 行号
                POOrderEntry.FItemID,               // 物料代码
                POOrderEntry.FDate,                 // 交货日期
                POOrderEntry.FAmount,               // 不含税金额
                POOrderEntry.FTaxRate,              // 折扣率(%)
                POOrderEntry.FTaxAmount,            // 税额
                POOrderEntry.FNote,                 // 备注
                POOrderEntry.FUnitID,               // 单位
                POOrderEntry.FAuxPrice,             // 不含税单价
                POOrderEntry.FAuxQty,               // 数量
                POOrderEntry.FSourceEntryID,        // 源单分录  
                POOrderEntry.FCess,                 // 税率(%)
                POOrderEntry.FMapNumber,            // 对应代码
                POOrderEntry.FMapName,              //  对应名称 
                POOrderEntry.FAllAmount,            // 价税合计
                POOrderEntry.FAuxPropID,            // 辅助属性
                POOrderEntry.FAuxPriceDiscount,     // 实际含税单价
                POOrderEntry.FAuxTaxPrice,          // 含税单价
                POOrderEntry.FReceiveAmountFor_Commit,  // 付款关联金额
                POOrderEntry.FSecCoefficient,       // 换算率
                POOrderEntry.FSecQty,               // 辅助数量
                POOrderEntry.FSourceTranType,       // 源单类型
                POOrderEntry.FSourceInterId,        // 源单内码
                POOrderEntry.FSourceBillNo,         // 源单单号
                POOrderEntry.FContractInterID,      // 合同内码
                POOrderEntry.FContractEntryID,      // 合同分录
                POOrderEntry.FContractBillNo,       // 合同单号
                POOrderEntry.FMRPLockFlag,          // MRP计算标记
                POOrderEntry.FSecInvoiceQty,        // 辅助单位开票数量
                POOrderEntry.FPlanMode,             // 计划模式
                POOrderEntry.FMTONo,                // 计划跟踪号
                POOrderEntry.FDescount              //折扣额
                );
            
        }
    }
}
