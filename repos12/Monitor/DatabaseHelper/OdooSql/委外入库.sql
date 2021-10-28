select stock_picking.date_done,
-- 审核标志
res_partner.name as res_partner_name,-- 加工单位
stock_picking.name as stock_picking_name,-- 单据编号
-- 委外类型
stock_location.name as stock_location_name,
stock_location.barcode as stock_location_barcode,--仓位条码
product_product.material_code as product_product_material_code,
product_template.name as product_template_name,
product_product.product_model as product_product_product_model,
uom_uom.name as uom_uom_name,
stock_move_line.product_uom_qty as stock_move_line_product_uom_qty,
stock_move_line.qty_done as stock_move_line_qty_done,
--product_template.standard_price --计算字段
--stock_move.total_amount,--计算字段
stock_picking.origin as stock_picking_origin,-- 订单单号
purchase_order_line.price_subtotal as purchase_order_price_subtotal,--加工费
purchase_order_line.price_unit as purchase_order_price_unit--加工单价
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.picking_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join stock_move_line
on stock_move_line.picking_id=stock_picking.id
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_warehouse
on stock_warehouse.id=stock_picking.picking_type_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join res_partner
on res_partner.id=stock_picking.partner_id
left join purchase_order_line
on purchase_order_line.product_id=product_product.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
where sequence_code='IN-WWR'
limit 500
