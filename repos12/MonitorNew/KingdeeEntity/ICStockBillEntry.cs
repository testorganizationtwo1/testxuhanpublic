namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 出入库单据分录表
    /// </summary>
    public class ICStockBillEntry
    {
        /// <summary>
        /// 是否VMI
        /// </summary>
        public int FIsVMI        { get; set; }
        /// <summary>
        /// 工序
        /// </summary>
        public int FOperID        { get; set; }
        /// <summary>
        /// 成本对象
        /// </summary>
        public int FCostOBJID { get; set; }
        /// <summary>
        /// 成本对象组
        /// </summary>
        public int FCostObjGroupID{ get; set; }
        /// <summary>
        /// 应收数量
        /// </summary>
        public decimal FQtyMust { get; set; }

        /// <summary>
        /// 辅助账存数量
        /// </summary>
        public decimal FAuxQtyMust { get; set; }

        /// <summary>
        /// 代销单价
        /// </summary>
        public decimal FConsignPrice { get; set; }

        /// <summary>
        /// 代销金额
        /// </summary>
        public decimal FConsignAmount { get; set; }

        /// <summary>
        /// 加工费
        /// </summary>
        public decimal FProcessCost { get; set; }

        /// <summary>
        /// 委外加工入库单增加加工单价
        /// </summary>
        public decimal FProcessPrice { get; set; }
        
        /// <summary>
        /// 辅助实际数量
        /// </summary>
        public decimal FAuxQty { get; set; }
        /// <summary>
        /// 辅助单价
        /// </summary>
        public decimal FAuxPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Famount { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string FBatchNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string FNote { get; set; }
        /// <summary>
        /// 源单单号
        /// </summary>
        public string FSourceBillNo { get; set; }
        /// <summary>
        /// 源单类型
        /// </summary>
        public int FSourceTranType { get; set; }
        /// <summary>
        /// 保质期(天)
        /// </summary>
        public int FKFPeriod { get; set; }
        /// <summary>
        /// 基本单位实收数量
        /// </summary>
        public decimal FQty { get; set; }
        /// <summary>
        /// 计划单价
        /// </summary>
        public decimal FAuxPlanPrice { get; set; }
        /// <summary>
        /// 计划价金额
        /// </summary>
        public decimal FPlanAmount { get; set; }
        /// <summary>
        /// 生产/采购日期
        /// </summary>
        public string FKFDate { get; set; }
        /// <summary>
        /// 位置号
        /// </summary>
        public string FPositionNo { get; set; }
        /// <summary>
        /// 坯料尺寸
        /// </summary>
        public string FItemSize { get; set; }
        /// <summary>
        /// 坯料数
        /// </summary>
        public string FItemSuite { get; set; }
        /// <summary>
        /// 填项，非文档要求
        /// </summary>
        public string FBrNo { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FInterID { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FEntryID { get; set; }
        /// <summary>
        /// 代销金额
        /// </summary>
        public decimal FConsiFConsignAmountgnPrice {  get; set; }
        /// <summary>
        /// 序列号内码
        /// </summary>
        public int FSNListID {  get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        public decimal FPeriodDate {  get; set; }
        /// <summary>
        /// 换算率
        /// </summary>
        public decimal FSecCoefficient { get; set; }
        /// <summary>
        /// 辅助数量
        /// </summary>
        public decimal FSecQty {  get; set; }
        /// <summary>
        /// 源单内码
        /// </summary>
        public int FSourceInterId {  get; set; }
        /// <summary>
        /// 源单分录
        /// </summary>
        public int FSourceEntryID {  get; set; }
        /// <summary>
        /// 生产任务单号
        /// </summary>
        public string FICMOBillNo {  get; set; }
        /// <summary>
        /// 任务单内码
        /// </summary>
        public int FICMOInterID {  get; set; }
        /// <summary>
        /// 投料单分录
        /// </summary>
        public int FPPBomEntryID {  get; set; }
        /// <summary>
        /// 计划跟踪号
        /// </summary>
        public string FMTONo {  get; set; }
        /// <summary>
        /// 检验是否良品
        /// </summary>
        public int FChkPassItem {  get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public int FItemID {  get; set; }
        /// <summary>
        /// 辅助属性
        /// </summary>
        public int FAuxPropID {  get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public int FUnitID { get; set; }
        /// <summary>
        /// 收货仓库
        /// </summary>
        public int FDCStockID {  get; set; }
        /// <summary>
        /// 仓位
        /// </summary>
        public int FDCSPID {  get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string FOrderBillNo {  get; set; }
        /// <summary>
        /// 订单行号
        /// </summary>
        public int FOrderEntryID {  get; set; }
        /// <summary>
        /// 订单行内码
        /// </summary>
        public int FOrderInterID {  get; set; }
        /// <summary>
        /// 对应代码
        /// </summary>
        public string FMapNumber {  get; set; }
        /// <summary>
        /// 对应名称
        /// </summary>
        public string FMapName {  get; set; }
        /// <summary>
        /// 拆单源单行号
        /// </summary>
        public int FOrgBillEntryID {  get; set; }
        /// <summary>
        /// 辅助单位开票数量
        /// </summary>
        public decimal FSecInvoiceQty {  get; set; }
        /// <summary>
        /// 计划模式
        /// </summary>
        public int FPlanMode { get; set; }
        /// <summary>
        /// 交货通知单内码
        /// </summary>
        public int FDeliveryNoticeFID {  get; set; }
        /// <summary>
        /// 交货通知单分录
        /// </summary>
        public int FDeliveryNoticeEntryID { get; set; }
        /// <summary>
        /// 调拨单价
        /// </summary>
        public decimal FAuxPriceRef {  get; set; }
        /// <summary>
        /// 调拨金额
        /// </summary>
        public decimal FAmtRef {  get; set; }
        /// <summary>
        /// 调出仓库
        /// </summary>
        public int FSCStockID {  get; set; }
        /// <summary>
        /// 调出仓位
        /// </summary>
        public int FSCSPID {  get; set; }
        /// <summary>
        /// 单位材料费
        /// </summary>
        public decimal FMaterialCostPrice {  get; set; }
        /// <summary>
        /// 材料费
        /// </summary>
        public decimal FMaterialCost {  get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public int FEntrySupply { get; set; }

    }
}
