using Monitor.DatabaseHelper;
using MonitorNew.KingdeeEntity;
using MonitorNew.Tools;
using OdooEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorNew.Services
{
    /// <summary>
    /// 虚仓出库page2数据交互
    /// </summary>
    public class VirtualWarehouseDelivery_page2_Service : BaseService
    {
        public static string InsertVirtualWarehouseDelivery_page2()
        {
            // 1、查询odoo  虚仓出库page2.sql
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->正在插入OdooHelper().GetVirtualWarehouseDelivery_page2()" + DateTime.Now);
            List<VirtualWarehouseDelivery_page2> dt = new OdooHelper().GetVirtualWarehouseDelivery_page2();
            if (dt == null)
                return "no,没有查到odoo虚仓出库page2数据";
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->插入OdooHelper().GetVirtualWarehouseDelivery_page2()结束" + DateTime.Now);
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->循环插入金蝶开始" + DateTime.Now);
            for (int i = 0; i < dt.Count; i++)
            {
                #region 循环插入金蝶
                VirtualWarehouseDelivery_page2 item = dt[i];
                #region 获取物料Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->正在插入物料表 t_ICItemCore FNumber=" + item.default_code + DateTime.Now);
                int t_ICItemCore_FItemID = 0;//物料Id
                object SearchByFNumberResult = SearchByColumnName("FItemID", "t_ICItemCore", "FNumber", item.default_code);
                if (string.IsNullOrEmpty(item.default_code) || SearchByFNumberResult==null)
                {
                    #region 此物料在金蝶中不存在，以下为将此物料插入金蝶的代码
                    t_ICItemCore t_ICItemCore_entity = new t_ICItemCore() {
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->物料表 t_ICItemCore 插入结束 FNumber=" + item.default_code + DateTime.Now);
                #endregion

                #region 获取单位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->正在插入计量单位表 t_MeasureUnit FName" + item.uom_uom_name + DateTime.Now);
                int FUnitID = 0;
                object MeasureUnitSearchByFNameResult = SearchByColumnName("FMeasureUnitID", "t_MeasureUnit", "FName", item.uom_uom_name);
                if (string.IsNullOrEmpty(item.uom_uom_name) || MeasureUnitSearchByFNameResult == null)
                {
                    #region 此单位在金蝶中不存在，以下为将此单位插入金蝶的代码
                    t_MeasureUnit t_MeasureUnit_entity = new t_MeasureUnit()
                    {
                        FMeasureUnitID = new SqlHelper().GetMaxId("FMeasureUnitID", "t_MeasureUnit"),
                        //FName = ,
                        //FNumber = */
                    };
                    new SqlHelper().SqlPour(t_MeasureUnitFormat.sql_t_MeasureUnit(t_MeasureUnit_entity), null);
                    FUnitID = t_MeasureUnit_entity.FMeasureUnitID;
                    #endregion
                }
                if (FUnitID == 0 && MeasureUnitSearchByFNameResult != null)
                {
                    FUnitID = Convert.ToInt32(MeasureUnitSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->计量单位表 t_MeasureUnit  插入结束 FName=" + item.uom_uom_name + DateTime.Now);
                #endregion

                #region 获取仓库Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->正在插入仓库表 t_Stock FName=" +item.stock_warehouse_name + DateTime.Now);
                int FDCStockID = 0;//仓库Id
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
                    FDCStockID = t_Stock_entity.FItemID;
                    #endregion
                }
                if (FDCStockID == 0 && StockSearchByFNameResult != null)
                {
                    FDCStockID = Convert.ToInt32(StockSearchByFNameResult);
                }
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->仓库表 t_Stock 插入结束 FName=" + item.stock_warehouse_name + DateTime.Now);
                #endregion

                #region 获取仓位Id的代码
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->正在插入仓位表 t_StockPlace FName=" + item.stock_location_name + DateTime.Now);
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
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->仓位表 t_StockPlace 插入结束 FName=" + item.stock_location_name + DateTime.Now);
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

                #region 此部分模型表名为sql语句，sql语句查询结果无实际用途，暂不处理
                //(select t2.FItemID,t1.FName FNumber,t2.Fname from   t_UnitGroup t1,t_MeasureUnit t2 where t1.FUnitGroupID=t2.FUnitGroupID)
                t_UnitGroup t_UnitGroup_entity = new t_UnitGroup()
                {
                    //FUnitGroupID = item.,
                    //FName = ,
                    //FDefaultUnitID =

                };
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

                
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->正在插入虚仓出入库单据分录表 ZPStockBillEntry" + DateTime.Now);
                // (1) 插入金蝶 ZPStockBillEntry表   
                ZPStockBillEntry zPStockBillEntry = new ZPStockBillEntry() {
                    //FInterID = item.stock_picking_name,
                    //FEntryID = ,
                    FItemID = t_ICItemCore_FItemID,
                    //FQty = ,
                    //FBatchNo = ,
                    FNote = item.stock_picking_note,
                    FUnitID = FUnitID,
                    FAuxQty = item.stock_move_demand_quantity,
                    //FSourceEntryID = ,
                    //FMapNumber =item. ,
                    //FMapName =item. ,
                    FDCSPID = FDCSPID,
                    //FAuxPropID = item.,
                    //FSecCoefficient = item.,
                    //FSecQty = item.,
                    //FSourceTranType = item.stock_picking_type_name,
                    //FSourceInterId = item.,
                    FSourceBillNo = item.stock_picking_origin,
                    FDCStockID = FDCStockID,
                    FKFDate = item.stock_move_date_deadline,
                    //FKFPeriod = item.
                };

                // (2) 插入金蝶 t_Stock表 ***   ====顶部已判断，按需插入

                // (3) 插入金蝶 t_ICItemCore表 ***   ====顶部已判断，按需插入

                // (4) 插入金蝶 t_MeasureUnit表 ***   ====顶部已判断，按需插入

                // (5) 插入金蝶 t_StockPlace表 ***   ====顶部已判断，按需插入

                // (6) 插入金蝶 t_AuxItem 表 ***

                // (7) 插入金蝶 t_ItemClass 表 ***

                // (8) 插入金蝶 t_UnitGroup 表 ***

                // (9) 插入金蝶 t_StockPlaceGroup 表 ***
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->虚仓出入库单据分录表 ZPStockBillEntry 插入结束" + DateTime.Now);
                #endregion
            }
            Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->循环插入金蝶结束" + DateTime.Now);
            return "";

        }
    }
}
