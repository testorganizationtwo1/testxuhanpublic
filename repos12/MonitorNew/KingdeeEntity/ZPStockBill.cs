using System;

namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 虚仓出入库单据表
    /// </summary>
    public class ZPStockBill
    {
        /// <summary>
        /// 单据号
        /// </summary>
        public int FInterID {  get; set; }
        /// <summary>
        /// 事务类型
        /// </summary>
        public string FTranType {  get; set; }
        /// <summary>
        /// 红蓝字
        /// </summary>
        public string FROB {  get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public decimal FDate {  get; set; }
        /// <summary>
        /// 编    号
        /// </summary>
        public string FBillNo {  get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int FCheckerID {  get; set; }
        /// <summary>
        /// 领料
        /// </summary>
        public int FFManagerID {  get; set; }
        /// <summary>
        /// 发货
        /// </summary>
        public int FSManagerID {  get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public int FBillerID {  get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public int FDeptID {  get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public int FCustID {  get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int FSupplyID {  get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime FCheckDate {  get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public int FEmpID {  get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string FExplanation {  get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public int FManagerID {  get; set; }
        /// <summary>
        /// 源单类型
        /// </summary>
        public int FSelTranType {  get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        public int FBillTypeID {  get; set; }
        /// <summary>
        /// 制单机构
        /// </summary>
        public int FBrID {  get; set; }
        /// <summary>
        /// 打印次数
        /// </summary>
        public int FPrintCount {  get; set; }





    }
}
