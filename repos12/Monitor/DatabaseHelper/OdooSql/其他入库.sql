select stock_picking.date_done,
-- 审核标志
stock_picking.name as stock_picking_name,-- 单据编号
stock_location.name as stock_location_name,
stock_location.barcode as stock_location_barcode,--仓位条码
product_product.material_code as product_product_material_code,
product_template.name as product_template_name,
product_product.product_model as product_product_product_model,
uom_uom.name as uom_uom_name,
stock_move_line.qty_done as stock_move_line_qty_done,
stock_move.price_unit as stock_move_price_unit,
--stock_move.total_amount,--计算字段
stock_move_line.lot_name as stock_move_line_lot_name-- 批号
--res_users.name, --保管
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.picking_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join stock_move_line
on stock_move_line.picking_id=stock_picking.id
left join res_users
on stock_move.keeping_user=res_users.id
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_warehouse
on stock_warehouse.id=stock_picking.picking_type_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
where sequence_code='IN-QT'
limit 500