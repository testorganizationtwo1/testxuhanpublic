select 
audit_data,--审核日期
stock_picking.date_done as stock_picking_date_done,--日期
stock_picking.maker as stock_picking_maker,--制单人_FName
stock_picking.name as stock_picking_name,--编    号
stock_picking.audit as stock_picking_audit,--审核人_FName
--制单机构_FNumber					** 模板数据为空 => xh
--制单机构_FName					** 模板数据为空 => xh
--红蓝字
--事务类型
--单据号
stock_picking.keeping_user as stock_picking_keeping_user,--res_users.id  验收_FNumber；验收_FName
stock_move.keeping_user as stock_move_keeping_user,--res_users.id  保管_FNumber；保管_FName
stock_picking_type.name as stock_picking_type_name,--源单类型
hr_department.id as hr_department_id,--部门_FNumber
hr_department.name as hr_department_name,--部门_FName
stock_picking.business_user as stock_picking_business_user,--res_users.id,--业务员_FNumber;--业务员_FName
--调拨类型_FID
--调拨类型_FName
--调拨类型_FTypeID
--打印次数
--凭证字号
res_partner.id as res_partner_id,--客户_FNumber
res_partner.commercial_company_name as res_partner_commercial_company_name--客户_FName
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

