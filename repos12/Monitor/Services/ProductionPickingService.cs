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
    public class ProductionPickingService
    {
        // 生产领料
        private DataTable ProductionPicking { get; set; }

        /// <summary>
        /// 生产领料
        /// </summary>
        public static string InserProductionPicking()
        {
            List<ProductionPicking> dtProductionPicking = new OdooHelper().GetProductionPicking();
            for (int i = 0; i < dtProductionPicking.Count; i++)
            {
                ICStockBill iCStockBill = new ICStockBill();
                iCStockBill.FDate = dtProductionPicking[i].stock_picking_date_done;
                iCStockBill.FCheckerID = 1111; //审核标志
                iCStockBill.FUse = dtProductionPicking[i].stock_picking_picking_use;//领料用途 **
                iCStockBill.FBillNo = dtProductionPicking[i].stock_picking_name;//单据编号 **
                iCStockBill.FBrNo = "必填项";//必填项，非文档要求
                iCStockBill.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBill
                string sql_icstockBill = new SqlHelper().GetSqlForKingdeeSql("ICStockBill.sql");
                sql_icstockBill = string.Format(sql_icstockBill, iCStockBill.FDate, iCStockBill.FCheckerID, "", iCStockBill.FBillNo, 0, iCStockBill.FBrNo, iCStockBill.FInterID, "", iCStockBill.FUse);
                new SqlHelper().SqlPour(sql_icstockBill, null);
                #endregion

                t_Department t_department = new t_Department();
                t_department.FName = "机械部";//dtProductionPicking[i].stock_picking_Picking_user; //领料部门 **
                t_department.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Department");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_department
                ArrayList arrlistDepartment = new SqlHelper().SelectInfo(string.Format("select * from t_department where FName='{0}'", t_department.FName), null);
                if (arrlistDepartment.Count == 0)
                {
                    string sql_t_department = new SqlHelper().GetSqlForKingdeeSql("t_Department.sql");
                    sql_t_department = string.Format(sql_t_department, t_department.FName, t_department.FItemID);
                    new SqlHelper().SqlPour(sql_t_department, null);
                }

                #endregion

                t_Stock t_stock = new t_Stock();
                t_stock.FName = dtProductionPicking[i].stock_location_name;
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
                t_ICItemCore.FNumber = dtProductionPicking[i].product_product_material_code;
                t_ICItemCore.FName = dtProductionPicking[i].product_template_name;
                t_ICItemCore.FModel = dtProductionPicking[i].product_product_product_model;
                t_ICItemCore.FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_ICItemCore
                string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
                sql_t_ICItemCore = string.Format(sql_t_ICItemCore, t_ICItemCore.FNumber, t_ICItemCore.FName, t_ICItemCore.FModel, t_ICItemCore.FItemID);
                new SqlHelper().SqlPour(sql_t_ICItemCore, null);
                #endregion

                t_MeasureUnit t_MeasureUnit = new t_MeasureUnit();
                t_MeasureUnit.FName = dtProductionPicking[i].uom_uom_name;
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
                iCStockBillEntry.FBatchNo = dtProductionPicking[i].stock_move_line_lot_name;//批次 **
                iCStockBillEntry.FAuxQty = dtProductionPicking[i].stock_move_line_qty_done;//实发数量 **
                iCStockBillEntry.FAuxPrice = dtProductionPicking[i].stock_move_price_unit;
                iCStockBillEntry.Famount = 5;//金额
                iCStockBillEntry.FNote = "备注";//备注
                iCStockBillEntry.FPositionNo = "12";//位置号
                iCStockBillEntry.FItemSize = "11"; //坯料尺寸
                iCStockBillEntry.FItemSuite = "21"; //坯料数
                iCStockBillEntry.FBrNo = "1";//必填项，非文档要求
                iCStockBillEntry.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID
                iCStockBillEntry.FEntryID = new SqlHelper().GetMaxId("FEntryID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBillEntry
                new SqlHelper().SqlPour(SqlStringFormat.sql_iCStockBillEntry(iCStockBillEntry), null);
                #endregion

                t_Base_Emp t_Base_Emp = new t_Base_Emp();
                t_Base_Emp.FName = dtProductionPicking[i].res_partner_name;// 职员名称 **
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
