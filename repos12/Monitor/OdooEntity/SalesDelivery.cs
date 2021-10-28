using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    public class SalesDelivery
    {   
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime  stock_picking_date_done { get; set; }//stock_picking.date_done
        // 审核标志
        // 单据编号
        // 购货单位
        /// <summary>
        /// 单据编号
        /// </summary>
        public string stock_picking_name { get; set; } //stock_picking **
        /// <summary>
        /// 发货仓库
        /// </summary>
        public string stock_location_name { get; set; }//stock_location.
        /// <summary>
        /// 仓位条码
        /// </summary>
        public string stock_location_barcode { get; set; }//stock_location.barcode,
        /// <summary>
        /// 购货单位
        /// </summary>
        public string res_partner_name { get; set; }//res_partner **
        /// <summary>
        /// 产品长代码
        /// </summary>
        public string product_product_material_code { get; set; }//product_product.material_code
        /// <summary>
        /// 产品名称
        /// </summary>
        public string product_template_name { get; set; }//product_template.name
        /// <summary>
        /// 规格型号
        /// </summary>
        public string product_product_product_model { get; set; }//product_product.product_model
        /// <summary>
        /// 单位
        /// </summary>
        public string uom_uom_name { get; set; }//uom_uom.name
        /// <summary>
        /// 批号
        /// </summary>
        public string stock_move_line_lot_name { get; set; }//stock_move_line_lot **
        /// <summary>
        /// 实发数量
        /// </summary>
        public decimal stock_move_line_qty_done { get; set; }// stock_move_line_qty **

        // 批号
        // 实发数量
        // product_template.standard_price 单位成本  --计算字段
        // 成本
        /// <summary>
        /// 部门
        /// </summary>
        public string hr_department_name { get; set; }//hr_department.name
        // res_users.name,--三个同名字段
        /// <summary>
        /// 摘要
        /// </summary>
        public string stock_picking_summary { get; set; }//stock_picking.summary
        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal stock_move_price_unit { get; set; }//stock_move.price_unit
        //stock_move.total_amount,  销售金额  --计算字段
        public List<SalesDelivery> GetEntitySalesDelivery(DataTable dt)
        {
            List<SalesDelivery> list = new List<SalesDelivery>();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                
                SalesDelivery oew = new SalesDelivery();
                oew.stock_picking_date_done = Convert.ToDateTime (dt.Rows[i]["date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["date_done"])); //修改
                oew.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.hr_department_name = dt.Rows[i]["hr_department_name"].ToString();
                oew.stock_picking_summary = dt.Rows[i]["stock_picking_summary"].ToString();
                oew.stock_move_price_unit = Convert.ToDecimal (dt.Rows[i]["stock_move_price_unit"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_price_unit"]);
                list.Add(oew);
            }
            return list;
        }
    }
    //oew.qty_done = Convert.ToDecimal(dt.Rows[i]["qty_done"] == DBNull.Value? 0 : dt.Rows[i]["qty_done"]); //修改
}
