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
stock_move.demand_quantity as stock_move_demand_quantity,
--product_template.standard_price --计算字段
--stock_move.total_amount--计算字段
stock_picking.origin as stock_picking_origin,-- 订单单号
-- 行关闭标志
stock_location.complete_name as stock_location_complete_name-- 位置号
-- 坯料尺寸
-- 坯料数
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.picking_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_warehouse
on stock_warehouse.id=stock_picking.picking_type_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join res_partner
on res_partner.id=stock_picking.partner_id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
where sequence_code='OUT-WWC'
limit 500