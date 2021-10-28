select 
--行号
stock_picking.name as stock_picking_name,--单据号_FBillno
--单据号_FTrantype
--单据号_FPOOrdBillNo				** 模板数据为空 => xh
product_product.material_code as product_product_material_code,--物料代码_FNumber
product_template.name as product_template_name,--物料代码_FName
product_product.product_model as product_product_product_model,--物料代码_FModel
--辅助属性_FNumber		** 模板数据为空 => xh
--辅助属性_FName		** 模板数据为空 => xh
--辅助属性_FClassName
uom_uom.id as uom_uom_id,--单位_FNumber
uom_uom.name as uom_uom_name,--单位_FName
stock_move.demand_quantity as stock_move_demand_quantity,--数量
--基本单位数量
--不含税单价
--含税单价
--不含税金额
--折扣率(%)
--实际含税单价
--折扣额
stock_picking.note as stock_picking_note,--备注
--交货日期
purchase_order_line.price_tax/purchase_order_line.price_subtotal as tax_rate,--税率(%)		***  =>xh
purchase_order.amount_tax as purchase_order_amount_tax,--税额		***  =>xh
--purchase_order.amount_total as purchase_order_amount_total--价税合计	***  =>xh
--对应代码		** 模板数据为空 => xh
--对应名称		** 模板数据为空 => xh
--换算率
--辅助数量
stock_picking.origin as stock_picking_origin,--源单单号
stock_picking_type.name as stock_picking_type_name,--源单类型
--源单内码
--源单分录
purchase_order.contract_code as purchase_order_contract_code--合同单号		***  =>xh
--合同内码
--合同分录
--辅助单位开票数量
--MRP计算标记
--付款关联金额
--计划模式_FID
--计划模式_FName
--计划模式_FTypeID
--计划跟踪号			** 模板数据为空 => xh
--供应商确认标志		** 模板数据为空 => xh
--供应商确认日期		** 模板数据为空 => xh		
--确认意见				** 模板数据为空 => xh
--确认数量
--供应商确认交货日期	** 模板数据为空 => xh	
--供应商确认人			** 模板数据为空 => xh
--采购申请单内码
--采购申请单分录
--表体附件数
--收料数量
--基本单位收料数量
--退料数量
--基本单位退料数量
--检验方式_FID
--检验方式_FName
--检验方式_FTypeID
--是否检验
--物料属性
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.product_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join stock_move_line
on stock_move_line.picking_id=stock_picking.id
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_warehouse
on stock_warehouse.id=stock_move.warehouse_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join res_partner
on res_partner.id=stock_picking.partner_id
left join purchase_order_line
on purchase_order_line.product_id=product_product.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
left join hr_department
on hr_department.id=stock_picking.department
left join purchase_order
on purchase_order_line.order_id=purchase_order.id
left join account_tax_purchase_order_line_rel 
on account_tax_purchase_order_line_rel.purchase_order_line_id = purchase_order_line.id
left join account_tax
on account_tax.id=account_tax_purchase_order_line_rel.account_tax_id
limit 500




