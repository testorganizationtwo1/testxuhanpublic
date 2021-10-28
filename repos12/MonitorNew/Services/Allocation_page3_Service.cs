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
using ICStockBillEntry = MonitorNew.KingdeeEntity.ICStockBillEntry;
using t_ICItemCore = MonitorNew.KingdeeEntity.t_ICItemCore;
using t_Stock = MonitorNew.KingdeeEntity.t_Stock;
using t_StockPlace = MonitorNew.KingdeeEntity.t_StockPlace;

namespace MonitorNew.Services
{
    /// <summary>
    /// 调拨单page3数据交互
    /// </summary>
    public class Allocation_page3_Service : BaseService
    {
        public static string InsertAllocation_page1()
        {
            // 1、查询odoo  调拨单page3.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->正在查询OdooHelper().GetAllocation_page3" + DateTime.Now);
            List<Allocation_page3> dt = new OdooHelper().GetAllocation_page3();
            if (dt == null)
                return "no,没有查到odoo调拨单page3数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->查询OdooHelper().GetAllocation_page3()结束" + DateTime.Now);

            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)

            {
                Allocation_page3 item = dt[i];
                #region 循环插入金蝶
                #region 获取仓库Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->正在插入仓库表 t_Stock FName=" + item.stock_warehouse_name + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->仓库表 t_Stock 插入结束 FName=" + item.stock_warehouse_name + DateTime.Now);
                #endregion

                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->正在插入出入库单据分录表 ICStockBillEntry" + DateTime.Now);
                // (1) 插入金蝶 ICStockBillEntry表   ***
                ICStockBillEntry iCStockBillEntry = new ICStockBillEntry
                {
                    //FSNListID = item.,
                    FOrderBillNo = item.stock_picking_name,
                    //FOrderEntryID = ,
                    //FOrderInterID = ,
                    //FEntryID = ,
                    //FInterID = ,
                    //FItemID = item.,
                    //FAuxPropID = ,
                    FBatchNo = item.stock_move_line_lot_name,
                    //FUnitID = item.,
                    //FAuxQty = ,
                    //FAuxPrice = ,
                    //FQty = ,
                    //Famount = item.,
                    //FAuxPriceRef = ,
                    //FAmtRef = ,
                    //FNote = item.,
                    //FAuxPlanPrice = ,
                    //FPlanAmount = ,
                    //FKFDate = item.,
                    //FKFPeriod = ,
                    //FPeriodDate = ,
                    //FSCStockID = ,
                    //FDCSPID = item.stock_location_name,
                    //FSecCoefficient = ,
                    //FSecQty = ,
                    //FSourceBillNo = ,
                    //FSourceTranType = item.,
                    //FSourceInterId = ,
                    //FSourceEntryID = ,
                    //FICMOBillNo = ,
                    //FICMOInterID = ,
                    //FPPBomEntryID = ,
                    //FPlanMode = ,
                    //FMTONo = ,
                    //FChkPassItem =
                    //FStockID =  金蝶数据库ICStockBillEntry表无此字段
                    //
                };
                new SqlHelper().SqlPour(ICStockBillEntryFormat.sql_ICStockBillEntry(iCStockBillEntry), null);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->出入库单据分录表 ICStockBillEntry 插入结束" + DateTime.Now);
                // (2) 插入金蝶 t_Stock表 ***

                //new SqlHelper().SqlPour(t_StockFormat.sql_t_Stock(t_Stock_entity), null);
                // (3) 插入金蝶 t_ICItemCore表 ***
                t_ICItemCore t_ICItemCore_entity = new t_ICItemCore()
                {
                    //FNumber = ,
                    //FName = ,
                    //FModel = item.,
                    //FItemID =
                };
                new SqlHelper().SqlPour(t_ICItemCoreFormat.sql_t_ICItemCore(t_ICItemCore_entity), null);
                // (4) 插入金蝶 t_AuxItem 表 ***
                t_AuxItem t_AuxItem_entity = new t_AuxItem()
                {
                    //FItemID = item.,
                    //FItemClassID = item.,
                    //FNumber = ,
                    //FName = ,
                    //FParentID = ,
                    //FUnUsed = ,
                    //FFullNumber = ,
                    //FDeleted = ,
                    //FShortNumber = ,
                    //FFullName =item.

                };
                new SqlHelper().SqlPour(t_AuxItemFormat.sql_t_AuxItem(t_AuxItem_entity), null);
                // (5) 插入金蝶 t_ItemClass 表 ***
                t_ItemClass t_ItemClass_entity = new t_ItemClass()
                {
                    //FItemClassID = item.,
                    //FNumber = ,
                    //FName = ,
                    //FName_en = ,
                    //FVersion = ,
                    //FImport = ,
                    //FBrNo = ,
                    //FUserDefilast = ,
                    //FType = item.,
                    //FGRType = ,
                    //FRemark = item.,
                    //FGrControl =
                };
                new SqlHelper().SqlPour(t_ItemClassFormat.sql_t_ItemClass(t_ItemClass_entity), null);
                // (6) 插入金蝶 t_StockPlaceGroup 表 ***
                t_StockPlaceGroup t_StockPlaceGroup_entity = new t_StockPlaceGroup()
                {
                    //FSPGroupID = ,
                    //FNumber = ,
                    //FName = ,
                    //FDefaultSPID = ,
                    //FDeleted =
                };

                new SqlHelper().SqlPour(t_StockPlaceGroupFormat.sql_t_StockPlaceGroup(t_StockPlaceGroup_entity), null);
                // (7) 插入金蝶 t_StockPlace 表 ***
                t_StockPlace t_StockPlace_entity = new t_StockPlace()
                {
                    //FName = item.,
                    //FDetail = ,
                    //FNumber = ,
                    //FParentID = ,
                    //FFullNumber = ,
                    //FSPID =

                };
                new SqlHelper().SqlPour(t_StockPlaceFormat.sql_t_StockPlace(t_StockPlace_entity), null);
                #endregion

            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->循环插入金蝶结束" + DateTime.Now);
            return "";
        }
    }
}
