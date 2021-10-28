using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    public class OutsourcingDeliveryDocumentsList
    {   
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime stock_picking_date_done { get; set; }//stock_picking.date_done
        // 审核标志
        // 加工单位
        // 单据编号
        // 委外类型
        /// <summary>
        /// 发料仓库
        /// </summary>
        public string stock_location_name { get; set; }//stock_location.name
        /// <summary>
        /// 仓位条码
        /// </summary>
        public string stock_location_barcode { get; set; }//stock_location.barcode,
        /// <summary>
        /// 材料长代码
        /// </summary>
        public string product_product_material_code { get; set; }//product_product.material_code
        /// <summary>
        /// 材料名称
        /// </summary>
        public string product_template_name { get; set; }// product_template.name
        /// <summary>
        /// 规格型号
        /// </summary>
        public string product_product_product_model { get; set; }//product_product.product_model
        /// <summary>
        /// 单位
        /// </summary>
        public string uom_uom_name { get; set; }//uom_uom.name
        /// <summary>
        /// 数量
        /// </summary>
        public decimal stock_move_demand_quantity { get; set; }//stock_move.demand_quantity
        /// <summary>
        /// 单据编号
        /// </summary>
        public string stock_picking_name { get; set; }//stock_picking.name **
        /// <summary>
        /// 加工单位
        /// </summary>
        public string res_partner_name { get; set; }//res_partner.name **
        /// <summary>
        /// 位置号
        /// </summary>
        public string stock_location_complete_name { get; set; }//stock_location.complete_name **
        /// <summary>
        /// 订单单号
        /// </summary>
        public string stock_picking_origin { get; set; }//stock_picking.origin **
        //product_template.standard_price  单位成本--计算字段
        //stock_move.total_amount  金额 --计算字段
        // 订单单号
        // 行关闭标志
        // 位置号
        // 坯料尺寸
        // 坯料数
        public List<OutsourcingDeliveryDocumentsList> GetEntityOutsourcingDeliveryDocumentsList(DataTable dt)
        {
            List<OutsourcingDeliveryDocumentsList> list = new List<OutsourcingDeliveryDocumentsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                OutsourcingDeliveryDocumentsList oddl = new OutsourcingDeliveryDocumentsList();
                oddl.stock_picking_date_done = Convert.ToDateTime (dt.Rows[i]["date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10): Convert.ToDateTime(dt.Rows[i]["date_done"]));
                oddl.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oddl.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oddl.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oddl.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oddl.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oddl.stock_move_demand_quantity = Convert.ToDecimal (dt.Rows[i]["stock_move_demand_quantity"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_demand_quantity"]);
                list.Add(oddl);
            }
            return list;
        }
    }
}
