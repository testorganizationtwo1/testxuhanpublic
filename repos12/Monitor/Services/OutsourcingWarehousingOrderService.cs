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
    class OutsourcingWarehousingOrderService
    {
        // 外购入库单
        private DataTable OutsourcingWarehousingOrder { get; set; }
        /// <summary>
        /// 外购入库单
        /// </summary>
        public static string InsertOutsourcingWarehousingOrder()
        {
            List<OutsourcingWarehousingOrder> dtOutsourcingWarehousingOrder = new OdooHelper().GetOutsourcingWarehousingOrder();
            for (int i = 0; i < dtOutsourcingWarehousingOrder.Count; i++)
            {
                ICStockBill iCStockBill = new ICStockBill();
                iCStockBill.FDate = dtOutsourcingWarehousingOrder[i].stock_picking_date_done;
                iCStockBill.FCheckerID = 1111; //审核标志
                iCStockBill.FBillNo = dtOutsourcingWarehousingOrder[i].stock_picking_name;//单据编号 **
                iCStockBill.FBrNo = "必填项";//必填项，非文档要求
                iCStockBill.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBill
                string sql_icstockBill = new SqlHelper().GetSqlForKingdeeSql("ICStockBill.sql");
                sql_icstockBill = string.Format(sql_icstockBill, iCStockBill.FDate, iCStockBill.FCheckerID, "", iCStockBill.FBillNo, 0, iCStockBill.FBrNo, iCStockBill.FInterID, "", "");
                new SqlHelper().SqlPour(sql_icstockBill, null);
                #endregion

                t_Supplier t_Supplier = new t_Supplier();
                t_Supplier.FName = "腾讯控股"; //供应商
                t_Supplier.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Supplier");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_Supplier

                ArrayList arrlistSupplier = new SqlHelper().SelectInfo(string.Format("select * from t_Supplier where FName='{0}'", t_Supplier.FName), null);
                if (arrlistSupplier.Count == 0)
                {
                    string sql_t_Supplier = new SqlHelper().GetSqlForKingdeeSql("t_Supplier.sql");
                    sql_t_Supplier = string.Format(sql_t_Supplier, t_Supplier.FName, t_Supplier.FItemID);
                    new SqlHelper().SqlPour(sql_t_Supplier, null);
                }

                #endregion

                t_Stock t_stock = new t_Stock();
                t_stock.FName = dtOutsourcingWarehousingOrder[i].stock_location_name;
                t_stock.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_Stock

                ArrayList arrlistStock = new SqlHelper().SelectInfo(string.Format("select * from t_Stock where FName='{0}'", t_stock.FName), null);
                if (arrlistStock.Count == 0)
                {
                    string sql_t_stock = new SqlHelper().GetSqlForKingdeeSql("t_Stock.sql");
                    sql_t_stock = string.Format(sql_t_stock, t_stock.FName, t_stock.FItemID);
                    new SqlHelper().SqlPour(sql_t_stock, null);
                }

                #endregion

                t_ICItemCore t_ICItemCore = new t_ICItemCore();
                t_ICItemCore.FNumber = dtOutsourcingWarehousingOrder[i].product_product_material_code;
                t_ICItemCore.FName = dtOutsourcingWarehousingOrder[i].product_template_name;
                t_ICItemCore.FModel = dtOutsourcingWarehousingOrder[i].product_product_product_model;
                t_ICItemCore.FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_ICItemCore
                string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
                sql_t_ICItemCore = string.Format(sql_t_ICItemCore, t_ICItemCore.FNumber, t_ICItemCore.FName, t_ICItemCore.FModel, t_ICItemCore.FItemID);
                new SqlHelper().SqlPour(sql_t_ICItemCore, null);
                #endregion

                t_MeasureUnit t_MeasureUnit = new t_MeasureUnit();
                t_MeasureUnit.FName = dtOutsourcingWarehousingOrder[i].uom_uom_name;
                t_MeasureUnit.FNumber = "2252";//必填项，非文档要求
                t_MeasureUnit.FMeasureUnitID = new SqlHelper().GetMaxId("FMeasureUnitID", "t_MeasureUnit");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_MeasureUnit
                ArrayList arrlist = new SqlHelper().SelectInfo(string.Format("select * from t_MeasureUnit where FName='{0}'", t_MeasureUnit.FName), null);
                if (arrlist.Count == 0)
                {
                    string sql_t_MeasureUnit = new SqlHelper().GetSqlForKingdeeSql("t_MeasureUnit.sql");
                    sql_t_MeasureUnit = string.Format(sql_t_MeasureUnit, t_MeasureUnit.FName, t_MeasureUnit.FNumber);
                    new SqlHelper().SqlPour(sql_t_MeasureUnit, null);
                }
                #endregion

                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry();
                iCStockBillEntry.FAuxQty = dtOutsourcingWarehousingOrder[i].stock_move_line_qty_done;
                iCStockBillEntry.Famount = 5;//金额
                iCStockBillEntry.FBrNo = "1";//必填项，非文档要求
                iCStockBillEntry.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID
                iCStockBillEntry.FEntryID = new SqlHelper().GetMaxId("FEntryID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBillEntry
                new SqlHelper().SqlPour(SqlStringFormat.sql_iCStockBillEntry(iCStockBillEntry), null);
                #endregion

                //部门
                //业务员

            }
            return string.Empty;
        }
    }
}
