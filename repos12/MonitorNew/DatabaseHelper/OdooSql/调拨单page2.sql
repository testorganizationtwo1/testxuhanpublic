select 
--序列号内码
product_product.default_code as default_code,
stock_picking.name as stock_picking_name,--订单号;--单据号_FBillno
--订单行号
--订单内码_FBillno		** 模板数据为空 => xh
--行号
--单据号_FBillno
--单据号_FTrantype
product_product.material_code as product_product_material_code,--物料代码_FNumber
product_template.name as product_template_name,--物料代码_FName
product_product.product_model as product_product_product_model,--物料代码_FModel
--辅助属性_FNumber
--辅助属性_FName
--辅助属性_FClassName
stock_move_line.lot_name as stock_move_line_lot_name,--批号		** 模板数据为空 => xh
uom_uom.id as uom_uom_id,--单位_FNumber
uom_uom.name as uom_uom_name,--单位_FName
stock_move.demand_quantity as stock_move_demand_quantity,--数量
--product_template.standard_price,--单位成本,计算字段
--基本单位数量
--product_product.standard_price,--成本,计算字段
--调拨单价
--调拨金额
stock_picking.note as stock_picking_note,--备注
--计划单价
--计划价金额
stock_move.date_deadline as stock_move_date_deadline,--生产/采购日期			** 模板数据为空 => xh
--保质期(天)
--代码里有，表里没有--stock_move_line.expiration_date,--有效期至
--调出仓库_FNumber
--调出仓库_FName
--调出仓位_FName			** 模板数据为空 => xh
--调出仓位_FGroupName		** 模板数据为空 => xh
--调入仓库_FNumber
--调入仓库_FName
--调入仓位_FName			** 模板数据为空 => xh
--调入仓位_FGroupName		** 模板数据为空 => xh
--换算率
--辅助数量
stock_picking.origin as stock_picking_origin,--源单单号			** 模板数据为空 => xh
stock_picking_type.name as stock_picking_type_name,--源单类型
--源单内码
--源单分录
--生产/委外订单号				** 模板数据为空 => xh
--任务单内码
--投料单分录
--计划模式_FID
--计划模式_FName
--计划模式_FTypeID
--计划跟踪号					** 模板数据为空 => xh
--检验是否良品_FID
--检验是否良品_FName
--检验是否良品_FTypeID	
stock_move.bom_remarks as stock_move_bom_remarks,--项目BOM单备注	** 模板数据为空 => xh
stock_move.price_unit as stock_move_price_unit,--销售单价
stock_move.price_unit * stock_move.quantity_done as stock_move_total_amount--销售金额
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
where sequence_code='INT'
limit 500

