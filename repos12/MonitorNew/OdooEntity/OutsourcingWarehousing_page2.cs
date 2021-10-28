using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    /// <summary>
    /// 委外入库
    /// </summary>
    public class OutsourcingWarehousing_page2
    {
        /// <summary>
        /// 金蝶物料代码
        /// </summary>
        public string default_code { get; set; }
        //序列号内码
        /// <summary>
        /// 订单号;--单据号_FBillno
        /// </summary>
        public string stock_picking_name { get; set; }
        //订单行号
        //订单内码_FBillno** 模板数据为空 => xh
        //行号
        //单据号_FBillno
        //单据号_FTrantype
        /// <summary>
        /// 加工材料编码_FNumber
        /// </summary>
        public string product_product_material_code { get; set; }
        /// <summary>
        /// 加工材料编码_FName	
        /// </summary>
        public string product_template_name { get; set; }
        /// <summary>
        /// 加工材料编码_FModel	
        /// </summary>
        public string product_product_product_model { get; set; }
        //辅助属性_FNumber
        //辅助属性_FName
        //辅助属性_FClassName
        /// 单位_FNumber
        /// </summary>
        public string uom_uom_id { get; set; }
        /// <summary>
        /// 单位_FName
        /// </summary>
        public string uom_uom_name { get; set; }
        /// <summary>
        /// 实收数量;--基本单位实收数量
        /// </summary>
        public decimal stock_move_line_qty_done { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal stock_move_total_amount { get; set; }
        //product_template.standard_price,--单位成本,计算字段
        /// <summary>
        /// 批号
        /// </summary>
        public string stock_move_line_lot_name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string stock_picking_note { get; set; }
        /// <summary>
        /// 加工单价
        /// </summary>
        public decimal purchase_order_line_price_unit { get; set; }
        //purchase_order.price_subtotal,--加工费计算字段
        //基本单位实收数量
        //税率(%)
        //计划单价
        //税额
        //计划价金额
        /// <summary>
        /// 生产/采购日期
        /// </summary>
        public DateTime stock_move_date_deadline { get; set; }
        //保质期(天)
        /// <summary>
        /// 源单单号
        /// </summary>
        public string stock_picking_origin { get; set; }
        //代码里有，表里没有--stock_move_line.expiration_date

        /// <summary>
        /// 源单类型
        /// </summary>
        public decimal stock_picking_type_name { get; set; }
        /// <summary>
        /// 收料仓库_FNumber
        /// </summary>
        public string stock_warehouse_id { get; set; }
        /// <summary>
        /// 收料仓库_FName
        /// </summary>
        public string stock_warehouse_name { get; set; }
        //源单内码
        /// <summary>
        /// 仓位_FName
        /// </summary>
        public string stock_location_name { get; set; }
        //仓位_FGroupName** 模板数据为空 => xh
        //源单分录
        //单位材料费
        //材料费
        //对应代码** 模板数据为空 => xh
        //对应名称** 模板数据为空 => xh
        //投料单内码
        //投料单分录
        //换算率
        //辅助数量
        //辅助单位开票数量
        //计划模式_FID
        //计划模式_FName
        //计划模式_FTypeID
        //计划跟踪号** 模板数据为空 => xh
        //检验是否良品_FID
        //检验是否良品_FName
        //检验是否良品_FTypeID
        //交货通知单内码
        //交货通知单分录
        //含税加工单价

        public List<OutsourcingWarehousing_page2> GetEntity(DataTable dt)
        {
            List<OutsourcingWarehousing_page2> list = new List<OutsourcingWarehousing_page2>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OutsourcingWarehousing_page2 oew = new OutsourcingWarehousing_page2();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.uom_uom_id = dt.Rows[i]["uom_uom_id"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_line_qty_done = Convert.ToDecimal(dt.Rows[i]["stock_move_line_qty_done"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_line_qty_done"]);
                oew.stock_move_total_amount = Convert.ToDecimal(dt.Rows[i]["stock_move_total_amount"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_total_amount"]);
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_line_lot_name = dt.Rows[i]["stock_move_line_lot_name"].ToString();
                oew.stock_picking_note = dt.Rows[i]["stock_picking_note"].ToString();
                oew.purchase_order_line_price_unit =Convert.ToDecimal(dt.Rows[i]["purchase_order_line_price_unit"] == DBNull.Value ? 0 : dt.Rows[i]["purchase_order_line_price_unit"]);
                oew.stock_move_date_deadline = Convert.ToDateTime(dt.Rows[i]["stock_move_date_deadline"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_move_date_deadline"]));
                oew.stock_picking_origin = dt.Rows[i]["stock_picking_origin"].ToString();
                oew.stock_picking_type_name = Convert.ToDecimal(dt.Rows[i]["stock_picking_type_name"] == DBNull.Value ? 0 : dt.Rows[i]["stock_picking_type_name"]);
                oew.stock_warehouse_id = dt.Rows[i]["stock_warehouse_id"].ToString();
                oew.stock_warehouse_name = dt.Rows[i]["stock_warehouse_name"].ToString();
                oew.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();

                list.Add(oew);
            }
            return list;
        }  // Convert.ToDecimal (dt.Rows[i]["stock_move_price_unit"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_price_unit"]);
    }
}
