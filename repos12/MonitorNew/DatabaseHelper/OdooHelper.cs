using MonitorNew;
using OdooEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Monitor.DatabaseHelper
{
    public class OdooHelper
    {
        public DataTable GetDataTable(string fileName) 
        {
            string directoryStr = string.Format("{0}\\DatabaseHelper\\OdooSql\\{1}", Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(directoryStr))
            {
                Program.mf.ListBoxKingdeeTaskList.Items.Add("找不到文件，文件路径："+ directoryStr + DateTime.Now);
                return null;
            }
            StreamReader rs = new StreamReader(directoryStr, System.Text.Encoding.UTF8);//注意编码
            string sqlStr = rs.ReadToEnd();
            Program.mf.ListBoxKingdeeTaskList.Items.Add("正在执行：" + directoryStr + DateTime.Now);
            return PgsqlHelper.ExecuteQuery(sqlStr);
        }
        
        /// <summary>
        /// 获取调拨单page1数据
        /// </summary>
        /// <returns></returns>
        public List<Allocation_page1> GetAllocation_page1()
        {
            DataTable dt = GetDataTable("调拨单page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<Allocation_page1> list = new Allocation_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取调拨单page2数据
        /// </summary>
        /// <returns></returns>
        public List<Allocation_page2> GetAllocation_page2()
        {
            DataTable dt = GetDataTable("调拨单page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<Allocation_page2> list = new Allocation_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取调拨单page3数据
        /// </summary>
        /// <returns></returns>
        public List<Allocation_page3> GetAllocation_page3()
        {
            DataTable dt = GetDataTable("调拨单page3.sql");
            if (dt == null)
            {
                return null;
            }
            List<Allocation_page3> list = new Allocation_page3().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取其他出库page1数据
        /// </summary>
        /// <returns></returns>
        public List<OtherExWarehouse_page1> GetOtherExWarehouse_page1()
        {
            DataTable dt = GetDataTable("其他出库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<OtherExWarehouse_page1> list = new OtherExWarehouse_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取其他出库page2数据
        /// </summary>
        /// <returns></returns>
        public List<OtherExWarehouse_page2> GetOtherExWarehouse_page2()
        {
            DataTable dt = GetDataTable("其他出库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<OtherExWarehouse_page2> list = new OtherExWarehouse_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取其他入库page1数据
        /// </summary>
        /// <returns></returns>
        public List<OtherWarehousing_page1> GetOtherWarehousing_page1()
        {
            DataTable dt = GetDataTable("其他入库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<OtherWarehousing_page1> list = new OtherWarehousing_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取其他入库page2数据
        /// </summary>
        /// <returns></returns>
        public List<OtherWarehousing_page2> GetOtherWarehousing_page2()
        {
            DataTable dt = GetDataTable("其他入库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<OtherWarehousing_page2> list = new OtherWarehousing_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取委外加工出库page1数据
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingDeliveryDocumentsList_page1> GetOutsourcingDeliveryDocumentsList_page1()
        {
            DataTable dt = GetDataTable("委外加工出库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<OutsourcingDeliveryDocumentsList_page1> list = new OutsourcingDeliveryDocumentsList_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取委外加工出库page2数据
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingDeliveryDocumentsList_page2> GetOutsourcingDeliveryDocumentsList_page2()
        {
            DataTable dt = GetDataTable("委外加工出库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<OutsourcingDeliveryDocumentsList_page2> list = new OutsourcingDeliveryDocumentsList_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取委外入库page1数据
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingWarehousing_page1> GetOutsourcingWarehousing_page1()
        {
            DataTable dt = GetDataTable("委外入库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<OutsourcingWarehousing_page1> list = new OutsourcingWarehousing_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取委外入库page2数据
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingWarehousing_page2> GetOutsourcingWarehousing_page2()
        {
            DataTable dt = GetDataTable("委外入库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<OutsourcingWarehousing_page2> list = new OutsourcingWarehousing_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取外购入库page1数据
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingWarehousingOrder_page1> GetOutsourcingWarehousingOrder_page1()
        {
            DataTable dt = GetDataTable("外购入库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<OutsourcingWarehousingOrder_page1> list = new OutsourcingWarehousingOrder_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取外购入库page2数据
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingWarehousingOrder_page2> GetOutsourcingWarehousingOrder_page2()
        {
            DataTable dt = GetDataTable("外购入库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<OutsourcingWarehousingOrder_page2> list = new OutsourcingWarehousingOrder_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取生产领料page1数据
        /// </summary>
        /// <returns></returns>
        public List<ProductionPicking_page1> GetProductionPicking_page1()
        {
            DataTable dt = GetDataTable("生产领料page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<ProductionPicking_page1> list = new ProductionPicking_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取生产领料page2数据
        /// </summary>
        /// <returns></returns>
        public List<ProductionPicking_page2> GetProductionPicking_page2()
        {
            DataTable dt = GetDataTable("生产领料page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<ProductionPicking_page2> list = new ProductionPicking_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取产品入库page1数据
        /// </summary>
        /// <returns></returns>
        public List<ProductStorage_page1> GetProductStorage_page1()
        {
            DataTable dt = GetDataTable("产品入库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<ProductStorage_page1> list = new ProductStorage_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取产品入库page2数据
        /// </summary>
        /// <returns></returns>
        public List<ProductStorage_page2> GetProductStorage_page2()
        {
            DataTable dt = GetDataTable("产品入库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<ProductStorage_page2> list = new ProductStorage_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取采购订单page1数据
        /// </summary>
        /// <returns></returns>
        public List<PurchaseOrder_page1> GetPurchaseOrder_page1()
        {
            DataTable dt = GetDataTable("采购订单page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<PurchaseOrder_page1> list = new PurchaseOrder_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取采购订单page2数据
        /// </summary>
        /// <returns></returns>
        public List<PurchaseOrder_page2> GetPurchaseOrder_page2()
        {
            DataTable dt = GetDataTable("采购订单page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<PurchaseOrder_page2> list = new PurchaseOrder_page2().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取虚仓出库page1数据
        /// </summary>
        /// <returns></returns>
        public List<VirtualWarehouseDelivery_page1> GetVirtualWarehouseDelivery_page1()
        {
            DataTable dt = GetDataTable("虚仓出库page1.sql");
            if (dt == null)
            {
                return null;
            }
            List<VirtualWarehouseDelivery_page1> list = new VirtualWarehouseDelivery_page1().GetEntity(dt);
            return list;
        }
        /// <summary>
        /// 获取虚仓出库page2数据
        /// </summary>
        /// <returns></returns>
        public List<VirtualWarehouseDelivery_page2> GetVirtualWarehouseDelivery_page2()
        {
            DataTable dt = GetDataTable("虚仓出库page2.sql");
            if (dt == null)
            {
                return null;
            }
            List<VirtualWarehouseDelivery_page2> list = new VirtualWarehouseDelivery_page2().GetEntity(dt);
            return list;
        }
    }
}
