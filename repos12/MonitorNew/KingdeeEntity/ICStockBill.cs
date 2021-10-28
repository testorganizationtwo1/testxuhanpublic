using System;

namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 出入库单据表
    /// </summary>
    public class ICStockBill
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime FDate { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        public int FCheckerID { get; set; }
        /// <summary>
        /// /作废标志
        /// </summary>
        public string FCancellation { get; set; }

        /// <summary>
        /// 领料用途
        /// </summary>
        public string FUse {  get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string  FBillNo { get; set; }
        /// <summary>
        /// 倒冲标志
        /// </summary>
        public string FBackFlushed { get; set; }
        /// <summary>
        /// 必填项，非文档要求
        /// </summary>
        public string FBrNo { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int  FInterID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string FStatus { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime FCheckDate {  get; set; }
        /// <summary>
        /// 红蓝字
        /// </summary>
        public string FROB {  get; set; }
        /// <summary>
        /// 事务类型
        /// </summary>
        public string FTranType {  get; set; }
        /// <summary>
        /// 源单类型
        /// </summary>
        public int FSelTranType {  get; set; }
        /// <summary>
        /// 打印次数
        /// </summary>
        public string FPrintCount {  get; set; }
        /// <summary>
        /// 凭证字号
        /// </summary>
        public int FVchInterID {  get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public int FBillerID {  get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public int FBrID {  get; set; }
        /// <summary>
        /// 交货单位
        /// </summary>
        public int FDeptID {  get; set; }
        /// <summary>
        /// 验收人
        /// </summary>
        public int FFManagerID {  get; set; }
        /// <summary>
        /// 保管人
        /// </summary>
        public int FSManagerID {  get; set; }
        /// <summary>
        /// 保税监管类型
        /// </summary>
        public int FManageType {  get; set; }
        /// <summary>
        /// 采购方式
        /// </summary>
        public int FPOStyle {  get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int FSupplyID {  get; set; }
        /// <summary>
        /// 供货机构
        /// </summary>
        public int FRelateBrID {  get; set; }
        /// <summary>
        /// 源单内码
        /// </summary>
        public int FOrgBillInterID {  get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string FExplanation {  get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public int FManagerID {  get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public int FEmpID {  get; set; }
        /// <summary>
        /// 往来科目
        /// </summary>
        public int FCussentAcctID {  get; set; }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime FSettleDate {  get; set; }
        /// <summary>
        /// 调拨类型
        /// </summary>
        public int FRefType {  get; set; }
        /// <summary>
        /// 委外类型
        /// </summary>
        public int FPurposeID {  get; set; }
        /// <summary>
        /// 对方单据号
        /// </summary>
        public string FPOOrdBillNo {  get; set; }
        /// <summary>
        /// 入库类型
        /// </summary>
        public int FBillTypeID {  get; set; }
        /// <summary>
        /// 工程项目
        /// </summary>
        public int FObjectItem {  get; set; }


    }
}
