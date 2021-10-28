using System;

namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 采购订单分录表
    /// </summary>
    public class POOrderEntry
    {
        /// <summary>
        /// 单据号
        /// </summary>
        public int FInterID {  get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int FEntryID {  get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public int FItemID {  get; set; }
        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime FDate {  get; set; }
        /// <summary>
        /// 不含税金额
        /// </summary>
        public decimal FAmount { get;set;  }
        /// <summary>
        /// 折扣率(%)
        /// </summary>
        public decimal FTaxRate {  get;set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal FTaxAmount {  get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string FNote {  get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public int FUnitID {  get; set; }
        /// <summary>
        /// 不含税单价
        /// </summary>
        public decimal FAuxPrice {  get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal FAuxQty {  get; set; }
        /// <summary>
        /// 源单分录
        /// </summary>
        public int FSourceEntryID {  get; set; }
        /// <summary>
        /// 税率(%)
        /// </summary>
        public decimal FCess {  get; set; }
        /// <summary>
        /// 对应代码
        /// </summary>
        public string FMapNumber {  get; set; }
        /// <summary>
        /// 对应名称
        /// </summary>
        public string FMapName {  get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal FAllAmount {  get; set; }
        /// <summary>
        /// 辅助属性
        /// </summary>
        public int FAuxPropID {  get; set; }
        /// <summary>
        /// 实际含税单价
        /// </summary>
        public decimal FAuxPriceDiscount {  get; set; }
        /// <summary>
        /// 含税单价
        /// </summary>
        public decimal FAuxTaxPrice {  get; set; }
        /// <summary>
        /// 付款关联金额
        /// </summary>
        public decimal FReceiveAmountFor_Commit {  get; set; }
        /// <summary>
        /// 换算率
        /// </summary>
        public decimal FSecCoefficient {  get; set; }
        /// <summary>
        /// 辅助数量
        /// </summary>
        public decimal FSecQty {  get; set; }
        /// <summary>
        /// 源单类型
        /// </summary>
        public int FSourceTranType {  get; set; }
        /// <summary>
        /// 源单内码
        /// </summary>
        public int FSourceInterId {  get; set; }
        /// <summary>
        /// 源单单号
        /// </summary>
        public string FSourceBillNo {  get; set; }
        /// <summary>
        /// 合同内码
        /// </summary>
        public int FContractInterID {  get; set; }
        /// <summary>
        /// 合同分录
        /// </summary>
        public int FContractEntryID {  get; set; }
        /// <summary>
        /// 合同单号
        /// </summary>
        public string FContractBillNo {  get; set; }
        /// <summary>
        /// MRP计算标记
        /// </summary>
        public int FMRPLockFlag {  get; set; }
        /// <summary>
        /// 辅助单位开票数量
        /// </summary>
        public decimal FSecInvoiceQty {  get; set; }
        /// <summary>
        /// 计划模式
        /// </summary>
        public int FPlanMode {  get; set; }
        /// <summary>
        /// 计划跟踪号
        /// </summary>
        public string FMTONo {  get; set; }
        /// <summary>
        /// 折扣额
        /// </summary>
        public decimal FDescount {  get; set; }
        /// <summary>
        /// 供应商确认人
        /// </summary>
        public int FSupConfirmor {  get; set; }
        /// <summary>
        /// 表体附件数
        /// </summary>
        public int FEntryAccessoryCount {  get; set; }
        /// <summary>
        /// 采购申请单内码
        /// </summary>
        public int FPRInterID {  get; set; }
        /// <summary>
        /// 采购申请单分录
        /// </summary>
        public int FPREntryID {  get; set; }
        /// <summary>
        /// 收料数量
        /// </summary>
        public decimal FAuxReceiptQty {  get; set; }
        /// <summary>
        /// 基本单位收料数量
        /// </summary>
        public decimal FReceiptQty { get; set; }
        /// <summary>
        /// 退料数量
        /// </summary>
        public decimal FAuxReturnQty {  get; set; }
        /// <summary>
        /// 基本单位退料数量
        /// </summary>
        public decimal FReturnQty {  get; set; }
        /// <summary>
        /// 检验方式
        /// </summary>
        public int FCheckMethod {  get; set; }




    }
}