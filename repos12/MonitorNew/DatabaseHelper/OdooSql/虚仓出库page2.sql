select 
--行号
stock_picking.name as stock_picking_name,--单据号_FBillno
--单据号_FTrantype
product_product.material_code as product_product_material_code,--物料代码_FNumber
product_template.name as product_template_name,--物料代码_FName
product_product.product_model as product_product_product_model,--物料代码_FModel
--辅助属性_FNumber					** 模板数据为空 => xh
--辅助属性_FName					** 模板数据为空 => xh
--辅助属性_FClassName
stock_move_line.lot_name as stock_move_line_lot_name,--批号		** 模板数据为空 => xh
--基本单位数量
uom_uom.id as uom_uom_id,--单位_FNumber
uom_uom.name as uom_uom_name,--单位_FName
--数量
stock_picking.note as stock_picking_note,--备注
--对应代码				** 模板数据为空 => xh
--对应名称				** 模板数据为空 => xh
stock_move.date_deadline as stock_move_date_deadline,--生产/采购日期		** 模板数据为空 => xh
--保质期(天)
--代码里有，表里没有--stock_move_line.expiration_date,--有效期至
stock_warehouse.id as stock_warehouse_id,--仓库_FNumber			
stock_warehouse.name as stock_warehouse_name,--仓库_FName
stock_location.name as stock_location_name,--仓位_FName		** 模板数据为空 => xh
--仓位_FGroupName			** 模板数据为空 => xh
--换算率
--辅助数量
stock_picking.origin as stock_picking_origin,--源单单号			** 模板数据为空 => xh
stock_picking_type.name as stock_picking_type_name--源单类型
--源单内码
--源单分录
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.product_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_warehouse
on stock_warehouse.id=stock_move.warehouse_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join res_users
on res_users.id=stock_picking.picker_picking
left join res_partner
on res_users.partner_id=res_partner.id
left join stock_move_line
on stock_move_line.picking_id=stock_picking.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
limit 500