using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;

namespace MonitorNew.Tools
{
    public class POOrderFormat
    {
        /// <summary>
        /// 获取采购订单表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">采购订单表实体</param>
        /// <returns>采购订单表SQL字符串</returns>
        public static string sql_POOrder(POOrder POOrder)
        {
            string sql_POOrder = new SqlHelper().GetSqlForKingdeeSql("POOrder.sql");
            return string.Format(
                sql_POOrder,
                POOrder.FTranType,                  // 事务类型
                POOrder.FInterID,                   // 单据号              
                POOrder.FBillNo,                    // 编    号
                POOrder.FSupplyID,                  // 供应商   外键，要求手动插入供应商表（t_Supplier）最大ID
                POOrder.FDate,                      // 日期
                POOrder.FEmpID,                     // 业务员    外键，要求手动插入职员表（t_Base_Emp）最大ID
                POOrder.FDeptID,                    // 部门   外键，要求手动插入部门表（t_Department）最大ID
                POOrder.FCurrencyID,                // 币    别
                POOrder.FCheckerID,                 // 审核人  外键，要求手动插入系统用户表（t_Base_User）最大ID
                POOrder.FBillerID,                  // 制单人  外键，要求手动插入系统用户表（t_Base_User）最大ID
                POOrder.FMangerID,                  // 主管   外键，要求手动插入职员表（t_Base_Emp）最大ID  
                POOrder.FPOStyle,                   // 采购方式  外键，要求手动插入辅助资料表（t_SubMessage）最大ID
                POOrder.FRelateBrID,                // 供货机构
                POOrder.FCheckDate,                 // 审核日期
                POOrder.FExplanation,               // 摘要
                POOrder.FSettleDate,                // 结算日期
                POOrder.FSettleID,                  // 结算方式
                POOrder.FSelTranType,               // 源单类型
                POOrder.FBrID,                      // 制单机构
                POOrder.FPOOrdBillNo,               // 分销订单号
                POOrder.FAreaPS,                    // 采购范围
                POOrder.FManageType,                // 保税监管类型
                POOrder.FSysStatus,                 // 系统设置
                POOrder.FValidaterName,             // 确认人
                POOrder.FConsignee,                 // 收 货 方
                POOrder.FPrintCount,                // 打印次数
                POOrder.FExchangeRateType,          // 汇率类型
                POOrder.FDeliveryPlace,             // 交货地点
                POOrder.FAccessoryCount,            // 附件数
                POOrder.FPOMode,                    // 采购模式  外键，要求手动插入辅助资料表（t_SubMessage）最大ID
                POOrder.FPlanCategory,              // 计划类别
                POOrder.FLastAlterBillNo            // 最新变更单编号
                );
        }
    }
}
