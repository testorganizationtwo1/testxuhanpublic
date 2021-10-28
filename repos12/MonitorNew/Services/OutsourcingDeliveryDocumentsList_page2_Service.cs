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
    /// 委外加工出库page2数据交互
    /// </summary>
    public class OutsourcingDeliveryDocumentsList_page2_Service : BaseService
    {
        public static string InsertOutsourcingDeliveryDocumentsList_page2()
        {
            // 1、查询odoo  委外加工出库page2.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->正在查询OdooHelper().GetOutsourcingDeliveryDocumentsList_page2()" + DateTime.Now); 
            List<OutsourcingDeliveryDocumentsList_page2> dt = new OdooHelper().GetOutsourcingDeliveryDocumentsList_page2();
            if (dt == null)
                return "no,没有查到odoo委外加工出库page2数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->查询OdooHelper().GetOutsourcingDeliveryDocumentsList_page2()结束" + DateTime.Now);
            
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                OutsourcingDeliveryDocumentsList_page2 item = dt[i];

                #region 获取物料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取物料Id的代码开始 FNumber" + item.default_code + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取物料Id的代码结束 FNumber" + item.default_code + DateTime.Now);
                #endregion

                #region 获取仓库Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取仓库Id开始 FName" + item.stock_warehouse_name + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取仓库Id结束 FName" + item.stock_warehouse_name + DateTime.Now);
                #endregion

                #region 获取单位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取单位Id开始 FName" + item.uom_uom_name + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取单位Id的代码结束 FName" + item.uom_uom_name + DateTime.Now);
                #endregion

                #region 获取仓位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取仓位Id的代码开始 FName" + item.stock_location_name + DateTime.Now);
                int FDCSPID = 0;//仓位Id
                object StockPlaceSearchByFNameResult = SearchByColumnName("FSPID", "t_StockPlace", "FName", item.stock_location_name);
                if (string.IsNullOrEmpty(item.stock_location_name) || StockPlaceSearchByFNameResult == null)
                {
                    #region 此仓位在金蝶中不存在，以下将为此仓位插入金蝶的代码
                    t_StockPlace t_StockPlace_entity = new t_StockPlace()
                    {
                        //UUID = System.Guid.NewGuid().ToString();
                        //FDetail = , // ??????  这个字段什么意思
                        FFullNumber = item.stock_location_name,
                        FName = item.stock_location_name,
                        FNumber = item.stock_warehouse_id,// ****** 考虑赋值是否正确
                        //FParentID = ,
                        FSPID = new SqlHelper().GetMaxId("FSPID", "t_StockPlace")
                    };
                    new SqlHelper().SqlPour(t_StockPlaceFormat.sql_t_StockPlace(t_StockPlace_entity), null);
                    FDCSPID = t_StockPlace_entity.FSPID;
                    #endregion
                }
                if (FDCSPID == 0 && StockPlaceSearchByFNameResult != null)
                {
                    FDCSPID = Convert.ToInt32(StockPlaceSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取仓位Id的代码结束  FName" + item.stock_location_name + DateTime.Now);
                #endregion

                #region 获取POOrder FInterID的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取POOrder的代码开始 *******" + "*******" + DateTime.Now);
                int FInterID = 0;//POOrder Id
                object POOrderSearchByFNameResult = SearchByColumnName("FInterID", "POOrder", "*******", "*******");
                if (string.IsNullOrEmpty("*******") || POOrderSearchByFNameResult == null)
                {
                    #region 此仓位在金蝶中不存在，以下将为此仓位插入金蝶的代码
                    POOrder pOOrder_entity = new POOrder()
                    {
                        //FTranType = item.,
                        FInterID = new SqlHelper().GetMaxId("FInterID", "POOrder"),
                        //FBillNo = item.,
                        //FSupplyID = item.,
                        //FDate = ,
                        //FEmpID = ,
                        //FDeptID = ,
                        //FCurrencyID = ,
                        //FCheckerID = item.,
                        //FBillerID = ,
                        //FMangerID = ,
                        //FPOStyle = ,
                        //FRelateBrID = ,
                        //FCheckDate = item.,
                        //FExplanation = ,
                        //FSettleDate = ,
                        //FSettleID = ,
                        //FSelTranType = item.stock_picking_type_name,
                        //FBrID = ,
                        //FPOOrdBillNo = ,
                        //FAreaPS = ,
                        //FManageType = ,
                        //FSysStatus = ,
                        //FValidaterName = ,
                        //FConsignee = ,
                        //FPrintCount = ,
                        //FExchangeRateType = ,
                        //FDeliveryPlace = ,
                        //FAccessoryCount = ,
                        //FPOMode = ,
                        //FPlanCategory = ,
                        //FLastAlterBillNo =

                    };
                    new SqlHelper().SqlPour(POOrderFormat.sql_POOrder(pOOrder_entity), null);
                    FInterID = pOOrder_entity.FInterID;
                    #endregion
                }
                if (FInterID == 0 && POOrderSearchByFNameResult != null)
                {
                    FInterID = Convert.ToInt32(POOrderSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取POOrder的代码结束 *******" + "*******" + DateTime.Now);
                #endregion

                #region 获取t_AuxItem的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取t_AuxItem的代码开始 *******" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取t_AuxItem的代码结束 *******" + "*******" + DateTime.Now);
                #endregion

                #region 获取t_ItemClass的代码*******
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取t_ItemClass的代码开始 ******* " + "*******" + DateTime.Now);
                int FAuxPropID1 = 0;//t_ItemClass Id
                object t_ItemClassSearchByFNameResult = SearchByColumnName("FItemClassID", "(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)", " *******", "*******");
                if (string.IsNullOrEmpty("*******") || t_AuxItemSearchByFNameResult == null)
                {
                    #region 在金蝶中不存在，以下为插入金蝶的代码
                    t_ItemClass t_ItemClass_entity = new t_ItemClass()
                    {
                        FItemClassID = new SqlHelper().GetMaxId("FItemClassID", "(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)"),
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
                    };
                    new SqlHelper().SqlPour(t_ItemClassFormat.sql_t_ItemClass(t_ItemClass_entity), null);
                    FAuxPropID1 = t_ItemClass_entity.FItemClassID;
                    #endregion
                }
                if (FAuxPropID1 == 0 && t_ItemClassSearchByFNameResult != null)
                {
                    FAuxPropID1 = Convert.ToInt32(t_ItemClassSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取t_ItemClass的代码结束 ******* " + "*******" + DateTime.Now);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取辅助资料Id的代码开始 *******" + "*******" + DateTime.Now);
                int t_SubMessage_FInterID = 0;
                object t_SubMessageSearchByFNameResult = SearchByColumnName("FInterID", "t_SubMessage", "*******", "*******");
                if (string.IsNullOrEmpty("*******") || t_SubMessageSearchByFNameResult == null)
                {
                    #region 此系统辅助资料在金蝶中不存在，以下为将此系统辅助资料插入金蝶的代码
                    t_SubMessage t_SubMessage_entity = new t_SubMessage()
                    {
                        //FBrNo = ,
                        FInterID = new SqlHelper().GetMaxId("FInterID", "t_SubMessage"),
                        //FID = ,
                        //FParentID = ,
                        //FName = item.,
                        //FTypeID = ,
                        //FDetail = ,
                        //FDeleted = ,
                        //FSystemType = ,
                        //FSpec =               //未定义

                    };
                    new SqlHelper().SqlPour(t_SubMessageFormat.sql_t_SubMessage(t_SubMessage_entity), null);
                    t_SubMessage_FInterID = t_SubMessage_entity.FInterID;
                    #endregion
                }
                if (t_SubMessage_FInterID == 0 && t_SubMessageSearchByFNameResult != null)
                {
                    t_SubMessage_FInterID = Convert.ToInt32(t_SubMessageSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取辅助资料Id的代码结束 *******" + "*******" + DateTime.Now);
                #endregion

                #region 获取t_Supplier  FEntrySupply的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取t_Supplier的代码开始 FName" + item.res_partner_commercial_company_name + DateTime.Now);
                int FEntrySupply = 0;
                object t_SupplierSearchByFNameResult = SearchByColumnName("FItemID", "t_Supplier", "FName", item.res_partner_commercial_company_name);
                if (string.IsNullOrEmpty("*******") || t_SupplierSearchByFNameResult == null)
                {
                    #region 此系统辅助资料在金蝶中不存在，以下为将此系统辅助资料插入金蝶的代码
                    t_Supplier t_Supplier_entity = new t_Supplier()
                    {
                        FName = item.res_partner_commercial_company_name,
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Supplier"),
                        //FNumber =
                    };
                    new SqlHelper().SqlPour(t_SupplierFormat.sql_t_Supplier(t_Supplier_entity), null);
                    FEntrySupply = t_Supplier_entity.FItemID;
                    #endregion
                }
                if (FEntrySupply == 0 && t_SupplierSearchByFNameResult != null)
                {
                    FEntrySupply = Convert.ToInt32(t_SupplierSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->获取t_Supplier的代码结束 FName" + item.res_partner_commercial_company_name + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FSPID,t2.Fname,t1.FName FGroupName from t_StockPlaceGroup t1,t_StockPlace t2 where t1.FSPGroupID = t2.FSPGroupID AND t2.FSPID > 0)

                #endregion 
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->插入金蝶 ICStockBillEntry表的代码开始" + DateTime.Now);
                // (1) 插入金蝶 ICStockBillEntry表   ***
                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry()
                {
                    //FSNListID = ,
                    FOrderBillNo = item.stock_picking_name,
                    //FOrderEntryID = ,
                    //FOrderInterID = ,
                    //FEntryID = ,
                    FInterID = FInterID,
                    FItemID = t_ICItemCore_FItemID,
                    FAuxPropID = FAuxPropID,
                    FUnitID = FUnitID,
                    FBatchNo = item.stock_move_line_lot_name,
                    //FAuxQty =item. ,
                    //FAuxPrice = ,
                    Famount = item.stock_move_total_amount,
                    FNote = item.stock_picking_note,
                    //FQty = ,
                    //FAuxPlanPrice = item.,
                    //FPlanAmount = item.,
                    //FKFDate = item.stock_move_date_deadline,
                    //FKFPeriod = ,
                    //FPeriodDate = ,
                    //FIsVMI = t_SubMessage_FInterID,
                    FEntrySupply = FEntrySupply,
                    FDCStockID = t_Stock_FDCStockID,
                    FDCSPID = FDCSPID,
                    //FMapNumber = ,
                    //FMapName = ,
                    //FSecCoefficient = ,
                    //FSecQty = ,
                    FSourceBillNo = item.stock_picking_origin,
                    //FSourceTranType = item.stock_picking_type_name,
                    //FSourceInterId = ,
                    //FSourceEntryID = ,
                    //FICMOInterID = ,
                    //FPPBomEntryID = ,
                    //FInStockID = ,
                    FPlanMode = t_SubMessage_FInterID,
                    //FMTONo = ,
                    //FPositionNo = ,
                    //FItemSize = ,
                    //FItemSuite =
                };
                new SqlHelper().SqlPour(ICStockBillEntryFormat.sql_ICStockBillEntry(iCStockBillEntry), null);

                // (2) 插入金蝶 t_Stock表 ***

                // (3) 插入金蝶 t_ICItemCore表 ***

                // (4) 插入金蝶 t_MeasureUnit表 ***

                // (5) 插入金蝶 t_StockPlace表 ***

                // (6) 插入金蝶 POOrder 表 ***

                // (7) 插入金蝶 t_AuxItem 表 ***

                // (8) 插入金蝶 t_ItemClass 表 ***

                //(9) 插入金蝶 t_UnitGroup 表 ***
                //(select t2.FItemID,t1.FName FNumber, t2.Fname from   t_UnitGroup t1, t_MeasureUnit t2 where t1.FUnitGroupID = t2.FUnitGroupID)
                //t_UnitGroup t_UnitGroup_entity = new t_UnitGroup()
                //{
                //FUnitGroupID = ,
                //FName = item.,
                //FDefaultUnitID =

                //};
                //new SqlHelper().SqlPour(t_UnitGroupFormat.sql_t_UnitGroup(t_UnitGroup_entity), null);
                //(10) 插入金蝶 t_SubMessage 表 ***

                // (11) 插入金蝶 t_Supplier 表 ***

                // (12) 插入金蝶 t_StockPlaceGroup 表 ***
                //t_StockPlaceGroup t_StockPlaceGroup_entity = new t_StockPlaceGroup()
                //{
                //FSPGroupID = ,
                //FNumber = ,
                //FName = ,
                //FDefaultSPID = ,
                //FDeleted =

                //};
                //new SqlHelper().SqlPour(t_StockPlaceGroupFormat.sql_t_StockPlaceGroup(t_StockPlaceGroup_entity), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->插入金蝶 ICStockBillEntry表的代码结束" + DateTime.Now);
                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
