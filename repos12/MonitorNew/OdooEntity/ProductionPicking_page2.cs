﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    /// <summary>
    /// 生产领料
    /// </summary>
    public class ProductionPicking_page2
    {
        /// <summary>
        /// 金蝶物料代码
        /// </summary>
        public string default_code { get; set; }
        //序列号内码
        //行号
        /// <summary>
        /// 订单号;--单据号_FBillno
        /// </summary>
        public string stock_picking_name { get; set; }
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
        //是否返工_FID
        //是否返工_FName
        //是否返工_FTypeID
        //成本对象_FNumber
        //成本对象_FName
        //成本对象_FItemClassID
        //成本对象组_FNumber
        //成本对象组_FName
        //成本对象组_FItemClassID
        /// 单位_FNumber
        /// </summary>
        public string uom_uom_id { get; set; }
        /// <summary>
        /// 单位_FName
        /// </summary>
        public string uom_uom_name { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string stock_move_line_lot_name { get; set; }
        /// <summary>
        /// 实发数量;--基本单位实发数量
        /// </summary>
        public decimal stock_move_line_qty_done { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal stock_move_price_unit { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal stock_move_total_amount { get; set; }
        //客户BOM
        //product_template.standard_price,--单位成本,计算字段

        /// <summary>
        /// 备注
        /// </summary>
        public string stock_picking_note { get; set; }
        //基本单位实发数量
        //计划单价
        //计划价金额
        /// <summary>
        /// 生产/采购日期
        /// </summary>
        public DateTime stock_move_date_deadline { get; set; }
        //保质期(天)
        //代码里有，表里没有--stock_move_line.expiration_date,--有效期至
        //是否VMI_FID** 模板数据为空 => xh
        //是否VMI_FName** 模板数据为空 => xh
        //是否VMI_FTypeID
        /// <summary>
        /// 供应商_FNumber
        /// </summary>
        public string res_partner_id { get; set; }
        /// <summary>
        /// 供应商_FName
        /// </summary>
        public string res_partner_commercial_company_name { get; set; }
        /// <summary>
        /// 发料仓库_FNumber
        /// </summary>
        public string stock_warehouse_id { get; set; }
        /// <summary>
        /// 发料仓库_FName
        /// </summary>
        public string stock_warehouse_name { get; set; }
        /// <summary>
        /// 仓位_FName
        /// </summary>
        public string stock_location_name { get; set; }
        //仓位_FGroupName
        //工序号
        //工序_FID** 模板数据为空 => xh
        //工序_FName** 模板数据为空 => xh
        //工序_FTypeID** 模板数据为空 => xh
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
        //生产任务单号** 模板数据为空 => xh
        //任务单内码
        //投料单分录
        //入库单内码
        //成本中心_FNumber
        //成本中心_FName
        //成本中心_FItemClassID
        //计划模式_FID
        //计划模式_FName
        //计划模式_FTypeID
        //计划跟踪号** 模板数据为空 => xh
        //位置号** 模板数据为空 => xh
        //坯料尺寸** 模板数据为空 => xh
        //坯料数** 模板数据为空 => xh
        /// <summary>
        /// 项目BOM备注
        /// </summary>
        public string stock_move_bom_remarks { get; set; }

        public List<ProductionPicking_page2> GetEntity(DataTable dt)
        {
            List<ProductionPicking_page2> list = new List<ProductionPicking_page2>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductionPicking_page2 oew = new ProductionPicking_page2();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.uom_uom_id = dt.Rows[i]["uom_uom_id"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_line_lot_name = dt.Rows[i]["stock_move_line_lot_name"].ToString();
                oew.stock_move_line_qty_done = Convert.ToDecimal(dt.Rows[i]["stock_move_line_qty_done"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_line_qty_done"]);
                oew.stock_move_price_unit = Convert.ToDecimal(dt.Rows[i]["stock_move_price_unit"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_price_unit"]);
                oew.stock_move_total_amount = Convert.ToDecimal(dt.Rows[i]["stock_move_total_amount"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_total_amount"]);
                oew.stock_picking_note = dt.Rows[i]["stock_picking_note"].ToString();
                oew.stock_move_date_deadline = Convert.ToDateTime(dt.Rows[i]["stock_move_date_deadline"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_move_date_deadline"]));
                oew.res_partner_id = dt.Rows[i]["res_partner_id"].ToString();
                oew.res_partner_commercial_company_name = dt.Rows[i]["res_partner_commercial_company_name"].ToString();
                oew.stock_warehouse_id = dt.Rows[i]["stock_warehouse_id"].ToString();
                oew.stock_warehouse_name = dt.Rows[i]["stock_warehouse_name"].ToString();
                oew.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oew.stock_picking_origin = dt.Rows[i]["stock_picking_origin"].ToString();
                oew.stock_picking_type_name = Convert.ToDecimal(dt.Rows[i]["stock_picking_type_name"] == DBNull.Value ? 0 : dt.Rows[i]["stock_picking_type_name"]);
                oew.stock_move_bom_remarks = dt.Rows[i]["stock_move_bom_remarks"].ToString();
                list.Add(oew);
            }
            return list;
        }
    }
}
