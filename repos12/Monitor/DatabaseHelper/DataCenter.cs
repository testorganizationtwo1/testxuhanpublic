using KingdeeEntity;
using Monitor.Services;
using OdooEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.DatabaseHelper
{
    public class DataCenter
    {
        public Dictionary<string,string> BeginTask()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            //try
            //{
                ProductStorageService.InsertProductStorage();
                dic.Add("ok-产品入库", "产品入库->同步完成"+DateTime.Now);
                OtherWarehousingService.InsertOtherWarehousing();
                dic.Add("ok-其他入库", "其他入库->同步完成" + DateTime.Now);
                OutsourcingWarehousingOrderService.InsertOutsourcingWarehousingOrder();
                dic.Add("ok-外购入库单", "外购入库单->同步完成" + DateTime.Now);
                ProductionPickingService.InserProductionPicking();
                dic.Add("ok-生产领料", "生产领料->同步完成" + DateTime.Now);
                OutsourcingDeliveryDocumentsListService.InsertdtOutsourcingDeliveryDocumentsList();
                dic.Add("ok-委外加工发出序时簿", "委外加工发出序时簿->同步完成" + DateTime.Now);
                OutsourcingWarehousingService.InsertOutsourcingWarehousing();
                dic.Add("ok-委外入库", "委外入库->同步完成" + DateTime.Now);
                SalesDeliveryService.InsertSalesDelivery();
                dic.Add("ok-销售出库", "销售出库->同步完成" + DateTime.Now);
                OtherExWarehouseService.InsetOtherExWarehouse();
                dic.Add("ok-其他出库", "其他出库->同步完成" + DateTime.Now);
            //}
            //catch (Exception ex)
            //{
                //dic.Add("bad", "同步失败->错误信息："+ ex.Message);
                //throw ex;
            //}
            return dic;
        }
    }
}
