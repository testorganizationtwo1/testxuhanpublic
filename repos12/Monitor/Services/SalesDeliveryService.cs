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
    public class SalesDeliveryService
    {
        // 销售出库
        private DataTable SalesDelivery { get; set; }

        /// <summary>
        /// 销售出库
        /// </summary>
        /// <returns></returns>
        public static string InsertSalesDelivery()
        {
            List<SalesDelivery> dtSalesDelivery = new OdooHelper().GetSalesDelivery();
            for (int i = 0; i < dtSalesDelivery.Count; i++)
            {
                ICStockBill icstockBill = new ICStockBill();
                icstockBill.FDate = dtSalesDelivery[i].stock_picking_date_done;
                icstockBill.FCheckerID = 16394; //FCheckerID 审核人
                icstockBill.FBillNo = dtSalesDelivery[i].stock_picking_name;//FBillNo 出库单号 **
                icstockBill.FBrNo = "必填项";//FBrNo 必填项，非文档要求
                icstockBill.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill");//FInterID 必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert icstockBill
                string sql_icstockBill = new SqlHelper().GetSqlForKingdeeSql("ICStockBill.sql");
                sql_icstockBill = string.Format(sql_icstockBill, icstockBill.FDate, icstockBill.FCheckerID, "", icstockBill.FBillNo, 0, icstockBill.FBrNo, icstockBill.FInterID, "", "");
                new SqlHelper().SqlPour(sql_icstockBill, null);
                #endregion

                t_Organization t_Organization = new t_Organization();
                t_Organization.FName = dtSalesDelivery[i].res_partner_name;//FName 购货单位 **
                t_Organization.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Organization");//FItemID 必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_Organization     //*

                ArrayList arrlist = new SqlHelper().SelectInfo(string.Format("select * from t_Organization  where FName='{0}'", t_Organization.FName), null);
                if (arrlist.Count == 0)

                {
                    string sql_t_Organization = new SqlHelper().GetSqlForKingdeeSql("t_Organization.sql");
                    sql_t_Organization = string.Format(sql_t_Organization, t_Organization.FName, t_Organization.FItemID);
                    new SqlHelper().SqlPour(sql_t_Organization, null);
                }

                #endregion

                t_Stock t_Stock = new t_Stock();
                t_Stock.FName = dtSalesDelivery[i].stock_location_name;
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
                t_ICItemCore.FNumber = dtSalesDelivery[i].product_product_material_code;
                t_ICItemCore.FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore");//FItemID 必填项，非文档要求，主键，要求手动插入最大ID
                t_ICItemCore.FName = dtSalesDelivery[i].product_template_name;
                t_ICItemCore.FModel = dtSalesDelivery[i].product_product_product_model;

                #region Insert t_ICItemCore
                string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
                sql_t_ICItemCore = string.Format(sql_t_ICItemCore, t_ICItemCore.FNumber, t_ICItemCore.FName, t_ICItemCore.FModel, t_ICItemCore.FItemID);
                new SqlHelper().SqlPour(sql_t_ICItemCore, null);
                #endregion

                t_MeasureUnit t_MeasureUnit = new t_MeasureUnit();
                t_MeasureUnit.FName = dtSalesDelivery[i].uom_uom_name;
                t_MeasureUnit.FNumber = "00000521";//FNumber 必填项，非文档要求

                #region Insert t_MeasureUnit

                ArrayList arrlistMeasureUnit = new SqlHelper().SelectInfo(string.Format("select * from t_MeasureUnit where FName='{0}'", t_MeasureUnit.FName), null);
                if (arrlistMeasureUnit.Count == 0)
                {
                    string sql_t_MeasureUnit = new SqlHelper().GetSqlForKingdeeSql("t_MeasureUnit.sql");
                    sql_t_MeasureUnit = string.Format(sql_t_MeasureUnit, t_MeasureUnit.FName, t_MeasureUnit.FNumber);
                    new SqlHelper().SqlPour(sql_t_MeasureUnit, null);
                }

                #endregion

                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry();
                iCStockBillEntry.FBatchNo = dtSalesDelivery[i].stock_move_line_lot_name;//FBatchNo 批次 **
                iCStockBillEntry.FAuxQty = dtSalesDelivery[i].stock_move_line_qty_done;//FAuxQty 辅助实际数量 **
                iCStockBillEntry.FAuxPrice = 10;//FAuxPrice 辅助单价
                iCStockBillEntry.Famount = 23;//Famount 金额
                iCStockBillEntry.FConsignPrice = dtSalesDelivery[i].stock_move_price_unit;
                iCStockBillEntry.FConsignAmount = 3333;//代销金额
                iCStockBillEntry.FBrNo = "523";//必填项，非文档要求
                iCStockBillEntry.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBillEntry");//必填项，非文档要求
                iCStockBillEntry.FEntryID = new SqlHelper().GetMaxId("FEntryID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID 

                #region Insert iCStockBillEntry
                new SqlHelper().SqlPour(SqlStringFormat.sql_iCStockBillEntry(iCStockBillEntry), null);
                #endregion

            }
            return string.Empty;

        }
    }
}
