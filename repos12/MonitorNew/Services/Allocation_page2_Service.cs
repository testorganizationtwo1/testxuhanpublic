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
    /// 调拨单page2数据交互
    /// </summary>
    public class Allocation_page2_Service : BaseService
    {
        public static string InsertAllocation_page2()
        {
            // 1、查询odoo  调拨单page2.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在查询OdooHelper().GetAllocation_page2()" + DateTime.Now);
            List<Allocation_page2> dt = new OdooHelper().GetAllocation_page2();
            if (dt == null)
                return "no,没有查到odoo调拨单page2数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->查询OdooHelper().GetAllocation_page2()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                Allocation_page2 item = dt[i];

                #region 循环插入金蝶
                #region 获取仓库Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在插入仓库表 t_Stock FName=" + item.stock_warehouse_name + DateTime.Now);
                int FDCStockID = 0;//仓库Id
                object StockSearchByFNameResult = SearchByColumnName("FItemID", "t_Stock", "FName", item.stock_warehouse_name);
                if (string.IsNullOrEmpty(item.stock_warehouse_name) || StockSearchByFNameResult == null)
                {
                    #region 此仓库在金蝶中不存在，以下为将此仓库插入金蝶的代码
                    t_Stock t_Stock_entity = new t_Stock()
                    {
                        FItemID = new SqlHelper().GetMaxId("FItemID", "t_Stock"),
                        FName = item.stock_warehouse_name,
                        //FNumber = 
                    };
                    new SqlHelper().SqlPour(t_StockFormat.sql_t_Stock(t_Stock_entity), null);
                    FDCStockID = t_Stock_entity.FItemID;
                    #endregion
                }
                if (FDCStockID == 0 && StockSearchByFNameResult != null)
                {
                    FDCStockID = Convert.ToInt32(StockSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->仓库表 t_Stock 插入结束 FName=" + item.stock_warehouse_name + DateTime.Now);
                #endregion

                #region 获取物料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在插入物料表 t_ICItemCore FNumber=" + item.default_code + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->物料表 t_ICItemCore 插入结束 FNumber=" + item.default_code + DateTime.Now);
                #endregion   

                #region 获取单位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在插入计量单位表 t_MeasureUnit FName" + item.uom_uom_name + DateTime.Now);
                int FUnitID = 0;
                object MeasureUnitSearchByFNameResult = SearchByColumnName("FMeasureUnitID", "t_MeasureUnit", "FName", item.uom_uom_name);
                if (string.IsNullOrEmpty(item.uom_uom_name) || MeasureUnitSearchByFNameResult == null)
                {
                    #region 此单位在金蝶中不存在，以下为将此单位插入金蝶的代码
                    t_MeasureUnit t_MeasureUnit_entity = new t_MeasureUnit()
                    {
                        FMeasureUnitID = new SqlHelper().GetMaxId("FMeasureUnitID", "t_MeasureUnit") ,
                        FName = item.uom_uom_name ,
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->计量单位表 t_MeasureUnit  插入结束 FName=" + item.uom_uom_name + DateTime.Now);
                #endregion

                #region 获取仓位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在插入仓位表 t_StockPlace FName" + item.stock_location_name + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->仓位表 插入结束 t_StockPlace FName" + item.stock_location_name + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
                #region 获取辅助属性基本信息ID的代码

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

                #endregion
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
                #region 获取基础资料类别ID的代码*******
                int FAuxPropID1 = 0;//t_ItemClass Id
                object t_ItemClassSearchByFNameResult = SearchByColumnName("FItemClassID", "(SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)", " *******", "*******");
                if (string.IsNullOrEmpty("*******") || t_AuxItemSearchByFNameResult == null)
                {
                    #region 在金蝶中不存在，以下为插入金蝶的代码
                    t_ItemClass t_ItemClass_entity = new t_ItemClass()
                    {
                        //FItemClassID = new SqlHelper().GetMaxId("FItemClassID", "t_ItemClass"),
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
                #endregion
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FItemID,t1.FName FNumber,t2.Fname from   t_UnitGroup t1,t_MeasureUnit t2 where t1.FUnitGroupID=t2.FUnitGroupID)
                t_UnitGroup t_UnitGroup_entity = new t_UnitGroup()
                {
                    //FUnitGroupID = item.,
                    //FName = ,
                    //FDefaultUnitID =

                };
                #endregion

                #region 获取辅助资料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在插入辅助资料表 t_SubMessage FName=" + "********" + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->辅助资料表 插入结束  t_SubMessage FName=" + "********" + DateTime.Now);
                #endregion

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FSPID,t2.Fname,t1.FName FGroupName from   t_StockPlaceGroup t1,t_StockPlace t2 where t1.FSPGroupID=t2.FSPGroupID AND t2.FSPID>0)
                t_StockPlaceGroup t_StockPlaceGroup_entity = new t_StockPlaceGroup()
                {
                    //FSPGroupID = ,
                    //FNumber = ,
                    //FName = ,
                    //FDefaultSPID = ,
                    //FDeleted =

                };
                #endregion 

                // (1) 插入金蝶 ICStockBillEntry表   ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->正在插入出入库单据表 ICStockBill" + DateTime.Now);
                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry()
                {
                    //FSNListID = item.,
                    FOrderBillNo = item.stock_picking_name,
                    //FOrderEntryID = item.,
                    //FOrderInterID = ,
                    //FEntryID = ,
                    //FInterID = ,
                    FItemID = t_ICItemCore_FItemID,
                    //FAuxPropID = item.,
                    FBatchNo = item.stock_move_line_lot_name,
                    FUnitID = FUnitID ,
                    //FAuxQty = item.,
                    //FAuxPrice = item.,
                    //FQty = ,
                    Famount = item.stock_move_total_amount,
                    //FAuxPriceRef = item.,
                    //FAmtRef = ,
                    FNote = item.stock_picking_note,
                    //FAuxPlanPrice = item.,
                    //FPlanAmount = ,
                    //FKFDate = item.stock_move_date_deadline,
                    //FKFPeriod = ,
                    //FPeriodDate = ,
                    FSCStockID = FDCStockID ,
                    //FSCSPID = ,
                    //FDCStockID = ,
                    FDCSPID = FDCSPID,
                    //FSecCoefficient = ,
                    //FSecQty = ,
                    FSourceBillNo = item.stock_picking_origin,
                    //FSourceTranType = item.stock_picking_type_name,
                    //FSourceInterId = item.,
                    //FSourceEntryID = ,
                    //FICMOBillNo = item.,
                    //FICMOInterID = ,
                    //FPPBomEntryID = ,
                    FPlanMode = t_SubMessage_FInterID,
                    //FMTONo = ,
                    FChkPassItem =t_SubMessage_FInterID

                };
                new SqlHelper().SqlPour(ICStockBillEntryFormat.sql_ICStockBillEntry(iCStockBillEntry), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->出入库单据表 ICStockBill 插入结束" + DateTime.Now);

                // (2) 插入金蝶 t_Stock表 *** ====顶端已判断，按需插入

                // (3) 插入金蝶 t_ICItemCore表 *** ====顶端已判断，按需插入

                // (4) 插入金蝶 t_MeasureUnit表 *** ====顶端已判断，按需插入

                // (5) 插入金蝶 t_StockPlace表 *** ====顶端已判断，按需插入

                //(6) 插入金蝶 t_AuxItem 表 *** ====顶端已判断，按需插入

                //(7) 插入金蝶 t_ItemClass 表 *** ====顶端已判断，按需插入

                //(8) 插入金蝶 t_UnitGroup 表 *** ====顶端已判断，按需插入

                //(9) 插入金蝶 t_SubMessage 表 *** ====顶端已判断，按需插入

                //(10) 插入金蝶 t_StockPlaceGroup 表 *** ====顶端已判断，按需插入




                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
