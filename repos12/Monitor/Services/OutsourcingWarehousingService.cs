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
    public class OutsourcingWarehousingService
    {
        // 委外入库
        private DataTable OutsourcingWarehousing { get; set; }

        /// <summary>
        /// 委外入库
        /// </summary>
        /// <returns></returns>
        public static string InsertOutsourcingWarehousing()
        {
            List<OutsourcingWarehousing> dtOutsourcingWarehousing = new OdooHelper().GetOutsourcingWarehousing();
            for (int i = 0; i < dtOutsourcingWarehousing.Count; i++)
            {
                ICStockBill icstockBill = new ICStockBill();
                icstockBill.FDate = dtOutsourcingWarehousing[i].stock_picking_date_done;
                icstockBill.FCheckerID = 16394; //FCheckerID 审核人
                icstockBill.FBillNo = "WIN000005";//FBillNo 出库单号
                icstockBill.FBrNo = "必填项";//FBrNo 必填项，非文档要求
                icstockBill.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill");//FInterID 必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert icstockBill
                string sql_icstockBill = new SqlHelper().GetSqlForKingdeeSql("icstockBill.sql");
                sql_icstockBill = string.Format(sql_icstockBill, icstockBill.FDate, icstockBill.FCheckerID, "", icstockBill.FBillNo, 0, icstockBill.FBrNo, icstockBill.FInterID, "", "");
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

                t_Stock t_Stock = new t_Stock();
                t_Stock.FName = dtOutsourcingWarehousing[i].stock_location_name;
                t_Stock.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock");//FItemID 必填项，非文档要求，主键，要求手动插入最大ID 

                #region Insert t_Stock

                ArrayList arrlistStock = new SqlHelper().SelectInfo(string.Format("select * from t_Stock where FName='{0}'", t_Stock.FName), null);
                if (arrlistStock.Count == 0)
                {
                    string sql_t_Stock = new SqlHelper().GetSqlForKingdeeSql("t_Stock.sql");
                    sql_t_Stock = string.Format(sql_t_Stock, t_Stock.FName, t_Stock.FItemID);
                    new SqlHelper().SqlPour(sql_t_Stock, null);
                }
                #endregion


                t_ICItemCore t_ICItemCore = new t_ICItemCore();
                t_ICItemCore.FNumber = dtOutsourcingWarehousing[i].product_product_material_code;
                t_ICItemCore.FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore");//FItemID 必填项，非文档要求，主键，要求手动插入最大ID
                t_ICItemCore.FName = dtOutsourcingWarehousing[i].product_template_name;
                t_ICItemCore.FModel = dtOutsourcingWarehousing[i].product_product_product_model;

                #region Insert t_ICItemCore
                string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
                sql_t_ICItemCore = string.Format(sql_t_ICItemCore, t_ICItemCore.FNumber, t_ICItemCore.FName, t_ICItemCore.FModel, t_ICItemCore.FItemID);
                new SqlHelper().SqlPour(sql_t_ICItemCore, null);
                #endregion

                t_MeasureUnit t_MeasureUnit = new t_MeasureUnit();
                t_MeasureUnit.FName = dtOutsourcingWarehousing[i].uom_uom_name;
                t_MeasureUnit.FNumber = "01.000003";//FNumber 必填项，非文档要求

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
                iCStockBillEntry.FAuxQty = dtOutsourcingWarehousing[i].stock_move_line_qty_done;
                iCStockBillEntry.FAuxPrice = 23;//FAuxPrice 辅助单价 product.template .standard_price
                iCStockBillEntry.Famount = 333;//FAmount --金额 stock.move.total_amount
                iCStockBillEntry.FBatchNo = "2929";//FBatchNo 批次
                iCStockBillEntry.FAuxQtyMust = dtOutsourcingWarehousing[i].stock_move_line_product_uom_qty;
                iCStockBillEntry.FBrNo = "520";//必填项，非文档要求
                iCStockBillEntry.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBillEntry");//必填项，非文档要求
                iCStockBillEntry.FEntryID = new SqlHelper().GetMaxId("FEntryID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID 
                iCStockBillEntry.FSourceBillNo = "OORD000211";//FSourceBillNo 源单单号
                iCStockBillEntry.FProcessCost = 12;//FProcessCost 加工费
                iCStockBillEntry.FProcessPrice = 1;//FProcessPrice 委外加工入库单增加加工单价

                #region Insert iCStockBillEntry
                new SqlHelper().SqlPour(SqlStringFormat.sql_iCStockBillEntry(iCStockBillEntry), null);
                #endregion

            }
            return string.Empty;

        }
    }
}
