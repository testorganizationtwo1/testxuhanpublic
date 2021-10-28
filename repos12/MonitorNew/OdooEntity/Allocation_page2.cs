using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{   
    /// <summary>
    /// 调拨单
    /// </summary>
    public class Allocation_page2
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
        //订单内码_FBillno
        //行号
        //单据号_FBillno
        //单据号_FTrantype
        /// <summary>
        /// 物料代码_FNumber
        /// </summary>
        public string product_product_material_code { get; set; }
        /// <summary>
        /// 物料代码_FName	
        /// </summary>
        public string product_template_name { get; set; }
        /// <summary>
        /// 物料代码_FModel	
        /// </summary>
        public string product_product_product_model { get; set; }
        //辅助属性_FNumber
        //辅助属性_FName
        //辅助属性_FClassName
        /// <summary>
        /// 批号
        /// </summary>
        public string stock_move_line_lot_name { get; set; }
        /// <summary>
        /// 单位_FNumber
        /// </summary>
        public string uom_uom_id { get; set; }
        /// <summary>
        /// 单位_FName
        /// </summary>
        public string uom_uom_name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal stock_move_demand_quantity { get; set; }
        //product_template.standard_price,--单位成本,计算字段
        //基本单位数量
        //product_product.standard_price,--成本,计算字段
        //调拨单价
        //调拨金额
        /// <summary>
        /// 备注
        /// </summary>
        public string stock_picking_note { get; set; }
        //计划单价
        //计划价金额
        /// <summary>
        /// 生产/采购日期
        /// </summary>
        public DateTime stock_move_date_deadline { get; set; }
        //保质期(天)
        //代码里有，表里没有--stock_move_line.expiration_date,--有效期至
        
        /// <summary>
        /// 调出仓库_FNumber;调入仓库_FNumber
        /// </summary>
        public string stock_warehouse_id { get; set; }
        /// <summary>
        /// 调出仓库_FName;//调入仓库_FName
        /// </summary>
        public string stock_warehouse_name { get; set; }
        /// <summary>
        /// 调出仓位_FName;调入仓位_FName
        /// </summary>
        public string stock_location_name { get; set; }
        //调出仓位_FGroupName
        //调入仓位_FGroupName
        //换算率
        //辅助数量
        /// <summary>
        /// 源单单号
        /// </summary>
        public string stock_picking_origin { get; set; }
        /// <summary>
        /// 源单类型
        /// </summary>
        public decimal stock_picking_type_name { get; set; }
        //源单内码
        //源单分录
        //生产/委外订单号** 模板数据为空 => xh
        //任务单内码
        //投料单分录
        //计划模式_FID
        //计划模式_FName
        //计划模式_FTypeID
        //计划跟踪号** 模板数据为空 => xh
        //检验是否良品_FID
        //检验是否良品_FName
        //检验是否良品_FTypeID
        /// <summary>
        /// 项目BOM单备注
        /// </summary>
        public string stock_move_bom_remarks { get; set; }
        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal stock_move_price_unit { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal stock_move_total_amount { get; set; }
        public List<Allocation_page2> GetEntity(DataTable dt)
        {
            List<Allocation_page2> list = new List<Allocation_page2>();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {

                Allocation_page2 oew = new Allocation_page2();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.stock_move_line_lot_name = dt.Rows[i]["stock_move_line_lot_name"].ToString();
                oew.uom_uom_id = dt.Rows[i]["uom_uom_id"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_demand_quantity = Convert.ToDecimal(dt.Rows[i]["stock_move_demand_quantity"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_demand_quantity"]);
                oew.stock_picking_note = dt.Rows[i]["stock_picking_note"].ToString();
                oew.stock_move_date_deadline = Convert.ToDateTime(dt.Rows[i]["stock_move_date_deadline"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_move_date_deadline"]));
                oew.stock_picking_origin = dt.Rows[i]["stock_picking_origin"].ToString();
                oew.stock_picking_type_name = Convert.ToDecimal(dt.Rows[i]["stock_picking_type_name"] == DBNull.Value ? 0 : dt.Rows[i]["stock_picking_type_name"]);
                oew.stock_move_bom_remarks = dt.Rows[i]["stock_move_bom_remarks"].ToString();
                oew.stock_move_price_unit = Convert.ToDecimal(dt.Rows[i]["stock_move_price_unit"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_price_unit"]);
                oew.stock_move_price_unit = Convert.ToDecimal(dt.Rows[i]["stock_move_total_amount"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_total_amount"]);

                list.Add(oew);
            }
            return list;
        }
    }
    //oew.qty_done = Convert.ToDecimal(dt.Rows[i]["qty_done"] == DBNull.Value? 0 : dt.Rows[i]["qty_done"]); //修改
}
