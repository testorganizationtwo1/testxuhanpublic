using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdeeEntity
{
    /// <summary>
    /// 出入库单据分录表
    /// </summary>
    public class ICStockBillEntry
    {
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
        public DateTime? FKFDate { get; set; }
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
    }
}
