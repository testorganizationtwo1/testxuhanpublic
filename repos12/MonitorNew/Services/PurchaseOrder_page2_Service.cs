using Monitor.DatabaseHelper;
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
    /// 采购订单page2数据交互
    /// </summary>
    public class PurchaseOrder_page2_Service : BaseService
    {
        public static string InsertPurchaseOrder_page2()
        {
            // 1、查询odoo  采购订单page2.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入OdooHelper().GetPurchaseOrder_page2()" + DateTime.Now);
            List<PurchaseOrder_page2> dt = new OdooHelper().GetPurchaseOrder_page2();
            if (dt == null)
                return "no,没有查到odoo采购订单page2数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->插入OdooHelper().GetPurchaseOrder_page2()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                PurchaseOrder_page2 item = dt[i];

                #region 获取仓库Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入仓库表 t_Stock FName=" + "********" + DateTime.Now);
                int t_Stock_FItemID = 0;//仓库Id
                object t_StockSearchByFNameResult = SearchByColumnName("FItemID", "t_Stock", "FName", "*******");
                if (string.IsNullOrEmpty("*******") || t_StockSearchByFNameResult == null)
                {
                    #region 此仓库在金蝶中不存在，以下为将此仓库插入金蝶的代码
                    t_Stock t_Stock_entity = new t_Stock()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock"),
                        //FNumber = ,
                        //FName = item.
                    };
                    new SqlHelper().SqlPour(t_StockFormat.sql_t_Stock(t_Stock_entity), null);
                    t_Stock_FItemID = t_Stock_entity.FItemID;
                    #endregion
                }
                if (t_Stock_FItemID == 0 && t_StockSearchByFNameResult != null)
                {
                    t_Stock_FItemID = Convert.ToInt32(t_StockSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->仓库表 插入结束  t_Stock FName=" + "********" + DateTime.Now);
                #endregion

                #region 获取物料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入物料表 t_ICItemCore FNumber=" + item.product_product_material_code + DateTime.Now);
                int t_ICItemCore_FItemID = 0;//物料Id
                object t_ICItemCoreSearchByFNumberResult = SearchByColumnName("FItemID", "t_ICItemCore", "FNumber", item.product_product_material_code);
                if (string.IsNullOrEmpty(item.product_product_material_code) || t_ICItemCoreSearchByFNumberResult == null)
                {
                    #region 此物料在金蝶中不存在，以下为将此物料插入金蝶的代码
                    t_ICItemCore t_ICItemCore_entity = new t_ICItemCore()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_ICItemCore"),
                        //FModel = item.,
                        FName = item.product_template_name,
                        FNumber = item.product_product_material_code
                    };
                    new SqlHelper().SqlPour(t_ICItemCoreFormat.sql_t_ICItemCore(t_ICItemCore_entity), null);
                    t_ICItemCore_FItemID = t_ICItemCore_entity.FItemID;
                    #endregion
                }
                if (t_ICItemCore_FItemID == 0 && t_ICItemCoreSearchByFNumberResult != null)
                {
                    t_ICItemCore_FItemID = Convert.ToInt32(t_ICItemCoreSearchByFNumberResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->物料表 t_ICItemCore 插入结束 FNumber=" + item.product_product_material_code + DateTime.Now);
                #endregion

                #region 获取计量单位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入计量单位表 t_MeasureUnit FName" + item.uom_uom_name + DateTime.Now);
                int t_MeasureUnit_FMeasureUnitID = 0;//计量单位Id
                object t_MeasureUnitSearchByFNameResult = SearchByColumnName("FMeasureUnitID", "t_ICItemCore", "FName", item.uom_uom_name);
                if (string.IsNullOrEmpty(item.product_product_material_code) || t_MeasureUnitSearchByFNameResult == null)
                {
                    #region 此计量单位在金蝶中不存在，以下为将此计量单位插入金蝶的代码
                    t_MeasureUnit t_MeasureUnit = new t_MeasureUnit()
                    {
                        FMeasureUnitID = new SqlHelper().GetMaxId("FMeasureUnitID", "t_MeasureUnit"),
                        FName = item.uom_uom_name,
                        FNumber = item.uom_uom_id
                    };
                    new SqlHelper().SqlPour(t_MeasureUnitFormat.sql_t_MeasureUnit(t_MeasureUnit), null);
                    t_MeasureUnit_FMeasureUnitID = t_MeasureUnit.FMeasureUnitID;
                    #endregion
                }
                if (t_MeasureUnit_FMeasureUnitID == 0 && t_MeasureUnitSearchByFNameResult != null)
                {
                    t_MeasureUnit_FMeasureUnitID = Convert.ToInt32(t_MeasureUnitSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->计量单位表 t_MeasureUnit  插入结束 FName=" + item.uom_uom_name + DateTime.Now);
                #endregion

                #region 获取POOrder FInterID的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入采购订单表 POOrder *******" + "*******" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->采购订单表 POOrder  插入结束 *******" + "*******" + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
                t_AuxItem t_AuxItem_entiry = new t_AuxItem()
                {
                    //FItemID = ,
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
                #endregion 

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
                t_ItemClass t_ItemClass_entity = new t_ItemClass()
                {
                    //FItemClassID = ,
                    //FNumber = item.,
                    //FName = ,
                    //FName_en = ,
                    //FVersion = ,
                    //FImport = ,
                    //FBrNo = ,
                    //FUserDefilast = ,
                    //FType = ,
                    //FGRType = ,
                    FRemark = item.stock_picking_note,
                    //FGrControl =
                };
                new SqlHelper().SqlPour(t_ItemClassFormat.sql_t_ItemClass(t_ItemClass_entity), null);
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入辅助资料表 t_SubMessage *******" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->辅助资料表 插入结束  t_SubMessage FName=" + "********" + DateTime.Now);
                #endregion


                // (1) 插入金蝶 POOrderEntry表   
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->正在插入采购订单分录表 POOrderEntry" + DateTime.Now);
                POOrderEntry pOOrderEntry = new POOrderEntry() {
                    //FInterID = item.stock_picking_name,
                    //FEntryID = item.,
                    //FItemID = item.product_product_material_code,
                    //FDate = item.,
                    //FAmount = item.,
                    //FTaxRate = item.,
                    //FTaxAmount = item.,
                    FNote = item.stock_picking_note,
                    //FUnitID = item.uom_uom_id,
                    //FAuxPrice = item.,
                    FAuxQty = item.stock_move_demand_quantity,
                    //FSourceEntryID = item.,
                    //FCess = item.,
                    //FMapNumber = item.,
                    //FMapName = item.,
                    //FAllAmount = item.,
                    //FAuxPropID = item.,
                    //FAuxPriceDiscount = item.,
                    //FAuxTaxPrice = item.,
                    //FReceiveAmountFor_Commit = item.,
                    //FSecCoefficient = item.,
                    //FSecQty = item.,
                    //FSourceTranType = item.stock_picking_type_name,
                    //FSourceInterId = item.,
                    FSourceBillNo = item.stock_picking_origin,
                    //FContractInterID = item.,
                    //FContractEntryID = item.,
                    FContractBillNo = item.stock_picking_name,
                    //FMRPLockFlag = item.,
                    //FSecInvoiceQty = item.,
                    //FPlanMode = item.,
                    //FMTONo = item.,
                    //FDescount = item.,
                    //FSupConfirmor = item.,
                    //FEntryAccessoryCount = ,
                    //FPRInterID = ,
                    //FPREntryID = ,
                    //FAuxReceiptQty = item.,
                    //FReceiptQty = ,
                    //FAuxReturnQty = item.,
                    //FReturnQty = ,
                    //FCheckMethod = item.
                };
                new SqlHelper().SqlPour(POOrderEntryFormat.sql_POOrderEntry(pOOrderEntry), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->采购订单分录表 POOrderEntry 插入结束" + DateTime.Now);
                // (2) 插入金蝶 t_Stock表 ***

                // (3) 插入金蝶 t_ICItemCore表 ***

                // (4) 插入金蝶 t_MeasureUnit表 ***

                // (5) 插入金蝶 t_StockPlace表 ***

                // (6) 插入金蝶 POOrder 表 ***

                // (7) 插入金蝶 t_AuxItem 表 ***

                // (8) 插入金蝶 t_ItemClass 表 ***

                // (9) 插入金蝶 t_SubMessage 表 ***

                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
