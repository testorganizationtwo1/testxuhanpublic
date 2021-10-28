using KingdeeEntity;
using Monitor.DatabaseHelper;
using Monitor.Tools;
using OdooEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Services
{
    public class OtherExWarehouseService
    {
        // 其他出库
        private DataTable OtherExWarehouse { get; set; }

        /// <summary>
        /// 其他出库
        /// </summary>
        public static string InsetOtherExWarehouse()
        {
            List<OtherExWarehouse> dtOtherExWarehouse = new OdooHelper().GetOtherExWarehouse();
            for (int i = 0; i < dtOtherExWarehouse.Count; i++)
            {
                ICStockBill iCStockBill = new ICStockBill();
                iCStockBill.FDate = dtOtherExWarehouse[i].stock_picking_date_done;
                iCStockBill.FCheckerID = 1111; //审核人
                iCStockBill.FBillNo = dtOtherExWarehouse[i].stock_picking_name;//入库单号 **
                iCStockBill.FBrNo = "必填项";//必填项，非文档要求
                iCStockBill.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBill
                string sql_icstockBill = new SqlHelper().GetSqlForKingdeeSql("ICStockBill.sql");
                sql_icstockBill = string.Format(sql_icstockBill, iCStockBill.FDate, iCStockBill.FCheckerID, "", iCStockBill.FBillNo, 0, iCStockBill.FBrNo, iCStockBill.FInterID, "", "");
                new SqlHelper().SqlPour(sql_icstockBill, null);
                #endregion

                t_Department t_department = new t_Department();
                t_department.FName = "机械部"; //领料部门
                t_department.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Department");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_department
                string sql_t_department = new SqlHelper().GetSqlForKingdeeSql("t_Department.sql");
                sql_t_department = string.Format(sql_t_department, t_department.FName, t_department.FItemID);
                new SqlHelper().SqlPour(sql_t_department, null);
                #endregion

                t_Stock t_stock = new t_Stock();
                t_stock.FName = dtOtherExWarehouse[i].stock_location_name;
                t_stock.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_stock
                string sql_t_stock = new SqlHelper().GetSqlForKingdeeSql("t_Stock.sql");
                sql_t_stock = string.Format(sql_t_stock, t_stock.FName, t_stock.FItemID);
                new SqlHelper().SqlPour(sql_t_stock, null);
                #endregion

                t_ICItemCore t_ICItemCore = new t_ICItemCore();
                t_ICItemCore.FNumber = dtOtherExWarehouse[i].product_product_material_code;
                t_ICItemCore.FName = dtOtherExWarehouse[i].product_template_name;
                t_ICItemCore.FModel = dtOtherExWarehouse[i].product_product_product_model;
                t_ICItemCore.FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_ICItemCore
                string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
                sql_t_ICItemCore = string.Format(sql_t_ICItemCore, t_ICItemCore.FNumber, t_ICItemCore.FName, t_ICItemCore.FModel, t_ICItemCore.FItemID);
                new SqlHelper().SqlPour(sql_t_ICItemCore, null);
                #endregion

                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry();
                iCStockBillEntry.FAuxQty = dtOtherExWarehouse[i].stock_move_demand_quantity;
                iCStockBillEntry.FAuxPrice = dtOtherExWarehouse[i].stock_move_price_unit;
                iCStockBillEntry.Famount = 5;//金额
                iCStockBillEntry.FBatchNo = dtOtherExWarehouse[i].stock_move_line_lot_name;//批次 **
                iCStockBillEntry.FBrNo = "1";//必填项，非文档要求
                iCStockBillEntry.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID
                iCStockBillEntry.FEntryID = new SqlHelper().GetMaxId("FEntryID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBillEntry
                new SqlHelper().SqlPour(SqlStringFormat.sql_iCStockBillEntry(iCStockBillEntry), null);
                #endregion

                t_Base_Emp t_Base_Emp = new t_Base_Emp();
                t_Base_Emp.FName = "战三";// 职员名称
                t_Base_Emp.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Base_Emp");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_Base_Emp
                string sql_t_Base_Emp = new SqlHelper().GetSqlForKingdeeSql("t_Base_Emp.sql");
                sql_t_Base_Emp = string.Format(sql_t_Base_Emp, t_Base_Emp.FName, t_Base_Emp.FItemID);
                new SqlHelper().SqlPour(sql_t_Base_Emp, null);
                #endregion

            }
            return string.Empty;
        }
    }
}
