using System;

namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 虚仓出入库单据分录表
    /// </summary>
    public class ZPStockBillEntry
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
        /// 基本单位数量
        /// </summary>
        public decimal FQty {  get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string FBatchNo {  get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string FNote {  get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public int FUnitID {  get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal FAuxQty {  get; set; }
        /// <summary>
        /// 源单分录
        /// </summary>
        public int FSourceEntryID {  get; set; }
        /// <summary>
        /// 对应代码
        /// </summary>
        public string FMapNumber {  get; set; }
        /// <summary>
        /// 对应名称
        /// </summary>
        public string FMapName {  get; set; }
        /// <summary>
        /// 仓位
        /// </summary>
        public int FDCSPID {  get; set; }
        /// <summary>
        /// 辅助属性
        /// </summary>
        public int FAuxPropID {  get; set; }
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
        public int FSourceInterId { get; set; }
        /// <summary>
        /// 源单单号
        /// </summary>
        public string FSourceBillNo { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public int FDCStockID {  get; set; }
        /// <summary>
        /// 生产/采购日期
        /// </summary>
        public DateTime FKFDate { get; set; }
        /// <summary>
        /// 保质期(天)
        /// </summary>
        public int FKFPeriod { get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        public DateTime FPeriodDate {  get; set; }

    }
}
