using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    public class OutsourcingWarehousing
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
        /// 单据编号
        /// </summary>
        public string stock_picking_name { get; set; }//stock_picking.name **
        /// <summary>
        /// 收料仓库
        /// </summary>
        public string res_partner_name { get; set; }//res_partner.name **
        /// <summary>
        /// 供应商
        /// </summary>
        public string stock_location_name { get; set; }//stock_location.name **
        /// <summary>
        /// 仓位条码
        /// </summary>
        public string stock_location_barcode { get; set; }//stock_location.barcode,
        /// <summary>
        /// 加工材料长代码
        /// </summary>
        public string product_product_material_code { get; set; }//product_product.material_code
        /// <summary>
        /// 加工材料名称
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
        /// 应收数量
        /// </summary>
        public decimal stock_move_line_product_uom_qty { get; set; }//stock_move_line.product_uom_qty
        /// <summary>
        /// 实收数量
        /// </summary>
        public decimal stock_move_line_qty_done { get; set; }//stock_move_line.qty_done
        //product_template.standard_price  单位成本  --计算字段
        //stock_move.total_amount,  金额  --计算字段
        public List<OutsourcingWarehousing> GetEntityOutsourcingWarehousing(DataTable dt)
        {
            List<OutsourcingWarehousing> list = new List<OutsourcingWarehousing>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {   
                OutsourcingWarehousing oew = new OutsourcingWarehousing();
                oew.stock_picking_date_done = Convert.ToDateTime (dt.Rows[i]["date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["date_done"])); //修改
                oew.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_line_product_uom_qty = Convert.ToDecimal (dt.Rows[i]["stock_move_line_product_uom_qty"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_line_product_uom_qty"]);
                oew.stock_move_line_qty_done = Convert.ToDecimal (dt.Rows[i]["stock_move_line_qty_done"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_line_qty_done"]);
                list.Add(oew);
            }
            return list;
        }  // Convert.ToDecimal (dt.Rows[i]["stock_move_price_unit"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_price_unit"]);
    }
}
