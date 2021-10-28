using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    /// <summary>
    /// 采购订单
    /// </summary>
    public class PurchaseOrder_page2
    {
        //行号
        /// <summary>
        /// 单据号_FBillno
        /// </summary>
        public string stock_picking_name { get; set; }
        //单据号_FTrantype
        //单据号_FPOOrdBillNo
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
        //辅助属性_FNumber** 模板数据为空 => xh
        //辅助属性_FName** 模板数据为空 => xh
        //辅助属性_FClassName
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
        //基本单位数量
        //不含税单价
        //含税单价
        //不含税金额
        //折扣率(%)
        //实际含税单价
        //折扣额
        /// <summary>
        /// 备注
        /// </summary>
        public string stock_picking_note { get; set; }
        //交货日期
        /// <summary>
        /// 税率(%)
        /// </summary>
        public decimal tax_rate { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal purchase_order_amount_tax { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal purchase_order_amount_total { get; set; }
        //对应代码** 模板数据为空 => xh
        //对应名称** 模板数据为空 => xh
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

        /// <summary>
        /// 合同单号
        /// </summary>
        public string purchase_order_contract_code { get; set; }
        //合同内码
        //合同分录
        //辅助单位开票数量
        //MRP计算标记
        //付款关联金额
        //计划模式_FID
        //计划模式_FName
        //计划模式_FTypeID
        //计划跟踪号** 模板数据为空 => xh
        //供应商确认标志** 模板数据为空 => xh
        //供应商确认日期** 模板数据为空 => xh
        //确认意见** 模板数据为空 => xh
        //确认数量
        //供应商确认交货日期** 模板数据为空 => xh
        //供应商确认人** 模板数据为空 => xh
        //采购申请单内码
        //采购申请单分录
        //表体附件数
        //收料数量
        //基本单位收料数量
        //退料数量
        //基本单位退料数量
        //检验方式_FID
        //检验方式_FName
        //检验方式_FTypeID
        //是否检验
        //物料属性
        public List<PurchaseOrder_page2> GetEntity(DataTable dt)
        {
            List<PurchaseOrder_page2> list = new List<PurchaseOrder_page2>();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                PurchaseOrder_page2 oew = new PurchaseOrder_page2();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.product_product_material_code = dt.Rows[i]["product_product_material_code"].ToString();
                oew.product_template_name = dt.Rows[i]["product_template_name"].ToString();
                oew.product_product_product_model = dt.Rows[i]["product_product_product_model"].ToString();
                oew.uom_uom_id = dt.Rows[i]["uom_uom_id"].ToString();
                oew.uom_uom_name = dt.Rows[i]["uom_uom_name"].ToString();
                oew.stock_move_demand_quantity = Convert.ToDecimal(dt.Rows[i]["stock_move_demand_quantity"] == DBNull.Value ? 0 : dt.Rows[i]["stock_move_demand_quantity"]);
                oew.stock_picking_note = dt.Rows[i]["stock_picking_note"].ToString();
                oew.stock_picking_origin = dt.Rows[i]["stock_picking_origin"].ToString();
                oew.stock_picking_type_name = Convert.ToDecimal(dt.Rows[i]["stock_picking_type_name"] == DBNull.Value ? 0 : dt.Rows[i]["stock_picking_type_name"]);
                oew.tax_rate = Convert.ToDecimal(dt.Rows[i]["tax_rate"] == DBNull.Value ? 0 : dt.Rows[i]["tax_rate"]);
                oew.purchase_order_amount_tax = Convert.ToDecimal(dt.Rows[i]["purchase_order_amount_tax"] == DBNull.Value ? 0 : dt.Rows[i]["purchase_order_amount_tax"]);
                oew.purchase_order_amount_total = Convert.ToDecimal(dt.Rows[i]["purchase_order_amount_total"] == DBNull.Value ? 0 : dt.Rows[i]["purchase_order_amount_total"]);
                oew.purchase_order_contract_code = dt.Rows[i]["purchase_order_contract_code"].ToString();
                list.Add(oew);
            }
            return list;
        }
    }
    //oew.qty_done = Convert.ToDecimal(dt.Rows[i]["qty_done"] == DBNull.Value? 0 : dt.Rows[i]["qty_done"]); //修改
}
