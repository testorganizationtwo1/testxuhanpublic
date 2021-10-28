using Monitor.DatabaseHelper;
using Monitor.Tools;
using MonitorNew.KingdeeEntity;
using MonitorNew.Tools;
using OdooEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Services
{
    /// <summary>
    /// 产品入库page2数据交互
    /// </summary>
    public class ProductStorage_page2_Service : BaseService
    {
        public static string InsertProductStorage_page2()
        {
            // 1、查询odoo  产品入库page2.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->正在查询OdooHelper().GetProductStorage_page2()" + DateTime.Now);
            List<ProductStorage_page2> dt = new OdooHelper().GetProductStorage_page2();
            if (dt == null)
                return "no,没有查到odoo产品入库page2数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->查询OdooHelper().GetProductStorage_page2()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                ProductStorage_page2 item = dt[i];

                #region 获取仓库Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取仓库Id开始 FName" + item.stock_warehouse_name + DateTime.Now);
                int t_Stock_FDCStockID = 0;//仓库Id
                object StockSearchByFNameResult = SearchByColumnName("FItemID", "t_Stock", "FName", item.stock_warehouse_name);
                if (string.IsNullOrEmpty(item.stock_warehouse_name) || StockSearchByFNameResult == null)
                {
                    #region 此仓库在金蝶中不存在，以下为将此仓库插入金蝶的代码
                    t_Stock t_Stock_entity = new t_Stock()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock"),
                        FName = item.stock_warehouse_name
                    };
                    new SqlHelper().SqlPour(t_StockFormat.sql_t_Stock(t_Stock_entity), null);
                    t_Stock_FDCStockID = t_Stock_entity.FItemID;
                    #endregion
                }
                if (t_Stock_FDCStockID == 0 && StockSearchByFNameResult != null)
                {
                    t_Stock_FDCStockID = Convert.ToInt32(StockSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取仓库Id结束 FName" + item.stock_warehouse_name + DateTime.Now);
                #endregion

                #region 获取物料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取物料Id开始 FNumber" + item.default_code + DateTime.Now);
                int t_ICItemCore_FItemID = 0;//物料Id
                object SearchByFNumberResult = SearchByColumnName("FItemID", "t_ICItemCore", "FNumber", item.default_code);
                if (string.IsNullOrEmpty(item.default_code) || SearchByFNumberResult == null)
                {
                    #region 此物料在金蝶中不存在，以下为将此物料插入金蝶的代码
                    t_ICItemCore t_ICItemCore_entity = new t_ICItemCore()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore"),
                        FModel = item.product_product_product_model,
                        FName = item.product_template_name,
                        FNumber = !string.IsNullOrEmpty(item.default_code) ? item.default_code : item.product_product_material_code
                    };
                    new SqlHelper().SqlPour(t_ICItemCoreFormat.sql_t_ICItemCore(t_ICItemCore_entity), null);
                    t_ICItemCore_FItemID = t_ICItemCore_entity.FItemID;
                    #endregion
                }
                if (t_ICItemCore_FItemID == 0 && SearchByFNumberResult != null)
                {
                    t_ICItemCore_FItemID = Convert.ToInt32(SearchByFNumberResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取物料Id结束 FNumber" + item.default_code + DateTime.Now);
                #endregion

                #region 获取单位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取单位Id开始 FName" + item.uom_uom_name + DateTime.Now);
                int FUnitID = 0;
                object MeasureUnitSearchByFNameResult = SearchByColumnName("FMeasureUnitID", "t_MeasureUnit", "FName", item.uom_uom_name);
                if (string.IsNullOrEmpty(item.uom_uom_name) || MeasureUnitSearchByFNameResult == null)
                {
                    #region 此单位在金蝶中不存在，以下为将此单位插入金蝶的代码
                    t_MeasureUnit t_MeasureUnit_entity = new t_MeasureUnit()
                    {
                        FMeasureUnitID = new SqlHelper().GetMaxId("FMeasureUnitID", "t_MeasureUnit"),
                        //FName = ,
                        //FNumber = 
                    };
                    new SqlHelper().SqlPour(t_MeasureUnitFormat.sql_t_MeasureUnit(t_MeasureUnit_entity), null);
                    FUnitID = t_MeasureUnit_entity.FMeasureUnitID;
                    #endregion
                }
                if (FUnitID == 0 && MeasureUnitSearchByFNameResult != null)
                {
                    FUnitID = Convert.ToInt32(MeasureUnitSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取单位Id结束  FName" + item.uom_uom_name + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FSPID,t2.Fname,t1.FName FGroupName from t_StockPlaceGroup t1,t_StockPlace t2 where t1.FSPGroupID = t2.FSPGroupID AND t2.FSPID > 0)

                #endregion

                #region 获取ICStockBill Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取ICStockBill Id开始 FBillNo" + item.stock_picking_name + DateTime.Now);
                int FInterID = 0;
                object ICStockBillSearchByFNameResult = SearchByColumnName("FInterID", "ICStockBill", "FBillNo", item.stock_picking_name);
                if (string.IsNullOrEmpty("******") || ICStockBillSearchByFNameResult == null)
                {
                    #region 此单位在金蝶中不存在，以下为将此单位插入金蝶的代码
                    ICStockBill iCStockBill = new ICStockBill()
                    {
                        //FDate = item.stock_picking_date_done,
                        //FCheckerID = item.,
                        //FCancellation = item.,
                        //FUse = item.,
                        //FBillNo = item.,
                        //FBackFlushed = ,
                        //FBrNo = ,
                        FInterID = new SqlHelper().GetMaxId("FInterID", "ICStockBill"),
                        //FStatus = ,
                        //FCheckDate = item.,
                        //FROB = ,
                        //FTranType = item.,
                        //FSelTranType = item.stock_picking_type_name,
                        //FPrintCount = ,,
                        //FVchInterID = item.,
                        //FBillerID = item.stock_picking_maker,
                        //FBrID = ,
                        //FDeptID = item.,
                        //FFManagerID = item.,
                        //FSManagerID = item.,
                        //FManageType = ,
                        //FPOStyle = item.,
                        //FSupplyID = item.,
                        //FRelateBrID = item.,
                        //FOrgBillInterID = item.,
                        //FExplanation = ,
                        //FManagerID = item.,
                        //FEmpID = item.,
                        //FCussentAcctID = ,
                        //FSettleDate = ,
                        //FRefType = ,
                        //FPurposeID = ,
                        //FPOOrdBillNo = ,
                        //FBillTypeID = ,
                        //FObjectItem = 
                    };
                    new SqlHelper().SqlPour(ICStockBillFormat.sql_ICStockBill(iCStockBill), null);
                    FInterID = iCStockBill.FInterID;
                    #endregion
                }
                if (FInterID == 0 && ICStockBillSearchByFNameResult != null)
                {
                    FInterID = Convert.ToInt32(ICStockBillSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取ICStockBill Id结束 FBillNo" + item.stock_picking_name + DateTime.Now);
                #endregion

                #region 获取t_AuxItem的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取t_AuxItem Id开始 *******" + "*******" + DateTime.Now);
                int FAuxPropID = 0;//t_AuxItem Id
                object t_AuxItemSearchByFNameResult = SearchByColumnName("FItemID", "t_AuxItem", "*******", "*******");
                if (string.IsNullOrEmpty("*******") || t_AuxItemSearchByFNameResult == null)
                {
                    #region 在金蝶中不存在，以下为插入金蝶的代码
                    t_AuxItem t_AuxItem_entiry = new t_AuxItem()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_AuxItem"),
                        //FItemClassID = ,
                        //FNumber = ,
                        //FName = ,
                        //FParentID = ,
                        //FUnUsed = ,
                        //FFullNumber = ,
                        //FDeleted = ,
                        //FShortNumber = ,
                        //FFullName =

                    };
                    new SqlHelper().SqlPour(t_AuxItemFormat.sql_t_AuxItem(t_AuxItem_entiry), null);
                    FAuxPropID = t_AuxItem_entiry.FItemID;
                    #endregion
                }
                if (FAuxPropID == 0 && t_AuxItemSearchByFNameResult != null)
                {
                    FAuxPropID = Convert.ToInt32(t_AuxItemSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->获取t_AuxItem Id结束 *******" + "*******" + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(SELECT t2.FName FClassName, t1.*FROM t_AuxItem t1, t_ItemClass t2 where t1.FItemClassID = t2.FItemClassID)

                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FItemID,t1.FName FNumber, t2.Fname from   t_UnitGroup t1, t_MeasureUnit t2 where t1.FUnitGroupID = t2.FUnitGroupID)

                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FSPID,t2.Fname,t1.FName FGroupName from   t_StockPlaceGroup t1,t_StockPlace t2 where t1.FSPGroupID=t2.FSPGroupID AND t2.FSPID>0)

                #endregion

                // (1) 插入金蝶 ICStockBillEntry表   ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->插入金蝶 ICStockBillEntry表开始" + DateTime.Now);
                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry() {
                    //FQtyMust = item.,
                    //FAuxQtyMust = item.,
                    //FConsignPrice = item.,
                    //FConsignAmount = ,
                    //FProcessCost = ,
                    //FProcessPrice = item.,
                    //FAuxQty = item.,
                    //FAuxPrice = item.,
                    Famount = item.stock_move_total_amount,
                    FBatchNo = item.stock_move_line_lot_name,
                    FNote = item.stock_picking_note,
                    FSourceBillNo = item.stock_picking_origin,
                    //FSourceTranType = item.stock_picking_type_name,
                    //FKFPeriod = item.,
                    FQty = item.stock_move_line_qty_done,
                    //FAuxPlanPrice = item.,
                    //FPlanAmount = item.,
                    //FKFDate = item.stock_move_date_deadline,
                    FPositionNo = item.stock_location_name,
                    //FItemSize = ,
                    //FItemSuite = ,
                    //FBrNo = item.,
                    FInterID = FInterID,
                    //FEntryID = ,
                    //FConsiFConsignAmountgnPrice = item.,
                    //FSNListID = item.,
                    //FPeriodDate = ,
                    //FSecCoefficient = ,
                    //FSecQty = item.,
                    //FSourceInterId = item.,
                    //FSourceEntryID = item.,
                    //FICMOBillNo = item.,
                    //FICMOInterID = item.,
                    //FPPBomEntryID = ,
                    //FMTONo = item.,
                    //FChkPassItem = item.,
                    FItemID = t_ICItemCore_FItemID,
                    //FAuxPropID = item.,
                    FUnitID = FUnitID,
                    FDCStockID = t_Stock_FDCStockID,
                    //FDCSPID = item.stock_location_name,
                    FOrderBillNo = item.stock_picking_name,
                    //FOrderEntryID = item.,
                    //FOrderInterID = item.,
                    //FMapNumber = ,
                    //FMapName = item.,
                    //FOrgBillEntryID = ,
                    //FSecInvoiceQty = ,
                    //FPlanMode = ,
                    //FDeliveryNoticeFID = ,
                    //FDeliveryNoticeEntryID = ,
                    //FAuxPriceRef = ,
                    //FAmtRef = item.,
                    //FSCStockID = item.,
                    //FSCSPID = ,
                    //FMaterialCostPrice = ,
                    //FMaterialCost =
                };
                new SqlHelper().SqlPour(ICStockBillEntryFormat.sql_ICStockBillEntry(iCStockBillEntry), null);
                // (2) 插入金蝶 t_Stock表 ***

                // (3) 插入金蝶 t_ICItemCore表 ***

                // (4) 插入金蝶 t_MeasureUnit表 ***

                // (5) 插入金蝶 t_StockPlace表 ***
                //t_StockPlace t_StockPlace_entity = new t_StockPlace() {
                //FDetail = ,
                //FFullNumber = ,
                //FName = item.stock_location_name,
                //FNumber = item.,
                //FParentID = ,
                //FSPID =
                //};
                //new SqlHelper().SqlPour(t_StockPlaceFormat.sql_t_StockPlace(t_StockPlace_entity), null);
                // (6) 插入金蝶 ICStockBill表   ***

                // (7) 插入金蝶 t_AuxItem 表 ***

                // (8) 插入金蝶 t_ItemClass 表 ***
                //t_ItemClass t_ItemClass_entity = new t_ItemClass()
                //{
                //FItemClassID = ,
                //FNumber = ,
                //FName = ,
                //FName_en = ,
                //FVersion = ,
                //FImport = ,
                //FBrNo = ,
                //FUserDefilast = ,
                //FType = ,
                //FGRType = ,
                //FRemark = ,
                //FGrControl =
                //};
                //new SqlHelper().SqlPour(t_ItemClassFormat.sql_t_ItemClass(t_ItemClass_entity), null);
                //(9) 插入金蝶 t_UnitGroup 表 ***
                //t_UnitGroup t_UnitGroup_entity = new t_UnitGroup()
                //{
                //FUnitGroupID = ,
                //FName = ,
                //FDefaultUnitID =
                //};
                //new SqlHelper().SqlPour(t_UnitGroupFormat.sql_t_UnitGroup(t_UnitGroup_entity), null);
                // (10) 插入金蝶 t_StockPlaceGroup 表 ***
                //t_StockPlaceGroup t_StockPlaceGroup_entity = new t_StockPlaceGroup()
                //{
                //FSPGroupID = ,
                //FNumber = ,
                //FName = ,
                //FDefaultSPID = ,
                //FDeleted =
                //};
                //new SqlHelper().SqlPour(t_StockPlaceGroupFormat.sql_t_StockPlaceGroup(t_StockPlaceGroup_entity), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->插入金蝶 ICStockBillEntry表结束" + DateTime.Now);
                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
