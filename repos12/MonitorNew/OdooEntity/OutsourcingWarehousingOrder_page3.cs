﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    /// <summary>
    /// 外购入库单
    /// </summary>
    public class OutsourcingWarehousingOrder_page3
    {
        /// <summary>
        /// 单据号_FBillno		
        /// </summary>
        public string stock_picking_name { get; set; }
        /// <summary>
        /// 仓库_FNumber--调出仓库_FNumber	
        /// </summary>
        public string stock_warehouse_id { get; set; }
        /// <summary>
        /// 仓库_FName--调出仓库_FName	
        /// </summary>
        public string stock_warehouse_name { get; set; }
        /// <summary>
        /// 仓位_FName--调出仓位_FName	
        /// </summary>
        public string stock_location_name { get; set; }
        //仓位_FGroupName
        //调出仓库_FNumber
        //调出仓库_FName
        //调出仓位_FName
        //调出仓位_FGroupName
        //辅助属性_FNumber
        //辅助属性_FName
        //辅助属性_FClassName
        /// <summary>
        /// 供应商_FNumber	
        /// </summary>
        public string res_partner_id { get; set; }
        /// <summary>
        /// 供应商_FName
        /// </summary>
        public string res_partner_commercial_company_name { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string stock_move_line_lot_name { get; set; }
        //生产采购日期
        //是否有效
        /// <summary>
        /// 物料_FNumber
        /// </summary>
        public string product_product_material_code { get; set; }
        /// <summary>
        /// 物料_FName	
        /// </summary>
        public string product_template_name { get; set; }
        /// <summary>
        /// 物料_FModel	
        /// </summary>
        public string product_product_product_model { get; set; }
        ///序列号stock_production_lot_lot_ids
        //序列号ID
        //序列号规则ID
        /// <summary>
        /// 状态
        /// </summary>
        public string stock_picking_state { get; set; }
        //最后SNListID
        //最后单据类别
        public List<OutsourcingWarehousingOrder_page3> GetEntity(DataTable dt)
        {
            List<OutsourcingWarehousingOrder_page3> list = new List<OutsourcingWarehousingOrder_page3>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OutsourcingWarehousingOrder_page3 oew = new OutsourcingWarehousingOrder_page3();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.stock_warehouse_id = dt.Rows[i]["stock_warehouse_id"].ToString();
                oew.stock_warehouse_name = dt.Rows[i]["stock_warehouse_name"].ToString();
                oew.stock_location_name = dt.Rows[i]["stock_location_name"].ToString();
                oew.res_partner_id = dt.Rows[i]["res_partner_id"].ToString();
                oew.res_partner_commercial_company_name = dt.Rows[i]["res_partner_commercial_company_name"].ToString();
                oew.stock_move_line_lot_name = dt.Rows[i]["stock_move_line_lot_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.stock_picking_state = dt.Rows[i]["stock_picking_state"].ToString();
                list.Add(oew);
            }
            return list;
        }
    }
}
