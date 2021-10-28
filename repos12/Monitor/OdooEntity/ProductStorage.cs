using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    public class ProductStorage
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime stock_picking_date_done { get; set; } //stock_picking.date_done
        //审核标志
        //作废标志                         
        /// <summary>
        /// 交货单位
        /// </summary>
        public string stock_picking_delivery_department { get; set; }//stock_picking.delivery_department
        //单据编号
        /// <summary>
        /// 收货仓库
        /// </summary>
        public string stock_location_name { get; set; }//stock_location.name
        /// <summary>
        /// 物料代码
        /// </summary>
        public string product_product_material_code { get; set; }//product_product.material_code
        /// <summary>
        /// 物料名称
        /// </summary>
        public string product_template_name { get; set; }//product_template.name;
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
        public decimal stock_move_line_product_uom_qty { get; set; } //stock_move_line.product_uom_qty
        /// <summary>
        /// 实收数量
        /// </summary>
        public decimal qty_done { get; set; } //stock_move_line.qty_done
        /// <summary>
        /// 单价
        /// </summary>
        public decimal stock_move_price_unit { get; set; } //stock_move.price_unit
        /// <summary>
        /// 单据编号
        /// </summary>
        public string stock_picking_name {  get; set; }//stock_picking.name  **
        /// <summary>
        /// 批号
        /// </summary>
        public string tock_move_line_lot_name {  get; set; }//stock_move_line.lot_name **
        //stock_move.total_amount   金额--计算字段
        //批号
        //验收
        //res_users.name, --保管
        //res_users.name, --制单
        //审核人
        /// <summary>
        /// 备注
        /// </summary>
        public string stock_picking_note { get; set; }//stock_picking.note,
        //凭证字号
        /// <summary>
        /// 审核日期
        /// </summary>
        public string stock_picking_audit_data { get; set; }//stock_picking.audit_data,
        //辅助属性
        //辅助属性代码
        //生产任务单号
        /// <summary>
        /// 源单单号
        /// </summary>
        public string stock_picking_origin { get; set; }//stock_picking.origin,
        //源单类型
        //基本单位
        /// <summary>
        /// 基本单位应收数量
        /// </summary>
        public string base_stock_move_line_product_uom_qty { get; set; }//stock_move_line.product_uom_qty,
        /// <summary>
        /// 基本单位实收数量
        /// </summary>
        public string base_stock_move_line_qty_done { get; set; }//stock_move_line.qty_done,
        //计划单价
        //计划价金额
        //常用单位
        //常用单位应收数量
        //常用单位实收数量
        /// <summary>
        /// 仓位
        /// </summary>
        public string position_stock_location_name { get; set; }//stock_location.name,
        /// <summary>
        /// 仓位条码
        /// </summary>
        public string stock_location_barcode { get; set; }//stock_location.barcode,
        //保质期(天)
        //生产/采购日期
        //有效期至stock_move_line_qty_donestock_move_line_qty_done
        //倒冲标志
        /// <summary>
        /// 收货仓库代码
        /// </summary>
        public string stock_picking_type_sequence_code { get; set; }//stock_picking_type.sequence_code,--待定
        //辅助单位
        //换算率
        //辅助数量
        //检验是否良品
        //打印次数
        /// <summary>
        /// 存放位置
        /// </summary>
        public string stock_move_store_position_info { get; set; }// stock_move.store_position_info
        /// <summary>
        /// 别名
        /// </summary>
        public string stock_move_another_name { get; set; }// stock_move.another_name

        public List<ProductStorage> GetEntityProductStorage(DataTable dt)
        {
            List<ProductStorage> list = new List<ProductStorage>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductStorage oew = new ProductStorage();
                oew.stock_picking_date_done = dt.Rows[i]["date_done"]== DBNull.Value ? DateTime.Now.AddYears(-10): Convert.ToDateTime (dt.Rows[i]["date_done"]);
                oew.stock_picking_delivery_department = dt.Rows[i]["delivery_department"].ToString();
                oew.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oew.stock_location_barcode = dt.Rows[i]["stock_location_barcode"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_model"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_line_product_uom_qty = Convert.ToDecimal (dt.Rows[i]["stock_move_line_product_uom_qty"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_line_product_uom_qty"]);
                oew.qty_done = Convert.ToDecimal (dt.Rows[i]["qty_done"] == DBNull.Value ? 0 : dt.Rows[i]["qty_done"]); //修改
                oew.stock_move_price_unit = Convert.ToDecimal(dt.Rows[i]["price_unit"]==DBNull.Value?0: dt.Rows[i]["price_unit"]);
                oew.stock_picking_note = dt.Rows[i]["stock_picking_note"].ToString();
                oew.stock_picking_audit_data = dt.Rows[i]["audit_data"].ToString();
                oew.stock_picking_origin = dt.Rows[i]["stock_picking_origin"].ToString();
                oew.base_stock_move_line_product_uom_qty = dt.Rows[i]["stock_move_line_product_uom_qty"].ToString();
                oew.base_stock_move_line_qty_done = dt.Rows[i]["qty_done"].ToString();
                oew.position_stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oew.stock_picking_type_sequence_code = dt.Rows[i]["sequence_code"].ToString();
                oew.stock_move_store_position_info = dt.Rows[i]["store_position_info"].ToString();
                oew.stock_move_another_name = dt.Rows[i]["another_name"].ToString();
                list.Add(oew);
            }
            return list;
        }
    }
}
