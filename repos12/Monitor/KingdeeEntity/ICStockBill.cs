using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdeeEntity
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
    }
}
