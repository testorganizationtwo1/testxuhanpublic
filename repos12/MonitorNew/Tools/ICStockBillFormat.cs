using MonitorNew.KingdeeEntity;
using Monitor.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Tools
{
        
        public class ICStockBillFormat
        {
        /// <summary>
        /// 获取出入库单据SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">出入库单据实体</param>
        /// <returns>出入库单据SQL字符串</returns>
        public static string sql_ICStockBill(ICStockBill iCStockBill)
            {
            string sql_ICStockBill = new SqlHelper().GetSqlForKingdeeSql("ICStockBill.sql");
            return string.Format(
                sql_ICStockBill,
                iCStockBill.FDate,                  // 日期
                iCStockBill.FCancellation,          // 作废标志
                iCStockBill.FBillNo,                // 单据编号，非空
                iCStockBill.FBackFlushed,           // 倒冲标志 
                iCStockBill.FBrNo,                  // 必填项，非文档要求   
                iCStockBill.FInterID,               // 必填项，非文档要求，主键，要求手动插入最大ID
                iCStockBill.FStatus,                // 状态
                iCStockBill.FUse,                   // "生产领用"领料用途
                iCStockBill.FCheckDate,             // 审核日期
                iCStockBill.FROB,                   // 红蓝字
                iCStockBill.FTranType,              // 事物类型
                iCStockBill.FSelTranType,           // 源单类型   
                iCStockBill.FPrintCount,            // 打印次数
                iCStockBill.FVchInterID,            // 凭证字号
                iCStockBill.FBillerID,              // 制单人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
                iCStockBill.FCheckerID,             // 审核人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
                iCStockBill.FBrID,                  // 必填项，外键，要求手动插入分支机构表（t_SonCompany）最大ID
                iCStockBill.FDeptID,                // 交货单位  必填项，外键，要求手动插入部门表（t_Department）最大ID
                iCStockBill.FFManagerID,            // 验收人  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
                iCStockBill.FSManagerID,            // 保管人  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
                iCStockBill.FManageType,            // 保税监管类型
                iCStockBill.FPOStyle,               // 采购方式   外键，要求手动插入辅助资料表（t_SubMessage）最大ID
                iCStockBill.FSupplyID,              // 供应商   外键，要求手动插入供应商表（t_Supplier）最大ID    （客户表t_Organization	FItemID）
                iCStockBill.FRelateBrID,            // 供货机构
                iCStockBill.FOrgBillInterID,        // 源单内码
                iCStockBill.FExplanation,           // 摘要
                iCStockBill.FManagerID,             // 负责人  外键，要求手动插入职员表（t_Base_Emp）最大ID
                iCStockBill.FEmpID,                 // 业务员  外键，要求手动插入职员表（t_Base_Emp）最大ID
                iCStockBill.FCussentAcctID,         // 往来科目  外键，要求手动插入科目表（t_Account）最大ID
                iCStockBill.FSettleDate,            // 付款日期
                iCStockBill.FRefType,               // 调拨类型
                iCStockBill.FPurposeID,             // 委外类型
                iCStockBill.FPOOrdBillNo,           // 对方单据号
                iCStockBill.FBillTypeID,            // 入库类型    
                iCStockBill.FObjectItem            // 工程项目
                );
            
            }
        }
    
}
