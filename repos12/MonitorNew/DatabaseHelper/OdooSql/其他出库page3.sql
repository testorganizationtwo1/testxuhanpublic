select 
stock_picking.name,--单据号_FBillno								** 此页模板数据全部为空 => xh
--单据号_FTrantype
--保质期
stock_warehouse.id,--仓库_FNumber--调出仓库_FNumber
stock_warehouse.name,--仓库_FName--调出仓库_FName
stock_location.name,--仓位_FName--调出仓位_FName
--仓位_FGroupName
--调出仓库_FNumber
--调出仓库_FName
--调出仓位_FName
--调出仓位_FGroupName
--辅助属性_FNumber
--辅助属性_FName
--辅助属性_FClassName
res_partner.id,--供应商_FNumber
res_partner.commercial_company_name,--供应商_FName
stock_move_line.lot_name,--批号
--生产采购日期
--是否有效
product_product.material_code,--物料_FNumber
product_template.name,--物料_FName
product_product.product_model,--物料_FModel
--stock_production_lot.lot_ids as stock_production_lot_lot_ids,--序列号				*** =>xh
--序列号ID
--序列号规则ID
stock_picking.state--状态
--最后SNListID
--最后单据类别
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join product_product
on product_product.id=stock_move.product_id
left join uom_uom
on uom_uom.id=stock_move.product_uom
left join stock_move_line
on stock_move_line.picking_id=stock_picking.id
left join stock_warehouse
on stock_warehouse.id=stock_move.warehouse_id
left join stock_location
on stock_warehouse.lot_stock_id=stock_location.id
left join product_template
on product_product.product_tmpl_id=product_template.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
left join res_partner
on res_partner.id=stock_picking.partner_id
where sequence_code='OUT-QT'
limit 500


