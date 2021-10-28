using OdooEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.DatabaseHelper
{
    public class OdooHelper
    {
        public DataTable GetDataTable(string fileName) 
        {
            string directoryStr = string.Format("{0}\\DatabaseHelper\\OdooSql\\{1}", Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(directoryStr))
            {
                return null;
            }
            StreamReader rs = new StreamReader(directoryStr, System.Text.Encoding.UTF8);//注意编码
            string sqlStr = rs.ReadToEnd();
            return PgsqlHelper.ExecuteQuery(sqlStr);
        }
        
        /// <summary>
        /// 获取产品入库数据
        /// </summary>
        /// <returns></returns>
        public List<ProductStorage> GetProductStorage()
        {
            DataTable dt = GetDataTable("产品入库.sql");
            List<ProductStorage> list = new ProductStorage().GetEntityProductStorage(dt);
            return list;
        }
        /// <summary>
        /// 获取其他出库数据
        /// </summary>
        /// <returns></returns>
        public List<OtherExWarehouse> GetOtherExWarehouse()
        {
            DataTable dt = GetDataTable("其他出库.sql");
            List<OtherExWarehouse> list = new OtherExWarehouse().GetEntityOtherExWarehouse(dt);
            return list;
        }
        /// <summary>
        /// 其他入库
        /// </summary>
        /// <returns></returns>
        public List<OtherWarehousing> GetOtherWarehousing()
        {
            DataTable dt = GetDataTable("其他入库.sql");
            List<OtherWarehousing> list = new OtherWarehousing().GetEntityOtherWarehousing(dt);
            return list;
        }
        /// <summary>
        /// 生产领料
        /// </summary>
        /// <returns></returns>
        public List<ProductionPicking> GetProductionPicking()
        {
            DataTable dt = GetDataTable("生产领料.sql");
            List<ProductionPicking> list = new ProductionPicking().GetEntityProductionPicking(dt);
            return list;
        }
        /// <summary>
        /// 外购入库单
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingWarehousingOrder> GetOutsourcingWarehousingOrder()
        {
            DataTable dt = GetDataTable("外购入库单模板.sql");
            List<OutsourcingWarehousingOrder> list = new OutsourcingWarehousingOrder().GetEntityOutsourcingWarehousingOrder(dt);
            return list;
        }
        /// <summary>
        /// 委外加工发出序时簿
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingDeliveryDocumentsList> GetOutsourcingDeliveryDocumentsList()
        {
            DataTable dt = GetDataTable("委外加工发出序时簿.sql");
            List<OutsourcingDeliveryDocumentsList> list = new OutsourcingDeliveryDocumentsList().GetEntityOutsourcingDeliveryDocumentsList(dt);
            return list;
        }
        /// <summary>
        /// 委外入库
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingWarehousing> GetOutsourcingWarehousing()
        {
            DataTable dt = GetDataTable("委外入库.sql");
            List<OutsourcingWarehousing> list = new OutsourcingWarehousing().GetEntityOutsourcingWarehousing(dt);
            return list;
        }
        /// <summary>
        /// 销售出库
        /// </summary>
        /// <returns></returns>
        public List<SalesDelivery> GetSalesDelivery()
        {
            DataTable dt = GetDataTable("销售出库.sql");
            List<SalesDelivery> list = new SalesDelivery().GetEntitySalesDelivery(dt);
            return list;
        }
    }
}
