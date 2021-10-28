select stock_picking.date_done,
--审核标志
--作废标志
delivery_department,
stock_picking.name as stock_picking_name,-- 单据编号
stock_location.name as stock_location_name,
stock_location.barcode as stock_location_barcode,--仓位条码
product_product.material_code as product_product_material_code,
product_template.name as product_template_name,
product_model,
uom_uom.name as uom_uom_name,
stock_move_line.product_uom_qty as stock_move_line_product_uom_qty,
qty_done,
price_unit,
--stock_move.total_amount,--计算字段
stock_move_line.lot_name as stock_move_line_lot_name,-- 批号
-- 验收
--res_users.name, --保管
--res_users.name, --制单
-- 审核人
stock_picking.note as stock_picking_note,
-- 凭证字号
audit_data,
-- 辅助属性
-- 辅助属性代码
-- 生产任务单号
stock_picking.origin as stock_picking_origin,
stock_picking_type.name as stock_picking_type_name,-- 源单类型
uom_uom.name as base_uom_uom_name,-- 基本单位
stock_move_line.product_uom_qty as stock_move_line_product_uom_qty,
qty_done,
-- 计划单价
-- 计划价金额
-- 常用单位
-- 常用单位应收数量
-- 常用单位实收数量
stock_location.name as stock_location_name,
-- 保质期(天)  
-- 生产/采购日期
--stock_move_line.expiration_date as stock_move_line_expiration_date,-- 有效期至
-- 倒冲标志
sequence_code,--待定
-- 辅助单位
-- 换算率
-- 辅助数量
-- 检验是否良品
-- 打印次数
store_position_info,
another_name
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.picking_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join stock_move_line
on stock_move_line.picking_id=stock_picking.id
left join stock_warehouse
on stock_warehouse.id=stock_picking.picking_type_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
where sequence_code='IN-CP'
limit 500

