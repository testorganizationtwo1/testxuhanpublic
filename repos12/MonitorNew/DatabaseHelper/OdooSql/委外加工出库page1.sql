select 
audit_data,--审核日期
stock_picking.date_done as stock_picking_date_done,--日期
stock_picking.maker as stock_picking_maker,--制单人_FName
stock_picking.name as stock_picking_name,--编    号
stock_picking.audit as stock_picking_audit,--审核人_FName
--制单机构_FNumber			** 模板数据为空 => xh
--制单机构_FName			** 模板数据为空 => xh
--红蓝字
--事务类型
--单据号
res_partner.id as res_partner_id,--加工单位_FNumber
res_partner.commercial_company_name as res_partner_commercial_company_name,--加工单位_FName
--委外类型_FID
--委外类型_FName
--委外类型_FTypeID
--加工要求				** 模板数据为空 => xh
stock_picking.picker_picking as stock_picking_picker_picking,--res_users.id,--领料_FNumber;--领料_FName
--发料_FNumber
--发料_FName
stock_picking_type.name as stock_picking_type_name,--源单类型
--倒冲标记
--保税监管类型_FNumber			** 模板数据为空 => xh
--保税监管类型_FName			** 模板数据为空 => xh
--受托机构_FNumber				** 模板数据为空 => xh
--受托机构_FName			** 模板数据为空 => xh
--对方单据号			** 模板数据为空 => xh
--打印次数
--凭证字号
stock_picking.business_user as stock_picking_business_user--res_users.id,--业务员_FNumber;--业务员_FName
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
left join res_partner
on res_partner.id=stock_picking.partner_id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
where sequence_code='OUT-WWC'
limit 500