select 
--序列号内码
product_product.default_code as default_code,
stock_picking.name as stock_picking_name,--订单号;--单据号_FBillno		** 模板数据为空 => xh
--订单行号
--订单内码_FBillno			** 模板数据为空 => xh
--行号
--单据号_FBillno
--单据号_FTrantype
product_product.material_code as product_product_material_code,--加工材料编码_FNumber			
product_template.name as product_template_name,--加工材料编码_FName
product_product.product_model as product_product_product_model,--加工材料编码_FModel
--辅助属性_FNumber			** 模板数据为空 => xh
--辅助属性_FName			** 模板数据为空 => xh
--辅助属性_FClassName
uom_uom.id as uom_uom_id,--单位_FNumber
uom_uom.name as uom_uom_name,--单位_FName
stock_move_line.qty_done as stock_move_line_qty_done,--实收数量;--基本单位实收数量
stock_move.price_unit * stock_move.quantity_done as stock_move_total_amount,--金额
--product_template.standard_price,--单位成本,计算字段
stock_move_line.lot_name as stock_move_line_lot_name,--批号			** 模板数据为空 => xh
stock_picking.note as stock_picking_note,--备注				** 模板数据为空 => xh
purchase_order_line.price_unit as purchase_order_line_price_unit,--加工单价
--purchase_order.price_subtotal,--加工费计算字段
--基本单位实收数量
--税率(%)
--计划单价
--税额
--计划价金额
stock_move.date_deadline as stock_move_date_deadline,--生产/采购日期		** 模板数据为空 => xh
--保质期(天)
stock_picking.origin as stock_picking_origin,--源单单号			** 模板数据为空 => xh
--代码里有，表里没有--stock_move_line.expiration_date,--有效期至			** 模板数据为空 => xh
stock_picking_type.name as stock_picking_type_name,--源单类型
stock_warehouse.id as stock_warehouse_id,--收料仓库_FNumber
stock_warehouse.name as stock_warehouse_name,--收料仓库_FName
--源单内码
stock_location.name as stock_location_name--仓位_FName			** 模板数据为空 => xh
--仓位_FGroupName				** 模板数据为空 => xh
--源单分录
--单位材料费
--材料费
--对应代码			** 模板数据为空 => xh
--对应名称			** 模板数据为空 => xh
--投料单内码
--投料单分录
--换算率
--辅助数量
--辅助单位开票数量
--计划模式_FID
--计划模式_FName
--计划模式_FTypeID
--计划跟踪号		** 模板数据为空 => xh
--检验是否良品_FID
--检验是否良品_FName
--检验是否良品_FTypeID
--交货通知单内码
--交货通知单分录
--含税加工单价
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
left join purchase_order
on purchase_order_line.order_id=purchase_order.id
where sequence_code='IN-WWR'
limit 500


