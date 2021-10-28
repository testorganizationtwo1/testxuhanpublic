using System;

namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 采购订单表
    /// </summary>
    public class POOrder
    {
        /// <summary>
        /// 事务类型
        /// </summary>
        public int FTranType {  get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public int FInterID {  get; set; }
        /// <summary>
        /// 编    号
        /// </summary>
        public string FBillNo {  get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int FSupplyID {  get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime FDate {  get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public int FEmpID {  get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public int FDeptID {  get; set; }
        /// <summary>
        /// 币    别
        /// </summary>
        public int FCurrencyID { get;set;  }
        /// <summary>
        /// 审核人
        /// </summary>
        public int FCheckerID {  get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public int FBillerID { get; set; }
        /// <summary>
        /// 主管
        /// </summary>
        public int FMangerID {  get; set; }
        /// <summary>
        /// 采购方式
        /// </summary>
        public int FPOStyle {  get; set; }
        /// <summary>
        /// 供货机构
        /// </summary>
        public int FRelateBrID {  get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime FCheckDate {  get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string FExplanation {  get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime FSettleDate {  get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        public int FSettleID {  get; set; }
        /// <summary>
        /// 源单类型
        /// </summary>
        public int FSelTranType {  get; set; }
        /// <summary>
        /// 制单机构
        /// </summary>
        public int FBrID {  get; set; }
        /// <summary>
        /// 分销订单号
        /// </summary>
        public string FPOOrdBillNo {  get; set; }
        /// <summary>
        /// 采购范围
        /// </summary>
        public int FAreaPS {  get; set; }
        /// <summary>
        /// 保税监管类型
        /// </summary>
        public int FManageType {  get; set; }
        /// <summary>
        /// 系统设置
        /// </summary>
        public string FSysStatus {  get; set; }
        /// <summary>
        /// 确认人
        /// </summary>
        public string FValidaterName { get; set; }
        /// <summary>
        /// 收 货 方
        /// </summary>
        public string FConsignee {  get; set; }
        /// <summary>
        /// 打印次数
        /// </summary>
        public string FPrintCount {  get; set; }
        /// <summary>
        /// 汇率类型
        /// </summary>
        public int FExchangeRateType {  get; set; }
        /// <summary>
        /// 交货地点
        /// </summary>
        public string FDeliveryPlace {  get; set; }
        /// <summary>
        /// 附件数
        /// </summary>
        public int FAccessoryCount {  get; set; }
        /// <summary>
        /// 采购模式
        /// </summary>
        public int FPOMode {  get; set; }
        /// <summary>
        /// 计划类别
        /// </summary>
        public int FPlanCategory {  get; set; }
        /// <summary>
        /// 最新变更单编号
        /// </summary>
        public string FLastAlterBillNo {  get; set; }

    }
}
