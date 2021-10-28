using MonitorNew;
using MonitorNew.Services;
using System;

namespace Monitor.DatabaseHelper
{
    public class DataCenter
    {
        private void IsContinue(string result)
        {
            if (result.IndexOf("no") > 0)
            {
                Program.mf.ListBoxKingdeeTaskList.Items.Add(result + DateTime.Now);
                Program.mf.ListBoxKingdeeTaskList.Items.Add("运行已终止！！！");
                return;
            }
        }
        public void BeginTask()
        {
            try
            {
                #region 采购订单
                // 采购订单page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->开始同步" + DateTime.Now);
                IsContinue(PurchaseOrder_page1_Service.InsertPurchaseOrder_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page1->同步完成" + DateTime.Now);
                // 采购订单page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->开始同步" + DateTime.Now);
                IsContinue(PurchaseOrder_page2_Service.InsertPurchaseOrder_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("采购订单page2->同步完成" + DateTime.Now);
                #endregion

                #region 产品入库
                // 产品入库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->开始同步" + DateTime.Now);
                IsContinue(ProductStorage_page1_Service.InsertProductStorage_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page1->同步完成" + DateTime.Now);
                // 产品入库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->开始同步" + DateTime.Now);
                IsContinue(ProductStorage_page2_Service.InsertProductStorage_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page2->同步完成" + DateTime.Now);
                // 产品入库page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page3->开始同步" + DateTime.Now);
                //IsContinue(ProductStorage_page3_Service.InsertProductStorage_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("产品入库page3->同步完成" + DateTime.Now);
                #endregion

                #region 调拨单
                // 调拨单page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->开始同步" + DateTime.Now);
                IsContinue(Allocation_page1_Service.InsertAllocation_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page1->同步完成" + DateTime.Now);
                // 调拨单page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->开始同步" + DateTime.Now);
                IsContinue(Allocation_page2_Service.InsertAllocation_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page2->同步完成" + DateTime.Now);
                // 调拨单page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->开始同步" + DateTime.Now);
                //IsContinue(Allocation_page3_Service.InsertAllocation_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("调拨单page3->同步完成" + DateTime.Now);
                #endregion

                #region 其他出库
                // 其他出库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->开始同步" + DateTime.Now);
                IsContinue(OtherExWarehouse_page1_Service.InsertOtherExWarehouse_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page1->同步完成" + DateTime.Now);
                // 其他出库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page2->开始同步" + DateTime.Now);
                IsContinue(OtherExWarehouse_page2_Service.InsertOtherExWarehouse_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page2->同步完成" + DateTime.Now);
                // 其他出库page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page3->开始同步" + DateTime.Now);
                //IsContinue(OtherExWarehouse_page3_Service.InsertOtherExWarehouse_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他出库page3->同步完成" + DateTime.Now);
                #endregion

                #region 其他入库
                // 其他入库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他入库page1->开始同步" + DateTime.Now);
                IsContinue(OtherWarehousing_page1_Service.InsertOtherWarehousing_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他入库page1->同步完成" + DateTime.Now);
                // 其他入库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他入库page2->开始同步" + DateTime.Now);
                IsContinue(OtherWarehousing_page2_Service.InsertOtherWarehousing_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他入库page2->同步完成" + DateTime.Now);
                // 其他入库page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他入库page3->开始同步" + DateTime.Now);
                //IsContinue(OtherWarehousing_page3_Service.InsertOtherWarehousing_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("其他入库page3->同步完成" + DateTime.Now);
                #endregion

                #region 生产领料
                // 生产领料page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->开始同步" + DateTime.Now);
                IsContinue(ProductionPicking_page1_Service.InsertProductionPicking_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page1->同步完成" + DateTime.Now);
                // 生产领料page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page2->开始同步" + DateTime.Now);
                IsContinue(ProductionPicking_page2_Service.InsertProductionPicking_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page2->同步完成" + DateTime.Now);
                // 生产领料page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page3->开始同步" + DateTime.Now);
                //IsContinue(ProductionPicking_page3_Service.InsertProductionPicking_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("生产领料page3->同步完成" + DateTime.Now);
                #endregion

                #region 外购入库
                // 外购入库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("外购入库page1->开始同步" + DateTime.Now);
                IsContinue(OutsourcingWarehousingOrder_page1_Service.InsertOutsourcingWarehousingOrder_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("外购入库page1->同步完成" + DateTime.Now);
                // 外购入库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("外购入库page2->开始同步" + DateTime.Now);
                IsContinue(OutsourcingWarehousingOrder_page2_Service.InsertOutsourcingWarehousingOrder_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("外购入库page2->同步完成" + DateTime.Now);
                // 外购入库page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("外购入库page3->开始同步" + DateTime.Now);
                //IsContinue(OutsourcingWarehousingOrder_page3_Service.InsertOutsourcingWarehousingOrder_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("外购入库page3->同步完成" + DateTime.Now);
                #endregion

                #region 委外加工出库
                // 委外加工出库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->开始同步" + DateTime.Now);
                IsContinue(OutsourcingDeliveryDocumentsList_page1_Service.InsertOutsourcingDeliveryDocumentsList_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page1->同步完成" + DateTime.Now);
                // 委外加工出库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->开始同步" + DateTime.Now);
                IsContinue(OutsourcingDeliveryDocumentsList_page2_Service.InsertOutsourcingDeliveryDocumentsList_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page2->同步完成" + DateTime.Now);
                // 委外加工出库page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page3->开始同步" + DateTime.Now);
                //IsContinue(OutsourcingDeliveryDocumentsList_page3_Service.InsertOutsourcingDeliveryDocumentsList_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外加工出库page3->同步完成" + DateTime.Now);
                #endregion

                #region 委外入库
                // 委外入库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->开始同步" + DateTime.Now);
                IsContinue(OutsourcingWarehousing_page1_Service.InsertOutsourcingWarehousing_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page1->同步完成" + DateTime.Now);
                // 委外入库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page2->开始同步" + DateTime.Now);
                IsContinue(OutsourcingWarehousing_page2_Service.InsertOutsourcingWarehousing_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page2->同步完成" + DateTime.Now);
                // 委外入库page3
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page3->开始同步" + DateTime.Now);
                //IsContinue(OutsourcingWarehousing_page3_Service.InsertOutsourcingWarehousing_page3());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("委外入库page3->同步完成" + DateTime.Now);
                #endregion

                #region 虚仓出库
                // 虚仓出库page1
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->开始同步" + DateTime.Now);
                IsContinue(VirtualWarehouseDelivery_page1_Service.InsertVirtualWarehouseDelivery_page1());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page1->同步完成" + DateTime.Now);
                // 虚仓出库page2
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->开始同步" + DateTime.Now);
                IsContinue(VirtualWarehouseDelivery_page2_Service.InsertVirtualWarehouseDelivery_page2());
                Program.mf.ListBoxKingdeeTaskList.Items.Add("虚仓出库page2->同步完成" + DateTime.Now);
                #endregion
                Program.mf.ListBoxKingdeeTaskList.Items.Add("==============="+ DateTime.Now + "===============");
                Program.mf.ListBoxKingdeeTaskList.Items.Add("**********所有模块已同步完成**********");
            }
            catch (Exception ex) {
                Program.mf.ListBoxKingdeeTaskList.Items.Add("同步失败->错误信息：" + ex.Message);
            }
        }
    }
}
