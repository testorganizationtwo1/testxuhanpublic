using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;

namespace MonitorNew.Tools
{
    public class ZPStockBillFormat
    {
        /// <summary>
        /// 虚仓出入库单据表SQL字符串
        /// </summary>
        /// <param name="t_ICStockBillEntry">虚仓出入库单据表实体</param>
        /// <returns>虚仓出入库单据表SQL字符串</returns>
        public static string sql_ZPStockBill(ZPStockBill ZPStockBill)
        {
            string sql_ZPStockBill = new SqlHelper().GetSqlForKingdeeSql("ZPStockBill.sql");
            return string.Format(
                sql_ZPStockBill,
                ZPStockBill.FInterID,               //单据号
                ZPStockBill.FTranType,              //事务类型
                ZPStockBill.FROB,                   //红蓝字
                ZPStockBill.FDate,                  //日期
                ZPStockBill.FBillNo,                //编    号
                ZPStockBill.FCheckerID,             //审核人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
                ZPStockBill.FFManagerID,            //领料   必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
                ZPStockBill.FSManagerID,            //发货
                ZPStockBill.FBillerID,              //制单人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
                ZPStockBill.FDeptID,                //部门   外键，要求手动插入供应商表（t_Department）最大ID
                ZPStockBill.FCustID,                //客户   外键，要求手动插入供应商表（t_Organization）最大ID
                ZPStockBill.FSupplyID,              //供应商  外键，要求手动插入供应商表（t_Supplier）最大ID
                ZPStockBill.FCheckDate,             //审核日期
                ZPStockBill.FEmpID,                 //业务员  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
                ZPStockBill.FExplanation,           //摘要
                ZPStockBill.FManagerID,             //负责人  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
                ZPStockBill.FSelTranType,           //源单类型
                ZPStockBill.FBillTypeID,            //单据类型
                ZPStockBill.FBrID,                  //制单机构
                ZPStockBill.FPrintCount             //打印次数
                );
            
        }
    }
}
