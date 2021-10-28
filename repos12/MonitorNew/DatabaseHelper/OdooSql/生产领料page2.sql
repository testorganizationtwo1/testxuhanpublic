select 
--序列号内码
--行号
product_product.default_code as default_code,
stock_picking.name,--单据号_FBillno
--单据号_FTrantype
product_product.material_code,--物料代码_FNumber
product_template.name,--物料代码_FName
product_product.product_model,--物料代码_FModel
--辅助属性_FNumber			** 模板数据为空 => xh
--辅助属性_FName			** 模板数据为空 => xh
--辅助属性_FClassName
--是否返工_FID
--是否返工_FName
--是否返工_FTypeID
--成本对象_FNumber
--成本对象_FName
--成本对象_FItemClassID
--成本对象组_FNumber
--成本对象组_FName
--成本对象组_FItemClassID
uom_uom.id,--单位_FNumber
uom_uom.name,--单位_FName
stock_move_line.lot_name,--批号			** 模板数据为空 => xh
stock_move_line.qty_done,--实发数量;--基本单位实发数量
stock_move.price_unit,--单价
stock_move.price_unit * stock_move.quantity_done as stock_move_total_amount,--金额
--客户BOM
stock_picking.note,--备注			** 模板数据为空 => xh
--基本单位实发数量
--计划单价
--计划价金额
stock_move.date_deadline,--生产/采购日期		** 模板数据为空 => xh
--保质期(天)
--代码里有，表里没有--stock_move_line.expiration_date,--有效期至		** 模板数据为空 => xh
--是否VMI_FID			** 模板数据为空 => xh
--是否VMI_FName			** 模板数据为空 => xh
--是否VMI_FTypeID		** 模板数据为空 => xh
res_partner.id,--供应商_FNumber		** 模板数据为空 => xh
res_partner.commercial_company_name,--供应商_FName		** 模板数据为空 => xh
stock_warehouse.id,--发料仓库_FNumber
stock_warehouse.name,--发料仓库_FName
stock_location.name,--仓位_FName		** 模板数据为空 => xh
--仓位_FGroupName					** 模板数据为空 => xh
--工序号
--工序_FID			** 模板数据为空 => xh
--工序_FName		** 模板数据为空 => xh
--工序_FTypeID		** 模板数据为空 => xh
--换算率
--辅助数量
stock_picking.origin,--源单单号		** 模板数据为空 => xh
stock_picking_type.name,--源单类型
--源单内码
--源单分录
--生产任务单号			** 模板数据为空 => xh
--任务单内码
--投料单分录
--入库单内码
--成本中心_FNumber
--成本中心_FName
--成本中心_FItemClassID
--计划模式_FID
--计划模式_FName
--计划模式_FTypeID
--计划跟踪号			** 模板数据为空 => xh
--位置号			** 模板数据为空 => xh
--坯料尺寸			** 模板数据为空 => xh
--坯料数			** 模板数据为空 => xh
stock_move.bom_remarks--项目BOM备注		** 模板数据为空 => xh
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
where sequence_code='OUT-SCLL'
limit 500