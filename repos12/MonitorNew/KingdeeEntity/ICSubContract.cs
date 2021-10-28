namespace MonitorNew.KingdeeEntity
{
    /// <summary>
    /// 委外订单
    /// </summary>
    public class ICSubContract
    {
        /// <summary>
        /// 内码
        /// </summary>
        public int FInterID {  get; set; }
        /// <summary>
        /// 供应商内码:
        /// </summary>
        public int FSupplyID {  get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string FBillNo {  get; set; }

    }
}
