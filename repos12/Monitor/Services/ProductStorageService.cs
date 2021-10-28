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
    public class ProductStorageService
    {
        // 产品入库
        private DataTable ProductStorage { get; set; }

        /// <summary>
        /// 产品入库
        /// </summary>
        /// <returns></returns>
        public static string InsertProductStorage()
        {
            List<ProductStorage> dtProductStorage = new OdooHelper().GetProductStorage();
            for (int i = 0; i < dtProductStorage.Count; i++)
            {
                ICStockBill icstockBill = new ICStockBill();
                icstockBill.FDate = dtProductStorage[i].stock_picking_date_done;
                icstockBill.FCheckerID = 001; //审核标志
                icstockBill.FCancellation = "0"; //作废标志
                icstockBill.FBillNo = dtProductStorage[i].stock_picking_name; //单据编号，非空  **
                icstockBill.FBackFlushed = "1";//倒冲标志
                icstockBill.FBrNo = "yy001"; //必填项，非文档要求
                icstockBill.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert ICStockBill
                string sql_icstockBill = new SqlHelper().GetSqlForKingdeeSql("ICStockBill.sql");
                sql_icstockBill = string.Format(sql_icstockBill, icstockBill.FDate, icstockBill.FCheckerID, icstockBill.FCancellation, icstockBill.FBillNo, icstockBill.FBackFlushed, icstockBill.FBrNo, icstockBill.FInterID, "", "");
                new SqlHelper().SqlPour(sql_icstockBill, null);
                #endregion

                t_Department t_department = new t_Department();
                t_department.FName = dtProductStorage[i].stock_picking_delivery_department;
                t_department.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Department");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_department
                string sql_t_department = new SqlHelper().GetSqlForKingdeeSql("t_Department.sql");
                sql_t_department = string.Format(sql_t_department, t_department.FName, t_department.FItemID);
                new SqlHelper().SqlPour(sql_t_department, null);
                #endregion

                t_Stock t_stock = new t_Stock();
                t_stock.FName = dtProductStorage[i].position_stock_location_name;
                t_stock.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_stock
                string sql_t_stock = new SqlHelper().GetSqlForKingdeeSql("t_Stock.sql");
                sql_t_stock = string.Format(sql_t_stock, t_stock.FName, t_stock.FItemID);
                new SqlHelper().SqlPour(sql_t_stock, null);
                #endregion

                t_ICItemCore t_ICItemCore = new t_ICItemCore();
                t_ICItemCore.FNumber = dtProductStorage[i].product_product_material_code;
                t_ICItemCore.FName = dtProductStorage[i].product_template_name;
                t_ICItemCore.FModel = dtProductStorage[i].product_product_product_model;
                t_ICItemCore.FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_ICItemCore
                string sql_t_ICItemCore = new SqlHelper().GetSqlForKingdeeSql("t_ICItemCore.sql");
                sql_t_ICItemCore = string.Format(sql_t_ICItemCore, t_ICItemCore.FNumber, t_ICItemCore.FName, t_ICItemCore.FModel, t_ICItemCore.FItemID);
                new SqlHelper().SqlPour(sql_t_ICItemCore, null);
                #endregion

                t_MeasureUnit t_MeasureUnit = new t_MeasureUnit();
                t_MeasureUnit.FName = dtProductStorage[i].uom_uom_name;
                t_MeasureUnit.FNumber = "2257";//必填项，非文档要求
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

                ICStockBillEntry t_ICStockBillEntry = new ICStockBillEntry();
                t_ICStockBillEntry.FQtyMust = dtProductStorage[i].stock_move_line_product_uom_qty;
                t_ICStockBillEntry.FAuxQty = dtProductStorage[i].qty_done;
                t_ICStockBillEntry.FAuxPrice = dtProductStorage[i].stock_move_price_unit;
                t_ICStockBillEntry.Famount = 5;//金额
                t_ICStockBillEntry.FBatchNo = dtProductStorage[i].tock_move_line_lot_name;//批号 **
                t_ICStockBillEntry.FNote = dtProductStorage[i].stock_picking_note;
                t_ICStockBillEntry.FSourceBillNo = dtProductStorage[i].stock_picking_origin;
                t_ICStockBillEntry.FSourceTranType = 111;//源单类型
                //t_ICStockBillEntry.FQtyMust = "33";//基本单位应收数量
                t_ICStockBillEntry.FQty = 22;//基本单位实收数量
                t_ICStockBillEntry.FAuxPlanPrice = 33;//计划单价
                t_ICStockBillEntry.FPlanAmount = 330;//计划价金额
                //t_ICStockBillEntry.FQtyMust = "22";//常用单位应收数量
                t_ICStockBillEntry.FKFPeriod = 3;//保质期(天)
                t_ICStockBillEntry.FKFDate = Convert.ToDateTime("2009-01-12 00:00:00.000");//生产 / 采购日期
                t_ICStockBillEntry.FPositionNo = "12";//位置号
                t_ICStockBillEntry.FItemSize = "3";//坯料尺寸
                t_ICStockBillEntry.FItemSuite = "5";//坯料数
                t_ICStockBillEntry.FBrNo = "1";//必填项，非文档要求
                t_ICStockBillEntry.FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID
                t_ICStockBillEntry.FEntryID = new SqlHelper().GetMaxId("FEntryID", "ICStockBillEntry");//必填项，非文档要求，主键，要求手动插入最大ID
                
                #region Insert ICStockBillEntry
                new SqlHelper().SqlPour(SqlStringFormat.sql_iCStockBillEntry(t_ICStockBillEntry), null);
                #endregion

                t_Base_Emp t_Base_Emp = new t_Base_Emp();
                t_Base_Emp.FName = "王二狗";// --验收 --保管
                t_Base_Emp.FItemID = new SqlHelper().GetMaxId("FItemID", "t_Base_Emp");//必填项，非文档要求，主键，要求手动插入最大ID

                #region Insert t_Base_Emp
                string sql_t_Base_Emp = new SqlHelper().GetSqlForKingdeeSql("t_Base_Emp.sql");
                sql_t_Base_Emp = string.Format(sql_t_Base_Emp, t_Base_Emp.FName, t_Base_Emp.FItemID);
                new SqlHelper().SqlPour(sql_t_Base_Emp, null);
                #endregion

                #region 制单--审核人--不能重复
                string zhidan = "王狗子" + new Random().Next(9999);
                ArrayList arrlist_t_Base_User = new SqlHelper().SelectInfo(string.Format("select * from t_Base_User where FName='{0}'", zhidan), null);

                if (arrlist_t_Base_User.Count == 0)
                {
                    t_Base_User t_Base_User = new t_Base_User();
                    t_Base_User.FName = zhidan;//res.users.name   -- 不能重复，制单--审核人
                    t_Base_User.FPrimaryGroup = "11" + new Random().Next(999);//必填项，非文档要求
                    t_Base_User.FUserID = new SqlHelper().GetMaxId("FUserID", "t_Base_User");//必填项，非文档要求，主键，要求手动插入最大ID

                    #region Insert t_Base_User
                    string sql_t_Base_User = new SqlHelper().GetSqlForKingdeeSql("t_Base_User.sql");
                    sql_t_Base_User = string.Format(sql_t_Base_User, t_Base_User.FName, t_Base_User.FPrimaryGroup, t_Base_User.FUserID);
                    new SqlHelper().SqlPour(sql_t_Base_User, null);
                    #endregion
                }
                #endregion

                ArrayList arrlist_t_StockPlace = new SqlHelper().SelectInfo(string.Format("select * from t_StockPlace where FNumber='{0}'", dtProductStorage[i].stock_location_barcode), null);

                if (arrlist_t_StockPlace.Count == 0)
                {
                    t_StockPlace t_StockPlace = new t_StockPlace();
                    t_StockPlace.FName = dtProductStorage[i].stock_location_name;
                    t_StockPlace.FNumber = dtProductStorage[i].stock_location_barcode;//不能重复，必填项，非文档要求
                    t_StockPlace.FDetail = "0" + new Random().Next(999);//必填项，非文档要求
                    t_StockPlace.FParentID = "33" + new Random().Next(999);//必填项，非文档要求
                    t_StockPlace.FFullNumber = "完整number";//必填项，非文档要求
                    t_StockPlace.FSPID = new SqlHelper().GetMaxId("FSPID", "t_StockPlace");//必填项，非文档要求，主键，要求手动插入最大ID

                    #region Insert t_StockPlace
                    string sql_t_StockPlace = new SqlHelper().GetSqlForKingdeeSql("t_StockPlace.sql");
                    sql_t_StockPlace = string.Format(sql_t_StockPlace, t_StockPlace.FName, t_StockPlace.FNumber, t_StockPlace.FDetail, t_StockPlace.FParentID, t_StockPlace.FFullNumber, t_StockPlace.FSPID);
                    new SqlHelper().SqlPour(sql_t_StockPlace, null);
                    #endregion
                }

                //凭证字号

                //审核日期 stock.picking.audit_data

                //辅助属性

                //辅助属性代码

                //生产任务单号

                //常用单位实收数量

                //有效期至

                //收货仓库代码--stock.picking.type.sequence_code

                //辅助单位

                //换算率

                //辅助数量

                //检验是否良品

                //打印次数

                //存放位置--stock.move.store_position_info

                //别名--stock.move.another_name
            }

            return String.Empty;

        }
    }
}
