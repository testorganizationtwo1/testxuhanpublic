using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Tools
{
    public class ICStockBillEntryFormat
    {
        /// <summary>
        /// 获取出入库单据分录表入库SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">出入库单据分录表实体</param>
        /// <returns>出入库单据分录表入库SQL字符串</returns>
        public static string sql_ICStockBillEntry(ICStockBillEntry t_ICStockBillEntry)
        {
            string sql_ICStockBillEntry = new SqlHelper().GetSqlForKingdeeSql("ICStockBillEntry.sql");
            return string.Format(
                sql_ICStockBillEntry,
                t_ICStockBillEntry.FQtyMust,                //应收数量--基本单位应收数量
                t_ICStockBillEntry.FAuxQty,                 //实收数量
                t_ICStockBillEntry.FAuxPrice,               //单价
                t_ICStockBillEntry.Famount,                 //金额
                t_ICStockBillEntry.FBatchNo,                //批号
                t_ICStockBillEntry.FNote,                   //备注
                t_ICStockBillEntry.FSourceBillNo,           //源单单号
                t_ICStockBillEntry.FSourceTranType,         //源单类型
                t_ICStockBillEntry.FQty,                    //基本单位实收数量
                t_ICStockBillEntry.FAuxPlanPrice,           //计划单价
                t_ICStockBillEntry.FPlanAmount,             //计划价金额
                t_ICStockBillEntry.FKFPeriod,               //保质期(天)
                t_ICStockBillEntry.FKFDate,                 //生产 / 采购日期
                t_ICStockBillEntry.FPositionNo,             //位置号
                t_ICStockBillEntry.FItemSize,               //坯料尺寸
                t_ICStockBillEntry.FItemSuite,              //坯料数
                t_ICStockBillEntry.FBrNo,                   //必填项，非文档要求
                t_ICStockBillEntry.FInterID,                //单据号  必填项，非文档要求，主键，要求手动插入最大ID（ICStockBill FInterID）
                t_ICStockBillEntry.FEntryID,                //行号  必填项，非文档要求，主键，要求手动插入最大ID
                t_ICStockBillEntry.FConsignPrice,           //代销单价
                t_ICStockBillEntry.FConsignAmount,          //代销金额
                t_ICStockBillEntry.FProcessCost,            //加工费
                t_ICStockBillEntry.FProcessPrice,           //委外加工入库单增加加工单价
                t_ICStockBillEntry.FAuxQtyMust,             //辅助账存数量
                t_ICStockBillEntry.FSNListID,               //序列号内码
                t_ICStockBillEntry.FPeriodDate,             //有效期至
                t_ICStockBillEntry.FSecCoefficient,         //换算率
                t_ICStockBillEntry.FSecQty,                 //辅助数量
                t_ICStockBillEntry.FSourceInterId,          //源单内码
                t_ICStockBillEntry.FSourceEntryID,          //源单分录
                t_ICStockBillEntry.FICMOBillNo,             //生产任务单号
                t_ICStockBillEntry.FICMOInterID,            //任务单内码
                t_ICStockBillEntry.FPPBomEntryID,           //投料单分录
                t_ICStockBillEntry.FMTONo,                  //计划跟踪号
                t_ICStockBillEntry.FChkPassItem,            //检验是否良品
                t_ICStockBillEntry.FItemID,                 //物料编码
                t_ICStockBillEntry.FAuxPropID,              //辅助属性
                t_ICStockBillEntry.FUnitID,                 //单位
                t_ICStockBillEntry.FDCStockID,              //收货仓库
                t_ICStockBillEntry.FDCSPID,                 //仓位
                t_ICStockBillEntry.FOrderBillNo,            //订单号
                t_ICStockBillEntry.FOrderEntryID,           //订单行号
                t_ICStockBillEntry.FOrderInterID,           //订单行内码
                t_ICStockBillEntry.FMapNumber,              //对应代码
                t_ICStockBillEntry.FMapName,                //对应名称
                t_ICStockBillEntry.FOrgBillEntryID,         //拆单源单行号
                t_ICStockBillEntry.FSecInvoiceQty,          //辅助单位开票数量
                t_ICStockBillEntry.FPlanMode,               //计划模式
                t_ICStockBillEntry.FDeliveryNoticeFID,      //交货通知单内码
                t_ICStockBillEntry.FDeliveryNoticeEntryID,  //交货通知单分录
                t_ICStockBillEntry.FAuxPriceRef,            //调拨单价
                t_ICStockBillEntry.FAmtRef,                 //调拨金额
                t_ICStockBillEntry.FSCStockID,              //调出仓库
                t_ICStockBillEntry.FSCSPID,                 //调出仓位
                t_ICStockBillEntry.FMaterialCostPrice,      //单位材料费
                t_ICStockBillEntry.FMaterialCost            //材料费
        );

        }
    }
}
